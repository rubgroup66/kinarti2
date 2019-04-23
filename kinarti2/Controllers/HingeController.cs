using kinarti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using HttpPutAttribute = System.Web.Mvc.HttpPutAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

using System.Data;

using System.Net;
using System.Net.Http;

namespace WebApplication1.Controllers
{

    public class HingeController : ApiController
    {
        [System.Web.Http.HttpGet]
        [Route("api/Hinges")]
        public IEnumerable<Hinge> GetHinge()
        {
            Hinge hinge = new Hinge();
            List<Hinge> lm = hinge.getHinges();
            return lm;
        }

    }
}
