using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SHUniversity.KPI;
/// <summary>
/// 导师制
/// </summary>
public partial class cpage_DSZ : System.Web.UI.Page
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
            //TODO:验证该考核表是否属于这个用户
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
                        ddl_pendyear.SelectedValue = m.Int3.ToString();//End年
                        ddl_pendmonth.SelectedValue = m.Int4.ToString();//End月

                        txtProjectNO.Text = m.ProjectNO;//项目编号
                        txtProjectName.Text = m.ProjectName;//项目名称
                        ddl_ptype.SelectedValue = m.ProjectType;//导师类型

                        rb_num.SelectedValue=m.Int5.ToString();//学年指导最大数量
                        //指导质量
                        rb_zl.SelectedValue=m.Str4;
                      txtZQ.Text=  m.Str1 ;//项目周期
                        txtStuNum.Text=Convert.ToInt32(m.float2).ToString() ;//学生数量
                        txtStuYuanXi.Text=m.Str3.ToString();//学生院系

                       
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
              int itemID=Common.StrToInt(hid_cid.Value,0);
              SHUniversity.KPI.Model.KPIItems m = bll.GetModel(itemID, currUser.WorkID);
              if (m != null)
              {
                  m.ItemLastUpdateDate = DateTime.Now;
                  m.ItemUpdateUser = currUser.WorkID;                  
                  //何年月至何年月
                  m.Int1 = int.Parse(ddl_pstartyear.SelectedValue);//开始年
                  m.Int2 = int.Parse(ddl_pstartmonth.SelectedValue);//开始月
                  m.Int3 = int.Parse(ddl_pendyear.SelectedValue);//End年
                  m.Int4 = int.Parse(ddl_pendmonth.SelectedValue);//End月

                  m.ProjectNO = txtProjectNO.Text.Trim();//项目编号
                  m.ProjectName = txtProjectName.Text.Trim();//项目名称

                  m.ProjectType = ddl_ptype.SelectedValue;//导师类型                  
                  //导师类型教分基数 每个学期
                  if (m.ProjectType == "本科班导师")
                  {                    
                     m.float1 = 3;  
                  }
                  if (m.ProjectType == "励志导师")
                  {
                      m.float1 = 1;  
                  }
                  if (m.ProjectType == "学术导师")
                  {
                      m.float1 = 1;  
                  }
                  m.Int5 =int.Parse(rb_num.SelectedValue);//学年指导最大数量
                  //指导质量
                  m.Str4 = rb_zl.SelectedValue;
                  //指导质量K4
                  if (m.Str4 == "院优")
                  {
                      m.float3 = 1.2M;
                  }
                  if (m.Str4 == "校优")
                  {
                      m.float3 = 1.5M;
                  }
                  if (m.Str4 == "合格")
                  {
                      m.float3 = 1;
                  }
                  if (m.Str4 == "不合格")
                  {
                      m.float3 = 0;
                  }   

                  m.Str1 = txtZQ.Text.Trim();//项目周期
                  m.float2 = decimal.Parse(txtStuNum.Text.Trim());//学生数量
                  m.Str3 = txtStuYuanXi.Text.Trim();//学生院系

                  bool r = bll.Update(m, currUser.WorkID);
                  if (r)
                  {
                      Jscript.AlertAndRedirect("修改成功", "/KPIManage.aspx?id=" + TableID);
                  }
                  else {
                      Jscript.Alert("修改失败，请稍后再试");
                  }
              }
           
        }
        else
        {
            SHUniversity.KPI.Model.KPIItems m = new SHUniversity.KPI.Model.KPIItems();

            m.KPINO = TableID;
            m.ItemType = "导师制";
            m.ItemCreator = currUser.WorkID;
            m.ItemDate = DateTime.Now;
            //何年月至何年月
            m.Int1 = int.Parse(ddl_pstartyear.SelectedValue);//开始年
            m.Int2 = int.Parse(ddl_pstartmonth.SelectedValue);//开始月
            m.Int3 = int.Parse(ddl_pendyear.SelectedValue);//End年
            m.Int4 = int.Parse(ddl_pendmonth.SelectedValue);//End月

            m.ProjectNO = txtProjectNO.Text.Trim();//项目编号
            m.ProjectName = txtProjectName.Text.Trim();//项目名称

            m.ProjectType = ddl_ptype.SelectedValue;//导师类型                  
            //导师类型教分基数 每个学期
            if (m.ProjectType == "本科班导师")
            {
                m.float1 = 3;
            }
            if (m.ProjectType == "励志导师")
            {
                m.float1 = 1;
            }
            if (m.ProjectType == "学术导师")
            {
                m.float1 = 1;
            }
            m.Int5 = int.Parse(rb_num.SelectedValue);//学年指导最大数量
            //指导质量
            m.Str4 = rb_zl.SelectedValue;
            //指导质量K4
            if (m.Str4 == "院优")
            {
                m.float3 = 1.2M;
            }
            if (m.Str4 == "校优")
            {
                m.float3 = 1.5M;
            }
            if (m.Str4 == "合格")
            {
                m.float3 = 1;
            }
            if (m.Str4 == "不合格")
            {
                m.float3 = 0;
            }   

            m.Str1 = txtZQ.Text.Trim();//项目周期
            m.float2 = decimal.Parse(txtStuNum.Text.Trim());//学生数量
            m.Str3 = txtStuYuanXi.Text.Trim();//学生院系
            int i = bll.Add(m);
            if (i > 0)
            {
                Jscript.AlertAndRedirect("添加成功", "/KPIManage.aspx?id=" + TableID);
            }
            else {
                Jscript.Alert("添加失败，请稍后再试");
            }
        }
        
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/KPIManage.aspx?id=" + TableID);
    }
}