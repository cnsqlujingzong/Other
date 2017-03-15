$(document).ready(function () {

    $("#accorionHome").click(function () {
        $(".nav-top-item").removeClass('current');
        $(this).addClass('current');
     
    });
 
    $("#main-nav li ul").hide();
    $("#main-nav li a.current").parent().find("ul").slideToggle("slow");

    $("#main-nav li a.nav-top-item").click( 
			function () {
			    $(this).parent().siblings().find("ul").slideUp("normal"); 
			    $(this).next().slideToggle("normal"); 
			    return false;
			}
		);

    $("#main-nav li a.no-submenu").click( 
			function () {
			    window.location.href = (this.href); 
			    return false;
			}
		);
    $("#main-nav li .nav-top-item").hover(
			function () {
			    $(this).stop().animate({ paddingRight: "25px" }, 200);
			},
			function () {
			    $(this).stop().animate({ paddingRight: "15px" });
			}
		);

});

function openform() {
    window.open('ApplyForm.aspx', 'Form', 'height=500, width=400, top=0,left=0, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
}
function chageType(obj, boj2) {
    var accorion = document.getElementsByName("accorion")
    var check = document.getElementById(obj);
    if (accorion.length > 0) {
        for (var i = 0; i < accorion.length; i++) {
            accorion.item(i).className = "nav-top-item";
        }
        check.className = "nav-top-item current";
    }
    if (boj2 != "") {
        var three = document.getElementsByName("accorion_");
        var checkthree = document.getElementById(boj2);
        if (three.length > 0) {
            for (var ii = 0; ii < three.length; ii++) {
                three.item(ii).className = "";
            }
            checkthree.className = "current";
        }
    }

}


function keycode(e) {
    if (e.keyCode == 13) {
        document.getElementById("serchbutton").focus();
        document.getElementById("serchbutton").click();
    }

}