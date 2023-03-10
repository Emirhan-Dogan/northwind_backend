using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Result
{
    public class SuccessDataResult<T> : DataResult<T>, ISuccess
    {
        public SuccessDataResult(T data,string message) : base(data, message, true)
        {

        }

        public SuccessDataResult(T data) : base(data, true)
        {

        }

        public SuccessDataResult(string message) : base(message, true)
        {

        }

        public SuccessDataResult() : base(true)
        {

        }
    }
}
