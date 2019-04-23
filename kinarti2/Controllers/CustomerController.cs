//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
////using WebApplication1.Models;

//namespace WebApplication1.Controllers
//{

//    public class CustomerController : ApiController
//    {

//        // POST api/values
//        //public void Post([FromBody]string value)
//        [Route("api/cust")]
//        public void Post([FromBody]Customer cust)
//        {
//            cust.insert();
//        }

//        [HttpGet]
//        [Route("api/customers")]
//        public IEnumerable<Customer> Get()
//        {
//            Customer cust = new Customer();
//            List<Customer> customerList = cust.GetCustomers();
//            return customerList;
//        }

//        //[HttpPost]
//        //[Route("api/person/filter")]
//        //public IEnumerable<Person> useFilter(Filter filter)
//        //{

//        //    #region // This code is only used for example, change it with your own
//        //    Person person = new Person();
//        //    List<Person> personList = person.Filter(filter);

//        //    //List<Person> personList = new List<Person>();
//        //    //personList.Add(new Person("bibi", "netanyahu", "male", 67, 175, "", "Jerusalem"));
//        //    ////personList.Add(new Person("sara", "netanyahu", "female", 57, 165, "", "Jerusalem"));
//        //    //personList.Add(new Person("rubi", "rivlin", "male", 75, 170, "", "Jerusalem"));
//        //    #endregion

//        //    return personList;

//        //}

//    }
//}
