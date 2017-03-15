using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    SHUniversity.KPI.BLL.UserKPI kpiBll = new SHUniversity.KPI.BLL.UserKPI();
    SHUniversity.KPI.Model.Users u;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SHUUser"] == null)
        {
            Jscript.AlertAndRedirect("未登录或登录超时，请重新登录","/Login.aspx");
            Response.End();
        }  
        u = (SHUniversity.KPI.Model.Users)Session["SHUUser"];
        if (!IsPostBack)
        {
         
            //lb_msg
            bool r = kpiBll.Exists(u.WorkID, DateTime.Now.Year);
            if (r)
            {
                lb_msg.Text = "已建表";
                lb_msg.ForeColor = System.Drawing.Color.Green;
                btn_CreatTable.Enabled = false;
            }
            else
            {
                lb_msg.Text = "未建表";
                lb_msg.ForeColor = System.Drawing.Color.Red;
                btn_CreatTable.Enabled = true;
            }

            rp_table.DataSource = kpiBll.GetList(" WorkID='" + u.WorkID + "'").Tables[0];
            rp_table.DataBind();
        }
        
    }
    protected void btn_CreatTable_Click(object sender, EventArgs e)
    {
        SHUniversity.KPI.Model.Users u = (SHUniversity.KPI.Model.Users)Session["SHUUser"];
        //lb_msg
        bool r = kpiBll.Exists(u.WorkID, DateTime.Now.Year);
        if (r)
        {
            Jscript.Alert("本年度已经创建了考核表，不能重复创建");
        }
        else
        {
            SHUniversity.KPI.Model.UserKPI kpi = new SHUniversity.KPI.Model.UserKPI();
            kpi.CreatDate = DateTime.Now;
            kpi.Creator = u.Name;
            kpi.KPINumber = SHUniversity.KPI.Common.CreatRandom();
            kpi.KPIYear = DateTime.Now.Year;
            kpi.Status = 0;//0未审核1正在审核2审核通过3退回
            kpi.WorkID = u.WorkID;
            int result= kpiBll.Add(kpi);
            if (result > 0)
            {
                Jscript.AlertAndRedirect("建表成功", "/Home.aspx");
            }
            else 
            { 
            
            }
        }
    }

    public string GetStatus(string z)
    {
        if (z == "0")
        {
            return "未提交";
        }
        if (z == "1")
        {
            return "正在审核";
        }
        if (z == "2")
        {
            return "审核通过";
        }
        if (z == "3")
        {
            return "退回";
        }
        else {
            return "";
        }
    }
    protected void rp_table_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        SHUniversity.KPI.Model.UserKPI kpi = kpiBll.GetModel(int.Parse(e.CommandArgument.ToString()));
        if (kpi.Status != 0)
        {
            Jscript.Alert("当前状态不可以提交");
            return;
        }

        if (e.CommandName == "apply")
        {
           bool r= kpiBll.ChangeStatus(e.CommandArgument.ToString(),1,u.Name,u.WorkID);
           if (r)
           {
               Jscript.Alert("提交成功");
           }
           else {
               Jscript.Alert("提交失败");
           }
        }
    }
}