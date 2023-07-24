// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//function GetProductList() {
//    $.ajax(
//        {
//            url: "/Admin/Admin/Index",
//            type: "GET",
//            success: function () {
//                $.ajax(
//                    {
//                        url: "/Admin/Admin/GetProductList",
//                        type: "GET",
//                        success: function (response) {
//                            $("#productList").html(response)
//                            $("#addProduct").html("")
//                            $("#updateProduct").html("")
//                            $("#deleteProduct").html("")
//                            $("#categoryList").html("")
//                            $("#updateCategory").html("")
//                            $("#addCategory").html("")
///*                            $("#orderList").html("")*/
//                        }
//                    });
//            }
//        });
//}

function GetProductList() {
    $.ajax(
        {
            url: "/Admin/Admin/GetProductList",
            type: "GET",
            success: function (response) {
                $("#productList").html(response)
                $("#addProduct").html("")
                $("#updateProduct").html("")
                $("#deleteProduct").html("")
                $("#categoryList").html("")
                $("#updateCategory").html("")
                $("#addCategory").html("")
                $("#orderList").html("")
                $("#orderDetails").html("")
            }
        }
    )
}

//---------------------ORDER LIST-----------------

function GetOrderList() {
    $.ajax(
        {
            url: "/Admin/Admin/GetOrderList",
            type: "GET",
            success: function (response) {
                $("#productList").html("")
                $("#addProduct").html("")
                $("#updateProduct").html("")
                $("#deleteProduct").html("")
                $("#categoryList").html("")
                $("#updateCategory").html("")
                $("#addCategory").html("")
                $("#orderList").html(response)
                $("#orderDetails").html("")

            }
        }
    )
}


//-----------Product ADD--------------
function GetProductPartial() {
    $.ajax(
        {
            url: "/Admin/Admin/AddProduct",
            type: "GET",
            success: function (response) {
                $("#addProduct").html(response)
                $("#productList").html("")
                $("#updateProduct").html("")
                $("#deleteProduct").html("")
                $("#categoryList").html("")
                $("#updateCategory").html("")
                $("#addCategory").html("")
                $("#orderList").html("")
                $("#orderDetails").html("")
            }
        }
    )
}

function ProductAdd() {
    let productData = {
        ProductName: $("#create-product-name").val(),
        Price: $("#create-product-price").val(),
        Photo: $("#create-product-photo").val(),
        Description: $("#create-product-description").val(),
        CategoryID: $("#create-product-categoryId").val()
    }

    $.ajax(
        {
            url: "/Admin/Admin/AddProduct",
            type: "POST",
            data: productData,
            dataType: "json",
            success: function (response) {
                if (response == "Ok") {
                    $("#star-icon").css({
                        "color": "#16FF00",
                        "transform": "scale(1.5)",
                        "transition": "all 0.5s ease-in-out"
                    });

                    setTimeout(function () {
                        $("#star-icon").css({
                            "color": "#ffd93d",
                            "transform": "scale(1)",
                            "transition": "all 0.5s ease-in-out"
                        });
                    }, 2000);

                    $("#star-brother").css({
                        "color": "#16FF00",
                        "transform": "scale(1.3)",
                        "transition": "all 0.5s ease-in-out"
                    });

                    setTimeout(function () {
                        $("#star-brother").css({
                            "color": "#ffd93d",
                            "transform": "scale(1)",
                            "transition": "all 0.5s ease-in-out"
                        });
                    }, 2000);

                    GetProductList();
                }
            }
        }
    )
}


//-----------UPDATE Product---------------

function GetUpdateProductPartial(id) {
    let updateData = {
        productId: id
    }
    $.ajax(
        {
            url: "/Admin/Admin/UpdateProduct",
            type: "GET",
            data: updateData,
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                $("#updateProduct").html(response)
                $("#productList").html("")
                $("#addProduct").html("")
                $("#deleteProduct").html("")
                $("#categoryList").html("")
                $("#updateCategory").html("")
                $("#addCategory").html("")
                $("#orderList").html("")
                $("#orderDetails").html("")
            }, error: function (error) {
                alert(JSON.stringify(error));

            }
        }
    )
}

function UpdateProduct(id) {
    let productData = {
        productId: id,
        productName: $("#update-product-name").val(),
        price: $("#update-product-price").val(),
        photo: $("#update-product-photo").val(),
        description: $("#update-product-description").val(),
        categoryId: $("#update-product-categoryId").val()
    }

    $.ajax(
        {
            url: "/Admin/Admin/UpdateProduct",
            type: "POST",
            data: productData,
            dataType: "json",
            success: function (response) {
                if (response == "Ok") {
                    $("#updateProduct").html("");
                    $("#star-icon").css({
                        "color": "#16FF00",
                        "transform": "scale(1.5)",
                        "transition": "all 0.5s ease-in-out"
                    });

                    setTimeout(function () {
                        $("#star-icon").css({
                            "color": "#ffd93d",
                            "transform": "scale(1)",
                            "transition": "all 0.5s ease-in-out"
                        });
                    }, 2000);

                    $("#star-brother").css({
                        "color": "#16FF00",
                        "transform": "scale(1.3)",
                        "transition": "all 0.5s ease-in-out"
                    });

                    setTimeout(function () {
                        $("#star-brother").css({
                            "color": "#ffd93d",
                            "transform": "scale(1)",
                            "transition": "all 0.5s ease-in-out"
                        });
                    }, 2000);
                    GetProductList();
                }
            }
        }

    )
}

//-----------DELETE PRODUCT---------------
function DeleteProduct(id) {
    let deleteData = {
        productId: id
    }
    $.ajax(
        {
            url: "/Admin/Admin/ProductDelete",
            type: "GET",
            data: deleteData,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                $("#productList").html("")
                $("#addProduct").html("")
                $("#updateProduct").html("")
                $("#deleteProduct").html("")
                $("#categoryList").html("")
                $("#updateCategory").html("")
                $("#addCategory").html("")
                $("#orderList").html("")
                $("#orderDetails").html("")

                $("#star-icon").css({
                    "color": "#16FF00",
                    "transform": "scale(1.5)",
                    "transition": "all 0.5s ease-in-out"
                });

                setTimeout(function () {
                    $("#star-icon").css({
                        "color": "#ffd93d",
                        "transform": "scale(1)",
                        "transition": "all 0.5s ease-in-out"
                    });
                }, 2000);

                $("#star-brother").css({
                    "color": "#16FF00",
                    "transform": "scale(1.3)",
                    "transition": "all 0.5s ease-in-out"
                });

                setTimeout(function () {
                    $("#star-brother").css({
                        "color": "#ffd93d",
                        "transform": "scale(1)",
                        "transition": "all 0.5s ease-in-out"
                    });
                }, 2000);
                GetProductList();
            }
        }
    )
}

//----------------------------------------------------------------- CATEGORY --------------------------------------------------

//------------ CATEGORY LİST -----------------
//function GetCategoryList() {
//    $.ajax(
//        {
//            url: "/Admin/Admin/Index",
//            type: "GET",
//            success: function () {
//                $.ajax(
//                    {
//                        url: "/Admin/Admin/GetCategoryList",
//                        type: "GET",
//                        success: function (response) {
//                            $("#productList").html("")
//                            $("#addProduct").html("")
//                            $("#updateProduct").html("")
//                            $("#deleteProduct").html("")
//                            $("#categoryList").html(response)
//                            $("#updateCategory").html("")
//                            $("#addCategory").html("")
///*                            $("#orderList").html("")*/
//                        }
//                    });
//            }
//        });
//}

function GetCategoryList() {
    $.ajax(
        {
            url: "/Admin/Admin/GetCategoryList",
            type: "GET",
            success: function (response) {
                $("#productList").html("")
                $("#addProduct").html("")
                $("#updateProduct").html("")
                $("#deleteProduct").html("")
                $("#addCategory").html("")
                $("#updateCategory").html("")
                $("#categoryList").html(response)
                $("#orderList").html("")
                $("#orderDetails").html("")
            }
        }
    )
}

//---------------------- CATEGORY ADD -----------------
function GetCategoryPartial() {
    $.ajax(
        {
            url: "/Admin/Admin/AddCategory",
            type: "GET",
            success: function (response) {

                $("#productList").html("")
                $("#addProduct").html("")
                $("#updateProduct").html("")
                $("#deleteProduct").html("")
                $("#categoryList").html("")
                $("#updateCategory").html("")
                $("#addCategory").html(response)
                $("#orderList").html("")
                $("#orderDetails").html("")
            }
        }
    )
}

function CategoryAdd() {
    let categoryData = {
        categoryName: $("#create-category-name").val(),
    }

    $.ajax(
        {
            url: "/Admin/Admin/AddCategory",
            type: "POST",
            data: categoryData,
            dataType: "json",
            success: function (response) {
                if (response == "Ok") {
                    $("#star-icon").css({
                        "color": "#16FF00",
                        "transform": "scale(1.5)",
                        "transition": "all 0.5s ease-in-out"
                    });

                    setTimeout(function () {
                        $("#star-icon").css({
                            "color": "#ffd93d",
                            "transform": "scale(1)",
                            "transition": "all 0.5s ease-in-out"
                        });
                    }, 2000);

                    $("#star-brother").css({
                        "color": "#16FF00",
                        "transform": "scale(1.3)",
                        "transition": "all 0.5s ease-in-out"
                    });

                    setTimeout(function () {
                        $("#star-brother").css({
                            "color": "#ffd93d",
                            "transform": "scale(1)",
                            "transition": "all 0.5s ease-in-out"
                        });
                    }, 2000);

                    GetCategoryList();
                }
            }
        }
    )
}

//-------------------------UPDATE CATEGORY------------------------------
function GetUpdateCategoryPartial(id) {
    let updateData = {
        categoryId: id
    }
    $.ajax(
        {
            url: "/Admin/Admin/UpdateCategory",
            type: "GET",
            data: updateData,
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                $("#productList").html("")
                $("#addProduct").html("")
                $("#updateProduct").html("")
                $("#deleteProduct").html("")
                $("#categoryList").html("")
                $("#updateCategory").html(response)
                $("#addCategory").html("")
                $("#orderList").html("")
                $("#orderDetails").html("")
            }, error: function (error) {
                alert(JSON.stringify(error));

            }
        }
    )
}

function UpdateCategory(id) {
    let categoryData = {
        categoryId: id,
        categoryName: $("#update-category-name").val(),
    }

    $.ajax(
        {
            url: "/Admin/Admin/UpdateCategory",
            type: "POST",
            data: categoryData,
            dataType: "json",
            success: function (response) {
                if (response == "Ok") {
                    $("#updateCategory").html("");
                    $("#star-icon").css({
                        "color": "#16FF00",
                        "transform": "scale(1.5)",
                        "transition": "all 0.5s ease-in-out"
                    });

                    setTimeout(function () {
                        $("#star-icon").css({
                            "color": "#ffd93d",
                            "transform": "scale(1)",
                            "transition": "all 0.5s ease-in-out"
                        });
                    }, 2000);

                    $("#star-brother").css({
                        "color": "#16FF00",
                        "transform": "scale(1.3)",
                        "transition": "all 0.5s ease-in-out"
                    });

                    setTimeout(function () {
                        $("#star-brother").css({
                            "color": "#ffd93d",
                            "transform": "scale(1)",
                            "transition": "all 0.5s ease-in-out"
                        });
                    }, 2000);
                    GetCategoryList();
                }
            }
        }

    )
}

/***********************ORDER**************************************/

function AddProductToBasket(id, Quantity) {
    let addData = {
        productId: id,
        quantity: Quantity
    }
    $.ajax(
        {
            url: "/Order/AddBasket",
            type: "GET",
            data: addData,

            success: function (response) {
                $('#order-basket').html(response);
                $('#successModal').modal('show');
                $('#successModal button[data-dismiss="modal"]').click(function () {
                    $('#successModal').modal('hide');
                });
            }
        }
    )
}


function RemoveItemBasket(id) {
    let removeData = {
        ItemBasket: id,

    }
    $.ajax(
        {
            url: "/Order/RemoveBasket",
            type: "GET",
            data: removeData,

            success: function (response) {
                $("#order-basket").html(response);


            }
        }
    )
}

//function ProductToBasketAdd() {
//    let menuData = {
//        productId: $("#create-menu-name").val(),
//        quantity: $("#create-menu-price").val(),
//    }

//    $.ajax(
//        {
//            url: "/Admin/Admin/AddMenu",
//            type: "POST",
//            data: menuData,
//            dataType: "json",
//            success: function (response) {
//                if (response == "Ok") {
//                    $("#addMenu").html("");
//                    GetMenuList();
//                }
//            }
//        }
//    )
//}


/***********************ORDER DETAİLS**************************************/

function OrderDetails(id) {
    let orderData = {
        orderID: id,

    }
    $.ajax(
        {
            url: "/Admin/Admin/GetOrderDetails",
            type: "GET",
            data: orderData,
            success: function (response) {
                $("#productList").html("")
                $("#addProduct").html("")
                $("#updateProduct").html("")
                $("#deleteProduct").html("")
                $("#categoryList").html("")
                $("#updateCategory").html("")
                $("#addCategory").html("")
                $("#orderList").html("")
                $("#orderDetails").html(response)

            }
        }
    )
}

