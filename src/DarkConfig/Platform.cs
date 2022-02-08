﻿namespace DarkConfig {
    public abstract class Platform {
        const string LOG_GUARD = "DC_LOGGING_ENABLED";
        const string ASSERT_GUARD = "DC_ASSERTS_ENABLED";
        const string LogPrefix = "[DarkConfig] ";

        protected abstract void LogCallback(LogVerbosity verbosity, string message);
        
        [System.Diagnostics.Conditional(ASSERT_GUARD)]
        public virtual void Assert(bool test, string message) {
            System.Diagnostics.Debug.Assert(test, message);
        }

        [System.Diagnostics.Conditional(LOG_GUARD)]
        public static void LogInfo(string message) {
            Log(LogVerbosity.Info, message);
        }

        [System.Diagnostics.Conditional(LOG_GUARD)]
        public static void LogWarning(string message) {
            Log(LogVerbosity.Warn, message);
        }

        [System.Diagnostics.Conditional(LOG_GUARD)]
        public static void LogError(string message) {
            Log(LogVerbosity.Error, message);
        }
        
        [System.Diagnostics.Conditional(LOG_GUARD)]
        public static void Log(LogVerbosity level, string msg) {
            if (level <= Config.Settings.LogLevel) {
                Config.Platform.LogCallback(level, LogPrefix + msg);
            }
        }
    }
}