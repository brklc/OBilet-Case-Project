using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Obilet.WebUI.Helpers
{
    public static class SessionHelper
    {
        public static void Set(this ISession session, string key, string value)
        {
            session.SetString(key, value);
        }

        public static string Get(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : value;
        }
    }
}
