let totalPrice = 0;
let cartItemCounter = 0; 

function addToCart(productId, productName, productPrice) {
    const cartItemsContainer = $('.cart-items');

    const pieces = $('#' + productId + ' #pieces').val();
    let selectedPrice = parseFloat(productPrice) * pieces;
    getSelectedExtraIngredientPrices(productId).forEach(function (extraPrice) {
        selectedPrice += parseFloat(extraPrice) * pieces;
    });

    totalPrice += selectedPrice;

    const cartItemId = 'cart-item-' + cartItemCounter++;
    const productHtml = `
    <div id="${cartItemId}" class="cart-item">
      <div class="cart-item-info"> <p>${productName} ${selectedPrice.toFixed(2)}$</p>
      </div>
      <button class="checkout-saving-remove-button" onclick="removeFromCart('${cartItemId}', ${selectedPrice.toFixed(2)})">Remove</button>
    </div>
   `;

    console.log("Product HTML:", productHtml);
    cartItemsContainer.append(productHtml);
    $('#totalPriceElement').text(totalPrice.toFixed(2));
}

function removeFromCart(cartItemId, itemPrice) {
    $('#' + cartItemId).remove();
    totalPrice -= itemPrice;
    $('#totalPriceElement').text(totalPrice.toFixed(2));
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

function toggleExtras(pastaId) {
    var extrasDiv = document.getElementById(pastaId).querySelector('.extras');
    extrasDiv.style.display = (extrasDiv.style.display === 'block') ? 'none' : 'block';
}
