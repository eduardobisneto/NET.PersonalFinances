using System.Configuration;

namespace NET.PersonalFinances.UI.WindowsForms.Util
{
    public class Constants
    {
        public static string Host = ConfigurationManager.AppSettings["Host"];
    }
}
