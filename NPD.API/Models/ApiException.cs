using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPD.API.Models
{
    public class ApiException
    {
        public ApiException(int errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        public int ErrorCode { get; }
        public string ErrorMessage { get; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
