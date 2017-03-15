using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SITED.NEWS;
public partial class Master_News_Del : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"];
        string type = Request.QueryString["type"];
        if (type == "0")//文章类型
        {
            FNEWS_TYPE fnt = new FNEWS_TYPE();
            fnt.GetDAL().Delete(Convert.ToInt32(id));           
            Jscript.RedirectToFrames("Admin_NewsType.aspx");
        }
        else //文章
        {

        }
    }
}