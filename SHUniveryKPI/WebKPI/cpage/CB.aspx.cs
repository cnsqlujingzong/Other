using SHUniversity.KPI;
using SHUniversity.KPI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
/// 著作出版
/// </summary>
public partial class cpage_cb : System.Web.UI.Page
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

                        txtProjectName.Text=m.ProjectName;//著作名
                        ddl_ptype.SelectedValue = m.ProjectType;//著作类别       
                        txtChubanshe.Text=m.ProjectNO;//出版社
         
                 ddl_cbtype.SelectedValue=m.ItemNO;//出版社类别
                ddl_zishu.SelectedValue=m.Str1;//著作字数
                ddl_isdl.SelectedValue=m.Str2;//是否独立作者
             


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

                m.ProjectName = txtProjectName.Text.Trim();//著作名
                m.ProjectType = ddl_ptype.SelectedValue;//著作类别       
                m.ProjectNO = txtChubanshe.Text.Trim();//出版社
                m.ItemNO = ddl_cbtype.SelectedValue;//出版社类别
                m.Str1 = ddl_zishu.SelectedValue.Trim();//著作字数

                m.Str2 = ddl_isdl.SelectedValue;//是否独立作者
                if (m.Str2 == "否")
                {
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
                    if (decimal.Parse(lv) >= 1 || decimal.Parse(lv) <= 0)
                    {
                        Jscript.Alert("请正确输入贡献比例，范围0~1");
                        return;
                    }
                    m.float1 = decimal.Parse(lv);
                }
                else if (m.Str2 == "是")
                {
                    m.float1 = 1;
                }

                //基本教分
                if (m.ProjectType == "专著") { m.float2 = 300; }
                if (m.ProjectType == "编著") { m.float2 = 200; }
                if (m.ProjectType == "教材") { m.float2 = 100; }
                if (m.ProjectType == "译著") { m.float2 = 100; }
                //出版权重
                if (m.ItemNO == "省部级和高校出版社") { m.float3 = 1; }
                if (m.ItemNO == "国家出版社") { m.float3 = 1.5M; }
                if (m.ItemNO == "科学出版社") { m.float3 = 2M; }
                //字数权重
                if (m.Str1 == "L15") { m.float4 = 0.8M; }
                if (m.Str1 == "15T25") { m.float4 = 1; }
                if (m.Str1 == "25P") { m.float4 = 1.2M; }



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
            m.ItemType = "著作出版";
            m.ItemCreator = currUser.WorkID;
            m.ItemDate = DateTime.Now;
            //何年月至何年月
            m.Int1 = int.Parse(ddl_pstartyear.SelectedValue);//开始年
            m.Int2 = int.Parse(ddl_pstartmonth.SelectedValue);//开始月

            m.ProjectName = txtProjectName.Text.Trim();//著作名
            m.ProjectType = ddl_ptype.SelectedValue;//著作类别       
            m.ProjectNO = txtChubanshe.Text.Trim();//出版社
            m.ItemNO = ddl_cbtype.SelectedValue;//出版社类别
            m.Str1 = ddl_zishu.SelectedValue.Trim();//著作字数

            m.Str2 = ddl_isdl.SelectedValue;//是否独立作者
            if (m.Str2 == "否")
            {
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
                if (decimal.Parse(lv) >= 1 || decimal.Parse(lv) <= 0)
                {
                    Jscript.Alert("请正确输入贡献比例，范围0~1");
                    return;
                }
                m.float1 = decimal.Parse(lv);
            }
            else if (m.Str2 == "是")
            {
                m.float1 = 1;
            }

            //基本教分
            if (m.ProjectType == "专著") { m.float2 = 300; }
            if (m.ProjectType == "编著") { m.float2 = 200; }
            if (m.ProjectType == "教材") { m.float2 = 100; }
            if (m.ProjectType == "译著") { m.float2 = 100; }
            //出版权重
            if (m.ItemNO == "省部级和高校出版社") { m.float3 = 1; }
            if (m.ItemNO == "国家出版社") { m.float3 = 1.5M; }
            if (m.ItemNO == "科学出版社") { m.float3 = 2M; }
            //字数权重
            if (m.Str1 == "L15") { m.float4 = 0.8M; }
            if (m.Str1 == "15T25") { m.float4 = 1; }
            if (m.Str1 == "25P") { m.float4 = 1.2M; }



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