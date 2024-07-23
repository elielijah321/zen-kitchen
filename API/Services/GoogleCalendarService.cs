using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Project.Function;

namespace Company.Function
{
    public static class GoogleCalendarService
    {
        static string[] Scopes = { CalendarService.Scope.Calendar };
        static string ApplicationName = "Google Calendar API .NET Quickstart";
        static string TimeZone = "Europe/London";
        static string NG_TimeZone = "Africa/Nigeria";
        static int hoursAhead = 0;

        public static void CreateMeeting()
        {
            Event meetEvent = CreateEvent();
            var request = CreateInsertRequest(meetEvent);

            Event createdEvent = request.Execute();

        }

        public static List<Event> GetListOfEvents()
        {
            Event meetEvent = CreateEvent();
            var request = GetListOfEventsRequest();

            var result = request.Execute();

            return result.Items.ToList();
        }
    
        private static Event CreateEvent()
        {
            // var attendees = !string.IsNullOrEmpty(student.EmailAddress) ? 
            // new EventAttendee[]
            // { new EventAttendee() { Email = student.EmailAddress, Optional = false }, new EventAttendee() { Email = "elijah@aremusoftwaresolutions.com", Optional = false } } 
            // : new EventAttendee[] { null };

            //adjust for daylight savings
            // var timeOfDay = student.TimeOfTheDay.ToDateTime().AddHours(-1);
            var timeOfDay = DateTime.Now;

            // Create a new event.
            Event newEvent = new Event()
            {
                Summary = GenerateMeetTitle(),
                Description = GenerateMeetTitle(),
                Start = new EventDateTime()
                {
                    DateTimeDateTimeOffset  = timeOfDay,
                    TimeZone = TimeZone,
                },
                End = new EventDateTime()
                {
                    DateTimeDateTimeOffset  = timeOfDay.AddMinutes(45),
                    TimeZone = TimeZone,
                },
                ConferenceData = new ConferenceData()
                {
                    CreateRequest = new CreateConferenceRequest()
                    {
                        RequestId = "sample123",
                        ConferenceSolutionKey = new ConferenceSolutionKey()
                        {
                            Type = "hangoutsMeet"
                        }
                    }
                },
                // Attendees = attendees
                Attendees = new EventAttendee[] { null }
            };

            return newEvent;
        }
    
        private static EventsResource.InsertRequest CreateInsertRequest(Event meetEvent)
        {
            CalendarService _service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = GoogleCredentialHelper.GetCredentials(),
                ApplicationName = ApplicationName,
            });

            var request = _service.Events.Insert(meetEvent, "primary");
            request.ConferenceDataVersion = 1;
            request.SendNotifications = true;

            return request;
        }

        private static EventsResource.ListRequest GetListOfEventsRequest()
        {
            CalendarService _service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = GoogleCredentialHelper.GetCredentials(),
                ApplicationName = ApplicationName,
            });

            var request = _service.Events.List("elijah@aremusoftwaresolutions.com");

            // var request = _service.Events.Insert(meetEvent, "primary");
            // request.ConferenceDataVersion = 1;
            // request.SendNotifications = true;

            return request;
        }
    
        private static string GenerateMeetTitle()
        {
            // return String.Format("{0} - {1} - ({2})", student.Name, "Yorùbá lesson", student.Teacher);

            return "New Meet title";
        }

        private static string GenerateMeetTimeString(DateTimeOffset startTimeOffset, DateTimeOffset endTimeOffset)
        {
            var dow = startTimeOffset.DayOfWeek;
            var day = startTimeOffset.Day;
            var month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(startTimeOffset.Month);
            var startTime = startTimeOffset.ToString("h:mmtt").ToLower();
            var endTime = endTimeOffset.ToString("h:mmtt").ToLower();

            return String.Format("{0}, {1} {2} · {3} - {4}", dow, day, month, startTime, endTime);
        }




        private static string MeetDescriptionBuilder(string description, string timeString, string timeZone, string hangoutLink)
        {
            return String.Format("{0} \n{1}\nTime Zone: {2}\nVideo call link: {3}", 
                description, 
                timeString,
                timeZone,
                hangoutLink);
        }

        private static DateTimeOffset GetDateTimeOffset(EventDateTime date)
        {
            return date.DateTimeDateTimeOffset.Value;
        }
    }
}