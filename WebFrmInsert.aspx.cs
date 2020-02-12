using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApDemo2
{
    public partial class WebFrmInsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                int idn = Convert.ToInt32(TextBox1.Text);
                string name = TextBox2.Text;
                string department = TextBox3.Text;
                int salary = Convert.ToInt32(TextBox4.Text);
                string designation = TextBox5.Text;
                salaryinfo dr = new salaryinfo { id = idn, name = name, department = department, salary = salary, designation = designation };
                DataLayer2 dl = new DataLayer2();
                string msg = dl.insert(dr);

                Response.Write("<script>alert('data inserted')</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataLayer2 d1 = new DataLayer2();
            var pdlst = d1.showdata();
            GridView1.DataSource = pdlst;

            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            
                int idn = Convert.ToInt32(TextBox1.Text);
                string name = TextBox2.Text;
                //string department = TextBox3.Text;
               // int salary = Convert.ToInt32(TextBox4.Text);
               // string designation = TextBox5.Text;
                salaryinfo dr = new salaryinfo { id = idn, name = name };
                DataLayer2 d1 = new DataLayer2();
                string msg = d1.updated(dr);
           
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            int idn = Convert.ToInt32(TextBox1.Text);
            DataLayer2 dl = new DataLayer2();
            salaryinfo dr = new salaryinfo { id = idn };

            string msg = dl.deletem(dr);
        }
    }
}