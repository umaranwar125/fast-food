if ($(window).width() > 992) {
    $('.side-bar').show();
}
function Open() {
    if ($(window).width() < 992) {
        $('.side-bar').hide();
    }
}

function openNav() {
    $('.side-bar').fadeIn(0);
}

function showContent() {
    $(document).ready(function () {
        $('.content').show(1000);
    });
}

$(document).ready(function () {
    $('.show-content').click(function () {
        $('.content').toggle(1000);
    });
});

$(document).ready(function () {
    $('.product-add').click(function () {
        var name = $('.name').val();
        var price = $('.price').val();
        var image = $('.image').val();
        if (name == "") {
            $('.error').text("Name is required");
            return false;
        }
        if (price == "") {
            $('.error').text("Price is required");
            return false;
        }
        if (image == "") {
            $('.error').text("Image is required");
            return false;
        }
        if (price > 0 || price < 9) {
        }
        else{
            $('.error').text("Price is not in correct format");
            return false;
        }
    });
});
