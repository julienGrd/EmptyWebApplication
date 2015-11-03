using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace EmptyWebApplication.Util
{
    public static class Properties
    {
        public static string AudienceId { get; } = ConfigurationManager.AppSettings["AudienceId"];
        public static string AudienceSecret { get; } = ConfigurationManager.AppSettings["AudienceSecret"];
        public static string ProjectUrl { get; } = ConfigurationManager.AppSettings["ProjectUrl"];
    }
}