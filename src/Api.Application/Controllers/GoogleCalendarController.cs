using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;
using Domain.Interfaces.Services.GoogleCalendar;
using Domain.Dtos;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoogleCalendarController : ControllerBase
    {
        private readonly IGoogleCalendarService _googleCalendarService;
        private readonly ILogger<GoogleCalendarController> _logger;

        public GoogleCalendarController(IGoogleCalendarService googleCalendarService, ILogger<GoogleCalendarController> logger)
        {
            _googleCalendarService = googleCalendarService;
            _logger = logger;
        }

        // Endpoint para obter horários livres de um dia específico usando o e-mail
        [HttpGet("daily-free-times")]
        public async Task<ActionResult> GetFreeTimesForDay([FromQuery] string userEmail, [FromQuery] DateTime date)
        {
            try
            {
                var freeTimes = await _googleCalendarService.GetFreeTimesForDayAsync(userEmail, date);
                return Ok(freeTimes);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao obter horários livres: {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Erro ao obter horários livres.");
            }
        }

        // Endpoint para agendar um novo compromisso com múltiplos participantes usando o e-mail do usuário
        [HttpPost("schedule-appointment")]
        public async Task<ActionResult> ScheduleAppointment([FromBody] AppointmentDto appointmentDto, [FromQuery] string userEmail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var scheduledEventLink = await _googleCalendarService.ScheduleAppointmentAsync(appointmentDto, userEmail);
                if (string.IsNullOrEmpty(scheduledEventLink))
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, "Erro ao agendar o compromisso.");
                }

                return Ok(new
                {
                    Message = "Evento agendado com sucesso!",
                    EventLink = scheduledEventLink
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao agendar o compromisso: {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Erro ao agendar o compromisso.");
            }
        }

        // Endpoint para obter todos os eventos do mês usando o e-mail do usuário
        [HttpGet("monthly-events")]
        public async Task<ActionResult> GetMonthlyEvents([FromQuery] string userEmail)
        {
            try
            {
                var events = await _googleCalendarService.GetMonthlyEventsAsync(userEmail);
                return Ok(events);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao obter eventos do mês: {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Erro ao obter eventos do mês.");
            }
        }

        // Endpoint para obter horários livres para o próximo mês (30 dias) para o usuário especificado
        [HttpGet("monthly-free-times")]
        public async Task<ActionResult> GetMonthlyFreeTimes([FromQuery] string userEmail)
        {
            try
            {
                var freeTimes = await _googleCalendarService.GetDailyFreeTimesForMonthAsync(userEmail);
                return Ok(freeTimes);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao obter horários livres para o mês: {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Erro ao obter horários livres para o mês.");
            }
        }

        // Endpoint para obter o ID do calendário pelo e-mail do usuário
        [HttpGet("calendar-id")]
        public async Task<ActionResult> GetCalendarIdByEmail([FromQuery] string userEmail)
        {
            try
            {
                var calendarId = await _googleCalendarService.GetCalendarIdByEmailAsync(userEmail);
                return Ok(new { CalendarId = calendarId });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao obter ID do calendário para o e-mail {userEmail}: {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Erro ao obter ID do calendário.");
            }
        }

        // Endpoint alternativo para agendar evento com detalhes simplificados
        [HttpPost("schedule-appointment-summary")]
        public async Task<IActionResult> ScheduleAppointmentSummary([FromBody] AppointmentSummaryDto appointmentDto, [FromQuery] string userEmail)
        {
            try
            {
                //if (string.IsNullOrEmpty(userEmail) || appointmentDto == null)
                //{
                //    return BadRequest("O e-mail do usuário e os detalhes do evento são obrigatórios.");
                //}

                var eventId = await _googleCalendarService.ScheduleAppointmentAsync2(appointmentDto, userEmail);

                return Ok(new { EventId = eventId });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao agendar evento: {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Erro ao agendar evento.");
            }
        }

        // Endpoint para obter uma lista de detalhes dos eventos de um dia específico
        [HttpGet("daily-event-details")]
        public async Task<IActionResult> GetEventDetailsForDay([FromQuery] string userEmail)
        {
            try
            {
                var eventDetails = await _googleCalendarService.GetEventDetailsForDayAsync(userEmail);
                return Ok(eventDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao obter detalhes dos eventos para o dia: {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Erro ao obter detalhes dos eventos.");
            }
        }
    }
}
