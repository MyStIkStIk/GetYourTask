$(".dailyBackground .block-tables .block-daily-tasks .table .block-add .button-add").click(function () {
    $(".add-task-background").addClass("active");
    $(".add-daily-form").addClass("active");
});
$(".dailyBackground .block-tables .block-everyday-tasks .table .block-add .button-add").click(function () {
    $(".add-task-background").addClass("active");
    $(".add-everyday-form").addClass("active");
});
$(".dailyBackground .block-tables .block-noterms-tasks .table .block-add .button-add").click(function () {
    $(".add-task-background").addClass("active");
    $(".add-noterms-form").addClass("active");
});
$(".add-task-background .add-daily-form .block-close .button-close").click(function () {
    $(".add-task-background").removeClass("active");
    $(".add-daily-form").removeClass("active");
});
$(".add-task-background .add-everyday-form .block-close .button-close").click(function () {
    $(".add-task-background").removeClass("active");
    $(".add-everyday-form").removeClass("active");
});
$(".add-task-background .add-noterms-form .block-close .button-close").click(function () {
    $(".add-task-background").removeClass("active");
    $(".add-noterms-form").removeClass("active");
});
