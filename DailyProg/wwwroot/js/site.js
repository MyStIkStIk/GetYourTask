$(".dailyBackground .block-tables .block-daily-tasks .block-add").click(function () {
    $(".add-task-background").addClass("active");
    $(".add-daily-form").addClass("active");
});
$(".dailyBackground .block-tables .block-everyday-tasks .block-add").click(function () {
    $(".add-task-background").addClass("active");
    $(".add-everyday-form").addClass("active");
});
$(".dailyBackground .block-tables .block-noterms-tasks .block-add").click(function () {
    $(".add-task-background").addClass("active");
    $(".add-noterms-form").addClass("active");
});
$(".add-task-tables .add-daily-form .block-close").click(function () {
    $(".add-task-background").removeClass("active");
    $(".add-daily-form").removeClass("active");
});
$(".add-task-tables .add-everyday-form .block-close").click(function () {
    $(".add-task-background").removeClass("active");
    $(".add-everyday-form").removeClass("active");
});
$(".add-task-tables .add-noterms-form .block-close").click(function () {
    $(".add-task-background").removeClass("active");
    $(".add-noterms-form").removeClass("active");
});
$(".add-task-background").click(function () {
    $(".add-task-background").removeClass("active");
    $(".add-noterms-form").removeClass("active");
    $(".add-everyday-form").removeClass("active");
    $(".add-daily-form").removeClass("active");
});
$(".dailyBackground .top-background .block-account .button").hover(function () {
    $(".account-info").addClass("active");
});
$(".block-tables").mouseover(function () {
    $(".account-info").removeClass("active");
});
$(".add-n-task").click(function () {
    var request = $(".n-task").serialize();
    GetData("CreateNTask", request);
});
function GetData(action, request) {
    $.ajax({
        type: "POST",
        url: "/Home/" + action,
        async: true,
        cache: false,
        timeout: 15000,
        data: request,
        success: function (data) {
            console.log(data);
            $(".add-task-background").removeClass("active");
            $(".add-noterms-form").removeClass("active");
            $(".add-everyday-form").removeClass("active");
            $(".add-daily-form").removeClass("active");
            AddTaskToNTask(data);
        },
        error: function (XML, status, error) {
            console.log(status);
        }
    });
}
function AddTaskToNTask(data) {
    let current = $("<div>");
    current.addClass("current-task");

    let p = $("<p>");
    p.text(data);
    let div = $("<div>");
    div.append(p);

    let div2 = $("<div>");
    div2.addClass("block-done");
    let button = $("<div>");
    button.addClass("button-done");
    div2.append(button);

    current.append(div);
    current.append(div2);

    $(".B-task").append(current);
}