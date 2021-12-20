using Cores.Results.Abstract;
using Cores.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cores.Results.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult(ResultStatus status,string message,T data)
        {
            ResultStatus = status;
            Message = message;
            Data = data;
        }
        public DataResult(ResultStatus status, string message, T data,Exception exception)
        {
            ResultStatus = status;
            Message = message;
            Data = data;
            Exception = exception;
        }
        public T Data { get; }
        public ResultStatus ResultStatus { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }
}
