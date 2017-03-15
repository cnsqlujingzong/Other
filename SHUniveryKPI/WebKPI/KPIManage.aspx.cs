using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SHUniversity.KPI;
public partial class KPIManage : System.Web.UI.Page
{

    /********
     * 
     * 项目类型
     * 大学生创新实验项目
     * 
     * 
     ******/
    SHUniversity.KPI.BLL.KPIItems bll = new SHUniversity.KPI.BLL.KPIItems();
    SHUniversity.KPI.BLL.UserKPI kpibll = new SHUniversity.KPI.BLL.UserKPI();
     public int Tid;
    protected void Page_Load(object sender, EventArgs e)
    {
        SHUniversity.KPI.Model.Users currUser = new SHUniversity.KPI.Model.Users();
        if (Session["SHUUser"] == null)
        {
            Jscript.AlertAndRedirect("未登录或登录超时，请重新登录", "/Login.aspx");
            Response.End();
        }
        else
        {
            currUser = Session["SHUUser"] as SHUniversity.KPI.Model.Users;
        }
        Tid =Common.StrToInt(Request.QueryString["id"],-1);    
        if (Tid<0)
        {
            Jscript.AlertAndRedirect("无法找到考核表信息", "../Home.aspx");
            return;
        }
        if (!kpibll.Exists(Tid, currUser.WorkID))
        {
            Jscript.AlertAndRedirect("考核表与用户信息不匹配", "../Home.aspx");
            return;
        }             
        List<SHUniversity.KPI.Model.KPIItems> list = bll.GetModelList(" KPINO= " + Tid + " and ItemCreator='" + currUser.WorkID + "'");
        if (list.Count > 0)
        {
     
            rp_cxsy.DataSource = list.Where(m => m.ItemType == "大学生创新实验项目").ToList();
            rp_cxsy.DataBind();

            rp_xkjs.DataSource = list.Where(m => m.ItemType == "学科竞赛").ToList();
            rp_xkjs.DataBind();

            rp_dsz.DataSource = list.Where(m => m.ItemType == "导师制").ToList();
            rp_dsz.DataBind();

            rp_jxgg.DataSource = list.Where(m => m.ItemType == "教学改革").ToList();
            rp_jxgg.DataBind();
       
            rp_jxhj.DataSource = list.Where(m => m.ItemType == "教学获奖").ToList();
            rp_jxhj.DataBind();
           
            rp_jxlw.DataSource = list.Where(m => m.ItemType == "教学论文").ToList();
            rp_jxlw.DataBind();
    
            rp_KYXM.DataSource = list.Where(m => m.ItemType == "科研项目").ToList();
            rp_KYXM.DataBind();

            rp_KYLW.DataSource = list.Where(m => m.ItemType == "科研论文").ToList();
            rp_KYLW.DataBind();

            rp_KYCB.DataSource = list.Where(m => m.ItemType == "著作出版").ToList();//科技奖励
            rp_KYCB.DataBind();

            rp_KJJL.DataSource = list.Where(m => m.ItemType == "科技奖励").ToList();//
            rp_KJJL.DataBind();

            rp_KL.DataSource = list.Where(m => m.ItemType == "专利").ToList();
            rp_KL.DataBind();
        }
        

    }
}