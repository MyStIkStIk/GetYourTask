$(".login-btn").click(function () {
    $(".login-form").addClass("active");
    $(".register-form").removeClass("active");
});
$(".register-btn").click(function () {
    $(".register-form").addClass("active");
    $(".login-form").removeClass("active");
});