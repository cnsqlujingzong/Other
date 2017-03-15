using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using SITED.COMMON;
public partial class Master_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {   
        string cn=ConfigurationManager.AppSettings["companyName"];
        lb_companyName.Text =string.IsNullOrEmpty(cn)?"":cn;
        lb_companyName2.Text = string.IsNullOrEmpty(cn)?"":cn;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //  Session["SHUUser"] 
        string code;
        if (Session["CheckCode"] == null)
        {
            code = null;
        }
        else
        {
             code = Session["CheckCode"].ToString();
        }
        string user = txt_USERNAME.Text;
        string pass = txt_PASSWORD.Text;
        string rcode = TB_Code.Text;
        if (code!=null &&code == rcode.ToUpper())
        {
            SITED.COMMON.FUser fu = new FUser();
            SITED.COMMON.Model.USER u = fu.GetDAL().GetModel(" LoginName='" + user + "' and PassWord='" + pass + "'");
            if (u != null && u.LoginName != null && u.LoginName != "")
            {
                Session["admin"] = u;
                Session.Timeout = 15;
                Response.Redirect("main.aspx");
            }
            else
            {
               MessageBox.Show(this,"用户名或密码错误！");
            }
        }
        else
        {
            MessageBox.Show(this, "验证码错误！");
        }
    }
}