using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class AppointmentDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string CalendarId { get; set; }

        // Adicione esta propriedade para armazenar os e-mails dos participantes
        public List<string> AttendeesEmails { get; set; }
    }

    public class FreeTimeDto
    {
        public string Date { get; set; }
        public List<string> AvailableTimes { get; set; } = new List<string>();
    }

    public class CalendarFreeTimesDto
    {
        public string CalendarId { get; set; }
        public List<FreeTimeDto> DailyFreeTimes { get; set; } = new List<FreeTimeDto>();
    }

    public class DailyFreeTimeDto
    {
        public DateTime Date { get; set; }
        public List<string> AvailableTimes { get; set; }
    }

    public class EventDetailsDto
    {
        public string EventId { get; set; }
        public string Summary { get; set; }
        public string Start { get; set; }  // Altere para string
        public string End { get; set; }    // Altere para string
        public List<string> AttendeesEmails { get; set; }
    }

    public class AppointmentSummaryDto
    {
        public string Summary { get; set; } // Título do evento
        public string Description { get; set; } // Descrição do evento
        public DateTime Start { get; set; } // Data e hora de início
        public DateTime End { get; set; } // Data e hora de término
        public List<string> AttendeesEmails { get; set; } // Lista de e-mails dos participantes
    }





}
