
     $(document).ready(function () {
         $(".check").each(function () {
             $(this).click(function () {
                 // alert($(".check :checked").length + "\n" + $(".check").length);
                 if ($(".check :checked").length == $(".check").length) {

                     $("#checkAll").attr("checked", "checked");
                 }
                 else {
                     $("#checkAll").removeAttr("checked");
                 }
             });
         });


       


     });


     function GetAllCheckBox(CheckAll) {
         var items = document.getElementsByTagName("input");
         for (var i = 0; i < items.length; i++) {
             if (items[i].type == "checkbox") {
                 items[i].checked = CheckAll.checked;
             }
         }
     }

