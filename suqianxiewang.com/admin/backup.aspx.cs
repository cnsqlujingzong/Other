using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JRO;
public partial class admin_backup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// 备份
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        string DbPath1, DbPath2, DbName4DbPath2;

        DbName4DbPath2 = string.Format("{0:yyyyMMddhhmmss}", DateTime.Now);
        DbPath1 = Server.MapPath("/App_Data/DataBase.mdb");
        DbPath2 = Server.MapPath("/App_Data/" + DbName4DbPath2 + ".mdb");

        try
        {
            File.Copy(DbPath1, DbPath2, true);
            SiteD.Common.Jscript.Alert("备份成功");
        }
        catch
        {
            SiteD.Common.Jscript.Alert("数据库备份失败，请重试!"); 
        } 

    }
    //压缩
    protected void Button2_Click(object sender, EventArgs e)
    {
        string DbPath1, DbPath2, DbConn1, DbConn2;

        DbPath1 = Server.MapPath("/App_Data/DataBase.mdb");//原数据库路径 
        DbPath2 = Server.MapPath("/App_Data/DataBase2.mdb");//压缩后的数据库路径 
        DbConn1 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DbPath1;
        DbConn2 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DbPath2;

        try
        {
            JetEngine DatabaseEngin = new JetEngine();
            DatabaseEngin.CompactDatabase(DbConn1, DbConn2);//压缩 

            File.Copy(DbPath2, DbPath1, true);//将压缩后的数据库覆盖原数据库 
            File.Delete(DbPath2);//删除压缩后的数据库 

         SiteD.Common.Jscript.Alert( "数据库压缩成功!");
        }
        catch
        {
          SiteD.Common.Jscript.Alert( "数据库压缩失败，请重试!");
        } 

    }
}