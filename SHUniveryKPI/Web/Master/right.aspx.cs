using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Management;
public partial class Master_right : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpBrowserCapabilities b=Request.Browser;
        lb_ip.Text = Request.UserHostAddress;
        lb_os.Text = System.Environment.OSVersion.VersionString;
        lb_ex.Text = b.Type;
        lb_exver.Text = b.Version;
        lb_iis.Text = Request.ServerVariables["SERVER_SOFTWARE"];
        lb_sname.Text = Environment.MachineName;
        lb_netver.Text = System.Environment.Version.ToString();

    }
}