using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SITED.NEWS;
public partial class Master_News_Admin_NewsType : SITED.COMMON.PageBase
{
    public void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HL_NewType.NavigateUrl = "Admin_NewsType_Add.aspx?language=cn";
            FNEWS_TYPE news_type = new FNEWS_TYPE();
            RP_con.DataSource = news_type.GetDAL().GetList(" Lang='cn' ");
            RP_con.DataBind();
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //新分类
        if (DD_language.SelectedValue == "cn")
        {
            HL_NewType.NavigateUrl = "Admin_NewsType_Add.aspx?language=cn";
            FNEWS_TYPE news_type = new FNEWS_TYPE();
            RP_con.DataSource = news_type.GetDAL().GetList(" Lang='cn' ");
            RP_con.DataBind();
        }
        else
        {
            HL_NewType.NavigateUrl = "Admin_NewsType_Add.aspx?language=en";
            FNEWS_TYPE news_type = new FNEWS_TYPE();
            RP_con.DataSource = news_type.GetDAL().GetList(" Lang='en' ");
            RP_con.DataBind();
        }
    }
    /// <summary>
    /// 删除所选项
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void LinkButton1_Click(object sender, EventArgs e)
    {
        FNEWS_TYPE news_type = new FNEWS_TYPE();
        string sb = string.Empty;
        for (int i = 0; i < this.RP_con.Items.Count; i++)
        {
            CheckBox cb = (RP_con.Items[i].FindControl("CheckBox1_")) as CheckBox;
            if (cb.Checked == true)
            {
                string id = ((RP_con.Items[i].FindControl("HiddenField_")) as HiddenField).Value;                
                    sb += id + ",";                
            }
        }
        news_type.GetDAL().DeleteMuli(sb);
        Jscript.RedirectToFrames("Admin_NewsType.aspx");
    }
    protected string GetPubICO(string flag)
    {
        if (flag == "1")
        {
            return "../resources/img/yes.gif";
        }
        else
        {
            return "../resources/img/no.gif";
        }
    }
}