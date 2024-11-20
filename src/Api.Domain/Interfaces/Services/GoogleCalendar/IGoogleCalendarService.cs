using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Dtos;
using Google.Apis.Calendar.v3.Data;

namespace Domain.Interfaces.Services.GoogleCalendar
{
    public interface IGoogleCalendarService
    {
        Task<IList<string>> GetFreeTimesForDayAsync(string userEmail, DateTime date);
        Task<string> ScheduleAppointmentAsync(AppointmentDto appointmentDto, string userEmail);
        Task<IList<Event>> GetMonthlyEventsAsync(string userEmail);
        Task<IList<DailyFreeTimeDto>> GetDailyFreeTimesForMonthAsync(string userEmail);
        Task<string> GetCalendarIdByEmailAsync(string userEmail);
        Task<IList<EventDetailsDto>> GetEventDetailsForDayAsync(string userEmail);

        Task<string> ScheduleAppointmentAsync2(AppointmentSummaryDto appointmentDto, string userEmail);
    }
}
