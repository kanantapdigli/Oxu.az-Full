
$(function () {

    $(".preloader-container").fadeOut(1000);
    $("body").css("overflow", "visible");

    let totalWidth = $(".lent a").length * 100;

    $(".lent").css("width", totalWidth + "%");


    let imgCount = $(".lent a").length;

    let width = $(".frame").width();


    let position = 0;



    $(document).on("click", ".arrow-right", function () {


        if (position >= (imgCount - 1) * width) {
            $(".lent").css("right", 0)

            position = 0;
        } else {
            position = position + width

            $(".lent").css("right", position);
        }
    })

    $(document).on("click", ".arrow-left", function () {

        if (position < width) {

            $(".lent").css("right", (imgCount - 1) * width)

            position = (imgCount - 1) * width;

        } else {

            position = position - width

            $(".lent").css("right", position);

        }

    })

    window.setInterval(() => {
        if (position >= (imgCount - 1) * width) {
            $(".lent").css("right", 0)

            position = 0;

        } else {
            position = position + width

            $(".lent").css("right", position);
        }
    }, 5000)

    $(".title").css("max-width", width);
    $(".lent a").css("width", width);


    $(document).on("click", ".bar", function () {

        if ($(".burger-menu").css("visibility") === "hidden") {
            $(".burger-menu").css({
                "left": "0",
                "visibility": "visible"
            });
        } else {
            $(".burger-menu").css({
                "left": "-230px",
                "visibility": "hidden"
            });
        }

    })

    $(".custom-file-input").on("change", function () {
        var fileName = $(this).val().split("\\").pop();
        $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
    });

    $(window).scroll(function () {
        var height = $(window).scrollTop();

        if (height > $('header').outerHeight()) {
            $('header').addClass('fixed');
            $('.nav').css({ "top": "-300px", "z-index": "-1"});
            $('.bar-scroll').css("z-index", "1")
        } else {
            $('header').removeClass('fixed');
            $('.nav').css({ "top": "0", "z-index": "0" });
            $('.bar-scroll').css("z-index", "-1")
        }
    });

    $(document).on("click", ".bar-scroll", function () {

        if ($('.nav').css("top") == '0px') {
            $('.nav').css("top", "-300px");
        }
        else {
            $('.nav').css("top", "0");
        }
    })

});