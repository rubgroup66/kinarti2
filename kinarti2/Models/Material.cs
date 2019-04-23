//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//using System.Data.SqlClient;
//using System.Web.Configuration;
//using System.Data;

//using System.Text;


//namespace kinarti.Models
//{
//    public class Material
//    {
//        public int ID { get; set; }
//        public string Name { get; set; }
//        public int Price { get; set; }
//        public string Size { get; set; }
//        public string Category { get; set; }
//        public Material(int _id, string _name, int _price, string _size, string _category)
//        {
//            ID = _id;
//            Name = _name;
//            Price = _price;
//            Size = _size;
//            Category = _category;
//        }
//        public Material()
//        {
//        }
//        public int insert()
//        {
//            DBservices dbs = new DBservices();
//            int numAffected = dbs.insertMaterial(this);
//            return numAffected;
//        }
//        //--------------------------------------------------------------------------
//        // get the list of the persons
//        //--------------------------------------------------------------------------
//        public List<Material> getMaterials()
//        {
//            DBservices dbs = new DBservices();
//            List<Material> lp = dbs.getMaterials("PriceITConnectionString", "Material");
//            return lp;
//        }

//        //public int SwitchActive(int isActive, int PersonId)
//        //{
//        //    DBservices dbs = new DBservices();
//        //    int numAffected = dbs.SwitchActive(isActive, PersonId);
//        //    return numAffected;
//        //}

//        //public Material getMaterial(string email, string password)
//        //{
//        //    DBservices dbs = new DBservices();
//        //    return dbs.getMaterial("TinderConnectionString", "MaterialTbl", email, password);
//        //}

//        public int updateMaterial(int Id)
//        {
//            DBservices dbs = new DBservices();
//            int numAffected = dbs.updateMaterial(this, Id);
//            return numAffected;
//        }

//    }
//}
