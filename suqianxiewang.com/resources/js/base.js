//标记
function getnow() {
    var myDate = new Date();
    var now = myDate.getTime();
    var st = encodeURI(window.location.pathname);
    st = st.replace(/\//g, "-");
    st = st.replace(/\./g, "_");
    now = st + now;
    return now;
}
//post请求
function Post(src,param, callback) {
    var cb = arguments[arguments.length - 1];
    $.post(src + "?v=" + getnow(), param, function (data) {
            if (cb)
            {
                cb(data);
            }
      
    }, "json");    
}
//get请求
function Get(src,param, callback) {
    var cb = arguments[arguments.length - 1];
    var msg = $.getJSON(src + "?v=" + getnow(), param, function (data) {
        if (data) {         
            if (cb) {
                cb(data);
            }
        }       
 });

}
//json to boject
function JSON2Obj(json) {
    var obj;
    if (json) {
        obj = eval("(" + json + ")");
        return obj;
    } else {
        return null;
    }
   
}
//手机验证
function phoneRegex (val) {
    var regex = /^1[3|4|5|7|8][0-9]\d{8}$/;
    if (!regex.test(val)) {
        return false;
    }
    return true;
}
//获取URL参数
function getQueryString (value)
{
    var reg = new RegExp("(^|&)" + value + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) {
        return unescape(r[2]);
    } else {
        return null;
    }

}

function ShowModal()
{
    $("#modal-bg").show();
    $("#modal-show").show();
}
function HideModal() {
    $("#modal-bg").hide();
    $("#modal-show").hide();
}

function isNull(obj) {
    if (typeof (obj) == "undefined")
        return true;
    if (obj == undefined)
        return true;
    if (obj == null)
        return true;
    if (obj === "")
        return true;
    return false;
}

//判断客户端
function IsPC() {
    var userAgentInfo = navigator.userAgent;
    var Agents = new Array("Android", "iPhone", "SymbianOS", "Windows Phone", "iPad", "iPod");
    var flag = true;
    for (var v = 0; v < Agents.length; v++) {
        if (userAgentInfo.indexOf(Agents[v]) > 0) { flag = false; break; }
    }
    return flag;
}