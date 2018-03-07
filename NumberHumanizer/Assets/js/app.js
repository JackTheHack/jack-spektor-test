$(function () {

    function showInputPanel() {
        $(".input-container").addClass("active");
        $(".input-container input, .input-container textarea").val('');
        $(".output-container").removeClass("active");
    }

    function showOutputPanel(result) {
        $(".input-container").removeClass("active");
        $(".output-container").removeClass("invisible").addClass("active");
        $(".output-container .tryagain").on("click",
            function() {
                showInputPanel();
            });
        $(".output-container .output-container__number").html(result.Result.Text);
        $(".output-container .output-container__username").html('Hey, ' + result.Result.Name);
    }

    $(".input-container button").on("click", function() {
        var name = $(".input-container input[name=Name]").val();
        var number = $(".input-container textarea[name=Number]").val();
        $.post("/api/Number/Transform",
            { Name: name, Number: number })
         .done(function (result) {
                if (result.IsSuccess) {
                    showOutputPanel(result);
                } else {
                    //TODO: Error message handling
                }
            });
    });
});