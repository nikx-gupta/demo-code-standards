using System;

namespace Demo.FailFastAndException.Logging
{
    public interface ILogService
    {
    }

    public interface ILogService<T> : ILogService
    {
        void LogError(Exception contextException, string exceptionMessage);
    }
}