function addToCart(productId, productName, productPrice) {
    var cartItemsContainer = $('.cart-items');

    var productHtml = `
        <div class="cart-item">
            <div>
                <p>${productName}</p>
                <p>${productPrice}$</p>
            </div>
        </div>
    `;

    console.log("Product HTML:", productHtml);

    cartItemsContainer.append(productHtml);
    updateTotalPrice(productPrice);
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
