using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_UserManage : System.Web.UI.Page
{
    SHUniversity.KPI.BLL.Users ubll = new SHUniversity.KPI.BLL.Users();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RP_con.DataSource = ubll.GetList(" workid <>'admin'");
            RP_con.DataBind();
        }
    }
    /// <summary>
    /// 删除所选项
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LB_DelSelect_Click(object sender, EventArgs e)
    {

        string sb = string.Empty;
        for (int i = 0; i < this.RP_con.Items.Count; i++)
        {
            CheckBox cb = (RP_con.Items[i].FindControl("CheckBox1_")) as CheckBox;
            if (cb.Checked == true)
            {
                string dd = ((RP_con.Items[i].FindControl("HiddenField_")) as HiddenField).Value;
                sb += dd + ",";
            }
        }
        if (ubll.DeleteList(sb))
        {
            Jscript.RedirectToFrames("UserManage.aspx");
        }
        else {
            Jscript.Alert("删除失败，请重试！！");
        }
     
    }
    /// <summary>
    /// 图标选择
    /// </summary>
    /// <param name="flag"></param>
    /// <returns></returns>
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
    /// <summary>
    /// 状态
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddl_stat_SelectedIndexChanged(object sender, EventArgs e)
    {
        string s = ddl_stat.SelectedValue;
        if (s == "-1")
        {
            RP_con.DataSource = ubll.GetList(" workid <>'admin' ");
        }
        else 
        {
            RP_con.DataSource = ubll.GetList(" workid <>'admin' and UserType=" + s);
        }      
        RP_con.DataBind();
    }
    /// <summary>
    /// 模糊搜索
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        string s = txt_search.Text.Trim();
        RP_con.DataSource = ubll.GetList(" workid <>'admin' and (WorkID like '%" + s + "%' or Name like '%" + s + "%' or Zhiwu like '%" + s + "%' or Email like '%" + s + "%' or Moblie like '%" + s + "%')");
        RP_con.DataBind();
    }
}