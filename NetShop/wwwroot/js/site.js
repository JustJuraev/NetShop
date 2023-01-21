// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    let $priceInput = $(".price-input");
    $priceInput.change(function () {
        let totalPrice = 0;
        $priceInput.each(function (e) {
            let count = $(this).val();
            let price = $(this).data("price");
            totalPrice += count * price;
        });
        $("#total-price").text(totalPrice);
    });
});


