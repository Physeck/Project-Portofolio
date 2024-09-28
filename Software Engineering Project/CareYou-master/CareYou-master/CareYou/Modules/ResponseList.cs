using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareYou.Modules
{
    public class ResponseList<T>
    {
        public Boolean Success { get; set; }
        public String Message { get; set; }
        public String Field { get; set; }
        public List<T> Payload { get; set; }
    }
}