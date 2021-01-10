using System;
using System.Collections.Generic;

namespace Sn0wballEngine
{
    public class Settings
    {
        static Dictionary<string, object> settings = new Dictionary<string, object>();

        public static void SetSetting(string setting, object value)
        {
            settings[setting] = value;
        }

        public static T GetSetting<T>(string setting) where T : class
        {
            return settings[setting] as T;
        }
    }
}
