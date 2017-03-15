using SHUniversity.KPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_User_UserEdit : System.Web.UI.Page
{
    SHUniversity.KPI.BLL.Users uBll = new SHUniversity.KPI.BLL.Users();     
    protected void Page_Load(object sender, EventArgs e)
    {
        SHUniversity.KPI.Model.Users model = new SHUniversity.KPI.Model.Users();
     
        if (!IsPostBack)
        {
            string con = Request.QueryString["con"];
            string id=Request.QueryString["id"];
            //发布
            if (con == "pub")
            {
                model = uBll.GetModel(Convert.ToInt32(id));
                if (model.Satat == 1)
                {
                    model.Satat = 0;
                }
                else if (model.Satat == 0)
                {
                    model.Satat = 1;
                }
                uBll.Update(model);
                Jscript.RedirectToFrames("UserManage.aspx");
            }
            //删除
            if (con == "del")
            {
                bool result = uBll.Delete(Convert.ToInt32(id));
                if (result)
                {
                    Jscript.RedirectToFrames("UserManage.aspx");
                }
                else
                {
                    Jscript.Alert("删除异常，请重试");
                    Jscript.RedirectToFrames("UserManage.aspx");
                }
            }
            //修改
            if (con == "edit")
            {
               SHUniversity.KPI.Model.Users u = uBll.GetModel(Convert.ToInt32(id));
                if (model == null)
                {
                    Jscript.Alert("账户不存在，请重试");
                    Jscript.RedirectToFrames("UserManage.aspx");
                }
                else
                {
                    hidid.Value = id;
                    txt_birthday.Text = string.Format("{0:yyyy-MM-dd}", u.BrithDay);                  
                    txt_email.Text=u.Email;
                    txt_indate.Text= string.Format("{0:yyyy-MM-dd}", u.InDate);   
                    txt_moblie.Text=u.Moblie;
                    txt_name.Text = u.Name;
                    txt_pwd.Text=u.Password ;
                    txt_common.Text=u.Ramerk;
                    rb_sex.SelectedValue=u.Sex.ToString();
                    txt_tell.Text=u.Tel;
                    rb_usertype.SelectedValue=u.UserType.ToString();
                    txt_workID.Text=u.WorkID;
                    txt_xueli.Text=u.Xueli;
                    txt_xuexiao.Text=u.Xuexiao;
                    txt_zhiwu.Text=u.Zhiwu;
                }
            }
        
           
         
        }
    }
    /// <summary>
    /// 修改
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void butSava_Click(object sender, EventArgs e)
    {
        SHUniversity.KPI.Model.Users u = new SHUniversity.KPI.Model.Users();
        u.ID = int.Parse(hidid.Value);
        u.BrithDay = SHUniversity.KPI.Common.ConvertDatetime(txt_birthday.Text.Trim());
        u.CreatDate = DateTime.Now;
        u.Email = txt_email.Text.Trim();
        u.InDate = Common.ConvertDatetime(txt_indate.Text.Trim());
        u.Moblie = txt_moblie.Text.Trim();
        u.Name = txt_name.Text.Trim();
        u.Password = txt_pwd.Text.Trim();
        u.Ramerk = txt_common.Text.Trim();
        u.Satat = 1;
        u.Sex = int.Parse(rb_sex.SelectedValue);
        u.Tel = txt_tell.Text.Trim();
        u.UserType = int.Parse(rb_usertype.SelectedValue);
        u.WorkID = txt_workID.Text.Trim();
        u.Xueli = txt_xueli.Text.Trim();
        u.Xuexiao = txt_xuexiao.Text.Trim();
        u.Zhiwu = txt_zhiwu.Text.Trim();

        bool result = uBll.Update(u);
        if (result)
        {
            Jscript.RedirectToFrames("UserManage.aspx");
        }
        else
        {
            Jscript.Alert("修改异常，请重试");
            Jscript.RedirectToFrames("UserManage.aspx");
        }
    
    }
}