using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SHUniversity.KPI;
/// <summary>
/// 学科竞赛
/// </summary>
public partial class cpage_XKJS : System.Web.UI.Page
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
                        ddl_ptype.SelectedValue = m.ProjectType;//项目类型

                        //个人质量得分
                        txtTGetScore.Text=Math.Round(m.float2.Value,2).ToString();
                        //是否全国挑战杯
                         rb_istzb.SelectedValue=m.Str4 ;
                        //挑战杯获奖
                         rb_tzb_jl.SelectedValue = m.Str5;     

                        txtZQ.Text = m.Str1;//项目周期
                        txtStuNum.Text = m.Int5.ToString();//学生数量
                        rb_status.SelectedValue = m.Str2.ToString();//项目质量
                        txtStuYuanXi.Text = m.Str3;//学生院系
                        txtStuNames.Text = m.text1;//学生姓名
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
                  m.Str2 = rb_status.SelectedValue;//获奖情况
                  //项目类型与得奖情况 =项目总教分
                  if (m.ProjectType == "校级奖励")
                  {
                      if (m.Str2 == "一等奖")
                      {
                          m.float1 = 3M;
                      }
                      if (m.Str2 == "二等奖")
                      {
                          m.float1 = 2M;
                      }
                      if (m.Str2 == "三等奖")
                      {
                          m.float1 = 1M;
                      }
                  
                  }
                  if (m.ProjectType == "市级奖励")
                  {
                      if (m.Str2 == "一等奖")
                      {
                          m.float1 = 6M;
                      }
                      if (m.Str2 == "二等奖")
                      {
                          m.float1 = 4M;
                      }
                      if (m.Str2 == "三等奖")
                      {
                          m.float1 = 2M;
                      }
                  }
                  if (m.ProjectType == "国际组织奖励")
                  {
                      if (m.Str2 == "一等奖")
                      {
                          m.float1 = 10M;
                      }
                      if (m.Str2 == "二等奖")
                      {
                          m.float1 = 6M;
                      }
                      if (m.Str2 == "三等奖")
                      {
                          m.float1 = 4M;
                      }
                  }
                  if (m.ProjectType == "国家级奖励")
                  {
                      if (m.Str2 == "一等奖")
                      {
                          m.float1 = 15M;
                      }
                      if (m.Str2 == "二等奖")
                      {
                          m.float1 = 10M;
                      }
                      if (m.Str2 == "三等奖")
                      {
                          m.float1 = 6M;
                      }
                  }
                  if (string.IsNullOrEmpty(txtTGetScore.Text.Trim()))
                  {
                      Jscript.Alert("请输入工作量比例");
                      return;
                  }
                  //个人质量得分
                  m.float2 = Common.StrToDecimal(txtTGetScore.Text.Trim(), 0);
                  if (m.float2 > 1 || m.float2 <= 0)
                  {
                      Jscript.Alert("工作量比例必须为0~1之间");
                      return;
                  }
                  //是否全国挑战杯
                  m.Str4 = rb_istzb.SelectedValue;             
                  if (m.Str4 == "是")//挑战杯分数
                  {
                      m.Str5 = rb_tzb_jl.SelectedValue;
                      if (m.Str5 == "特等奖")
                      {
                          m.float3 = 300;
                      }
                      if (m.Str5 == "一等奖")
                      {
                          m.float3 = 200;
                      }
                      if (m.Str5 == "二等奖")
                      {
                          m.float3 = 80;
                      } if (m.Str5 == "其他")
                      {
                          m.float3 = 0;
                      }

                  }

                  m.Str1 = txtZQ.Text.Trim();//项目周期
                  m.Int5 = int.Parse(txtStuNum.Text.Trim());//学生数量
                  m.Str3 = txtStuYuanXi.Text.Trim();//学生院系
                  m.text1 = txtStuNames.Text.Trim();//学生姓名
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
            m.ItemType = "学科竞赛";
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
            m.Str2 = rb_status.SelectedValue;//项目获奖
            //项目类型与得奖情况 =项目总教分
            if (m.ProjectType == "校级奖励")
            {
                if (m.Str2 == "一等奖")
                {
                    m.float1 = 3M;
                }
                if (m.Str2 == "二等奖")
                {
                    m.float1 = 2M;
                }
                if (m.Str2 == "三等奖")
                {
                    m.float1 = 1M;
                }

            }
            if (m.ProjectType == "市级奖励")
            {
                if (m.Str2 == "一等奖")
                {
                    m.float1 = 6M;
                }
                if (m.Str2 == "二等奖")
                {
                    m.float1 = 4M;
                }
                if (m.Str2 == "三等奖")
                {
                    m.float1 = 2M;
                }
            }
            if (m.ProjectType == "国际组织奖励")
            {
                if (m.Str2 == "一等奖")
                {
                    m.float1 = 10M;
                }
                if (m.Str2 == "二等奖")
                {
                    m.float1 = 6M;
                }
                if (m.Str2 == "三等奖")
                {
                    m.float1 = 4M;
                }
            }
            if (m.ProjectType == "国家级奖励")
            {
                if (m.Str2 == "一等奖")
                {
                    m.float1 = 15M;
                }
                if (m.Str2 == "二等奖")
                {
                    m.float1 = 10M;
                }
                if (m.Str2 == "三等奖")
                {
                    m.float1 = 6M;
                }
            }
            if (string.IsNullOrEmpty(txtTGetScore.Text.Trim()))
            {
                Jscript.Alert("请输入工作量比例");
                return;
            }
            //个人质量得分
            m.float2 = Common.StrToDecimal(txtTGetScore.Text.Trim(), 0);
            if (m.float2 > 1 || m.float2 <= 0)
            {
                Jscript.Alert("工作量比例必须为0~1之间");
                return;
            }
            //是否全国挑战杯
            m.Str4 = rb_istzb.SelectedValue;       
            if (m.Str4 == "是")//挑战杯分数
            {
                m.Str5 = rb_tzb_jl.SelectedValue;
                if( m.Str5=="特等奖")
                {
                    m.float3 = 300;
                }
                if (m.Str5 == "一等奖")
                {
                    m.float3 = 200;
                }
                if (m.Str5 == "二等奖")
                {
                    m.float3 = 80;
                } if (m.Str5 == "其他")
                {
                    m.float3 = 0;
                }
            
            }

            m.Str1 = txtZQ.Text.Trim();//项目周期
            m.Int5 = int.Parse(txtStuNum.Text.Trim());//学生数量    
            m.Str3 = txtStuYuanXi.Text.Trim();//学生院系
            m.text1 = txtStuNames.Text.Trim();//学生姓名
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