using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SITED.NEWS;
using SITED.NEWS.Model;
public partial class Master_News_Admin_NewsType_Add : System.Web.UI.Page
{    
        string language;
        protected void Page_Load(object sender, EventArgs e)
        {
            language = Request.QueryString["language"];
            if (!IsPostBack)
            {
                BindType(language);               
            }
          
            if (language == "cn")
            {
                LB_language.Text = "简体中文";
            }
            else if (language == "en")
            {
                LB_language.Text = "English";
            }
        }
        /// <summary>
        /// 根据语言获取新闻类别
        /// </summary>
        private void BindType(string lan)
        {
            FNEWS_TYPE newtype = new FNEWS_TYPE();           
            DD_Type.DataSource = newtype.GetDAL().GetList("Lang='" + lan + "'");
            DD_Type.DataTextField = "TypeName";
            DD_Type.DataValueField = "ID";
            DD_Type.DataBind();
            DD_Type.Items.Insert(0, new ListItem("最上层", "0"));
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void butSava_Click(object sender, EventArgs e)
        {
            FNEWS_TYPE news_type = new FNEWS_TYPE();
            ENEWSType Enewtype = new ENEWSType();
            Enewtype.TypeName = Request.Form["newstypename"];
            Enewtype.ParentID = Convert.ToInt32(DD_Type.SelectedValue);
            if (Request.Form["isfabu"] == "on")
            {
                Enewtype.ISFabu = 1;
            }
            else 
            {
                Enewtype.ISFabu = 0;
            }
            if (Request.Form["islimit"] == "on")//0全访问1会员访问
            {
                Enewtype.ISLimit = 1;
            }
            else
            {
                Enewtype.ISLimit = 0;
            }
            Enewtype.Lang = language;

            bool result = news_type.GetDAL().Add(Enewtype);
            if (result)
          {
              Jscript.RedirectToFrames("Admin_NewsType.aspx");
          }
          else 
          {
              Jscript.Alert("异常错误，请重试！");
          }
        }
    }
