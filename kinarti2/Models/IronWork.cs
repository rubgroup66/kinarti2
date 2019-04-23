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
    public class IronWork
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public int Cost { get; set; }
        public IronWork(int _id, string _type, int _cost)
        {
            ID = _id;
            Type = _type;
            Cost = _cost;
        }
        public IronWork()
        {
        }
        //public int insert()
        //{
        //    DBservices dbs = new DBservices();
        //    int numAffected = dbs.insertMaterial(this);
        //    return numAffected;
        //}
        //--------------------------------------------------------------------------
        // get the list of the boxes
        //--------------------------------------------------------------------------
        public List<IronWork> getIronWorks()
        {
            DBservices dbs = new DBservices();
            List<IronWork> lp = dbs.getIronWorks("PriceITConnectionString", "ironWorkTbl");
            return lp;
        }

        //public int SwitchActive(int isActive, int PersonId)
        //{
        //    DBservices dbs = new DBservices();
        //    int numAffected = dbs.SwitchActive(isActive, PersonId);
        //    return numAffected;
        //}

        //public Material getMaterial(string email, string password)
        //{
        //    DBservices dbs = new DBservices();
        //    return dbs.getMaterial("TinderConnectionString", "MaterialTbl", email, password);
        //}

        //public int updateMaterial(int Id)
        //{
        //    DBservices dbs = new DBservices();
        //    int numAffected = dbs.updateMaterial(this, Id);
        //    return numAffected;
        //}

    }
}
