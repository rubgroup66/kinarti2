//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace WebApplication1.Models
//{
//    public class Hobbie
//    {
//        public string Name { get; set; }
//        public int Id { get; set; }
//        public Hobbie(string _name, int _id)
//        {
//            Id = _id;
//            Name = _name;
//        }
//        public Hobbie()
//        {

//        }
//        public int insert()
//        {
//            DBservices dbs = new DBservices();
//            int num = dbs.insert(this);
//            return num;
//        }    
//        //--------------------------------------------------------------------------
//        // get the list of the hobbies
//        //--------------------------------------------------------------------------
//        public List<Hobbie> Read()
//        {
//            DBservices dbs = new DBservices();
//            List<Hobbie> lh = dbs.getHobbies("TinderConnectionString", "HobbiesTbl");
//            return lh;
//        }
//    }
//}