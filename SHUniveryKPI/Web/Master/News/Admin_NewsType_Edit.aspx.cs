using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SITED.NEWS.Model;
using SITED.NEWS;
public partial class Master_News_Admin_NewsType_Edit : SITED.COMMON.PageBase
{
        protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            {
              
               FNEWS_TYPE dalNewsType=new FNEWS_TYPE (); 
               string id = Request.QueryString["id"];
               ENEWSType eNewsType =dalNewsType.GetDAL().GetModel(Convert.ToInt32(id));
                if (Request.QueryString["ispub"] == "true")
                {
                    if (eNewsType.ISFabu == 0)
                    {
                        eNewsType.ISFabu = 1;
                    }
                    else {
                        eNewsType.ISFabu = 0;
                    }
                    dalNewsType.GetDAL().Update(eNewsType);
                    Jscript.RedirectToFrames("Admin_NewsType.aspx");
                }
                else
                {                                  
                    txtTypeName.Text = eNewsType.TypeName;               
                    if (eNewsType.Lang == "cn")
                    {
                        LB_language.Text = "简体中文";
                    }
                    else { LB_language.Text = "English"; }
                    BindType(eNewsType.Lang,id);
                    DD_Type.SelectedValue = eNewsType.ParentID.ToString();
                    if (eNewsType.ISFabu == 1)
                    {
                        isfabu.Checked = true;
                    }
                    else
                    {
                        isfabu.Checked = false;
                    }
                    if (eNewsType.ISLimit == 1)
                    {
                        islimit.Checked = true;
                    }
                    else
                    {
                        islimit.Checked = false;
                    }
                    Hid.Value = id;
                }
            }
        }
        private void BindType(string lang,string id)
        {
            FNEWS_TYPE fnt=new FNEWS_TYPE ();
            
            DD_Type.DataSource = fnt.GetDAL().GetList("Lang='" + lang + "' and [ID] <>"+id);
            DD_Type.DataTextField = "TypeName";
            DD_Type.DataValueField = "ID";
        
            DD_Type.DataBind();
            DD_Type.Items.Insert(0, new ListItem("最上层", "0"));
            
        }
        protected void butSava_Click(object sender, EventArgs e)
        {
               FNEWS_TYPE dalNewsType=new FNEWS_TYPE (); 
               string id = Request.QueryString["id"];
               ENEWSType eNewsType =dalNewsType.GetDAL().GetModel(Convert.ToInt32(Hid.Value));           
               eNewsType.TypeName = txtTypeName.Text.Trim();
               eNewsType.ParentID = Convert.ToInt32(DD_Type.SelectedValue);
            if (isfabu.Checked==true)
            {
                eNewsType.ISFabu = 1;
            }
            else
            {
                eNewsType.ISFabu = 0;
            }
            if (islimit.Checked==true)//0全访问1会员访问
            {
                eNewsType.ISLimit = 1;
            }
            else
            {
                eNewsType.ISLimit = 0;
            }
            bool count = dalNewsType.GetDAL().Update(eNewsType);
            if (count )
            {
                Jscript.RedirectToFrames("Admin_NewsType.aspx");
            }
            else
            {
                Jscript.Alert("异常错误，请重试！");
            }
        }
}