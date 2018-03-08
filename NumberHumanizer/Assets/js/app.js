$(function () {

    function showInputPanel() {
        $(".input-container").addClass("active");
        $(".input-container input, .input-container textarea").val('');
        $(".output-container").removeClass("active");
    }

    function showOutputPanel(result) {
        $(".input-container").removeClass("active");
        $(".validation-summary-errors").addClass("hidden");
        $(".output-container").removeClass("invisible").addClass("active");
        $(".output-container .tryagain").on("click",
            function() {
                showInputPanel();
            });
        $(".output-container .output-container__number").html(result.Result.Text);
        $(".output-container .output-container__username").html('Hey, ' + result.Result.Name);
    }

    $(".input-container #mainform").on("submit", function (e) {

        var isValid = this.checkValidity();

        //$(".input-container input, .input-container textarea").each(function() {
        //    if (!this.checkValidity()) {
        //        isValid = false;
        //    }
        //});

        if (!isValid) {
            e.preventDefault();
            return;
        }

        var name = $(".input-container input[name=Name]").val();
        var number = $(".input-container textarea[name=Number]").val();
        $.post("/api/Number/Transform", { Name: name, Number: number })
         .done(function (result) {
                if (result.IsSuccess) {
                    showOutputPanel(result);
                } else {
                    $(".validation-summary-errors").removeClass("hidden").html("Error: " + result.ErrorMessage);
                }
         });

        e.preventDefault();
    });
});