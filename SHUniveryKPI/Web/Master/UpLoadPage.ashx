<%@ WebHandler Language="C#" Class="UpLoadPage" %>

using System;
using System.Web;
using System.IO;
using SITED.FILE;
public class UpLoadPage : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";        
        HttpPostedFile file = context.Request.Files["FileData"];
        string uploadpath = context.Server.MapPath(context.Request["folder"] + "\\");
        string tid =HttpUtility.HtmlEncode(context.Request.QueryString["tid"]);
        if (file != null)
        {
            if (!Directory.Exists(uploadpath))
            {
                Directory.CreateDirectory(uploadpath);
            }
            string fileNew = CreateRandomCode(25)+file.FileName.Substring(file.FileName.LastIndexOf("."));// ;
            file.SaveAs(uploadpath + fileNew);
            EImg_Lib model = new EImg_Lib();
            model.P_ImgLibrary = Convert.ToInt32(tid);
            model.SRC = fileNew;
            FImg_Lib bll = new FImg_Lib();
            bll.GetDAL().Add(model);
            context.Response.Write("1");
        }
        else
        {
           context.Response.Write("0");
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    private string CreateRandomCode(int codeCount)
    {
        string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,i,J,K,M,N,P,Q,R,S,T,U,W,X,Y,Z";
        string[] allCharArray = allChar.Split(',');
        string randomCode = "";
        int temp = -1;

        Random rand = new Random();
        for (int i = 0; i < codeCount; i++)
        {
            
                if (temp != -1)
                {
                    rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(32);
                if (temp == t)
                {
                    return CreateRandomCode(codeCount);//性能问题
                }
                temp = t;
                randomCode += allCharArray[t];
         
        }
        return randomCode;
    }
}