using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //for (int i = 0; i < 10; i++)
        //{
        //    Response.Write("<p>"+   SHUniversity.KPI.Common.CreatRandom()+"</p>");
        //}
        string s = "||";
        string[] ss=  s.Split('|');
         Response.Write("<p>"+ ss.Length+"</p>");
        foreach (string b in ss)
        {
            Label l = new Label();
            l.Text = b;
        }

    }
}