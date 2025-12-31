// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

    function likeProduct(button) {

        const productId = button.getAttribute("data-id");

        fetch('/HomeProducts/Like', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            body: 'id=' + productId
        })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                button.classList.remove('text-secondary');
                button.classList.add('text-danger');
                button.disabled = true; // prevent multiple clicks
            }
        });
    }

