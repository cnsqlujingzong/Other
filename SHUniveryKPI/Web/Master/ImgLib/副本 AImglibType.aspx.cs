using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SITED.FILE;
public partial class Master_ImgLib_AImglibType : SITED.COMMON.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindData();
    }
    protected void BindData()
    {
        FImg_Lib_Type filt = new FImg_Lib_Type();
        RP_imgtype.DataSource= filt.GetDAL().GetList("");
        RP_imgtype.DataBind();
    }
    protected string GetCoverImg(string typeid)
    {
        FImg_Lib bll = new FImg_Lib();
        EImg_Lib model = bll.GetDAL().GetModel(" P_ImgLibrary=" + typeid);
        if (model != null)
        {
            return "../../upload/Img_Lib/"+model.SRC;
        }
        else
        {
            return "../../img/no_photo.png";
        }
    }
}