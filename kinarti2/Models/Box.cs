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
    public class Box
    {
        public int ID { get; set; }
        public int Type { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }
       // public int CostForBasicMaterial { get; set; }
        public Box(int _id, int _type, int _height, int _width, int _depth) //int _costForBasicMaterial)
        {
            ID = _id;
            Type = _type;
            Height = _height;
            Width = _width;
            Depth = _depth;
          //  CostForBasicMaterial = _costForBasicMaterial;
        }
        public Box()
        {
        }

        public int insert()
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.insertBox(this);
            return numAffected;
        }

        //--------------------------------------------------------------------------
        // get the list of the boxes
        //--------------------------------------------------------------------------
        public List<Box> getBoxes()
        {
            DBservices dbs = new DBservices();
            List<Box> lp = dbs.getBoxes("PriceITConnectionString", "boxTbl");
            return lp;
        }

        public int updateBox(int Id)
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.updateBox(this, Id);
            return numAffected;
        }



    }
}
