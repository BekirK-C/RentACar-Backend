using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool ısSuccess, string message) : base(ısSuccess, message)
        {
            Data = data;
        }
        public DataResult(T data, bool ısSuccess) : base(ısSuccess)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
