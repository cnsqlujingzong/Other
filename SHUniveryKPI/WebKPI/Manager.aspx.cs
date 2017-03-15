using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager : System.Web.UI.Page
{
    string sql = "select u.id,k.ID as kid,u.WorkID,u.Name,k.KPINumber,k.KPIYear,k.[Status] from  users u  left join UserKPI k on u.WorkID=k.WorkID where u.UserType<>99 and (k.KPIYear='{0}' or k.KPIYear is null) and k.Status=1";
    SHUniversity.KPI.BLL.KPIItems itemBll = new SHUniversity.KPI.BLL.KPIItems();
    SHUniversity.KPI.BLL.UserKPI kpiBll = new SHUniversity.KPI.BLL.UserKPI();
    protected void Page_Load(object sender, EventArgs e)
    {     
        if (!IsPostBack)
        {
            int currYear = DateTime.Now.Year;
            ddl_year.SelectedValue = currYear.ToString();
            DataSet ds = DBUtility.DbHelperSQL.Query(string.Format(sql, currYear));
            rp_main.DataSource = ds;
            rp_main.DataBind();
        }
     
  }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string kw = tx_kw.Text.Trim();
        string year = ddl_year.SelectedValue;
        string searchSQL =  string.Format(sql, year);
        if (!string.IsNullOrEmpty(kw))
        {
            searchSQL = searchSQL + "  and (u.WorkID='%" + kw + "%' or u.Name='%" + kw + "%')";
        }
        DataSet ds = DBUtility.DbHelperSQL.Query(searchSQL);
        rp_main.DataSource = ds;
        rp_main.DataBind();
    }
    /// <summary>
    /// 是否有免考核项
    /// </summary>
    /// <returns></returns>
    public string GetTop(string kid)
    {
        if (string.IsNullOrEmpty(kid))
        {
            return "<span style=''>否</span>";
        }

        //免考核两个，1.顶级论文 2，科技奖励 
       List< SHUniversity.KPI.Model.KPIItems> lws= itemBll.GetModelList(" KPINO =" + kid + " and ItemType='科研论文' ");
       List<SHUniversity.KPI.Model.KPIItems> kys = itemBll.GetModelList(" KPINO =" + kid + " and ItemType='科技奖励' ");
       if (lws.Count > 0)
       {
           foreach (var item in lws)
           {
               if (item.float4 == 1)
               {
                   return "<span style='color:red'>是</span>";
               }
           }
       }
       if (kys.Count > 0)
       {
           foreach (var item in kys)
           {
             //  m.ItemNO = ddl_cbtype.SelectedItem.Text;//奖励类型 国家 /部
              // m.ProjectType = ddl_ptype.SelectedItem.Text;//奖项 1~4等奖
              // m.Int3 = int.Parse(ddl_isdl.SelectedValue);//排位
               if (item.ItemNO == "省部委级")
               {
                   if (item.ProjectType == "一等奖")
                   {
                       if (item.Int3 <= 2)
                       {
                           return "<span style='color:red'>是</span>";//省级奖励一等奖 排名前两位
                       }
                   }
                   if (item.ProjectType == "二等奖")
                   {
                       if (item.Int3 ==1)
                       {
                           return "<span style='color:red'>是</span>";//省级奖励二等奖 排名第一位
                       }
                   }
               }
               if (item.ItemNO == "国家级别")
               {
                   if (item.Int3<=5)
                   {
                       return "<span style='color:red'>是</span>";//国家家前五位
                   }
               }
           }
       }
       return "<span style=''>否</span>";    
    }

    /// <summary>
    /// 计算总分
    /// </summary>
    /// <param name="kid"></param>
    /// <returns></returns>
    public string GetScore(string kid)
    {

        List<SHUniversity.KPI.Model.KPIItems> kpis = itemBll.GetModelList(" KPINO =" + kid );
        decimal TotleScore = 0;
        if (kpis.Count > 0)
        {
            foreach (SHUniversity.KPI.Model.KPIItems item in kpis)
            {
             //大学生创新实验项目
                if (item.ItemType == "大学生创新实验项目")
                {
                    TotleScore += ( item.float1.Value * item.float2.Value);
                }
            //学科竞赛
                if (item.ItemType == "学科竞赛")
                {
                    if (item.Str4 == "是")
                    {
                        TotleScore += item.float3.Value;
                    }
                    else {
                        TotleScore += (item.float2.Value * item.float1.Value);
                    }
                }
            //导师制
                if (item.ItemType == "导师制")
                {
                    TotleScore += (item.float1.Value * 3 * item.float3.Value);              
                }
            //教学改革
                if (item.ItemType == "教学改革")
                {
                    TotleScore += (item.float1.Value * item.float2.Value * item.float3.Value*1.5M);                
                }
            //教学获奖
                if (item.ItemType == "教学获奖")
                {
                    if (item.ProjectType == "校级获奖")
                    {
                        TotleScore += (item.float1.Value/item.Int3.Value);//平均分配
                    }
                    else
                    {
                        TotleScore += (item.float1.Value * item.float3.Value * item.float4.Value * item.float2.Value);//平均分配     
                    }
              
                }
            //教学论文
                if (item.ItemType == "教学论文")
                {
                    TotleScore += item.float2.Value*1.5M; 
                }
            //科研项目
                if (item.ItemType == "科研项目")
                {
                    TotleScore += (item.float1.Value * item.float2.Value * item.float3.Value); 
                }

            //科研论文
                if (item.ItemType == "科研论文")
                {
                    TotleScore += item.float2.Value; 
                }
            //著作出版
                if (item.ItemType == "著作出版")
                {
                    TotleScore += (item.float1.Value * (item.float2.Value * (item.float3.Value + item.float4.Value)));     
                }
            //科技奖励
                if (item.ItemType == "科技奖励")
                {
                    TotleScore += (item.float2.Value * item.float3.Value * item.float1.Value);
                }
            //专利
                if (item.ItemType == "专利")
                {
                    TotleScore += (item.float1.Value * item.float2.Value * item.float3.Value);
                }
            }        
        
        
        }

        return TotleScore == 0 ? "0" : TotleScore.ToString(".00");
    }
    public string GetStatus(string type)
    {
        //0未提交1正在审核2审核通过3退回
        switch (type)
        { 
            case "0":
                return "未提交";
            case "1":
                return "正在审核";
            case "2":
                return "审核通过";
            case "3":
                return "退回";
            default:
                return "";
        }
    
    }
    
    protected void rp_main_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
       SHUniversity.KPI.Model.Users   currUser = Session["SHUUser"] as SHUniversity.KPI.Model.Users;
        string parma = e.CommandArgument.ToString();
        //0未提交1正在审核2审核通过3退回
        if (e.CommandName == "pass")
        {
          bool r=   kpiBll.ChangeStatus(parma,2, currUser.Name, currUser.WorkID);
          if (r)
          {
              Jscript.Alert("审核成功");
          }
          else {
              Jscript.Alert("审核失败，稍后再试");
          }
        }
        if (e.CommandName == "back")
        {
           bool r= kpiBll.ChangeStatus(parma,3, currUser.Name, currUser.WorkID);
            if (r)
            {
                Jscript.Alert("审核成功");
            }
            else
            {
                Jscript.Alert("审核失败，稍后再试");
            }
        }
    }
}