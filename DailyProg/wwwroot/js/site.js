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



//$(".dailyBackground .block-tables .block-daily-tasks .current-task .done-button").click(function () {
//    var txt = $(this).prev().prev().prev().find("p");
//    $(this("#TaskID")).val(txt.attr("task-id"));
//    $(this("#Done")).val(txt.attr("done"));
//});
//$(".dailyBackground .block-tables .block-everyday-tasks .current-task .done-button").click(function () {
//    var txt = $(this).prev().prev().prev().find("p");
//    $(this("#TaskID")).val(txt.attr("task-id"));
//    $(this("#Done")).val(txt.attr("done"));
//});
//$(".dailyBackground .block-tables .block-noterms-tasks .current-task .done-button").click(function () {
//    var txt = $(this).prev().prev().prev().find("p");
//    $(".dailyBackground .block-tables .block-noterms-tasks .current-task #TaskID").val(txt.attr("task-id"));
//    $(".dailyBackground .block-tables .block-noterms-tasks .current-task #Done").val(txt.attr("done"));
//});

$(".add-task-background").click(function () {
    $(".add-task-background").removeClass("active");
    $(".add-noterms-form").removeClass("active");
    $(".add-everyday-form").removeClass("active");
    $(".add-daily-form").removeClass("active");
    $(".input-validation-error").removeClass("input-validation-error");
});
$(".dailyBackground .top-background .block-account .button").hover(function () {
    $(".account-info").addClass("active");
});
$(".block-tables").mouseover(function () {
    $(".account-info").removeClass("active");
});