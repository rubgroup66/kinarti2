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

namespace kinarti.Controllers
{

    public class IronWorksController : ApiController
    {
        [System.Web.Http.HttpGet]
        [Route("api/IronWorks")]
        public IEnumerable<IronWork> GetIronWorks()
        {
            IronWork ironWork = new IronWork();
            List<IronWork> lm = ironWork.getIronWorks();
            return lm;
        }

    }
}
