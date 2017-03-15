using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SITED.PRODUCT;
using SITED.PRODUCT.Model;
using System.Data;
public partial class Master_Pro_Admin_PRO : System.Web.UI.Page
{
      FPRO bll_fpo=new FPRO ();
      FPRO_TYPE bll_ftype=new FPRO_TYPE ();
     protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RP_con.DataSource = GetData(" [Language]='cn'");
                RP_con.DataBind();
                HY_AddPros.NavigateUrl = "ProsManage.aspx?lang=cn&con=add&cid=NAN";
                BindProsType("cn");
            }
            DD_Type.Items.Insert(0,new ListItem("查看所有","0"));
        }
        /// <summary>
        /// 绑定 产品类型
        /// </summary>
        /// <param name="lang"></param>
        private void BindProsType(string lang)
        {          
            DD_Type.DataSource = bll_ftype.GetDAL().GetList(" [Language]='" + lang + "'");
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
            return bll_fpo.GetDAL().GetList(strWhere);
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
            HY_AddPros.NavigateUrl = "ProsManage.aspx?lang=" + DL_lang.SelectedValue + "&con=add&cid=NAN";
            BindProsType(DL_lang.SelectedValue);

        
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
        /// 根据产品名称搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string strCodition = txtCondition.Text;          
            string sql = " 1=1 ";
            if (strCodition.Trim().Length > 0)
            {
                sql += " and ([PName] like '%" + strCodition + "%' or [PModel] like '%" + strCodition + "%') ";
            }
            if (DD_Type.SelectedValue != "0")
            {
                sql += " and PType=" + DD_Type.SelectedValue;
            }
            sql += " and [Language]= '" + DL_lang.SelectedValue + "'";
            RP_con.DataSource = bll_fpo.GetDAL().GetList(sql);
            RP_con.DataBind();
        }
        /// <summary>
        /// 切换产品类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DD_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = " [Language]= '" + DL_lang.SelectedValue + "' ";
            if (DD_Type.SelectedValue != "0")
            {
                sql += " and  PType =" + DD_Type.SelectedValue;
            }
            RP_con.DataSource = bll_fpo.GetDAL().GetList(sql);
            RP_con.DataBind();

        }
        /// <summary>
        /// 删除所选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LB_Del_Click(object sender, EventArgs e)
        {
            string sb = string.Empty;
            for (int i = 0; i < this.RP_con.Items.Count; i++)
            {
                CheckBox cb = (RP_con.Items[i].FindControl("CheckBox1_")) as CheckBox;
                if (cb.Checked == true)
                {
                    sb += ((RP_con.Items[i].FindControl("HiddenField_")) as HiddenField).Value + ",";

                }
            }
            bll_fpo.GetDAL().DeleteMuli(sb);
            Jscript.RedirectToFrames("Admin_PRO.aspx");
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
               string id= ((RP_con.Items[i].FindControl("HiddenField_")) as HiddenField).Value;
               string orderby = ((RP_con.Items[i].FindControl("txtOrderBy")) as TextBox).Text;
               if (SITED.COMMON.PageValidate.IsNumber(orderby))
               {
                   EPRO epo=  bll_fpo.GetDAL().GetModel(Convert.ToInt32(id));
                   epo.OrderBy =Convert.ToInt32(orderby);
                   bll_fpo.GetDAL().Update(epo);
               }
               else 
               {
                   Jscript.Alert("顺序只能为数字！");
               }
            }
            Jscript.RedirectToFrames("Admin_PRO.aspx");
        }
        /// <summary>
        /// 获取类型名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string GetProTypeName(string id)
        {
           return bll_ftype.GetDAL().GetModel(Convert.ToInt32(id)).TypeName;
     
        }
    }
