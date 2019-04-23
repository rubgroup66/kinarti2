using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;

using System.Text;


namespace kinarti.Models
{
    public class Facade
    {
        public int ID { get; set; }

        public string Type { get; set; }
        public int Cost { get; set; }

        public Facade(int _id, string _type, int _cost)
        {
            ID = _id;
            Type = _type;
            Cost = _cost;
        }
        public Facade()
        {
        }
        public int insert()
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.insertFacade(this);
            return numAffected;
        }

        //--------------------------------------------------------------------------
        // get the list of the persons
        //--------------------------------------------------------------------------
        public List<Facade> getFacades()
        {
            DBservices dbs = new DBservices();
            List<Facade> lp = dbs.getFacades("PriceITConnectionString", "facadeTbl");
            return lp;
        }


        //public int updateFacade(int Id)
        //{
        //    DBservices dbs = new DBservices();
        //    int numAffected = dbs.updateFacade(this, Id);
        //    return numAffected;
        //}

    }
}
