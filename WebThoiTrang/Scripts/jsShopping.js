﻿$(document).ready(function () {
    ShowCount()
    $('body').on('click', '.btnAddToCart', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var quantity = 1;
        var tquantity = $('#quantity_value').text();
        if (tquantity != '') {
            quantity = parseInt(tquantity);
        }
        $.ajax({
            url: '/shoppingcart/addtocart',
            type: 'POST',
            data: { id: id, quantity: quantity },
            success: function (rs) {
                if (rs.Success) {
                    $('#checkout_items').html(rs.count);
                    alert(rs.msg);
                }
            }
        });
    });

    $('body').on('click', '.btnUpdate', function (e) {
        e.preventDefault();
        var id = $(this).data("id");
        var quantity = $('#Quantity_' + id).val();
        Update(id, quantity);
    });

    $('body').on('click', '.btnDeleteAll', function (e) {
        e.preventDefault();
        var conf = confirm("Bạn muốn xóa hết sản phầm khỏi giỏ hàng ?");
        if (conf == true) {
            DeleteAll();
        }
    });

    $('body').on('click', '.btnDelete', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var conf = confirm("Bạn muốn xóa sản phầm này khỏi giỏ hàng ?");
        if (conf == true) {
            $.ajax({
                url: '/shoppingcart/delete',
                type: 'POST',
                data: { id: id },
                success: function (rs) {
                    if (rs.Success) {
                        $('#checkout_items').html(rs.count);
                        $('#trow_' + id).remove();
                        LoadCart();
                    }
                }
            });
        }
    });
});

function ShowCount() {
    $.ajax({
        url: '/shoppingcart/ShowCount',
        type: 'GET',
        success: function (rs) {
            $('#checkout_items').html(rs.count);
        }
    });
}

function DeleteAll() {
    $.ajax({
        url: '/shoppingcart/DeleteAll',
        type: 'POST',
        success: function (rs) {
            if (rs.Success) {
                LoadCart();
            }
        }
    });
}

function Update(id, quantity) {
    $.ajax({
        url: '/shoppingcart/Update',
        type: 'POST',
        data: { id: id, quantity:quantity },
        success: function (rs) {
            if (rs.Success) {
                LoadCart();
            }
        }
    });
}

function LoadCart() {
    $.ajax({
        url: '/shoppingcart/PartialItemCart',
        type: 'GET',
        success: function (rs) {
            $('#load_data').html(rs);
        }
    });
}