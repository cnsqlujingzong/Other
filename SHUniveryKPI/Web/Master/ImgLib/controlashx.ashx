<%@ WebHandler Language="C#" Class="controlashx" %>

using System;
using System.Web;
using SITED.FILE;
using SITED.COMMON;
using System.Web.SessionState;
public class controlashx : IHttpHandler,IRequiresSessionState {
    
    public void ProcessRequest (HttpContext context) {
         // context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        SITED.COMMON.Model.USER user = (SITED.COMMON.Model.USER)context.Session["admin"];
        if (user == null)
        {
            Jscript.AlertAndRedirect("请先登陆！", "/Master/index.aspx");
        }
        else
        {
            string flag = context.Request.QueryString["flag"];
            string id = context.Request.QueryString["id"];
            string pid = context.Request.QueryString["lib"];
            if (flag == "img")
            {
                if (delimg(id))
                {
                    Jscript.RedirectToFrames("AImglib.aspx?tid=" + pid);

                }
            }
            else if (flag == "lib")
            {
                if (editlib(id, pid))
                {
                    Jscript.RedirectToFrames("AImglibType.aspx");
                }
            }
            else if (flag == "libd")
            {
                if (editlibd(id, pid))
                {
                    Jscript.RedirectToFrames("AImglibType.aspx");
                }
            }
            else if (flag == "addlib")
            {
                if (addlib(pid))
                {
                    Jscript.RedirectToFrames("AImglibType.aspx");
                }
            }
        }
    }
 
    public bool IsReusable 
    {
        get {
            return false;
        }
    }
    /// <summary>
    /// 删除照片
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool delimg(string id)
    {
        FImg_Lib bll = new FImg_Lib();
       return  bll.GetDAL().Delete(Convert.ToInt32(id));    
    }
    /// <summary>
    /// 修改照片分类名
    /// </summary>
    /// <param name="id"></param>
    /// <param name="libName"></param>
    /// <returns></returns>
    public bool editlib(string id, string libName)
    {
        FImg_Lib_Type bll = new FImg_Lib_Type();
        EImg_Lib_Type model = bll.GetDAL().GetModel(Convert.ToInt32(id));
        model.La_NAME = libName;
        return bll.GetDAL().Update(model);
    }
    /// <summary>
    /// 修改照片分类描述
    /// </summary>
    /// <param name="id"></param>
    /// <param name="libName"></param>
    /// <returns></returns>
    public bool editlibd(string id, string libdesc)
    {
        FImg_Lib_Type bll = new FImg_Lib_Type();
        EImg_Lib_Type model = bll.GetDAL().GetModel(Convert.ToInt32(id));
        model.La_Dec = libdesc;
        return bll.GetDAL().Update(model);
    }
    /// <summary>
    /// 增加分类
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public bool addlib(string name)
    {
        FImg_Lib_Type bll = new FImg_Lib_Type();
        EImg_Lib_Type model = new EImg_Lib_Type();
        model.La_NAME = name;
      return  bll.GetDAL().Add(model);
    }
}