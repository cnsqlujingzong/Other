using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SITED.PRODUCT.Model;
using SITED.PRODUCT;
public partial class Master_Pro_ProsTypeManage : System.Web.UI.Page
{
        string language;
        string con;
        string id;
        FPRO_TYPE fpt=new FPRO_TYPE ();
        protected void Page_Load(object sender, EventArgs e)
        {
            //操作
            con=Request.QueryString["con"];
            id = Request.QueryString["id"];
            language = Request.QueryString["language"];
            if (!IsPostBack)
            {
                EPROType model;
                if (con == "add")//增加类别
                {
                    BindType(language, "");
                }
                else if (con == "edit")
                {
                   model= fpt.GetDAL().GetModel(Convert.ToInt32(id));
                    language = model.Language;
                    BindType(language,id);
                    txtProTypeName.Text = model.TypeName;
                    DD_Type.SelectedValue = model.ParentID.ToString();
                    if (model.ISPub == "1")
                    {
                        CB_ispub.Checked = true;
                    }
                    else { CB_ispub.Checked = false; }
                    if (model.ISLimit == "1")
                    {
                        CB_isLimit.Checked = true;
                    }
                    else
                    {
                        CB_isLimit.Checked = false;
                    }
                }
                else if (con == "del")
                {
                        bool result = fpt.GetDAL().Delete(Convert.ToInt32(id));
                        if (result)
                        {
                            Jscript.RedirectToFrames("Admin_PROTYPE.aspx");
                        }
                        else
                        {
                            Jscript.Alert("删除异常，请重试");
                            Jscript.RedirectToFrames("Admin_PROTYPE.aspx");
                        }
                   
                }
                else if (con == "pub")
                {
                    model= fpt.GetDAL().GetModel(Convert.ToInt32(id));
                    if (model.ISPub == "1")
                    {
                        model.ISPub = "0";
                    }
                    else if (model.ISPub == "0")
                    {
                        model.ISPub = "1";
                    }
                    fpt.GetDAL().Update(model);
                    Jscript.RedirectToFrames("Admin_PROTYPE.aspx");
                }
            }
            if (language == "cn")
            {
                LB_language.Text = "简体中文";
            }
            else if (language == "en")
            {
                LB_language.Text = "英语";
            }
        }
        /// <summary>
        /// 根据语言获取所有类别
        /// </summary>
        private void BindType(string lang,string id)
        {
            string strWhere = "  [Language] ='" + lang + "' ";
            if (id.Length > 0)
            { 
            strWhere+="and ID<>"+id;
            }
            DD_Type.DataSource=fpt.GetDAL().GetList(strWhere);
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
           EPROType model=new EPROType ();
            if (con == "edit")
            {
               model=fpt.GetDAL().GetModel(Convert.ToInt32(id));
            }

            model.TypeName = txtProTypeName.Text.Trim();
            model.ParentID = Convert.ToInt32(DD_Type.SelectedValue);
            if (CB_ispub.Checked == true)
            {
                model.ISPub = "1";
            }
            else
            {
                model.ISPub = "0";
            }
            if (CB_isLimit.Checked == true)//0全访问1会员访问
            {
                model.ISLimit = "1";
            }
            else
            {
                model.ISLimit = "0";
            }
       
            bool result;
            if (con == "add")
            {
                result = fpt.GetDAL().Add(model);
            }
            else 
            {
                result = fpt.GetDAL().Update(model);
            }

          if (result)
          {
              Jscript.RedirectToFrames("Admin_PROTYPE.aspx");
          }
          else 
          {
              Jscript.Alert("异常错误，请重试！");
          }
        }
    }