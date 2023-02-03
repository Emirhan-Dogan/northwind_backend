using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Result
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(bool success, string message, T data) : base(success, message)
        {
            this.Data = data;
        }

        public DataResult(bool success, T data) : base(success)
        {
            this.Data = data;
        }



        public T Data { get; }
    }
}
