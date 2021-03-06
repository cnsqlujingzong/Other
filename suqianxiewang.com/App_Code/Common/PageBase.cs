﻿using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Reflection;
using System.Text;
namespace SiteD.Common
{
	/// <summary>
	/// 页面层(表示层)基类,所有页面继承该页面
	/// </summary>
	public class PageBase:System.Web.UI.Page
	{	
		/// <summary>
		/// 构造函数
		/// </summary>
		public PageBase()
		{
            //this.Load+=new EventHandler(PageBase_Load);
		}
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new System.EventHandler(PageBase_Load);
            this.Error += new System.EventHandler(PageBase_Error);
        }
        //错误处理
        protected void PageBase_Error(object sender, System.EventArgs e)
        {
            string errMsg;
            Exception currentError = Server.GetLastError();
            errMsg = "<link rel=\"stylesheet\" href=\"/style.css\">";
            errMsg += "<h1>系统错误：</h1><hr/>系统发生错误， " +
                "该信息已被系统记录，请稍后重试或与管理员联系。<br/>" +
                "错误地址： " + Request.Url.ToString() + "<br/>" +
                "错误信息： <font class=\"ErrorMessage\">" + currentError.Message.ToString() + "</font><hr/>" +
                "<b>Stack Trace:</b><br/>" +  currentError.ToString();
            Response.Write(errMsg);
            Server.ClearError();

        }

        private void PageBase_Load(object sender, EventArgs e)
        {
            //SiteD.Model.USER user = (SiteD.Model.USER)Session["admin"];
            //if (user == null)
            //{
            //    Jscript.AlertAndRedirect("请先登陆！", "/admin/index.aspx");
            //}
        }
	}
}
