
$(".add-task-background").click(function () {
    $(".add-task-background").removeClass("active");
    $(".add-noterms-form").removeClass("active");
    $(".add-everyday-form").removeClass("active");
    $(".add-daily-form").removeClass("active");
    $(".input-validation-error").removeClass("input-validation-error");
});
$(".sign-out").click(function () {

});
$(".mobile-menu button").click(function () {
    var button = $(this).parent().attr("class");
    console.log(button);
    $(".mobile-menu .active").removeClass("active");
    $(this).addClass("active");
    $(".block-tables").attr("class", "row block-tables");
    $(".block-tables").addClass(button);
    setCookie("pos", button);
})
$(document).ready(function () {
    var pos = getCookie("pos");
    $(".block-tables").addClass(pos);
    $("." + pos + " button").addClass("active");
})