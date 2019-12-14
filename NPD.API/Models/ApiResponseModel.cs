using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPD.API.Models
{
    public class ApiResponseModel<T>
    {
        public ApiResponseModel(bool success, T data)
        {
            Success = success;
            Data = data;
        }

        public bool Success { get; }
        public T Data { get; }
    }
}
