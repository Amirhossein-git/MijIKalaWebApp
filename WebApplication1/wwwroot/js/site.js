// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    var intervalreplacement = true;
    $(document).scroll(function () {
        if (window.scrollY >= 82) {
            $(".goto-top-btn").css("display", "initial");
        }
        else {
            $(".goto-top-btn").css("display", "none");
        }
    });
    $(".goto-top-btn").click(function () {
        $(".goto-top-btn").css("display", "none");
        window.scrollTo(0, 0);
    });
    //$(".home - div - products > button").click(window.location.href = "http://www.google.com";/*$(".home - div - products > button").children("img").attr("alt")*/
});