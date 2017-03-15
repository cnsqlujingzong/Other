using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SITED.PRODUCT.Model;
using SITED.PRODUCT;
public partial class Master_Pro_Admin_PROTYPE : System.Web.UI.Page
{
         FPRO_TYPE fpt=new FPRO_TYPE ();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                  HL_NewType.NavigateUrl = "ProsTypeManage.aspx?con=add&language=cn&id=NAN";//初始化新分类列表                  
                  RP_con.DataSource = fpt.GetDAL().GetList(" [Language]='cn' ");     
                  RP_con.DataBind();
            }
        }
        /// <summary>
        /// 切换语言
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DD_language_SelectedIndexChanged(object sender, EventArgs e)
        {
            //新分类
            if (DD_language.SelectedValue == "cn")
            {
                HL_NewType.NavigateUrl = "ProsTypeManage.aspx?con=add&language=cn&id=NAN";               
                RP_con.DataSource = fpt.GetDAL().GetList(" [Language]='cn'");
                RP_con.DataBind();
            }
            else 
            {
                HL_NewType.NavigateUrl = "ProsTypeManage.aspx?con=add&language=en&id=NAN";
               
                RP_con.DataSource = fpt.GetDAL().GetList(" [Language]='en'");
                RP_con.DataBind();
            }
        }
        /// <summary>
        /// 删除所选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LB_DelSelect_Click(object sender, EventArgs e)
        {
          
            string sb = string.Empty;
            for (int i = 0; i < this.RP_con.Items.Count; i++)
            {
                CheckBox cb = (RP_con.Items[i].FindControl("CheckBox1_")) as CheckBox;
                if (cb.Checked == true)
                {
                    string dd = ((RP_con.Items[i].FindControl("HiddenField_")) as HiddenField).Value;                   
                    sb += dd + ",";                    
                }
            }
            fpt.GetDAL().DeleteMuli(sb);
            Jscript.RedirectToFrames("ProsTypeAdmin.aspx");
        }
        protected string GetPubICO(string flag)
        {
            if (flag == "1")
            {
                return "../resources/img/yes.gif";
            }
            else 
            {
                return "../resources/img/no.gif";
            }
        }
    }