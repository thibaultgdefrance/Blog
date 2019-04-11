$(document).ready(function () {
    console.log("ok");


    var scrollTop = $(window).scrollTop();
    var nav = document.getElementById("navigation");
    elementOffset = $(nav).offset().top;
    var distance = (elementOffset - scrollTop);

    if (distance == 0) {
        nav.style.position = "fixed";
        nav.style.top = "0px";
    }
});