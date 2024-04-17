function addToCart(productId, productName, productPrice) {
    var cartItemsContainer = $('.cart-items');

    var totalPrice = parseFloat(productPrice);
    getSelectedExtraIngredientPrices(productId).forEach(function (extraPrice) {
        totalPrice += parseFloat(extraPrice);
    });

    var productHtml = `
        <div class="cart-item">
            <div>
                <p>${productName} ${totalPrice.toFixed(2)}$</p>
            </div>
        </div>
    `;

    console.log("Product HTML:", productHtml);

    cartItemsContainer.append(productHtml);
    updateTotalPrice(totalPrice);
}

function updateTotalPrice(price) {
    var totalPriceElement = $('.total-price span');

    var currentTotal = parseFloat(totalPriceElement.text());

    console.log("Current Total Price:", currentTotal);

    var newTotal = currentTotal + parseFloat(price);
    totalPriceElement.text(newTotal.toFixed(2) + '$');

    console.log("New Total Price:", newTotal);

    $('.checkout-btn').prop('disabled', false);
}

function getSelectedExtraIngredientPrices(productId) {
    let selectedExtraPrices = [];
    const extras = $('#' + productId + ' .extras input[type=checkbox]:checked');

    extras.each(function () {
        var extraPrice = parseFloat($(this).next('label').text().split(' - ')[1]);
        selectedExtraPrices.push(extraPrice);
    });

    extras.prop('checked', false);

    return selectedExtraPrices;
}