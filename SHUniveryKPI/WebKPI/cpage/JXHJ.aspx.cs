using SHUniversity.KPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
/// 教学获奖
/// </summary>
public partial class cpage_JXHJ : System.Web.UI.Page
{

    SHUniversity.KPI.BLL.KPIItems bll = new SHUniversity.KPI.BLL.KPIItems();
    SHUniversity.KPI.BLL.UserKPI kpibll = new SHUniversity.KPI.BLL.UserKPI();
    SHUniversity.KPI.Model.Users currUser;
    int TableID;//考核表ID
    string op;//操作

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SHUUser"] == null)
        {
            Jscript.AlertAndRedirect("未登录或登录超时，请重新登录", "/Login.aspx");
            Response.End();
        }
        else
        {
            currUser = Session["SHUUser"] as SHUniversity.KPI.Model.Users;
            string id = Request.QueryString["id"];
            TableID = Common.StrToInt(id, -1);
            if (TableID < 0)
            {
                Jscript.AlertAndRedirect("无法找到考核表信息", "../Home.aspx");
                return;
            }
            if (!kpibll.Exists(TableID, currUser.WorkID))
            {
                Jscript.AlertAndRedirect("考核表与用户信息不匹配", "../Home.aspx");
                return;
            }
            if (!kpibll.isEdit(TableID))
            {
                Jscript.AlertAndRedirect("考核表只有在未提交和驳回的时候才可以修改", "../Home.aspx");
                return;
            }
            if (!IsPostBack)
            {
                op = Request.QueryString["op"];
                string cid = Request.QueryString["cxsyid"];
                //根据操作参数判断是新增、删除、编辑          
                int cxsyid;//itemID
                int.TryParse(cid, out cxsyid);
                if (op == "edit")//编辑----初始赋值
                {
                    SHUniversity.KPI.Model.KPIItems m = bll.GetModel(cxsyid, currUser.WorkID);
                    if (m != null)
                    {
                        hid_cid.Value = cxsyid.ToString();
                        //何年月至何年月
                        ddl_pstartyear.SelectedValue = m.Int1.ToString();//开始年
                        ddl_pstartmonth.SelectedValue = m.Int2.ToString();//开始月                    
                        txtProjectName.Text = m.ProjectName;//项目名称
                        ddl_ptype.SelectedValue = m.ProjectType;//项目类型       
                        ddl_xj_level.SelectedValue = m.Str5;//校级奖励 奖项
         
                    }
                }
                if (op == "del")//删除
                {
                    bool r = bll.Delete(cxsyid, currUser.WorkID);
                    if (r)
                    {
                        Jscript.AlertAndRedirect("删除成功！", "/KPIManage.aspx?id=" + id);
                    }
                    else
                    {
                        Jscript.AlertAndRedirect("删除失败，请稍后再试", "/KPIManage.aspx?id=" + id);
                    }
                }
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        op = Request.QueryString["op"];
        if (op == "edit")
        {
            int itemID = Common.StrToInt(hid_cid.Value, 0);
            SHUniversity.KPI.Model.KPIItems m = bll.GetModel(itemID, currUser.WorkID);
            if (m != null)
            {
                m.ItemLastUpdateDate = DateTime.Now;
                m.ItemUpdateUser = currUser.WorkID;
                //何年月至何年月
                m.Int1 = int.Parse(ddl_pstartyear.SelectedValue);//开始年
                m.Int2 = int.Parse(ddl_pstartmonth.SelectedValue);//开始月

                m.Int3 = 1;//计算参与人数         

          
                m.ProjectName = txtProjectName.Text.Trim();//项目名称
                m.ProjectType = ddl_ptype.SelectedValue;//项目类型       
                m.Str5 = ddl_xj_level.SelectedValue;//校级奖励的级别
               
           
                //项目级别
                if (m.ProjectType == "校级获奖")
                {
                   if(m.Str5=="特等奖")
                   {
                        m.float1 = 50;//获奖总教分
                   }
                       if(m.Str5=="一等奖")
                   {
                        m.float1 = 40;//获奖总教分
                   }
                       if(m.Str5=="二等奖")
                   {
                        m.float1 = 30;//获奖总教分
                   }
                       if(m.Str5=="三等奖")
                   {
                        m.float1 = 20;//获奖总教分
                   }                          

                }
                else
                {      
                    //TODO 相应等级科研获奖教分
                    if (m.ProjectType == "全国优秀教学成果奖")
                    {
                        m.float1 = 0.5M*1;
                    }
                    if (m.ProjectType == "全国优秀教材奖")
                    {
                        m.float1 = 0.5M * 1;
                    }
                    if (m.ProjectType == "省部委级优秀教学成果奖")
                    {
                        m.float1 = 0.5M * 1;
                    }
                    if (m.ProjectType == "省部委级优秀教材奖")
                    {
                        m.float1 = 0.5M * 1;
                    }           

                }

                m.Int3 = int.Parse(ddl_qty.SelectedValue);

                bool r = bll.Update(m, currUser.WorkID);
                if (r)
                {
                    Jscript.AlertAndRedirect("修改成功", "/KPIManage.aspx?id=" + TableID);
                }
                else
                {
                    Jscript.Alert("修改失败，请稍后再试");
                }
            }

        }
        else
        {
            SHUniversity.KPI.Model.KPIItems m = new SHUniversity.KPI.Model.KPIItems();
            //添加一个创新实验项目
            m.KPINO = TableID;
            m.ItemType = "教学获奖";
            m.ItemCreator = currUser.WorkID;
            m.ItemDate = DateTime.Now;
            //何年月至何年月
            m.Int1 = int.Parse(ddl_pstartyear.SelectedValue);//开始年
            m.Int2 = int.Parse(ddl_pstartmonth.SelectedValue);//开始月

            m.Int3 = 1;//计算参与人数         


            m.ProjectName = txtProjectName.Text.Trim();//项目名称
            m.ProjectType = ddl_ptype.SelectedValue;//项目类型       
            m.Str5 = ddl_xj_level.SelectedValue;//校级奖励的级别


            //项目级别
            if (m.ProjectType == "校级获奖")
            {
                if (m.Str5 == "特等奖")
                {
                    m.float1 = 50;//获奖总教分
                }
                if (m.Str5 == "一等奖")
                {
                    m.float1 = 40;//获奖总教分
                }
                if (m.Str5 == "二等奖")
                {
                    m.float1 = 30;//获奖总教分
                }
                if (m.Str5 == "三等奖")
                {
                    m.float1 = 20;//获奖总教分
                }

            }
            else
            {
                //TODO 相应等级科研获奖教分
                if (m.ProjectType == "全国优秀教学成果奖")
                {
                    m.float1 = 0.5M * 1;
                }
                if (m.ProjectType == "全国优秀教材奖")
                {
                    m.float1 = 0.5M * 1;
                }
                if (m.ProjectType == "省部委级优秀教学成果奖")
                {
                    m.float1 = 0.5M * 1;
                }
                if (m.ProjectType == "省部委级优秀教材奖")
                {
                    m.float1 = 0.5M * 1;
                }

            }

            m.Int3=int.Parse(ddl_qty.SelectedValue);


            int i = bll.Add(m);
            if (i > 0)
            {
                Jscript.AlertAndRedirect("添加成功", "/KPIManage.aspx?id=" + TableID);
            }
            else
            {
                Jscript.Alert("添加失败，请稍后再试");
            }
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/KPIManage.aspx?id=" + TableID);
    }

    protected void ddl_ptype_SelectedIndexChanged(object sender, EventArgs e)
    {
        string type = ddl_ptype.SelectedValue;
        if (type == "校级获奖")
        {
            ddl_xj_level.Visible = true;
        }
        else {
            ddl_xj_level.Visible = false;
        }
    }
}