//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace WebApplication1.Models
//{
//    public class Person
//    {
//        public int ID { get; set; }
//        public string Name { get; set; }
//        public string FamilyName { get; set; }
//        public string Gender { get; set; }
//        public double Age { get; set; }
//        public double Height { get; set; }
//        public string Image { get; set; }
//        public string Address { get; set; }
//        public int[] Hobbies { get; set; }
//        public string Phone { get; set; }
//        public bool IsActive { get; set; }
//        public bool IsPremium { get; set; }
//        public string Password { get; set; }
//        public string Email { get; set; }

//        public Person(int _id, string _name, string _familyName, string _gender, double _age, double _height, string _image, string _address, int[] _hobbies, string _phone, bool _isActive, bool _isPremium, string _password, string _email)
//        {
//            ID = _id;
//            Name = _name;
//            FamilyName = _familyName;
//            Gender = _gender;
//            Age = _age;
//            Height = _height;
//            Address = _address;
//            Image = _image;
//            Phone = _phone;
//            IsActive = _isActive;
//            IsPremium = _isPremium;
//            Hobbies = _hobbies;
//            Password = _password;
//            Email = _email;
//        }
//        public Person()
//        {
//        }
//        public int insert()
//        {
//            DBservices dbs = new DBservices();
//            int numAffected = dbs.insertPerson(this);
//            return numAffected;
//        }
//        //--------------------------------------------------------------------------
//        // get the list of the persons
//        //--------------------------------------------------------------------------
//        public List<Person> getPersons()
//        {
//            DBservices dbs = new DBservices();
//            List<Person> lp = dbs.getPersons("TinderConnectionString", "PersonTbl");
//            return lp;
//        }

//        public int SwitchActive(int isActive, int PersonId)
//        {
//            DBservices dbs = new DBservices();
//            int numAffected = dbs.SwitchActive(isActive, PersonId);
//            return numAffected;
//        }

//        public Person getPerson(string email, string password)
//        {
//            DBservices dbs = new DBservices();

//            return dbs.getPerson("TinderConnectionString", "PersonTbl", email, password);
//        }

//        public int updatePerson(int Id)
//        {
//            DBservices dbs = new DBservices();
//            int numAffected = dbs.updatePerson(this, Id);
//            return numAffected;
//        }
//    }
//}
