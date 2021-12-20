using Cores.Results.Abstract;
using Cores.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cores.Results.Concrete
{
    public class Result : IResult
    {
        public Result(ResultStatus status,string message)
        {
            ResultStatus = status;
            Message = message;
        }
        public Result(ResultStatus status, string message,Exception exception)
        {
            ResultStatus = status;
            Message = message;
            Exception = exception;
        }
        public ResultStatus ResultStatus { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }
}
