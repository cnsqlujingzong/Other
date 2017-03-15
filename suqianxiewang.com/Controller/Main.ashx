<%@ WebHandler Language="C#" Class="Main" %>

using System;
using System.Web;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Web.Script.Serialization;
public class Main : IHttpHandler,System.Web.SessionState.IRequiresSessionState {
    private static readonly JavaScriptSerializer jss = new JavaScriptSerializer();
    Dictionary<string, string> r;
    CardsBiz card ;
    OrderBiz order ;
    public void ProcessRequest (HttpContext context)
    {
        context.Response.AppendHeader("Connection", "keep-alive");
        context.Response.ContentType = "text/javascript";
        NameValueCollection Parms = context.Request.Form;
                   r = new Dictionary<string, string>();
        string method = context.Request.Form["m"];
        try
        {
            switch (method)
            {
                case "vcard":
                    string result = VCard(Parms);
                    context.Response.Write(result);
                    break;
                case "addorder":
                    string save = AddOrder(Parms);
                    context.Response.Write(save);
                    break;
                case "report":
                    string data = VCard(Parms);
                    context.Response.Write(data);
                    break;
            }
        }
        catch (Exception e)
        {    
                r.Add("r","-1");
                    r.Add("msg",e.Message);
                 context.Response.Write( jss.Serialize(r));
        }

        context.Response.End();
    }

       
    
    public bool IsReusable {
        get {
            return false;
        }
    }
    #region VCard


    //验证卡号
    public string VCard(NameValueCollection parms)
    {
       
        string num = parms["cardNum"].Trim();
        string pwd = parms["cardPwd"].Trim();
        string code = parms["vcode"].Trim();
        r = CheckVCard(num, pwd, code); 
        return jss.Serialize(r);
    }
    
    //提交订单
 public string AddOrder(NameValueCollection parms)
{
   string orderinfo = parms["order"];
   orderInfo info = jss.Deserialize<orderInfo>(orderinfo);
   r = CheckVCard(info.cardNum,info.cardPwd,"",true);
   if (r["r"] == "0")
   {
      r= CheckInfo(info);
      if (r["r"] != "0")
      {
          return jss.Serialize(r);
      }
       r = new Dictionary<string, string>();
       order = new OrderBiz();
       string oid = string.Format("{0:yyyyMMddHHmmss}", DateTime.Now) + CommonUtils.RandomCode.Number(4);
       order.OrderID = oid;
       order.CardNum = info.cardNum.Trim();
       order.OrderSate = 0;
       order.Mobile = info.phone.Trim();
       order.DName = info.pname.Trim();
       order.Sheng = info.provin2.Trim();
       order.Shi = info.city2.Trim();
       order.Address = info.address.Trim();
       order.CreatTime = DateTime.Now;
       card = new CardsBiz();
       card.GetModel(info.cardNum,info.cardPwd);
       card.UseState=1;
       bool isuse= card.Update();
       if (isuse)//提货券状态修改成功==>增加订单
       {
          int i= order.Add();
          if (i >= 0)//订单添加成功
          {
              r.Add("r", "0");
              r.Add("oid", oid);
          }
          else {
              card.UseState = 0;//订单失败 提货券状态改回
              card.Update();
              r.Add("r", "-1");
              r.Add("msg", "订单提交失败，请稍后再试");
          }
       }
       else {        
           r.Add("r","-1");
           r.Add("msg", "提货券验证失败请稍后重试");
       }
       return jss.Serialize(r);
   }
   else {
       return jss.Serialize(r);
   }
}

 public Dictionary<string, string> CheckInfo(orderInfo info)
 {
     r = new Dictionary<string, string>();
     if (string.IsNullOrEmpty(info.pname))
     {
         r.Add("r", "-1");
         r.Add("msg", "请输入收货人姓名");
         return r;
     }
     if (string.IsNullOrEmpty(info.phone))
     {
         r.Add("r", "-1");
         r.Add("msg", "请输入手机号");
         return r;
     }
     if (!CommonUtils.RegExpUtil.Isphone(info.phone))
     {
         r.Add("r", "-1");
         r.Add("msg", "请输入正确的手机号");
         return r;
     }
     if (info.provin=="-2")
     {
         r.Add("r", "-1");
         r.Add("msg", "请选择省份");
         return r;
     }
     if (string.IsNullOrWhiteSpace(info.address))
     {
         r.Add("r", "-1");
         r.Add("msg", "请输入收货地址");
         return r;
     }
     r.Add("r", "0");
     return r;
 }

    public  Dictionary<string, string> CheckVCard(string num,string pwd,string code,bool isOrder=false)
    {
        r = new Dictionary<string, string>();
        if (string.IsNullOrEmpty(num))
        {
            r.Add("r","-1");
            r.Add("msg","请输入提货卡卡号");
            return r;
        }
        if (string.IsNullOrEmpty(pwd))
        {
            r.Add("r","-1");
            r.Add("msg","请输入提货卡密码");
            return r;
        }
        if (!isOrder)
        {
            if (string.IsNullOrEmpty(code))
            {
                r.Add("r", "-1");
                r.Add("msg", "请输入验证码");
                return r;
            }
            if (HttpContext.Current.Session["CheckCode"] == null)
            {
                r.Add("r", "-1");
                r.Add("msg", "验证码不正确");
                return r;
            }
            string scode = (string)HttpContext.Current.Session["CheckCode"];
            if (scode.ToLower() != code.ToLower())
            {
                r.Add("r", "-1");
                r.Add("msg", "验证码不正确");
                return r;
            }
        }
        card = new CardsBiz();
        r = new Dictionary<string, string>();
        card.GetModel(num, pwd);
        if (string.IsNullOrEmpty(card.CardNum))//为空未找到
        {
            r.Add("r", "-1"); r.Add("msg", "提货券信息不正确"); return r;
        }
        else
            if (!string.IsNullOrEmpty(card.CardNum) && card.UseState == 1)
            {
                r.Add("r", "-1"); r.Add("msg", "提货券已经被使用"); return r;
            }
            else
                if (!string.IsNullOrEmpty(card.CardNum) && card.UseState == 0)
                {
                    r.Add("r", "0");
                    r.Add("cardType", card.CardType.ToString());
                    return r;
                }
                else
                {
                    r.Add("r", "-1");
                    r.Add("msg", "未知错误，请稍后再试");
                    return r;
                }
    }
    #endregion
}
public class orderInfo
{
    public string cardNum { get; set; }
    public string cardPwd { get; set; }
    public string pname { get; set; }
    public string phone { get; set; }
    public string provin { get; set; }
    public string city { get; set; }
    public string address { get; set; }
    public string provin2 { get; set; }
    public string city2 { get; set; }
}