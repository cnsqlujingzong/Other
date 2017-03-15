using SHUniversity.KPI;
using SHUniversity.KPI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
/// 科研论文
/// </summary>
public partial class cpage_zl : System.Web.UI.Page
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

                      txtProjectName.Text=m.ProjectName;//专利名
                  txtChubanshe.Text=m.ProjectNO;//专利编号
                  ddl_cbtype.SelectedItem.Text=m.ItemNO ;//专利类型
                  ddl_ptype.SelectedItem.Text=m.ProjectType;//专利国家

                  ddl_isdl.SelectedValue= m.Int3.ToString();//排位
                        txt_lv.Text=    m.float1.ToString(); //权重

                 //  m.float2=decimal.Parse( ddl_cbtype.SelectedValue);//奖励类型 国家 /部  系数
                 //  m.float3 = decimal.Parse( ddl_ptype.SelectedValue);//奖项 1~4等奖     分数


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

                m.ProjectName = txtProjectName.Text.Trim();//专利名称
                m.ProjectNO = txtChubanshe.Text.Trim();//授权编号
                m.ItemNO = ddl_cbtype.SelectedItem.Text;//专利类型
                m.ProjectType = ddl_ptype.SelectedItem.Text;//专利国别

                m.Int3 = int.Parse(ddl_isdl.SelectedValue);//排位

                string lv = txt_lv.Text.Trim();
                if (string.IsNullOrEmpty(lv))
                {
                    Jscript.Alert("请输入贡献比例");
                    return;
                }
                if (!PageValidate.IsDecimal(lv))
                {
                    Jscript.Alert("请正确输入贡献比例，范围0~1");
                    return;
                }
                if (decimal.Parse(lv) > 1 || decimal.Parse(lv) <= 0)
                {
                    Jscript.Alert("请正确输入贡献比例，范围0~1");
                    return;
                }
                m.float1 = decimal.Parse(lv);//权重

                m.float2 = decimal.Parse(ddl_cbtype.SelectedValue);//专利基本分
                m.float3 = decimal.Parse(ddl_ptype.SelectedValue);//专利国别


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
                m.KPINO = TableID;
                m.ItemType = "专利";
                m.ItemCreator = currUser.WorkID;
                m.ItemDate = DateTime.Now;
                //何年月至何年月
                m.Int1 = int.Parse(ddl_pstartyear.SelectedValue);//开始年
                m.Int2 = int.Parse(ddl_pstartmonth.SelectedValue);//开始月

                m.ProjectName = txtProjectName.Text.Trim();//住哪里名
                m.ProjectNO = txtChubanshe.Text.Trim();//专利编号
                m.ItemNO = ddl_cbtype.SelectedItem.Text;//专利类型
                m.ProjectType = ddl_ptype.SelectedItem.Text;//专利国家

                m.Int3 = int.Parse(ddl_isdl.SelectedValue);//排位

                string lv = txt_lv.Text.Trim();
                if (string.IsNullOrEmpty(lv))
                {
                    Jscript.Alert("请输入贡献比例");
                    return;
                }
                if (!PageValidate.IsDecimal(lv))
                {
                    Jscript.Alert("请正确输入贡献比例，范围0~1");
                    return;
                }
                if (decimal.Parse(lv) > 1 || decimal.Parse(lv) <= 0)
                {
                    Jscript.Alert("请正确输入贡献比例，范围0~1");
                    return;
                }
                m.float1 = decimal.Parse(lv);//权重

                m.float2 = decimal.Parse(ddl_cbtype.SelectedValue);//专利积分
                m.float3 = decimal.Parse(ddl_ptype.SelectedValue);//专利国家


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

 
}