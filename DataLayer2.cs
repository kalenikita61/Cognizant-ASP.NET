using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace WebApDemo2
{
    public class DataLayer2
    {
        string conString = "";
        public DataLayer2()
        {
            conString = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        }
        public string insert(salaryinfo pr)
        {
            string insertquery = string.Format("insert into employee2(id,name,department,salary,designation)values({0},'{1}','{2}',{3},'{4}')",
            pr.id, pr.name, pr.department, pr.salary, pr.designation);

            DataSet ds = new DataSet();
            int i = 0;
            string msg = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    SqlCommand cmd = new SqlCommand(insertquery, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    i = da.Fill(ds);
                    da.Update(ds);
                }
            }
            catch (Exception ex)
            {

            }
            if (i > 0)
            {
                msg = string.Format("one row inserted");
            }
            return msg;
        }
        public string updated(salaryinfo pr)
        {
            string msg = "";
            int i = 0;

            // string updatequery = string.Format("update employee2 set name ={0},department={1},salary = {2} designation={3} where id={4}", pr.name, pr.department,pr.salary, pr.designation, pr.id);
            string updatequery = "update employee2 set name='"+pr.name+"' where id='"+pr.id+"'";
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    SqlCommand cmd = new SqlCommand(updatequery, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                   da.Fill(ds);
                    da.Update(ds);
                }
            }
            catch (Exception ex)
            {

            }
            if (i > 0)
            {
                msg = string.Format("one row inserted");
            }
            return msg;
        }
        public string deletem(salaryinfo pr)
        {
           
            int i = 0;
            string msg = "";
            //int id = 
            string deletequery = string.Format("delete from employee2 where id={0}",pr.id);
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    SqlCommand cmd = new SqlCommand(deletequery, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    da.Update(ds);
                }
            }
            catch (Exception ex)
            {

            }
           
            if (i > 0)
            {
                msg = string.Format("row Deleted");
            }
            return msg;
        }

        public DataSet showdata()
        {
            string selectquery = "select * from employee2";
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    SqlCommand cmd = new SqlCommand(selectquery, con);
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    ada.Fill(ds);
                    ada.Update(ds);

                }
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            return ds;
        }
    }
}