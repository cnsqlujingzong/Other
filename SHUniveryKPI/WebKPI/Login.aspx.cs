using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using  SHUniversity.KPI;
public partial class Login : System.Web.UI.Page
{
    SHUniversity.KPI.BLL.Users userBll = new SHUniversity.KPI.BLL.Users();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Image1_ServerClick(object sender, ImageClickEventArgs e)
    {
        //userBll
        string loginName = this.TextBox1.Text.Trim();
        string password = this.TextBox2.Text.Trim();
        if (string.IsNullOrEmpty(loginName) || string.IsNullOrEmpty(password))
        {
            lb_msg.Text = "用户名/密码不能为空";
        }
        else
        {
            SHUniversity.KPI.Model.Users user = userBll.Login(loginName, password);
            if (user == null)
            {
                lb_msg.Text = "用户名/密码错误";
            }
            else
            {              
                //用户类型 99：管理员 0员工1管理 
                if (user.UserType == 99)
                {
                    Session["SHUAdmin"] = user;
                    Session["SHUUser"] = user;
                    Response.Redirect("~/admin/main.aspx");
                }
                if (user.UserType == 0)
                {
                    Session["SHUUser"] = user;
                    Response.Redirect("~/Home.aspx");
                }
                if (user.UserType == 1)
                {
                    Session["SHUManage"] = user;
                    Session["SHUUser"] = user;
                    Response.Redirect("~/Manager.aspx");
                }
                else
                {
                    Jscript.AlertAndRedirect("用户信息错误", "/Login.aspx");
                }


            }
        }
    }
    
}