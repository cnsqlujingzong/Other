using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SITED.NEWS.Model;
using SITED.NEWS;
public partial class Master_News_Admin_News_Add : SITED.COMMON.PageBase
{
         string lang;
         string cid;
         FNEWS_TYPE fnt = new FNEWS_TYPE();
         FNews fn = new FNews();
        protected void Page_Load(object sender, EventArgs e)
        {            
            lang = Request.QueryString["lang"];
            if (lang == null)
            {
                lang = "cn";
            }
            string con = Request.QueryString["con"];
            cid = Request.QueryString["cid"];
            if (lang == "cn")
            {
                LB_lang.Text = "简体中文";

            }
            else if (lang == "en")
            {
                LB_lang.Text = "English";
            }
            if (!IsPostBack)
            {
                txtDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
                //编辑还是增加               
                if (con == "add")
                {                 
                    // 绑定newsType
                    BindNewsType(lang);
                }
                else if (Request.QueryString["con"] == "edit")
                {
                    //编辑                    
                    ENEWS model = new ENEWS();
                    model=fn.GetDAL().GetModel(Convert.ToInt32(cid));
                    // 绑定newsType
                    BindNewsType(model.Language);
                    DL_NewsType.SelectedValue = model.News_Type.ToString();//新闻类型
                    txtTitle.Text = model.Title;//标题
                    txtAuthor.Text = model.Author;//作者
                    txtDate.Text = string.Format("{0:yyyy-MM-dd}", model.Data);          //日期
                    if (model.ISSEO == 1) //是否seo
                    {
                        ISSEO.SelectedValue = "true";                 //
                        txtKeyWord.Text = model.SEO_KEYWORD;//自定义seo keyWord
                    }
                    else
                    {
                        ISSEO.SelectedValue = "false";
                    }
                    txtSummary.Text = model.Summary;//简介
                    txtContent.Text = model.F_Content;  //内容
                }
                else if (Request.QueryString["con"] == "del")
                {
                   fn.GetDAL().Delete(Convert.ToInt32(cid));
                   Jscript.RedirectToFrames("Admin_News.aspx");                    
                }
                else if (Request.QueryString["con"] == "ispub")
                {
                   ENEWS model= fn.GetDAL().GetModel(Convert.ToInt32(cid));
                   if (model.ISPublish == 1)
                    {
                        model.ISPublish = 0;
                    }
                    else
                    {
                        model.ISPublish = 1;
                    }
                    fn.GetDAL().Update(model);
                    Jscript.RedirectToFrames("Admin_News.aspx");
                }
            }
        
           
        }
        /// <summary>
        /// 根据语言 绑定新闻类型
        /// </summary>
        private void BindNewsType(string language)
        {           
            DL_NewsType.DataSource = fnt.GetDAL().GetList(" Lang='" + language + "'");
            DL_NewsType.DataTextField = "TypeName";
            DL_NewsType.DataValueField = "ID";
            DL_NewsType.DataBind();
        }
        /// <summary>
        /// 添加文章
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void butSava_Click(object sender, EventArgs e)
        {
            ENEWS model=new ENEWS ();   
            if (cid != "NAN")
            {
               model=fn.GetDAL().GetModel(Convert.ToInt32(cid));
            }
            model.Language = lang;//语言
            model.News_Type = Convert.ToInt32(DL_NewsType.SelectedValue);//新闻类型
                if (txtTitle.Text.Trim().Length > 0)
                {
                    model.Title = txtTitle.Text.Trim();//标题
                }
                else {
                    Jscript.Alert("标题不能为空！");
                    return;
                }
                if (txtAuthor.Text.Trim().Length>0)
                {
                    model.Author = txtAuthor.Text.Trim();//作者
                }
                model.Data = Convert.ToDateTime(txtDate.Text);          //日期
                if (ISSEO.SelectedValue == "true") //是否seo
                {
                    model.ISSEO = 1;                 //
                    model.SEO_KEYWORD = txtKeyWord.Text.Trim();//自定义seo keyWord
                }
                else 
                {
                    model.ISSEO = 0;
                }
                if (txtSummary.Text.Trim().Length > 0)
                {
                    model.Summary = txtSummary.Text.Trim();//简介
                }
                if (txtContent.Text.Trim().Length > 0)
                {
                    model.F_Content = txtContent.Text;  //内容
                }
                else
                {
                    Jscript.Alert("正文不能为空！");
                    return;
                }
                model.ISLimit = 0;//是否只有会员访问
                model.ISPublish = 1;//是否发布
                model.ISRecommend = "0";//0不推荐1标题推荐2图片推荐

                model.OrderBy = "0";
               if (cid == "NAN")
                {
                    bool result = fn.GetDAL().Add(model);
                  if (result)
                  {
                      Jscript.AlertAndRedirect("添加成功", "Admin_News.aspx");
                  }
                }
                else
               {
                   bool result = fn.GetDAL().Update(model);
                   if(result)
                   {
                       Jscript.AlertAndRedirect("修改成功", "Admin_News.aspx");
                   }
               }
               
           
        }

        protected void ISSEO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ISSEO.SelectedValue == "true")
            {
                LB_KeyWord.Visible = true;
                txtKeyWord.Visible = true;
            }
            else 
            {
                LB_KeyWord.Visible = false;
                txtKeyWord.Visible = false;
            }
        }
    }
