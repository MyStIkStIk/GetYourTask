$(".dailyBackground .block-tables .block-daily-tasks .block-add").click(function () {
    $(".add-task-background").addClass("active");
    $(".add-task-tables .add-daily-form").addClass("active");
});
$(".dailyBackground .block-tables .block-everyday-tasks .block-add").click(function () {
    $(".add-task-background").addClass("active");
    $(".add-task-tables .add-everyday-form").addClass("active");
});
$(".dailyBackground .block-tables .block-noterms-tasks .block-add").click(function () {
    $(".add-task-background").addClass("active");
    $(".add-task-tables .add-noterms-form").addClass("active");
});

$(".add-task-tables .add-daily-form .block-close").click(function () {
    $(".add-task-background").removeClass("active");
    $(".add-task-tables .add-daily-form").removeClass("active");
    $(".input-validation-error").removeClass("input-validation-error");
});
$(".add-task-tables .add-everyday-form .block-close").click(function () {
    $(".add-task-background").removeClass("active");
    $(".add-task-tables .add-everyday-form").removeClass("active");
    $(".input-validation-error").removeClass("input-validation-error");
});
$(".add-task-tables .add-noterms-form .block-close").click(function () {
    $(".add-task-background").removeClass("active");
    $(".add-task-tables .add-noterms-form").removeClass("active");
    $(".input-validation-error").removeClass("input-validation-error");
});