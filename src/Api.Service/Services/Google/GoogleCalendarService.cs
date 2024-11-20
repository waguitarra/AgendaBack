using Domain.Dtos;
using Domain.Interfaces.Services.GoogleCalendar;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using TimeZoneConverter;

namespace Service.Services.Google
{
    public class GoogleCalendarService : IGoogleCalendarService
    {
        private static readonly string[] Scopes = { CalendarService.Scope.Calendar };
        private readonly string ApplicationName = "Google Calendar API Service";
        private readonly IConfiguration _configuration;
        private CalendarService _calendarService;
        private string _userEmail;

        public GoogleCalendarService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private CalendarService AuthenticateGoogleCalendar(string userEmail)
        {
            _userEmail = userEmail;
            var credPath = $"token_{userEmail}.json";

            var clientId = _configuration["Google:ClientId"];
            var clientSecret = _configuration["Google:ClientSecret"];

            var secrets = new ClientSecrets
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            };

            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                secrets,
                Scopes,
                userEmail,
                CancellationToken.None,
                new FileDataStore(credPath, true)).Result;

            return new CalendarService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }

        public async Task<string> GetCalendarIdByEmailAsync(string userEmail)
        {
            _calendarService ??= AuthenticateGoogleCalendar(userEmail);

            var calendarListRequest = _calendarService.CalendarList.List();
            var calendarList = await calendarListRequest.ExecuteAsync();

            foreach (var calendar in calendarList.Items)
            {
                if (calendar.Summary == userEmail)
                {
                    return calendar.Id;
                }
            }

            throw new Exception($"Nenhum calendário encontrado para o e-mail {userEmail}");
        }

        public async Task<IList<Event>> GetMonthlyEventsAsync(string userEmail)
        {
            var calendarId = await GetCalendarIdByEmailAsync(userEmail);
            var startOfMonth = DateTime.UtcNow;
            var endOfMonth = startOfMonth.AddMonths(1);

            var request = _calendarService.Events.List(calendarId);
            request.TimeMin = startOfMonth;
            request.TimeMax = endOfMonth;
            request.SingleEvents = true;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            var events = await request.ExecuteAsync();
            return events.Items ?? new List<Event>();
        }

        public async Task<string> ScheduleAppointmentAsync(AppointmentDto appointmentDto, string userEmail)
        {
            var calendarId = await GetCalendarIdByEmailAsync(userEmail);

            var startTime = appointmentDto.StartTime.ToUniversalTime();
            var endTime = appointmentDto.EndTime.ToUniversalTime();

            var newEvent = new Event
            {
                Summary = appointmentDto.Title,
                Description = appointmentDto.Description,
                Start = new EventDateTime { DateTime = startTime, TimeZone = "UTC" },
                End = new EventDateTime { DateTime = endTime, TimeZone = "UTC" },
                Attendees = appointmentDto.AttendeesEmails
                    .Select(email => new EventAttendee { Email = email })
                    .ToList()
            };

            var request = _calendarService.Events.Insert(newEvent, calendarId);
            var createdEvent = await request.ExecuteAsync();
            return createdEvent.HtmlLink;
        }

        public async Task<IList<string>> GetFreeTimesForDayAsync(string userEmail, DateTime date)
        {
            var calendarId = await GetCalendarIdByEmailAsync(userEmail);
            var startOfDay = new DateTime(date.Year, date.Month, date.Day, 8, 0, 0, DateTimeKind.Utc);
            var endOfDay = new DateTime(date.Year, date.Month, date.Day, 20, 0, 0, DateTimeKind.Utc);

            var requestBody = new FreeBusyRequest
            {
                TimeMin = startOfDay,
                TimeMax = endOfDay,
                TimeZone = "UTC",
                Items = new List<FreeBusyRequestItem> { new FreeBusyRequestItem { Id = calendarId } }
            };

            var freeBusyRequest = _calendarService.Freebusy.Query(requestBody);
            var response = await freeBusyRequest.ExecuteAsync();

            var busyTimes = response.Calendars[calendarId].Busy;
            return GetFreePeriods(startOfDay, endOfDay, busyTimes)
                .Select(period => $"{period.Start:yyyy-MM-ddTHH:mm:ss} - {period.End:yyyy-MM-ddTHH:mm:ss}")
                .ToList();
        }


        public async Task<IList<EventDetailsDto>> GetEventDetailsForDayAsync(string userEmail)
        {
            userEmail = "wagnerfbenajes@gmail.com";
            var calendarId = await GetCalendarIdByEmailAsync(userEmail);
            var eventsDetailsForDay = new List<EventDetailsDto>();

            // Definindo o dia específico 30/10/2024 em horário UTC para consulta na API
            var specificDate = new DateTime(2024, 10, 30);
            var startOfDayUtc = new DateTime(specificDate.Year, specificDate.Month, specificDate.Day, 0, 0, 0, DateTimeKind.Utc);
            var endOfDayUtc = new DateTime(specificDate.Year, specificDate.Month, specificDate.Day, 23, 59, 0, DateTimeKind.Utc);

            var requestBody = new FreeBusyRequest
            {
                TimeMin = startOfDayUtc,
                TimeMax = endOfDayUtc,
                TimeZone = "UTC",
                Items = new List<FreeBusyRequestItem> { new FreeBusyRequestItem { Id = calendarId } }
            };

            try
            {
                // Passo 1: Obter os horários ocupados com FreeBusyRequest
                var freeBusyRequest = _calendarService.Freebusy.Query(requestBody);
                var response = await freeBusyRequest.ExecuteAsync();

                // Para cada intervalo ocupado, obtenha os detalhes do evento usando Events.list
                foreach (var busyTime in response.Calendars[calendarId].Busy)
                {
                    // Passo 2: Buscar os eventos específicos usando o intervalo ocupado
                    var eventsRequest = _calendarService.Events.List(calendarId);
                    eventsRequest.TimeMin = busyTime.Start;
                    eventsRequest.TimeMax = busyTime.End;
                    eventsRequest.ShowDeleted = false;
                    eventsRequest.SingleEvents = true;
                    eventsRequest.MaxResults = 10;

                    var events = await eventsRequest.ExecuteAsync();

                    // Para cada evento, obtenha os detalhes dos e-mails dos convidados
                    foreach (var calendarEvent in events.Items)
                    {
                        var attendeesEmails = calendarEvent.Attendees?
                            .Where(attendee => !string.IsNullOrEmpty(attendee.Email))
                            .Select(attendee => attendee.Email)
                            .ToList() ?? new List<string>();

                        eventsDetailsForDay.Add(new EventDetailsDto
                        {
                            EventId = calendarEvent.Id,
                            Summary = calendarEvent.Summary,
                            Start = (calendarEvent.Start.DateTime?.AddHours(-1)).GetValueOrDefault().ToString("dd/MM/yyyy HH:mm"),
                            End = (calendarEvent.End.DateTime?.AddHours(-1)).GetValueOrDefault().ToString("dd/MM/yyyy HH:mm"),
                            AttendeesEmails = attendeesEmails
                        });

                    }
                }
            }
            catch (Exception ex)
            {
                // Em caso de erro, retorne uma lista vazia ou manipule conforme necessário
                Console.WriteLine($"Erro ao consultar eventos: {ex.Message}");
                return new List<EventDetailsDto>();
            }

            return eventsDetailsForDay;
        }

        public async Task<IList<DailyFreeTimeDto>> GetDailyFreeTimesForMonthAsync(string userEmail)
        {
            userEmail = "wagnerfbenajes@gmail.com";
            var calendarId = await GetCalendarIdByEmailAsync(userEmail);
            var occupiedTimesForDay = new List<DailyFreeTimeDto>();

            // Define o dia específico 30/10/2024 para consulta na API
            var specificDate = new DateTime(2024, 10, 30);
            var startOfDayUtc = new DateTime(specificDate.Year, specificDate.Month, specificDate.Day, 0, 0, 0, DateTimeKind.Utc);
            var endOfDayUtc = new DateTime(specificDate.Year, specificDate.Month, specificDate.Day, 23, 59, 0, DateTimeKind.Utc);

            var requestBody = new FreeBusyRequest
            {
                TimeMin = startOfDayUtc,
                TimeMax = endOfDayUtc,
                TimeZone = "UTC",
                Items = new List<FreeBusyRequestItem> { new FreeBusyRequestItem { Id = calendarId } }
            };

            try
            {
                var freeBusyRequest = _calendarService.Freebusy.Query(requestBody);
                var response = await freeBusyRequest.ExecuteAsync();

                var busyTimes = response.Calendars[calendarId].Busy;

                // Preparando o retorno dos horários ocupados com ajuste de uma hora a menos
                var dailyOccupiedTimeDto = new DailyFreeTimeDto
                {
                    Date = specificDate,
                    AvailableTimes = busyTimes
                        .Select(busy =>
                        {
                            // Subtraindo uma hora dos horários de início e fim
                            var start = busy.Start.Value.AddHours(-1);
                            var end = busy.End.Value.AddHours(-1);

                            return $"{start:dd/MM/yyyy HH:mm} até {end:dd/MM/yyyy HH:mm}";
                        })
                        .ToList()
                };

                occupiedTimesForDay.Add(dailyOccupiedTimeDto);
            }
            catch (Exception ex)
            {
                // Trata o erro de forma silenciosa ou retorna uma lista vazia
                return new List<DailyFreeTimeDto>();
            }

            return occupiedTimesForDay;
        }

        private IList<TimePeriod> GetFreePeriods(DateTime startOfDay, DateTime endOfDay, IList<TimePeriod> busyTimes)
        {
            var freeTimes = new List<TimePeriod>();
            var currentStart = startOfDay;

            foreach (var period in busyTimes)
            {
                if (period.Start.HasValue && period.End.HasValue)
                {
                    var busyStart = period.Start.Value;
                    var busyEnd = period.End.Value;

                    if (currentStart < busyStart)
                    {
                        freeTimes.Add(new TimePeriod { Start = currentStart, End = busyStart });
                    }

                    currentStart = busyEnd > currentStart ? busyEnd : currentStart;
                }
            }

            if (currentStart < endOfDay)
            {
                freeTimes.Add(new TimePeriod { Start = currentStart, End = endOfDay });
            }

            return freeTimes;
        }

        public async Task<string> ScheduleAppointmentAsync2(AppointmentSummaryDto appointmentDto, string userEmail)
        {
            userEmail = "wagnerfbenajes@gmail.com";
            // Obtém o ID do calendário do usuário
            var calendarId = await GetCalendarIdByEmailAsync(userEmail);

            // Cria o evento com os detalhes fornecidos no AppointmentDto
            var newEvent = new Event
            {
                Summary = appointmentDto.Summary,
                Description = appointmentDto.Description,
                Start = new EventDateTime
                {
                    DateTime = appointmentDto.Start,
                    TimeZone = "Europe/Madrid" // Ajuste o fuso horário conforme necessário
                },
                End = new EventDateTime
                {
                    DateTime = appointmentDto.End.AddMinutes(20),
                    TimeZone = "Europe/Madrid"
                },
                Attendees = new List<EventAttendee>()
            };

            // Adiciona cada e-mail da lista de participantes como um convidado com permissão de edição
            foreach (var email in appointmentDto.AttendeesEmails)
            {
                newEvent.Attendees.Add(new EventAttendee
                {
                    Email = email,
                    Organizer = false,  // Define que o organizador é o usuário do calendário
                    ResponseStatus = "needsAction" // Status inicial
                });
            }

            // Cria o evento no Google Calendar
            var createdEvent = await _calendarService.Events.Insert(newEvent, calendarId).ExecuteAsync();

            return createdEvent.Id; // Retorna o ID do evento criado
        }
    }
}
