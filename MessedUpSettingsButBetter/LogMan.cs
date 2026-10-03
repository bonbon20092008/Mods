using System;
using System.Collections.Generic;
using System.Text;

namespace Messed_Up_Settings
{
    public class LogMan
    {
        public static void Info(object data)
        {
            Plugin.Logger.LogInfo(data);
        }
        public static void Warning(object data)
        {
            Plugin.Logger.LogWarning(data);
        }
        public static void Error(object data)
        {
            Plugin.Logger.LogError(data);
        }
    }
}
