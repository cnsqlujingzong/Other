using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SHUniversity.KPI;
/// <summary>
/// 科研项目
/// </summary>
public partial class cpage_KYXM : System.Web.UI.Page
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


                        txtProjectNO.Text= m.ProjectNO ;//项目编号
                        txtProjectName.Text=m.ProjectName;//项目名称
                        ddl_ptype.SelectedValue=m.ProjectType ;//项目类型       

                        txtGJJF.Text=Math.Round( m.float1.Value,2).ToString();//实到经费

                        txt_self_lv.Text = Math.Round(m.float3.Value, 2).ToString();//本人贡献比例
                        txtJS1.Text = m.Str1;
                        txtJS2.Text = m.Str2;
                        txtJS3.Text = m.Str3;
                        txtJS4.Text = m.Str4;
              

                        txt_js1_lv.Text =m.float4==null?"": Math.Round(m.float4.Value, 2).ToString();
                        txt_js2_lv.Text = m.float5 == null ? "" : Math.Round(m.float5.Value, 2).ToString();
                        txt_js3_lv.Text = m.float6 == null ? "" : Math.Round(m.float6.Value, 2).ToString();
                        txt_js4_lv.Text = m.float7 == null ? "" : Math.Round(m.float7.Value, 2).ToString();



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
                  m.ProjectType = ddl_ptype.SelectedValue;//项目类型       
     
                  decimal money=Common.StrToDecimal(txtGJJF.Text.Trim(),0);
                  if(money<=0)
                  {
                   Jscript.Alert("实到经费必须大于0");
                      return;
                  }
                  m.float1 = money;//实到经费
                  //项目级别
                  if (m.ProjectType == "F")
                  {
                      if (money >= 800)
                      {
                          m.float2 = 5;//float2 F类 N 经费权重
                      }
                      if (500 <= money && money < 800)
                      {
                          m.float2 = 4.8M;
                      }
                      if (300 <= money && money < 500)
                      {
                          m.float2 = 4.6M;
                      }
                      if (200 <= money && money < 300)
                      {
                          m.float2 = 4.4M;
                      }
                      if (150 <= money && money < 200)
                      {
                          m.float2 = 4.2M;
                      }
                      if (100 <= money && money < 150)
                      {
                          m.float2 = 4M;
                      }
                      if (70 <= money && money < 100)
                      {
                          m.float2 = 3.6M;
                      }
                      if (50 <= money && money < 70)
                      {
                          m.float2 = 3M;
                      }
                      if (20 <= money && money < 50)
                      {
                          m.float2 = 2.4M;
                      }
                      if (money < 20)
                      {
                          m.float2 = 2M;
                      }

                  }
                  else {
                      if (m.ProjectType == "A")
                      {
                          m.float2 = 8;
                      }
                      if (m.ProjectType == "B")
                      {
                          m.float2 = 5;
                      }
                      if (m.ProjectType == "C")
                      {
                          m.float2 = 4;
                      }
                      if (m.ProjectType == "D")
                      {
                          m.float2 = 3;
                      }
                      if (m.ProjectType == "E")
                      {
                          m.float2 = 2;
                      }
                  
                  }
                  m.float3 = Common.StrToDecimal(txt_self_lv.Text.Trim(),0);//本人贡献比例
                  if (m.float3 <= 0 || m.float3 >= 1)
                  {
                      Jscript.Alert("本人贡献比例错误！数值范围0~1");
                  }
                  if (!string.IsNullOrEmpty(txtJS1.Text.Trim()))
                  {
                      m.Str1 = txtJS1.Text.Trim();
                      m.float4= Common.StrToDecimal(txt_js1_lv.Text.Trim(),0);//教师一 贡献比例
                      if (m.float4 <= 0 || m.float4>=1)
                      {
                          Jscript.Alert("教师1贡献比例错误！数值范围0~1");
                          return;
                      }
                  }
                  if (!string.IsNullOrEmpty(txtJS2.Text.Trim()))
                  {
                      m.Str2 = txtJS2.Text.Trim();
                      m.float5 = Common.StrToDecimal(txt_js2_lv.Text.Trim(), 0);//教师2 贡献比例
                      if (m.float5 <= 0 || m.float5 >= 1)
                      {
                          Jscript.Alert("教师2贡献比例错误！数值范围0~1");
                          return;
                      }
                  }

                  if (!string.IsNullOrEmpty(txtJS3.Text.Trim()))
                  {
                      m.Str3 = txtJS3.Text.Trim();
                      m.float6 = Common.StrToDecimal(txt_js3_lv.Text.Trim(), 0);//教师3 贡献比例
                      if (m.float6 <= 0 || m.float6 >= 1)
                      {
                          Jscript.Alert("教师3贡献比例错误！数值范围0~1");
                          return;
                      }
                  }
                  if (!string.IsNullOrEmpty(txtJS4.Text.Trim()))
                  {
                      m.Str4 = txtJS4.Text.Trim();
                      m.float7 = Common.StrToDecimal(txt_js4_lv.Text.Trim(), 0);//教师2 贡献比例
                      if (m.float7 <= 0 || m.float7 >= 1)
                      {
                          Jscript.Alert("教师4贡献比例错误！数值范围0~1");
                          return;
                      }
                  }
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
            //添加一个创新实验项目
            m.KPINO = TableID;
            m.ItemType = "科研项目";
            m.ItemCreator = currUser.WorkID;
            m.ItemDate = DateTime.Now;
            //何年月至何年月
            m.Int1 = int.Parse(ddl_pstartyear.SelectedValue);//开始年
            m.Int2 = int.Parse(ddl_pstartmonth.SelectedValue);//开始月
            m.Int3 = int.Parse(ddl_pendyear.SelectedValue);//End年
            m.Int4 = int.Parse(ddl_pendmonth.SelectedValue);//End月

            m.ProjectNO = txtProjectNO.Text.Trim();//项目编号
            m.ProjectName = txtProjectName.Text.Trim();//项目名称
            m.ProjectType = ddl_ptype.SelectedValue;//项目类型       

            decimal money = Common.StrToDecimal(txtGJJF.Text.Trim(), 0);
            if (money <= 0)
            {
                Jscript.Alert("实到经费必须大于0");
                return;
            }
            m.float1 = money;//实到经费
            //项目级别
            if (m.ProjectType == "F")
            {
                if (money >= 800)
                {
                    m.float2 = 5;//float2 F类 N 经费权重
                }
                if (500 <= money && money < 800)
                {
                    m.float2 = 4.8M;
                }
                if (300 <= money && money < 500)
                {
                    m.float2 = 4.6M;
                }
                if (200 <= money && money < 300)
                {
                    m.float2 = 4.4M;
                }
                if (150 <= money && money < 200)
                {
                    m.float2 = 4.2M;
                }
                if (100 <= money && money < 150)
                {
                    m.float2 = 4M;
                }
                if (70 <= money && money < 100)
                {
                    m.float2 = 3.6M;
                }
                if (50 <= money && money < 70)
                {
                    m.float2 = 3M;
                }
                if (20 <= money && money < 50)
                {
                    m.float2 = 2.4M;
                }
                if (money < 20)
                {
                    m.float2 = 2M;
                }

            }
            else
            {
                if (m.ProjectType == "A")
                {
                    m.float2 = 8;
                }
                if (m.ProjectType == "B")
                {
                    m.float2 = 5;
                }
                if (m.ProjectType == "C")
                {
                    m.float2 = 4;
                }
                if (m.ProjectType == "D")
                {
                    m.float2 = 3;
                }
                if (m.ProjectType == "E")
                {
                    m.float2 = 2;
                }

            }
            m.float3 = Common.StrToDecimal(txt_self_lv.Text.Trim(), 0);//本人贡献比例
            if (m.float3 <= 0 || m.float3 > 1)
            {
                Jscript.Alert("本人贡献比例错误！数值范围0~1");
            }
            if (!string.IsNullOrEmpty(txtJS1.Text.Trim()))
            {
                m.Str1 = txtJS1.Text.Trim();
                m.float4 = Common.StrToDecimal(txt_js1_lv.Text.Trim(), 0);//教师一 贡献比例
                if (m.float4 <= 0 || m.float4 > 1)
                {
                    Jscript.Alert("教师1贡献比例错误！数值范围0~1");
                    return;
                }
            }
            if (!string.IsNullOrEmpty(txtJS2.Text.Trim()))
            {
                m.Str2 = txtJS2.Text.Trim();
                m.float5 = Common.StrToDecimal(txt_js2_lv.Text.Trim(), 0);//教师2 贡献比例
                if (m.float5 <= 0 || m.float5 > 1)
                {
                    Jscript.Alert("教师2贡献比例错误！数值范围0~1");
                    return;
                }
            }

            if (!string.IsNullOrEmpty(txtJS3.Text.Trim()))
            {
                m.Str3 = txtJS3.Text.Trim();
                m.float6 = Common.StrToDecimal(txt_js3_lv.Text.Trim(), 0);//教师3 贡献比例
                if (m.float6 <= 0 || m.float6 > 1)
                {
                    Jscript.Alert("教师3贡献比例错误！数值范围0~1");
                    return;
                }
            }
            if (!string.IsNullOrEmpty(txtJS4.Text.Trim()))
            {
                m.Str4 = txtJS4.Text.Trim();
                m.float7 = Common.StrToDecimal(txt_js4_lv.Text.Trim(), 0);//教师2 贡献比例
                if (m.float7 <= 0 || m.float7 > 1)
                {
                    Jscript.Alert("教师4贡献比例错误！数值范围0~1");
                    return;
                }
            }

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