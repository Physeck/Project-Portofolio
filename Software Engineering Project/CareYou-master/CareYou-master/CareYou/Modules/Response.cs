using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareYou.DataClass
{
    public class Response<T>
    {
        public Boolean Success { get; set; }
        public String Message { get; set; }
        public String Field { get; set; }
        public T Payload { get; set; }
    }
}