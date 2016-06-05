using System;

namespace Swart.DomainDrivenDesign
{
    public class SystemMessage
    {
        public MessageType Type { get; protected set; }
        public string Message { get; protected set; }

        public SystemMessage(MessageType type, string message)
        {
            Type = type;
            Message = message;
        }
    }

    public class DebugMessage:SystemMessage
    {
        public DebugMessage(string message):base(MessageType.Debug, message)
        {
        }
    }

    public class InfoMessage : SystemMessage
    {
        public InfoMessage(string message) : base(MessageType.Info, message)
        {
        }
    }

    public class WarningMessage : SystemMessage
    {
        public WarningMessage(string message) : base(MessageType.Warning, message)
        {
        }
    }

    public class ErrorMessage : SystemMessage
    {
        public Exception Exception { get; private set;}
        public ErrorMessage(string message) : base(MessageType.Error, message)
        {
        }

        public ErrorMessage(string message, Exception exception) : base(MessageType.Error, message)
        {
            Exception = exception;
        }

        public ErrorMessage(Exception exception) : base(MessageType.Error, "An unexpected error occured.")
        {
            Exception = exception;
        }
    }

    public enum MessageType
    {
        Debug,
        Info,
        Warning,
        Error,
    }
}
