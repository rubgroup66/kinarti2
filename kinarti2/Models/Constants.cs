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
    public class Constants
    {
        public int ID { get; set; }
        public string constantName { get; set; }
        public float Cost { get; set; }
        public Constants(int _id, string _constantName, float  _cost) //int _costForBasicMaterial)
        {
            ID = _id;
            constantName = constantName;
            Cost = _cost;
        }
        public Constants()
        {
        }

        //--------------------------------------------------------------------------
        // get the list of the boxes
        //--------------------------------------------------------------------------
        public List<Constants> getConstants()
        {
            DBservices dbs = new DBservices();
            List<Constants> lp = dbs.getConstants("PriceITConnectionString", "constantParametersCostTbl");
            return lp;
        }

        public int updateConstants()
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.updateConstants(this);
            return numAffected;
        }



    }
}
