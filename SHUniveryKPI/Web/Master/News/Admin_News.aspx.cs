using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SITED.NEWS;

public partial class Master_News_Admin_News : SITED.COMMON.PageBase
{
       protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RP_con.DataSource = GetData("");
                RP_con.DataBind();
                HY_AddNews.NavigateUrl = "Admin_News_Add.aspx?lang=cn&con=add&cid=NAN";
                BindNewsType("cn");
                DD_Type.Items.Insert(0, new ListItem("查看全部", "0"));
            }
           
        }
        /// <summary>
        /// 绑定新闻类型
        /// </summary>
        /// <param name="lang"></param>
        private void BindNewsType(string lang)
        {
            FNEWS_TYPE fnt=new FNEWS_TYPE ();           
            DD_Type.DataSource = fnt.GetDAL().GetList(" Lang='"+lang+"'");
            DD_Type.DataTextField = "TypeName";
            DD_Type.DataValueField = "ID";
            DD_Type.DataBind();        
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        private DataSet GetData(string strWhere)
        {   
            FNews news = new FNews();
            return news.GetDAL().GetList(strWhere);
        }
        /// <summary>
        /// 切换语言
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RP_con.DataSource = GetData(" [Language] ='" + DL_lang.SelectedValue + "'");
            RP_con.DataBind();
            HY_AddNews.NavigateUrl = "Admin_News_Add.aspx?lang=" + DL_lang.SelectedValue + "&con=add&cid=NAN";
            BindNewsType(DL_lang.SelectedValue);
        }
          /// <summary>
          /// 获取发布状态图片
          /// </summary>
          /// <param name="flag"></param>
          /// <returns></returns>
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
        /// <summary>
        /// 根据标题搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string strCodition = txtCondition.Text;
            FNews fnews = new FNews();
            string sql = " 1=1 ";
            if(strCodition.Trim().Length>0)
            {
                sql+=" and [Title] like '%" + strCodition + "%'";
            }
            if(DD_Type.SelectedValue !="0")
            {
                sql += " and News_Type="+DD_Type.SelectedValue;
            }
            sql += " and [Language]= '" + DL_lang.SelectedValue + "'";
            RP_con.DataSource = fnews.GetDAL().GetList(sql);
            RP_con.DataBind();
        }
        /// <summary>
        /// 切换新闻类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DD_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            FNews fnews = new FNews();
            string sql = " [Language]= '" + DL_lang.SelectedValue + "'";
            if(DD_Type.SelectedValue !="0")
            {
                sql += " and News_Type =" + DD_Type.SelectedValue ;
            }
            RP_con.DataSource = fnews.GetDAL().GetList(sql);
            RP_con.DataBind();

        }
        /// <summary>
        /// 删除所选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LB_Del_Click(object sender, EventArgs e)
        {
            FNews fnews = new FNews();
            string sb = string.Empty;
            for (int i = 0; i < this.RP_con.Items.Count; i++)
            {
                CheckBox cb = (RP_con.Items[i].FindControl("CheckBox1_")) as CheckBox;
                if (cb.Checked == true)
                {
                   string cid= ((RP_con.Items[i].FindControl("HiddenField_")) as HiddenField).Value;                  
                       sb += cid + ",";   
                }
            }
            fnews.GetDAL().DeleteMuli(sb);
            Jscript.RedirectToFrames("Admin_News.aspx");
        }
       /// <summary>
       /// 保存顺序
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        protected void OrderBy_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.RP_con.Items.Count; i++)
            {
               FNews fnews = new FNews();
               string id= ((RP_con.Items[i].FindControl("HiddenField_")) as HiddenField).Value;
               string orderby = ((RP_con.Items[i].FindControl("txtOrderBy")) as TextBox).Text;
               if (SITED.COMMON.PageValidate.IsNumber(orderby))
               {
                   SITED.NEWS.Model.ENEWS eNews= fnews.GetDAL().GetModel(Convert.ToInt32(id));
                   eNews.OrderBy = orderby;
                   fnews.GetDAL().Update(eNews);
               }
            }
            Jscript.RedirectToFrames("Admin_News.aspx");
        }
        /// <summary>
        /// 获取文章类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string GetNewsType(string id)
        {
            try
            {
                FNEWS_TYPE fnt = new FNEWS_TYPE();
                return fnt.GetDAL().GetModel(Convert.ToInt32(id)).TypeName;
            }
            catch 
            { 
                return "";
            }
        }
    }