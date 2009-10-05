using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using eventcreate2.Properties;
using System.Security;

namespace eventcreate2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showUsageOnly = false;
            string logName = string.Empty;
            string source = string.Empty;
            string message = string.Empty;
            string typeString = string.Empty;
            string idString = string.Empty;

            if (args.Length == 0)
            {
                showUsageOnly = true;
            }
            else 
            {
                for (int i = 0; i < args.Length; i++)
                {
                    string key = args[i];
                    string value = string.Empty;
                    if ((i + 1) < args.Length)
                    {
                        value = args[i + 1];
                    }

                    switch (key.ToLower())
                    {
                        case "/l": logName = value; break;
                        case "/t": typeString = value; break;
                        case "/so": source = value; break;
                        case "/id": idString = value; break;
                        case "/d": message = value; break;
                        case "/?": showUsageOnly = true; break;
                    }
                }

            }

            if (showUsageOnly)
            {
                showUsage();
                return;
            }

            try
            {
                if (!EventLog.SourceExists(source))
                {
                    EventLog.CreateEventSource(source, logName);
                }
            }
            catch (SecurityException ex)
            {
                Console.WriteLine(
                    "\r\nA security error occurred, try running with elevated " +
                    "security permissions (Run as Administrator).\r\n\r\n" + 
                    ex.Message);
                return;
            }

            EventLogEntryType type = EventLogEntryType.Information;
            switch (typeString.ToLower())
            {
                case "error": 
                    type = EventLogEntryType.Error; break;

                case "failureaudit": 
                    type = EventLogEntryType.FailureAudit; break;

                case "information": 
                    type = EventLogEntryType.Information; break;

                case "successaudit": 
                    type = EventLogEntryType.SuccessAudit; break;

                case "warning": 
                    type = EventLogEntryType.Warning; break;
            }

            int id = int.Parse(idString);

            EventLog.WriteEntry(source, message, type, id);
        }

        private static void showUsage()
        {
            Console.Write(Resources.Usage);
        }
    }
}
