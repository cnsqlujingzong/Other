using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SITED.FILE;
public partial class Master_ImgLib_AImglib : SITED.COMMON.PageBase
{
    string id;
    protected void Page_Load(object sender, EventArgs e)
    {
        id=Request.QueryString["tid"];
        HF_typeid.Value=id;
        if (id != null && id != "")
        {
            FImg_Lib_Type bll = new FImg_Lib_Type();
            LB_imgType.Text = bll.GetDAL().GetModel(Convert.ToInt32(id)).La_NAME; ;
            BindData(id);
        }
    }
    protected void BindData(string id)
    { 
        FImg_Lib bll=new FImg_Lib ();
        RP_img.DataSource = bll.GetDAL().GetList("P_ImgLibrary="+id);
        RP_img.DataBind();
       
    }
}