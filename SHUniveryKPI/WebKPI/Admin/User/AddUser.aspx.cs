using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SHUniversity.KPI;

    public partial class Admin_User_AddUser : System.Web.UI.Page
    {
        SHUniversity.KPI.BLL.Users ubll = new SHUniversity.KPI.BLL.Users();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void butSava_Click(object sender, EventArgs e)
        {
            try
            {
                if (ubll.Exists(txt_workID.Text.Trim()))
                {
                    Jscript.Alert("已经存在的工号");
                    return;
                }
                //添加用户
                SHUniversity.KPI.Model.Users u = new SHUniversity.KPI.Model.Users();
                u.BrithDay =SHUniversity.KPI.Common.ConvertDatetime(txt_birthday.Text.Trim());
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
                if (ubll.Add(u) > 0)
                {
                    Jscript.AlertAndRedirect("添加成功！", "AddUser.aspx");
                }
                else
                {
                    Jscript.Alert("添加失败请重试");
                }
            }
            catch (Exception ex)
            {
                Jscript.Alert("异常信息："+ex.Message);
            }
        }
    }
