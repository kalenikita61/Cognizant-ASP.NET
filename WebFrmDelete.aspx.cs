using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApDemo2
{
    public partial class WebFrmDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int idn = Convert.ToInt32(TextBox1.Text);
            DataLayer2 dl = new DataLayer2();
            salaryinfo dr = new salaryinfo { id = idn };

            string msg = dl.deletem(dr);
        }
    }
}