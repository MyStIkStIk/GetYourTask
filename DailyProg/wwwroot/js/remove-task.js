$(".dailyBackground .block-tables .block-daily-tasks .current-task .close-button").click(function () {
    $(".add-task-background").addClass("active");
    $(".delete-task-tables .add-daily-form").addClass("active");
    var txt = $(this).prev().prev().find("p");
    $(".delete-task-tables .add-daily-form label").text(txt.text());
    $(".delete-task-tables .add-daily-form #TaskID").val(txt.attr("task-id"));
});
$(".dailyBackground .block-tables .block-everyday-tasks .current-task .close-button").click(function () {
    $(".add-task-background").addClass("active");
    $(".delete-task-tables .add-everyday-form").addClass("active");
    var txt = $(this).prev().prev().find("p");
    console.log(txt.text())
    $(".delete-task-tables .add-everyday-form label").text(txt.text());
    $(".delete-task-tables .add-everyday-form #TaskID").val(txt.attr("task-id"));
});
$(".dailyBackground .block-tables .block-noterms-tasks .current-task .close-button").click(function () {
    $(".add-task-background").addClass("active");
    $(".delete-task-tables .add-noterms-form").addClass("active");
    var txt = $(this).prev().prev().find("p");
    $(".delete-task-tables .add-noterms-form label").text(txt.text());
    $(".delete-task-tables .add-noterms-form #TaskID").val(txt.attr("task-id"));
});

$(".delete-task-tables .add-daily-form .block-close").click(function () {
    $(".add-task-background").removeClass("active");
    $(".delete-task-tables .add-daily-form").removeClass("active");
    $(".input-validation-error").removeClass("input-validation-error");
});
$(".delete-task-tables .add-everyday-form .block-close").click(function () {
    $(".add-task-background").removeClass("active");
    $(".delete-task-tables .add-everyday-form").removeClass("active");
    $(".input-validation-error").removeClass("input-validation-error");
});
$(".delete-task-tables .add-noterms-form .block-close").click(function () {
    $(".add-task-background").removeClass("active");
    $(".delete-task-tables .add-noterms-form").removeClass("active");
    $(".input-validation-error").removeClass("input-validation-error");
});