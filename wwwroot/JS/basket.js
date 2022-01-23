'use strict';

//addtobasket


function AddToBasket(elements) {
    let allAddSpan;
    if (elements == undefined) {
        allAddSpan = document.querySelectorAll('.addToBasket');
    } else {
        allAddSpan = elements;
    }


    allAddSpan.forEach(item => {
        item.addEventListener('click', function (e) {
            console.log(allAddSpan);
            let id = e.target.getAttribute('data-id');
            let formdata = new FormData();
            if (document.getElementById('pageName').value === 'detail') {
                let addProductCount = document.getElementById('addProductCount').value;
                let productDbCount = document.getElementById('productDbCount').value;
                if (addProductCount > 1 && addProductCount <= productDbCount) {
                    formdata.append('addProductCount', addProductCount)
                }
            }


            formdata.append('id', id);
            axios.post('/basket/AddBasket', formdata)
                .then(function (resp) {
                    console.log(resp.data.basketTotalPrice)
                    console.log(resp.data.basketProductCount)
                    let totalPriceNav = document.getElementById('totalPriceNav');
                    let totalCountNav = document.getElementById('totalCountNav');
                    if (resp.data.basketProductCount != null) {
                        totalPriceNav.textContent = '$' + resp.data.basketTotalPrice;
                        totalCountNav.textContent = resp.data.basketProductCount;
                    } else {
                        window.location = 'Account/Login';
                    }
                })
                .catch(function (error) {
                    if (error.resp) {
                        let errorObj = error.resp.data;
                        for (let errors in errorObj) {
                            let error = errorObj[errors];
                            console.log(error);
                        }
                    }
                })
        })
    });
}


AddToBasket();

//plus product

let plusProduct = document.querySelectorAll('.plusProduct');


plusProduct.forEach(item => {
    item.addEventListener('click', function (e) {
        var plusBtn = e.target;
        let formdata = new FormData();
        let id = plusBtn.getAttribute('data-id');
        formdata.append('id', id);
        axios.post('/basket/ProductCountPlusAxios', formdata)

            .then(function (response) {
                console.log(response.data)
                let basketTotalPrice = document.getElementById('basketTotalPrice');
                let totalPriceNav = document.getElementById('totalPriceNav');


                basketTotalPrice.innerHTML = 'Total: $' + response.data.basketTotalPrice;
                totalPriceNav.innerHTML = '$' + response.data.basketTotalPrice;
                plusBtn.parentElement.parentElement.previousElementSibling.
                    previousElementSibling.textContent = response.data.productBasketCount;
                plusBtn.parentElement.parentElement.previousElementSibling.previousElementSibling.previousElementSibling.textContent = response.data.productTotalPrice;

                if (response.data.productBasketCount > 1) {
                    plusBtn.parentElement.parentElement.previousElementSibling
                        .firstElementChild.firstElementChild.classList.remove('d-none');
                }

                if (response.data.productBasketCount == response.data.basketProductDbCount) {
                    plusBtn.classList.add('d-none');
                }
            })
            .catch(function (error) {
                if (error.response) {
                    let errorObj = error.response.data;
                    for (let errors in errorObj) {
                        let error = errorObj[errors];
                        console.log(error);
                    }
                }
            })
    })
});
