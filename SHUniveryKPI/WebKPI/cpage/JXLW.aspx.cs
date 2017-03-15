using SHUniversity.KPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
/// 教学论文
/// </summary>
public partial class cpage_kylw : System.Web.UI.Page
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

                        txtProjectName.Text=m.ProjectName;//论文题目
                        ddl_ptype.SelectedValue = m.ProjectType;//期刊类别       
                        txtChubanshe.Text=m.ProjectNO;//杂志出版社
                        txtJuanqi.Text=m.ItemNO;//卷期
                        txtShijian.Text=m.Str1;//时间

                        //int3 自己是第几作者(从0开始) Int4 是否是学生 Int5是否通讯作者 
                         txtJS1.Text=m.Str2.Split('|')[0];
                         txtJS2.Text=m.Str3.Split('|')[0];
                         txtJS3.Text=m.Str4.Split('|')[0];
                         txtJS4.Text=m.Str5.Split('|')[0];
                         txtJS5.Text=m.Str6.Split('|')[0];

                            if(m.Str2.Split('|')[1]=="1"){cb_iss_1.Checked=true;}else{cb_iss_1.Checked=false;}
                            if(m.Str3.Split('|')[1]=="1"){cb_iss_2.Checked=true;}else{cb_iss_2.Checked=false;}
                            if(m.Str4.Split('|')[1]=="1"){cb_iss_3.Checked=true;}else{cb_iss_3.Checked=false;}
                            if(m.Str5.Split('|')[1]=="1"){cb_iss_4.Checked=true;}else{cb_iss_4.Checked=false;}
                            if(m.Str6.Split('|')[1]=="1"){cb_iss_5.Checked=true;}else{cb_iss_5.Checked=false;}

                           if(m.Str2.Split('|')[2]=="1"){cb_istx_1.Checked=true;}else{cb_istx_1.Checked=false;}
                            if(m.Str3.Split('|')[2]=="1"){cb_istx_2.Checked=true;}else{cb_istx_2.Checked=false;}
                            if(m.Str4.Split('|')[2]=="1"){cb_istx_3.Checked=true;}else{cb_istx_3.Checked=false;}
                            if(m.Str5.Split('|')[2]=="1"){cb_istx_4.Checked=true;}else{cb_istx_4.Checked=false;}
                            if(m.Str6.Split('|')[2]=="1"){cb_istx_5.Checked=true;}else{cb_istx_5.Checked=false;}

                            if (m.float3 == 1.2M) { ddl_gjhz.SelectedValue = "是"; } else { ddl_gjhz.SelectedValue = "否"; }//是否国际合作                      
                       if(m.float4==1){ddl_mkh.SelectedValue = "是";}else{ddl_mkh.SelectedValue = "否";}//是否顶级发表论文

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

                //m.Int3 = int.Parse(ddl_pendyear.SelectedValue);//End年
                //m.Int4 = int.Parse(ddl_pendmonth.SelectedValue);//End月
          
                m.ProjectName = txtProjectName.Text.Trim();//论文题目
                m.ProjectType = ddl_ptype.SelectedValue;//期刊类别       
                m.ProjectNO = txtChubanshe.Text.Trim();//杂志出版社
                m.ItemNO = txtJuanqi.Text.Trim();//卷期
                m.Str1 = txtShijian.Text.Trim();//时间

                int flag=0;//int3 自己是第几作者(从0开始) Int4 是否是学生 Int5是否通讯作者 
                if (rb_1.Checked) { flag++; m.Int3 = 0;  m.Int5 = cb_istx_1.Checked ? 1 : 0; if (cb_iss_1.Checked) { Jscript.Alert("自己不能是学生"); return; } }
                if (rb_2.Checked) { flag++; m.Int3 = 1;  m.Int5 = cb_istx_2.Checked ? 1 : 0; if (cb_iss_2.Checked) { Jscript.Alert("自己不能是学生"); return; } }
                if (rb_3.Checked) { flag++; m.Int3 = 2;  m.Int5 = cb_istx_3.Checked ? 1 : 0; if (cb_iss_3.Checked) { Jscript.Alert("自己不能是学生"); return; } }
                if (rb_4.Checked) { flag++; m.Int3 = 3;  m.Int5 = cb_istx_4.Checked ? 1 : 0; if (cb_iss_4.Checked) { Jscript.Alert("自己不能是学生"); return; } }
                if (rb_5.Checked) { flag++; m.Int3 = 4;  m.Int5 = cb_istx_5.Checked ? 1 : 0; if (cb_iss_5.Checked) { Jscript.Alert("自己不能是学生"); return; } }
                if (flag != 1)
                {
                    Jscript.Alert("作者中必须有一个是自己");
                    return;
                }
                m.Str2 = txtJS1.Text.Trim() + "|" + (cb_iss_1.Checked ? 1 : 0) + "|" + (cb_istx_1.Checked ? 1 : 0); //独立作者
                m.Str3 = txtJS2.Text.Trim() + "|" + (cb_iss_2.Checked ? 1 : 0) + "|" + (cb_istx_2.Checked ? 1 : 0); //1
                m.Str4 = txtJS3.Text.Trim() + "|" + (cb_iss_3.Checked ? 1 : 0) + "|" + (cb_istx_3.Checked ? 1 : 0); //2
                m.Str5 = txtJS4.Text.Trim() + "|" + (cb_iss_4.Checked ? 1 : 0) + "|" + (cb_istx_4.Checked ? 1 : 0); //3
                m.Str6 = txtJS5.Text.Trim() + "|" + (cb_iss_5.Checked ? 1 : 0) + "|" + (cb_istx_5.Checked ? 1 : 0); //其他

                bool isTop = false;//是否因为第一位是学生 自己是通讯作者进位为第一作者
                if (cb_iss_1.Checked && m.Int5 == 1)
                {
                    isTop = true;
                }
                m.float1 =decimal.Parse(ddl_xk.SelectedValue);//这是学科系数

                //项目教分 float2 教分                 
                    if (m.ProjectType == "A")
                    {
                     
                              switch(m.Int3)
                        {
                                     case 0: m.float2 = 20*m.float1;break;
                                     case 1: m.float2 = 15*m.float1;break;
                                     case 2: m.float2 = 8*m.float1;break;
                                     case 3: m.float2 = 5*m.float1;break;
                                     case 4: m.float2 = 3*m.float1;break;
                                     default: m.float2=0;break;
                        }
                    }
                    if (m.ProjectType == "B")
                    {
                                  switch(m.Int3)
                        {
                                     case 0: m.float2 = 20;break;
                                     case 1: m.float2 = 15;break;
                                     case 2: m.float2 = 8;break;
                                     case 3: m.float2 = 5;break;
                                     case 4: m.float2 = 3;break;
                                     default: m.float2=0;break;
                        }
                    }
                    if (m.ProjectType == "C")
                    {
                                   switch(m.Int3)
                        {
                                     case 0: m.float2 = 15;break;
                                     case 1: m.float2 = 10;break;
                                     case 2: m.float2 = 6;break;
                                     case 3: m.float2 = 4;break;
                                     case 4: m.float2 = 2;break;
                                     default: m.float2=0;break;
                        }
                    }
                    if (m.ProjectType == "D")
                    {
                                switch(m.Int3)
                        {
                                     case 0: m.float2 = 10;break;
                                     case 1: m.float2 = 5;break;
                                     case 2: m.float2 = 3;break;
                                     case 3: m.float2 = 2;break;
                                     case 4: m.float2 = 1;break;
                                     default: m.float2=0;break;
                        }
                    }
                    if (m.ProjectType == "E")
                    {
                           switch(m.Int3)
                        {
                                     case 0: m.float2 = 6;break;
                                     case 1: m.float2 = 3;break;
                                     case 2: m.float2 = 2;break;
                                     case 3: m.float2 = 1;break;
                                     case 4: m.float2 = 0;break;
                                     default: m.float2=0;break;
                        }
                    }

                    if (isTop)//如果是进位第一作者
                    {

                        switch (m.ProjectType)
                        {
                            case "B": m.float2 = 15; break;
                            case "C": m.float2 = 10; break;
                            case "D": m.float2 = 5; break;
                            case "E": m.float2 = 3; break;
                            default: m.float2 = 0; break;
                        }
                    }

                }
              m.float3 = ddl_gjhz.SelectedValue=="是"?1.2M:1;//是否国际合作
              m.float2=m.float2*m.float3;//重新赋值
              m.float4=ddl_mkh.SelectedValue=="是"?1:0;//是否顶级发表论文

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
        else
        {
            SHUniversity.KPI.Model.KPIItems m = new SHUniversity.KPI.Model.KPIItems();
            //添加一个创新实验项目
            m.KPINO = TableID;
            m.ItemType = "教学论文";
            m.ItemCreator = currUser.WorkID;
            m.ItemDate = DateTime.Now;
             //何年月至何年月
                m.Int1 = int.Parse(ddl_pstartyear.SelectedValue);//开始年
                m.Int2 = int.Parse(ddl_pstartmonth.SelectedValue);//开始月
         
                m.ProjectName = txtProjectName.Text.Trim();//论文题目
                m.ProjectType = ddl_ptype.SelectedValue;//期刊类别       
                m.ProjectNO = txtChubanshe.Text.Trim();//杂志出版社
                m.ItemNO = txtJuanqi.Text.Trim();//卷期
                m.Str1 = txtShijian.Text.Trim();//时间

                int flag=0;//int3 自己是第几作者(从0开始) Int4 是否是学生 Int5是否通讯作者 
                if (rb_1.Checked) { flag++; m.Int3 = 0;m.Int5 = cb_istx_1.Checked ? 1 : 0; if (cb_iss_1.Checked) { Jscript.Alert("自己不能是学生"); return; } }
                if (rb_2.Checked) { flag++; m.Int3 = 1;m.Int5 = cb_istx_2.Checked ? 1 : 0; if (cb_iss_2.Checked) { Jscript.Alert("自己不能是学生"); return; } }
                if (rb_3.Checked) { flag++; m.Int3 = 2;m.Int5 = cb_istx_3.Checked ? 1 : 0; if (cb_iss_3.Checked) { Jscript.Alert("自己不能是学生"); return; } }
                if (rb_4.Checked) { flag++; m.Int3 = 3;m.Int5 = cb_istx_4.Checked ? 1 : 0; if (cb_iss_4.Checked) { Jscript.Alert("自己不能是学生"); return; } }
                if (rb_5.Checked) { flag++; m.Int3 = 4;m.Int5 = cb_istx_5.Checked ? 1 : 0; if (cb_iss_5.Checked) { Jscript.Alert("自己不能是学生"); return; } }
                if (flag != 1)
                {
                    Jscript.Alert("作者中必须有一个是自己");
                    return;
                }
                m.Str2 = txtJS1.Text.Trim() + "|" + (cb_iss_1.Checked ? 1 : 0) + "|" + (cb_istx_1.Checked ? 1 : 0); //独立作者
                m.Str3 = txtJS2.Text.Trim() + "|" + (cb_iss_2.Checked ? 1 : 0) + "|" + (cb_istx_2.Checked ? 1 : 0); //1
                m.Str4 = txtJS3.Text.Trim() + "|" + (cb_iss_3.Checked ? 1 : 0) + "|" + (cb_istx_3.Checked ? 1 : 0); //2
                m.Str5 = txtJS4.Text.Trim() + "|" + (cb_iss_4.Checked ? 1 : 0) + "|" + (cb_istx_4.Checked ? 1 : 0); //3
                m.Str6 = txtJS5.Text.Trim() + "|" + (cb_iss_5.Checked ? 1 : 0) + "|" + (cb_istx_5.Checked ? 1 : 0); //其他

                bool isTop = false;//是否因为第一位是学生 自己是通讯作者进位为第一作者
                if (cb_iss_1.Checked && m.Int5 == 1)
                {
                    isTop = true;
                }

                m.float1 =decimal.Parse(ddl_xk.SelectedValue);//这是学科系数

                //项目教分 float2 教分                 
                    if (m.ProjectType == "A")
                    {
                     
                              switch(m.Int3)
                        {
                                     case 0: m.float2 = 20*m.float1;break;
                                     case 1: m.float2 = 15*m.float1;break;
                                     case 2: m.float2 = 8*m.float1;break;
                                     case 3: m.float2 = 5*m.float1;break;
                                     case 4: m.float2 = 3*m.float1;break;
                                     default: m.float2=0;break;
                        }
                    }
                    if (m.ProjectType == "B")
                    {
                                  switch(m.Int3)
                        {
                                     case 0: m.float2 = 20;break;
                                     case 1: m.float2 = 15;break;
                                     case 2: m.float2 = 8;break;
                                     case 3: m.float2 = 5;break;
                                     case 4: m.float2 = 3;break;
                                     default: m.float2=0;break;
                        }
                    }
                    if (m.ProjectType == "C")
                    {
                                   switch(m.Int3)
                        {
                                     case 0: m.float2 = 15;break;
                                     case 1: m.float2 = 10;break;
                                     case 2: m.float2 = 6;break;
                                     case 3: m.float2 = 4;break;
                                     case 4: m.float2 = 2;break;
                                     default: m.float2=0;break;
                        }
                    }
                    if (m.ProjectType == "D")
                    {
                                switch(m.Int3)
                        {
                                     case 0: m.float2 = 10;break;
                                     case 1: m.float2 = 5;break;
                                     case 2: m.float2 = 3;break;
                                     case 3: m.float2 = 2;break;
                                     case 4: m.float2 = 1;break;
                                     default: m.float2=0;break;
                        }
                    }
                    if (m.ProjectType == "E")
                    {
                           switch(m.Int3)
                        {
                                     case 0: m.float2 = 6;break;
                                     case 1: m.float2 = 3;break;
                                     case 2: m.float2 = 2;break;
                                     case 3: m.float2 = 1;break;
                                     case 4: m.float2 = 0;break;
                                     default: m.float2=0;break;
                        }
                    }

                    if (isTop)//如果是进位第一作者
                    {

                        switch (m.ProjectType)
                        {
                            case "B": m.float2 = 15; break;
                            case "C": m.float2 = 10; break;
                            case "D": m.float2 = 5; break;
                            case "E": m.float2 = 3; break;                       
                            default: m.float2 = 0; break;
                        }
                    }

                
              m.float3 = ddl_gjhz.SelectedValue=="是"?1.2M:1;//是否国际合作
              m.float2=m.float2*m.float3;//重新赋值
              m.float4=ddl_mkh.SelectedValue=="是"?1:0;//是否顶级发表论文


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