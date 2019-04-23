using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using kinarti.Models;
using System.IO;
using System.Web;
using System.Web.Hosting;

namespace kinarti.Controllers
{

    public class ConstantsController : ApiController
    {
        [System.Web.Http.HttpGet]
        [Route("api/constants")]
        public IEnumerable<Constants> GetBox()
        {
            Constants constant = new Constants();
            List<Constants> lm = constant.getConstants();
            return lm;
        }

        [HttpPut]
        [Route("api/constants")]
        public void Put([FromBody]Constants constants)
        {
            constants.updateConstants();
        }
        //// POST api/values
        //[HttpPost]
        //[Route("api/boxes")]
        //public void Post([FromBody]Box p)
        //{
        //    try
        //    {                
        //        p.insert();   //    int someError = Convert.ToInt32("will fail to convert");
        //    }
        //    catch (Exception e)
        //    {
        //        throw e; // throw new Exception("Error in posting a new person");
        //    }
        //}
    }
}
