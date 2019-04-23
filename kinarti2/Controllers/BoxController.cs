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

    public class BoxController : ApiController
    {
        [System.Web.Http.HttpGet]
        [Route("api/boxes")]
        public IEnumerable<Box> GetBox()
        {
            Box box = new Box();
            List<Box> lm = box.getBoxes();
            return lm;
        }

        //[HttpGet]
        //[Route("api/boxes")]
        //public IEnumerable<Box> Get()
        //{
        //    Box box = new Box();
        //    List<Box> boxesList = box.getBoxes();
        //    return boxesList;
        //}

        //[System.Web.Http.HttpPost]
        //[Route("api/calculateItemPrice")]
        //public IEnumerable<float> CalculatePrice()
        //{
        //    Box box = new Box();
        //    List<Box> lm = box.getBoxes();

        //    Hinge hinge = new Hinge();
        //    List<Hinge> lh = hinge.getHinges();
        //    return lm;
        //}


        // POST api/values
        [HttpPost]
        [Route("api/boxes")]
        public void Post([FromBody]Box p)
        {
            try
            {                
                p.insert();   //    int someError = Convert.ToInt32("will fail to convert");
            }
            catch (Exception e)
            {
                throw e; // throw new Exception("Error in posting a new person");
            }
        }

        [HttpPut]
        [Route("api/boxes")]
        public void Put([FromBody]Box p, int Id)
        {
            p.updateBox(Id);
        }

   //[HttpGet]
        //[Route("api/boxes")]
        //public float getTotalCost(params p)
        //{
        //    params person = new Person();
        //    return person.getPerson(email, password);
        //}
    }
}
