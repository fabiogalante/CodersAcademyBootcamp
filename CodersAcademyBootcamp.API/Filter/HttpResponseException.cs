using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.API.Filter
{
    public class HttpResponseException
    {
        public HttpStatusCode StatusCode { get; set; }

        public String Title { get; set; } = "One or more validation errors occurred";

        public List<HttpResponseMessage> Errors { get; set; } = new List<HttpResponseMessage>();
    }
}
