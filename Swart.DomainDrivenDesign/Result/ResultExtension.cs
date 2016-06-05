using System;
using System.Collections.Generic;

namespace Swart.DomainDrivenDesign
{
    public static class ResultExtension
    {
        public static TResult AddMessage<TResult>(this TResult result, SystemMessage message) where TResult : IVoidResult
        {
            result.Messages.Add(message);
            return result;
        }

        public static TResult AddErrorMessage<TResult>(this TResult result, string message, Exception exception = null) where TResult : IVoidResult
        {
            result.Messages.Add(new ErrorMessage(message, exception));
            return result;
        }

        public static TResult AddMessages<TResult>(this TResult result, IList<SystemMessage> messages) where TResult : IVoidResult
        {
            foreach (var message in messages)
                result.Messages.Add(message);
            return result;
        }

        public static TResult AddErrorMessages<TResult>(this TResult result, IList<string> messages) where TResult : IVoidResult
        {
            foreach (var message in messages)
                result.Messages.Add(new ErrorMessage(message));
            return result;
        }
    }
}
