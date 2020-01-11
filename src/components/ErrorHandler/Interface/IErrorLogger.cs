using System;
using Components.DbConnection.Interface;

namespace Components.Errorhandler.Interface
{
    public interface IErrorLogger
    {
        void LogError(Exception error);
        void SetWorkingDirectory(string directory);
        void LogAuthentication<T>(ISqlHelper sql, T data);
    }
}