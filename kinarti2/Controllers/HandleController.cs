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

    public class HandleController : ApiController
    {
        [System.Web.Http.HttpGet]
        [Route("api/handles")]
        public IEnumerable<Handle> GetHandle()
        {
            Handle handle = new Handle();
            List<Handle> lm = handle.getHandles();
            return lm;
        }
        // POST api/values
        //public void Post([FromBody]string value)
        //[Route("api/cust")]
        //public void Post([FromBody]Customer cust)
        //{
        //    cust.insert();
        //}

        //[HttpGet]
        //[Route("api/customers")]
        //public IEnumerable<Box> Get()
        //{
        //    Box box = new Box();
        //    List<Box> boxesList = box.GetBoxes();
        //    return boxesList;
        //}

        //[HttpPost]
        //[Route("api/person/filter")]
        //public IEnumerable<Person> useFilter(Filter filter)
        //{

        //    #region // This code is only used for example, change it with your own
        //    Person person = new Person();
        //    List<Person> personList = person.Filter(filter);

        //    //List<Person> personList = new List<Person>();
        //    //personList.Add(new Person("bibi", "netanyahu", "male", 67, 175, "", "Jerusalem"));
        //    ////personList.Add(new Person("sara", "netanyahu", "female", 57, 165, "", "Jerusalem"));
        //    //personList.Add(new Person("rubi", "rivlin", "male", 75, 170, "", "Jerusalem"));
        //    #endregion

        //    return personList;

        //}


    }
}
