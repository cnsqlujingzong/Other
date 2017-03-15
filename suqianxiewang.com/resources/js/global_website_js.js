

$(document).ready(function ()
{
 autoMaxWidth.ini();
});

$(window).load(function ()
{
	 autoMaxWidth.ini();
	 $(window).resize(function ()
    {
        autoMaxWidth.ini();
    });
     
});

var autoMaxWidth = {};
autoMaxWidth.ini = function ()
{
    var winW = $(window).width();
    if (winW < 980) 
        winW = 980;
    $('.autoMaxWidth').each(function ()
    {
        $(this).width(winW);
        var $img = $('img', this).first();
        var imgW = $img.width();
        var left = (winW - imgW) / 2;
        $img.css({ "left": left + "px", "position": "relative" });
        if ($.browser.msie && parseInt($.browser.version) == 6) 
        {
            $(this).css({
                'overflow': 'hidden',
                'position': 'relative'
            }).width(winW);
            $('#banner').css({
                'overflow': 'hidden',
                'position': 'relative'
            }).width(winW);
        }
        
    });
}

    
