using System;

namespace StudioIdGames.MimiClean
{
    public class CleanResultException : CleanResultError
    {
        public Exception Exception { get; }

        public CleanResultException(Exception exception)
        {
            Exception = exception;
        }

        public override string Message => Exception.Message;

        public static implicit operator CleanResultException(Exception exception)
        {
            return new CleanResultException(exception);
        }
    }
}
