using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SITED.PRODUCT.Model;
using SITED.PRODUCT;
public partial class Master_Pro_ProsManage : System.Web.UI.Page
{
    string lang;
    string cid;
    string con;
    FPRO bll = new FPRO();
    FPRO_TYPE type_bll = new FPRO_TYPE();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        //操作
        con = Request.QueryString["con"];
        cid = Request.QueryString["cid"];
        lang = Request.QueryString["lang"];
        txtDate.Text = DateTime.Now.ToString();
        if (!IsPostBack)
        {
            if (con == "add")//增加类别
            {
                BindNewsType(lang);
            }
            else if (con == "edit")
            {
               
               EPRO model= bll.GetDAL().GetModel(Convert.ToInt32(cid));
               lang = model.Language; //语言
                BindNewsType(lang); //获取分类

                txtProName.Text = model.PName;//产品名称
                txtDate.Text = string.Format("{0:yyyy-MM-dd HH-mm-ss}", model.PubDate); //发布日期
                DL_prosType.SelectedValue = model.PType.ToString();//产品分类
                if (model.ISRecommend == 1)
                {
                    CB_Recommend.Checked = true;
                }
                else
                {
                    CB_Recommend.Checked = false;
                }
                if (model.ISSEO == 1)
                {
                    ISSEO.SelectedValue = "true";
                    LB_KeyWord.Visible = true;
                    txtKeyWord.Visible = true;
                    txtKeyWord.Text = model.SEO;
                }
                else
                {
                    ISSEO.SelectedValue = "false";
                }
                txtIntro.Text = model.Intro;    //简介
                txtContent.Text = model.Content;//概述
                txtAgument.Text = model.Agument;//详细参数
                txtCase.Text = model.Case;//应用案例
                string[] pics = model.Picture.Split('@');
                if (pics.Length > 0)
                {
                    try
                    {
                        Image1.ImageUrl = "../../upload/images/" + pics[0];
                        txtimg1.Text = "../../upload/images/" + pics[0];
                        Image2.ImageUrl = "../../upload/images/" + pics[1];
                        txtimg2.Text = "../../upload/images/" + pics[1];
                        Image3.ImageUrl = "../../upload/images/" + pics[2];
                        txtimg3.Text = "../../upload/images/" + pics[2];
                        Image4.ImageUrl = "../../upload/images/" + pics[3];
                        txtimg4.Text = "../../upload/images/" + pics[3];
                    }
                    catch { };
                }
            }
            else if (con == "del")
            {               
                bool result = bll.GetDAL().Delete(Convert.ToInt32(cid));
                if (result)
                {
                    Jscript.RedirectToFrames("Admin_PRO.aspx");
                }
                else
                {
                    Jscript.Alert("删除异常，请重试");
                    Jscript.RedirectToFrames("Admin_PRO.aspx");
                }
            }
            else if (con == "ispub")
            {
                
                 EPRO model=bll.GetDAL().GetModel(Convert.ToInt32(cid));
                 if (model.ISPub == 1)
                {
                    model.ISPub = 0;
                }
                 else if (model.ISPub == 0)
                {
                    model.ISPub = 1;
                }
                 bll.GetDAL().Update(model);
                Jscript.RedirectToFrames("Admin_PRO.aspx");
            }
        }
        if (lang == "cn")
        {
            LB_lang.Text = "简体中文";
        }
        else if (lang == "en")
        {
            LB_lang.Text = "英语";
        }
    }
    /// <summary>
    /// 根据语言 绑定新闻类型
    /// </summary>
    private void BindNewsType(string language)
    {
        DL_prosType.DataSource =type_bll.GetDAL().GetList(" [Language]='" + language + "'");
        DL_prosType.DataTextField = "TypeName";
        DL_prosType.DataValueField = "ID";
        DL_prosType.DataBind();
    }
    /// <summary>
    /// 添加文章
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void butSava_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            EPRO model=new EPRO ();
            string[] imgs;
            string imgss = "";
            if (con == "edit")  //编辑
            {
                model= bll.GetDAL().GetModel(Convert.ToInt32(cid));
                imgs = model.Picture.Split('@');
                imgss = model.Picture;


                if (upimg1.FileName.Length <= 0 && txtimg1.Text.Length <= 0)
                {
                    if (imgss.Trim().Length > 0)
                    {
                        if (imgss.Substring(imgs[0].Length + 1, 1) == "@")
                        {
                            imgss.Remove(0, imgs[0].Length + 1);
                        }
                        else
                        {
                            imgss.Remove(0, imgs[0].Length);
                        }
                    }
                }
                if (upimg2.FileName.Length <= 0 && txtimg2.Text.Length <= 0)
                {
                    try
                    {
                        if (imgss.Substring(imgs[1].Length + 1, 1) == "@")
                        {
                            imgss.Remove(0, imgs[1].Length + 1);
                        }
                        else
                        {
                            imgss.Remove(0, imgs[1].Length);
                        }
                    }
                    catch { }
                }

                if (upimg3.FileName.Length <= 0 && txtimg3.Text.Length <= 0)
                {
                    try
                    {
                        if (imgss.Substring(imgs[2].Length + 1, 1) == "@")
                        {
                            imgss.Remove(0, imgs[2].Length + 1);
                        }
                        else
                        {
                            imgss.Remove(0, imgs[2].Length);
                        }
                    }
                    catch { }
                }

                if (upimg4.FileName.Length <= 0 && txtimg4.Text.Length <= 0)
                {
                    try
                    {

                        if (imgss.Substring(imgs[3].Length + 1, 1) == "@")
                        {
                            imgss.Remove(0, imgs[3].Length + 1);
                        }
                        else
                        {
                            imgss.Remove(0, imgs[3].Length);
                        }

                    }
                    catch { }
                }
            }

            model.Language = lang;  //所属语言
            model.PType = Convert.ToInt32(DL_prosType.SelectedValue);//所属分类
            model.PName = txtProName.Text; //产品名
            model.PubDate = Convert.ToDateTime(txtDate.Text);//发布日期
            if (ISSEO.SelectedValue == "true") //是否单独SEO
            {
                model.ISSEO = 1;
            }
            else
            {
                model.ISSEO = 0;
            }
            if (txtKeyWord.Text.Length > 0)
            {
                model.SEO = txtKeyWord.Text;  //Seo
            }
            if (txtIntro.Text.Length > 0)
            {
                model.Intro = txtIntro.Text;     //简介
            }
            if (txtContent.Text.Length > 0)
            {
                model.Content = txtContent.Text;  //产品概述
            }
            if (txtAgument.Text.Length > 0)
            {
                model.Agument = txtAgument.Text; //详细参数
            }
            if (txtCase.Text.Length > 0)
            {
                model.Case = txtCase.Text;  //应用案例
            }
            if (CB_Recommend.Checked == true)  //是否推荐产品
            {
                model.ISRecommend = 1;
            }
            else
            {
                model.ISRecommend = 0;
            }
            model.OrderBy = 0;   //顺序
            string imgssrc = "";


            //img1
            if (upimg1.FileName.Length > 0 && txtimg1.Text.Length <= 0)
            {
                string filename = upimg1.FileName;
                string dotname = filename.Substring(filename.LastIndexOf(".") + 1);
                if (dotname.ToUpper() == "PNG" || dotname.ToUpper() == "JPG" || dotname.ToUpper() == "GIF" || dotname.ToUpper() == "BMP")
                {
                    upimg1.PostedFile.SaveAs(Server.MapPath("~/upload/images/" + upimg1.FileName));
                    imgssrc += upimg1.FileName + "@";
                }
                else
                {
                    Jscript.Alert("图片格式不对");
                    return;
                }

            }
            else if ((upimg1.FileName.Length <= 0 && txtimg1.Text.Length > 0) || (upimg1.FileName.Length > 0 && txtimg1.Text.Length > 0))
            {
                imgssrc += txtimg1.Text.Substring(txtimg1.Text.LastIndexOf("/") + 1) + "@";
            }

            //img2
            if (upimg2.FileName.Length > 0 && txtimg2.Text.Length <= 0)
            {
                string filename = upimg2.FileName;
                string dotname = filename.Substring(filename.LastIndexOf(".") + 1);
                if (dotname.ToUpper() == "PNG" || dotname.ToUpper() == "JPG" || dotname.ToUpper() == "GIF" || dotname.ToUpper() == "BMP")
                {
                    upimg2.PostedFile.SaveAs(Server.MapPath("~/upload/images/" + upimg2.FileName));
                    imgssrc += upimg2.FileName + "@";
                }
                else
                {
                    Jscript.Alert("图片格式不对");
                    return;
                }
            }
            else if ((upimg2.FileName.Length <= 0 && txtimg2.Text.Length > 0) || (upimg2.FileName.Length > 0 && txtimg2.Text.Length > 0))
            {
                imgssrc += txtimg2.Text.Substring(txtimg2.Text.LastIndexOf("/") + 1) + "@";
            }

            //img3
            if (upimg3.FileName.Length > 0 && txtimg3.Text.Length <= 0)
            {
                string filename = upimg3.FileName;
                string dotname = filename.Substring(filename.LastIndexOf(".") + 1);
                if (dotname.ToUpper() == "PNG" || dotname.ToUpper() == "JPG" || dotname.ToUpper() == "GIF" || dotname.ToUpper() == "BMP")
                {
                    upimg3.PostedFile.SaveAs(Server.MapPath("~/upload/images/" + upimg3.FileName));
                    imgssrc += upimg3.FileName + "@";
                }
                else
                {
                    Jscript.Alert("图片格式不对");
                    return;
                }

            }
            else if ((upimg3.FileName.Length <= 0 && txtimg3.Text.Length > 0) || (upimg3.FileName.Length > 0 && txtimg3.Text.Length > 0))
            {
                imgssrc += txtimg3.Text.Substring(txtimg3.Text.LastIndexOf("/") + 1) + "@";
            }

            //img4
            if (upimg4.FileName.Length > 0 && txtimg4.Text.Length <= 0)
            {
                string filename = upimg4.FileName;
                string dotname = filename.Substring(filename.LastIndexOf(".") + 1);
                if (dotname.ToUpper() == "PNG" || dotname.ToUpper() == "JPG" || dotname.ToUpper() == "GIF" || dotname.ToUpper() == "BMP")
                {
                    upimg4.PostedFile.SaveAs(Server.MapPath("~/upload/images/" + upimg4.FileName));
                    imgssrc += upimg4.FileName + "@";
                }
                else
                {
                    Jscript.Alert("图片格式不对");
                    return;
                }

            }
            else if ((upimg4.FileName.Length <= 0 && txtimg4.Text.Length > 0) || (upimg4.FileName.Length > 0 && txtimg4.Text.Length > 0))
            {
                imgssrc += txtimg4.Text.Substring(txtimg4.Text.LastIndexOf("/") + 1) + "@";
            }


            model.Picture = imgssrc.Substring(0, imgssrc.Length - 1);//图片
            if (upomfile.FileName.Length > 0)
            {
                model.Att1 = upomfile.FileName;
                upomfile.PostedFile.SaveAs(Server.MapPath("~/upload/files/" + upomfile.FileName));
            }
            bool result;
            if (con == "add")
            {
                result = bll.GetDAL().Add(model);
            }
            else
            {
                result = bll.GetDAL().Update(model);
            }
            if (result )
            {
                Jscript.RedirectToFrames("Admin_PRO.aspx");
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