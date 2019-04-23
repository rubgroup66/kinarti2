using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;

using System.Text;
using kinarti.Models;
/// <summary>
/// DBServices is a class created by me to provides some DataBase Services
/// </summary>
public class DBservices
{
    public SqlDataAdapter da;
    public DataTable dt;

    public DBservices()
    {
        // TODO: Add constructor logic here
    }
    //internal int insert(Hobbie hobbie)
    //{
    //    throw new NotImplementedException();
    //}
    //--------------------------------------------------------------------------------------------------
    // This method creates a connection to the database according to the connectionString name in the web.config 
    //--------------------------------------------------------------------------------------------------
    public SqlConnection connect(String conString)
    {
        // read the connection string from the configuration file
        string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }

    //--------------------------------------------------------------------------------------------------
    // This method inserts a person to the PersonTbl table 
    //--------------------------------------------------------------------------------------------------
    public int insertMaterial(Material material)
    {
        SqlConnection con;
        SqlCommand cmd;
        try
        {
            con = connect("PriceITConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            throw (ex); // write to log
        }
        String cStr = BuildInsertMaterialCommand(material);      // helper method to build the insert string
        cmd = CreateCommand(cStr, con); // create the command  
        try
        {
            int materialId = Convert.ToInt32(cmd.ExecuteScalar()); // execute the command
            //for (int i = 0; i < material.Prices.Length; i++)
            //{
            //    //cStr = BuildInsertHobbiesForUsersCommand(personId, material.Prices[i]);      // helper method to build the insert string
            //    //cmd = CreateCommand(cStr, con);
            //    cmd.ExecuteNonQuery();
            //}
            return materialId;
        }
        catch (Exception ex)
        {
            throw (ex); // write to log
        }
        finally
        {
            if (con != null)
            {
                con.Close();// close the db connection
            }
        }
    }
    //--------------------------------------------------------------------
    // Build the Insert command String-person
    //--------------------------------------------------------------------
    private String BuildInsertMaterialCommand(Material material)
    {
        String command;

        StringBuilder sbMaterial = new StringBuilder();
        // use a string builder to create the dynamic string
        sbMaterial.AppendFormat("Values('{0}', '{1}', {2}, {3})",
            material.Name, material.Type, material.Cost, material.Coefficient);
        String prefix = "INSERT INTO materialTbl " + "(name, type, cost, coefficient, workCost) ";
        command = prefix + sbMaterial.ToString() + ";" + "SELECT CAST(scope_identity() AS int)";
        return command;

    }

    //--------------------------------------------------------------------
    //  This method inserts a hobbies to the hobbiesforusersTbl table 
    //--------------------------------------------------------------------
    //public int insertHobbie(Hobbie hobbie)
    //{
    //    SqlConnection con;
    //    SqlCommand cmd;
    //    try
    //    {
    //        con = connect("TinderConnectionString"); // create the connection
    //    }
    //    catch (Exception ex)
    //    {          
    //        throw (ex); // write to log
    //    }
    //    String cStr = BuildInsertHobbiesForUsersCommand(hobbie);      // helper method to build the insert string
    //    cmd = CreateCommand(cStr, con);             // create the command
    //    try
    //    {
    //        int numEffected = Convert.ToInt32(cmd.ExecuteScalar());
    //        //for (int i = 0; i < hobbie.Length; i++)
    //        //{
    //        //}
    //        return numEffected;
    //    }
    //    catch (Exception ex)
    //    {
    //        return 0;
    //        throw (ex); // write to log
    //    }
    //    finally
    //    {
    //        if (con != null)
    //        {
    //            con.Close();// close the db connection
    //        }
    //    }
    //}

    //--------------------------------------------------------------------
    // Build the Insert command String-hobbies
    //--------------------------------------------------------------------
    //private String BuildInsertHobbiesForUsersCommand(int personId, int hobbieID)
    //{
    //    String command;
    //    StringBuilder sb = new StringBuilder();
    //    // use a string builder to create the dynamic string
    //    sb.AppendFormat("Values('{0}', '{1}' )", personId, hobbieID);
    //    String prefix = "INSERT INTO HobbiesForUsers " + "(personID, hobbieID) ";
    //    command = prefix + sb.ToString();
    //    return command;

    //StringBuilder sbHobbies = new StringBuilder();
    //String prefix2 = "";
    //for (int i = 0; i < person.Hobbies.Length; i++)
    //{
    //    sbHobbies = new StringBuilder();
    //    sbHobbies.AppendFormat("Values('{0}', '{1}' )", person.ID, person.Hobbies[i]);
    //    prefix2 += "INSERT INTO HobbiesForUsers " + " (personID, hobbieId) " + sbHobbies.ToString() + ";";
    //}
    //}
    //---------------------------------------------------------------------------------
    // Read from the DB into a list - dataReader
    //---------------------------------------------------------------------------------
    //public List<Material> getMaterials(string conString, string tableName)
    //{
    //    SqlConnection con = null;
    //    List<Material> lm = new List<Material>();
    //    try
    //    {
    //        con = connect(conString); // create a connection to the database using the connection String defined in the web config file
    //        String selectSTR = "SELECT * FROM " + tableName;

    //        SqlCommand cmd = new SqlCommand(selectSTR, con);
    //        // get a reader
    //        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
    //        while (dr.Read())
    //        {   // Read till the end of the data into a row
    //            Material m = new Material();
    //            m.ID = Convert.ToInt32(dr["id"]);
    //            m.Name = Convert.ToString(dr["name"]);
    //            m.Price = Convert.ToInt32(dr["price"]);
    //            m.Size = Convert.ToString(dr["size"]);
    //            m.Category = Convert.ToString(dr["category"]);


    //            //this function will return list of hobbies indexes
    //            //p.Hobbies = getHobbiesForPerson("TinderConnectionString", "HobbiesForUsers", p.ID);

    //            lm.Add(m);
    //        }
    //        return lm;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw (ex); // write to log
    //    }
    //    finally
    //    {
    //        if (con != null)
    //        {
    //            con.Close();
    //        }
    //    }
    //}

    //---------------------------------------------------------------------------------
    // Read from the DB into a list - dataReader
    //---------------------------------------------------------------------------------
    public List<Material> getMaterials(string conString, string tableName)
    {
        SqlConnection con = null;
        List<Material> lm = new List<Material>();
        try
        {
            con = connect(conString); // create a connection to the database using the connection String defined in the web config file
            String selectSTR = "SELECT * FROM " + tableName;

            SqlCommand cmd = new SqlCommand(selectSTR, con);
            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
            while (dr.Read())
            {   // Read till the end of the data into a row
                Material m = new Material();
                m.ID = Convert.ToInt32(dr["id"]);
                m.Name = Convert.ToString(dr["name"]);
                m.Type = Convert.ToString(dr["type"]);
                m.Cost = Convert.ToInt32(dr["cost"]);
                m.Coefficient = Convert.ToInt32 (dr["coefficient"]);
               // m.WorkCost = Convert.ToInt32(dr["workCost"]);

                //this function will return list of hobbies indexes
                //p.Hobbies = getHobbiesForPerson("TinderConnectionString", "HobbiesForUsers", p.ID);

                lm.Add(m);
            }
            return lm;
        }
        catch (Exception ex)
        {
            throw (ex); // write to log
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    //---------------------------------------------------------------------------------
    // Read from the DB into a list - dataReader
    //---------------------------------------------------------------------------------
    public List<Material> getMaterials2(string conString, string tableName)
    {
        SqlConnection con = null;
        List<Material> lm = new List<Material>();
        try
        {
            con = connect(conString); // create a connection to the database using the connection String defined in the web config file
            String selectSTR = "SELECT * FROM " + tableName;

            SqlCommand cmd = new SqlCommand(selectSTR, con);
            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
            while (dr.Read())
            {   // Read till the end of the data into a row
                Material m = new Material();
                m.ID = Convert.ToInt32(dr["id"]);
                m.Name = Convert.ToString(dr["name"]);
                m.Type = Convert.ToString(dr["type"]);
            //    m.Cost = Convert.ToInt32(dr["cost"]);
                m.Coefficient = Convert.ToInt32(dr["coefficient"]);
            //    m.WorkCost = Convert.ToInt32(dr["workCost"]);

                lm.Add(m);
            }
            return lm;
        }
        catch (Exception ex)
        {
            throw (ex); // write to log
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    //---------------------------------------------------------------------------------
    // Read from the DB into a list - dataReader
    //---------------------------------------------------------------------------------
    public List<Facade> getFacades(string conString, string tableName)
    {
        SqlConnection con = null;
        List<Facade> lm = new List<Facade>();
        try
        {
            con = connect(conString); // create a connection to the database using the connection String defined in the web config file
            String selectSTR = "SELECT * FROM " + tableName;

            SqlCommand cmd = new SqlCommand(selectSTR, con);
            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
            while (dr.Read())
            {   // Read till the end of the data into a row
                Facade m = new Facade();
                m.ID = Convert.ToInt32(dr["id"]);
                m.Type = Convert.ToString(dr["type"]);
                m.Cost = Convert.ToInt32(dr["cost"]);

                lm.Add(m);
            }
            return lm;
        }
        catch (Exception ex)
        {
            throw (ex); // write to log
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    //--------------------------------------------------------------------------------------------------
    // This method inserts a person to the PersonTbl table 
    //--------------------------------------------------------------------------------------------------
    public int insertFacade(Facade facade)
    {
        SqlConnection con;
        SqlCommand cmd;
        try
        {
            con = connect("PriceITConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            throw (ex); // write to log
        }
        String cStr = BuildInsertFacadeCommand(facade);      // helper method to build the insert string
        cmd = CreateCommand(cStr, con); // create the command  
        try
        {
            int facadeId = Convert.ToInt32(cmd.ExecuteScalar()); // execute the command
            //for (int i = 0; i < material.Prices.Length; i++)
            //{
            //    //cStr = BuildInsertHobbiesForUsersCommand(personId, material.Prices[i]);      // helper method to build the insert string
            //    //cmd = CreateCommand(cStr, con);
            //    cmd.ExecuteNonQuery();
            //}
            return facadeId;
        }
        catch (Exception ex)
        {
            throw (ex); // write to log
        }
        finally
        {
            if (con != null)
            {
                con.Close();// close the db connection
            }
        }
    }
    //--------------------------------------------------------------------
    // Build the Insert command String-person
    //--------------------------------------------------------------------
    private String BuildInsertFacadeCommand(Facade facade)
    {
        String command;

        StringBuilder sbFacade = new StringBuilder();
        // use a string builder to create the dynamic string
        sbFacade.AppendFormat("Values('{0}', {1})",
             facade.Type, facade.Cost);
        String prefix = "INSERT INTO materialTbl " + "(type, cost) ";
        command = prefix + sbFacade.ToString() + ";" + "SELECT CAST(scope_identity() AS int)";
        return command;

    }
    public List<Box> getBoxes(string conString, string tableName)
    {
        SqlConnection con = null;
        List<Box> boxesList = new List<Box>();
        try
        {
            con = connect(conString);
            String selectSTR = "SELECT * FROM  " + tableName; //"SELECT* FROM " + tableName + " where age >=" + filter.MinAge + " and age <=" + filter.MaxAge + "and gender = 'Male'";

            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {// Read till the end of the data into a row
                // read first field from the row into the list collection
                Box box = new Box();
                box.Type = Convert.ToInt32(dr["type"]);
                box.ID = Convert.ToInt32(dr["id"]);
                box.Height = Convert.ToInt32(dr["height"]);
                box.Width = Convert.ToInt32(dr["width"]);
                box.Depth = Convert.ToInt32(dr["depth"]);
              //  box.CostForBasicMaterial = Convert.ToInt32(dr["costForBasicMaterial"]);
                boxesList.Add(box);
            }
            return boxesList;
        }
        catch (Exception ex)
        {
            throw (ex); // write to log
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<Handle> getHandles(string conString, string tableName)
    {
        SqlConnection con = null;
        List<Handle> handlesList = new List<Handle>();
        try
        {
            con = connect(conString);
            String selectSTR = "SELECT * FROM  " + tableName; //"SELECT* FROM " + tableName + " where age >=" + filter.MinAge + " and age <=" + filter.MaxAge + "and gender = 'Male'";

            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {// Read till the end of the data into a row
                // read first field from the row into the list collection
                Handle handle = new Handle();
                handle.Type = Convert.ToString(dr["type"]);
                handle.ID = Convert.ToInt32(dr["id"]);
                handle.Cost = Convert.ToInt32(dr["cost"]);

                handlesList.Add(handle);
            }
            return handlesList;
        }
        catch (Exception ex)
        {
            throw (ex); // write to log
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<Hinge> getHinges(string conString, string tableName)
    {
        SqlConnection con = null;
        List<Hinge> hingesList = new List<Hinge>();
        try
        {
            con = connect(conString);
            String selectSTR = "SELECT * FROM  " + tableName; //"SELECT* FROM " + tableName + " where age >=" + filter.MinAge + " and age <=" + filter.MaxAge + "and gender = 'Male'";

            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {// Read till the end of the data into a row
                // read first field from the row into the list collection
                Hinge hinge = new Hinge();
                hinge.Type = Convert.ToString(dr["type"]);
                hinge.ID = Convert.ToInt32(dr["id"]);
                hinge.Cost = Convert.ToInt32(dr["cost"]);

                hingesList.Add(hinge);
            }
            return hingesList;
        }
        catch (Exception ex)
        {
            throw (ex); // write to log
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<IronWork> getIronWorks(string conString, string tableName)
    {
        SqlConnection con = null;
        List<IronWork> ironWorksList = new List<IronWork>();
        try
        {
            con = connect(conString);
            String selectSTR = "SELECT * FROM  " + tableName; //"SELECT* FROM " + tableName + " where age >=" + filter.MinAge + " and age <=" + filter.MaxAge + "and gender = 'Male'";

            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {// Read till the end of the data into a row
                // read first field from the row into the list collection
                IronWork ironWork = new IronWork();
                ironWork.Type = Convert.ToString(dr["type"]);
                ironWork.ID = Convert.ToInt32(dr["id"]);
                ironWork.Cost = Convert.ToInt32(dr["cost"]);

                ironWorksList.Add(ironWork);
            }
            return ironWorksList;
        }
        catch (Exception ex)
        {
            throw (ex); // write to log
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }
    public List<Constants> getConstants(string conString, string tableName)
    {
        SqlConnection con = null;
        List<Constants> constantsList = new List<Constants>();
        try
        {
            con = connect(conString);
            String selectSTR = "SELECT * FROM  " + tableName; //"SELECT* FROM " + tableName + " where age >=" + filter.MinAge + " and age <=" + filter.MaxAge + "and gender = 'Male'";

            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {// Read till the end of the data into a row
                // read first field from the row into the list collection
                Constants constants = new Constants();
                constants.constantName = Convert.ToString(dr["constantName"]);
                constants.ID = Convert.ToInt32(dr["id"]);
                constants.Cost = Convert.ToInt32(dr["cost"]);

                constantsList.Add(constants);
            }
            return constantsList;
        }
        catch (Exception ex)
        {
            throw (ex); // write to log
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }
    public DBservices ReadFromDataBase(string conString, string tableName)
    {
        SqlConnection con = null;
        try
        {
            con = connect(conString); // open the connection to the database/

            String selectStr = "SELECT * FROM " + tableName; // create the select that will be used by the adapter to select data from the DB

            SqlDataAdapter da = new SqlDataAdapter(selectStr, con); // create the data adapter

            DataSet ds = new DataSet(); // create a DataSet and give it a name (not mandatory) as defualt it will be the same name as the DB
            da.Fill(ds);                        // Fill the datatable (in the dataset), using the Select command

            DataTable dt = ds.Tables[0];
            // add the datatable and the data adapter to the dbS helper class in order to be able to save it to a Session Object
            this.dt = dt;
            this.da = da;
            return this;
        }
        catch (Exception ex)
        {
            // write to log
            throw ex;
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }
    //---------------------------------------------------------------------------------
    // update the dataset into the database
    //---------------------------------------------------------------------------------
    public void Update()
    {
        // the command build will automatically create insert/update/delete commands according to the select command
        SqlCommandBuilder builder = new SqlCommandBuilder(da);
        da.Update(dt);
    }
    private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
    {
        SqlCommand cmd = new SqlCommand(); // create the command object
        cmd.Connection = con;              // assign the connection to the command object
        cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 
        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds
        cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure
        return cmd;
    }

    //--------------------------------------------------------------------------------------------------
    // This method inserts a person to the PersonTbl table 
    //--------------------------------------------------------------------------------------------------
    public int insertBox(Box box)
    {
        SqlConnection con;
        SqlCommand cmd;
        try
        {
            con = connect("PriceITConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            throw (ex); // write to log
        }
        String cStr = BuildInsertBoxCommand(box);      // helper method to build the insert string
        cmd = CreateCommand(cStr, con); // create the command  
        try
        {
            int boxId = Convert.ToInt32(cmd.ExecuteScalar()); // execute the command
            //for (int i = 0; i < box.Hobbies.Length; i++)
            //{
            //    cStr = BuildInsertHobbiesForUsersCommand(personId, person.Hobbies[i]);      // helper method to build the insert string
            //    cmd = CreateCommand(cStr, con);
            //    cmd.ExecuteNonQuery();
            //}
            return boxId;
        }
        catch (Exception ex)
        {
            throw (ex); // write to log
        }
        finally
        {
            if (con != null)
            {
                con.Close();// close the db connection
            }
        }
    }
    //--------------------------------------------------------------------
    // Build the Insert command String-person
    //--------------------------------------------------------------------
    private String BuildInsertBoxCommand(Box box)
    {
        String command;

        StringBuilder sbBox = new StringBuilder();
        // use a string builder to create the dynamic string
        sbBox.AppendFormat("Values({0}, {1} ,{2}, {3}, {4})",
            box.Type, box.Height, box.Width, box.Depth);
        String prefix = "INSERT INTO boxTbl " + "(type, height, width, depth) ";
        command = prefix + sbBox.ToString() + ";" + "SELECT CAST(scope_identity() AS int)";
        return command;
    }







    //update edited Material in system
    public int updateMaterial(Material material, int Id)
    {
        SqlConnection con;
        SqlCommand cmd;
        //SqlCommand cmd1;
        //SqlCommand cmd2;

        try
        {
            con = connect("PriceITConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            throw (ex);          // write to log
        }
        //String cStrDelete = BuildDeleteHobbiesCommand(Id);
        //cmd2 = CreateCommand(cStrDelete, con);
        //int numEffected2 = (int)cmd2.ExecuteNonQuery();
        String cStr = BuildUpdateCommand(material, Id);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = (int)cmd.ExecuteNonQuery(); // execute the command
            //for (int i = 0; i < material.Hobbies.Length; i++)
            //{
            //    String cStrInsertHobbies = BuildInsertHobbiesForUsersCommand(Id, person.Hobbies[i]);
            //    cmd1 = CreateCommand(cStrInsertHobbies, con);
            //    int numEffected1 = cmd1.ExecuteNonQuery();
            //}
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            throw (ex);       // write to log
        }
        finally
        {
            if (con != null)
            {
                con.Close();        // close the db connection
            }
        }
    }
    
    private string BuildUpdateCommand(Material m, int id)
    {
        //String command;
        //StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        string prefix = "UPDATE Material SET name = '" + m.Name + "', cost = '" + m.Cost + "', type = '" + m.Type + "',coefficient = '" + m.Coefficient  + " WHERE id=" + id;
        //command = prefix + "SELECT CAST(scope_identity() AS int)";

        return prefix;
    }
    //update edited box in system
    public int updateBox(Box box, int Id)
    {
        SqlConnection con;
        SqlCommand cmd;
        try
        {
            con = connect("PriceITConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            throw (ex);          // write to log
        }
        String cStr = BuildUpdateCommand(box, Id);      // helper method to build the insert string
        cmd = CreateCommand(cStr, con);             // create the command
        try
        {
            int numEffected = (int)cmd.ExecuteNonQuery(); // execute the command

            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            throw (ex);       // write to log
        }
        finally
        {
            if (con != null)
            {
                con.Close();        // close the db connection
            }
        }
    }

    private string BuildUpdateCommand(Box box, int id)
    {
        string prefix = "UPDATE boxTbl SET type = '" + 1 + "', height = '" + box.Height + "', width = '" + box.Width + "',depth = '" + box.Depth + " WHERE id=" + id;
        return prefix;
    }

    //update edited Material in system
    public int updateConstants(Constants constants)
    {
        SqlConnection con;
        SqlCommand cmd;
        try
        {
            con = connect("PriceITConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            throw (ex);          // write to log
        }
        String cStr = BuildUpdateCommand(constants);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = (int)cmd.ExecuteNonQuery(); // execute the command
            //for (int i = 0; i < material.Hobbies.Length; i++)
            //{
            //    String cStrInsertHobbies = BuildInsertHobbiesForUsersCommand(Id, person.Hobbies[i]);
            //    cmd1 = CreateCommand(cStrInsertHobbies, con);
            //    int numEffected1 = cmd1.ExecuteNonQuery();
            //}
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            throw (ex);       // write to log
        }
        finally
        {
            if (con != null)
            {
                con.Close();        // close the db connection
            }
        }
    }





    // need to update the buildupdate command
    private string BuildUpdateCommand(Constants constants)
    {
        //String command;
        //StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        string prefix = "UPDATE constantParametersCostTbl SET boxWorkCost = '" + constants.Cost + "', cost = '" + constants.Cost/* + " WHERE id=" + id*/;//מעדכנים את כל הטבלה 
        //command = prefix + "SELECT CAST(scope_identity() AS int)";
         return prefix;
    }
}
