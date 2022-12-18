$(".dailyBackground .block-tables .block-daily-tasks .current-task .change-button").click(function () {
    $(".add-task-background").addClass("active");
    $(".change-task-tables .add-daily-form").addClass("active");
    var txt = $(this).prev().find("p");
    $(".change-task-tables .add-daily-form #Task").val(txt.text());
    $(".change-task-tables .add-daily-form #TaskID").val(txt.attr("task-id"));
    $(".change-task-tables .add-daily-form #Time").val(txt.attr("time"));
});
$(".dailyBackground .block-tables .block-everyday-tasks .current-task .change-button").click(function () {
    $(".add-task-background").addClass("active");
    $(".change-task-tables .add-everyday-form").addClass("active");
    var txt = $(this).prev().find("p");
    $(".change-task-tables .add-everyday-form #Task").val(txt.text());
    $(".change-task-tables .add-everyday-form #TaskID").val(txt.attr("task-id"));
    $(".change-task-tables .add-everyday-form #Time").val(txt.attr("time"));
});
$(".dailyBackground .block-tables .block-noterms-tasks .current-task .change-button").click(function () {
    $(".add-task-background").addClass("active");
    $(".change-task-tables .add-noterms-form").addClass("active");
    var txt = $(this).prev().find("p");
    $(".change-task-tables .add-noterms-form #Task").val(txt.text());
    $(".change-task-tables .add-noterms-form #TaskID").val(txt.attr("task-id"));
});

$(".change-task-tables .add-daily-form .block-close").click(function () {
    $(".add-task-background").removeClass("active");
    $(".change-task-tables .add-daily-form").removeClass("active");
    $(".input-validation-error").removeClass("input-validation-error");
});
$(".change-task-tables .add-everyday-form .block-close").click(function () {
    $(".add-task-background").removeClass("active");
    $(".change-task-tables .add-everyday-form").removeClass("active");
    $(".input-validation-error").removeClass("input-validation-error");
});
$(".change-task-tables .add-noterms-form .block-close").click(function () {
    $(".add-task-background").removeClass("active");
    $(".change-task-tables .add-noterms-form").removeClass("active");
    $(".input-validation-error").removeClass("input-validation-error");
});