using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;
using Google.Apis.Services;
using Google.Apis.Auth.OAuth2;
using System.Threading;


namespace ASPCalendarEvent
{
    public partial class ASPCalendarEvent : System.Web.UI.Page
    {
        public class CalendarEvents
        {
            public string Day { get; set; }
            public string Location { get; set; }
            public string Time { get; set; }
            public string Map { get; set; }
            public string Month { get; set; }
        }

        /// <summary>
        /// Get the google calendar events on page load.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            int days;
            int.TryParse(Request.QueryString["days"], out days);
            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                     new ClientSecrets
                     {
                         ClientId = "9662071531-q6j5ui4k39k1hno7fgnmchhgo1nqcrvi.apps.googleusercontent.com",
                         ClientSecret = "nc1Zh6LGd8TqaJZIWzuNrs8z",
                     },
                     new[] { Google.Apis.Calendar.v3.CalendarService.Scope.Calendar },
                     "user",
                     CancellationToken.None).Result;
            var service = new Google.Apis.Calendar.v3.CalendarService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "Calendar API Sample",

            });

            var noOfDays = int.Parse(Request.QueryString["days"]);

            var eventList = service.Events.List("bombayfoodjunkies@gmail.com");

            var calEvents = new List<CalendarEvents>();

            for (var i = 0; i < noOfDays; i++)
            {
                var minDate = DateTime.Now.AddDays(i);
                eventList.TimeMin = DateTime.Now.AddDays(i);
                eventList.TimeMax = DateTime.Now.AddDays(i + 1);

                var newList = eventList.Execute().Items;// check for each day having event or not

                if (newList.Count > 0)
                {
                    foreach (var newitem in newList)
                    {
                        var startTime = Convert.ToString(eventList.TimeMin);
                        var arrDateTime = startTime.Split('/');
                        var month = minDate.ToString("MMM");
                        var day = arrDateTime[1];
                        var arrYearTime = arrDateTime[2].Split(' ');
                        var startTimeSpan = arrYearTime[1];
                        var endDate = Convert.ToString(newitem.End.DateTime);
                        var arrEndDateTime = endDate.Split('/');
                        var arrEndYearTime = arrEndDateTime[2].Split(' ');
                        var endTimeSpan = arrEndYearTime[1] + arrEndYearTime[2];
                        var time = startTimeSpan + " - " + endTimeSpan;
                        var map = "https://www.google.com/maps?q=" + newitem.Location;
                        calEvents.Add(new CalendarEvents { Day = day, Time = time, Map = map, Location = newitem.Summary, Month =month });
                    }
                }
                else
                {
                    var startTime = Convert.ToString(eventList.TimeMin);
                    var arrDateTime = startTime.Split('/');
                    var month = minDate.ToString("MMM");
                    var day = arrDateTime[1];
                    calEvents.Add(new CalendarEvents { Day = day, Month = month, Location = "No Event Found!", Time = "N/A" });
                }
            }
            rptEvents.DataSource = calEvents;
            rptEvents.DataBind();
        }

        /// <summary>
        /// Get the google calendar events on page load.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    int days;
        //    int.TryParse(Request.QueryString["days"], out days);
        //    var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
        //             new ClientSecrets
        //             {
        //                 ClientId = "9662071531-q6j5ui4k39k1hno7fgnmchhgo1nqcrvi.apps.googleusercontent.com",
        //                 ClientSecret = "nc1Zh6LGd8TqaJZIWzuNrs8z",
        //             },
        //             new[] { Google.Apis.Calendar.v3.CalendarService.Scope.Calendar },
        //             "user",
        //             CancellationToken.None).Result;
        //    var service = new Google.Apis.Calendar.v3.CalendarService(new BaseClientService.Initializer
        //    {
        //        HttpClientInitializer = credential,
        //        ApplicationName = "Calendar API Sample",

        //    });

        //    var eventList = service.Events.List("bombayfoodjunkies@gmail.com");
        //    var min = DateTime.Now;
        //    var max = DateTime.Now.AddDays(5);
        //    var calEvents = new List<CalendarEvents>();
        //    while (min < max)
        //    {
        //        var ts = new TimeSpan(00, 00, 0);// used so that it check whole day 
        //        eventList.TimeMin = min.Date + ts;
        //        eventList.TimeMax = (min.Date + ts).AddHours(24);
        //        var newList = eventList.Execute().Items;// check for each day having event or not
        //        if (newList.Count > 0)
        //        {
        //            foreach (var newitem in newList)
        //            {
        //                var startTime = Convert.ToString(newitem.Start.DateTime);
        //                var arrDateTime = startTime.Split('/');
        //                var day = arrDateTime[1];
        //                var arrYearTime = arrDateTime[2].Split(' ');
        //                var startTimeSpan = arrYearTime[1];
        //                var endDate = Convert.ToString(newitem.End.DateTime);
        //                var arrEndDateTime = endDate.Split('/');
        //                var arrEndYearTime = arrEndDateTime[2].Split(' ');
        //                var endTimeSpan = arrEndYearTime[1] + arrEndYearTime[2];
        //                var time = startTimeSpan + " - " + endTimeSpan;
        //                var map = "https://www.google.co.in/maps?q=" + newitem.Location;
        //                if (newitem.Recurrence == null)
        //                {
        //                    calEvents.Add(new CalendarEvents
        //                    {
        //                        Day = day,
        //                        Time = time,
        //                        Map = map,
        //                        Location = newitem.Location
        //                    });
        //                }
        //                //else
        //                //{
        //                //    calEvents.Add(new CalendarEvents { Day = Convert.ToString(min.Day), Location = "No Event Found!", Time = "N/A" });
        //                //}
        //            }
        //        }
        //        else
        //        {
        //            calEvents.Add(new CalendarEvents { Day = Convert.ToString(min.Day), Location = "No Event Found!", Time = "N/A" });
        //        }
        //        min = min.AddDays(1);//min++;
        //    }
            
        //    //bind events list with repeater
        //    rptEvents.DataSource = calEvents.OrderBy(x => x.Day);
        //    rptEvents.DataBind();
        //}
    }
}