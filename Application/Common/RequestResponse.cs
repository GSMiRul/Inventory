using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public class RequestResponse<T>
    {
        public bool Succeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Container { get; set; }

        public RequestResponse() { }
        public RequestResponse(T container, string message = null) 
        {
            Succeded = true;
            Message = message;
            Container = container;
        }
    }
}
