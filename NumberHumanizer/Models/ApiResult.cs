using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumberHumanizer.Models
{
    public class ApiResult<T>
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public T Result { get; set; }
    }
}