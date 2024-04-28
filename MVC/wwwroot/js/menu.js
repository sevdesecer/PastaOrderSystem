let totalPrice = 0;
let cartItemCounter = 0;
let pastaNumberGlobal = 1;
let order = {
    Pastas: [],
    Beverages: [],
    CustomerName: undefined,
    CustomerAddress: undefined
};


function addToCart(productId, productName, productPrice, productType) {
    const cartItemsContainer = $('.cart-items');

    const pieces = $('#' + productId + ' #pieces').val();
    let selectedPrice = parseFloat(productPrice) * pieces;

    if (productType === 'pasta') {
        for (let i = 0; i < pieces; i++) {
            order.Pastas.push({
                Id: productId,
                ExtraIngredients: [],
                PastaNumber: pastaNumberGlobal
            })
        }

        getSelectedExtraIngredientPrices(productId, pastaNumberGlobal).forEach(function (extraPrice) {
            selectedPrice += parseFloat(extraPrice) * pieces;
        });
    }

    if (productType === 'beverage') {
        for (let i = 0; i < pieces; i++) {
            order.Beverages.push({
                Id: productId
            })
        }
    }

    totalPrice += selectedPrice;

    const cartItemId = 'cart-item-' + cartItemCounter++;
    const productHtml = `
    <div id="${cartItemId}" class="cart-item">
      <div class="cart-item-info"> <p>${productName} ${selectedPrice.toFixed(2)}$</p>
      </div>
      <button class="checkout-saving-remove-button" onclick="removeFromCart('${cartItemId}', ${selectedPrice.toFixed(2)}, '${productId}', '${productType}', ${pastaNumberGlobal})">Remove</button>
    </div>
   `;

    console.log("Product HTML:", productHtml);
    cartItemsContainer.append(productHtml);
    $('#totalPriceElement').text(totalPrice.toFixed(2));
    console.log(order);
    pastaNumberGlobal++;
}
function removeFromCart(cartItemId, itemPrice, productId, productType, pastaNumber) {
    $('#' + cartItemId).remove();
    totalPrice -= itemPrice;
    $('#totalPriceElement').text(totalPrice.toFixed(2));
    if (productType === 'pasta') {
        for (let i = order.Pastas.length - 1; i >= 0; i--) {
            if (order.Pastas[i].Id === productId && order.Pastas[i].PastaNumber === pastaNumber) {
                order.Pastas.splice(i, 1);
            }
        }
    } else {
        const matchingBeverageIndex = order.Beverages.findIndex(bev => bev.Id === productId);
        if (matchingBeverageIndex !== -1) {
            order.Beverages.splice(matchingBeverageIndex, 1);
        }
    }
    console.log(order);
}


function getSelectedExtraIngredientPrices(productId, pastaNumber) {
    let selectedExtraPrices = [];
    const extras = $('#' + productId + ' .extras input[type=checkbox]:checked');

    extras.each(function () {
        var extraPrice = parseFloat($(this).next('label').text().split(' - ')[1]);
        selectedExtraPrices.push(extraPrice);

        const extraId = $(this).attr('id');
        const cleanExtraId = extraId.replace('extra_', '');
        order.Pastas.forEach(function (pasta) {
            if (pasta.Id === productId && pasta.PastaNumber === pastaNumber) {
                pasta.ExtraIngredients.push(cleanExtraId);
            }
        });
    });

    extras.prop('checked', false);

    return selectedExtraPrices;
}

function toggleExtras(pastaId) {
    var extrasDiv = document.getElementById(pastaId).querySelector('.extras');
    extrasDiv.style.display = (extrasDiv.style.display === 'block') ? 'none' : 'block';
}
