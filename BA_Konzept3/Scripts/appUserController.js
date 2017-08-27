
var setView = function (view) {
	userModel.currentView(view)
}

//var setListMode = function (mode) {
//    console.log("Mode: " + mode);
//    adminModel.listMode(mode);
//}

//var authenticateUser = function () {
//    authenticate(function () {
//        setView("productList");
//        getProducts();
//        getOrders();
//    });
//}

var editProducttype = function (producttype) {	
	setView($data, "ProducttypeEdit");
	saveProducttype(producttype,
		function () {
			setView("ProducttypeList");
		});
}

var createProducttype = function () {
	editProducttype(userModel.newProducttype); 
}

var removeProducttype = function (producttype) {
	deleteProducttype(producttype.Id);
}

$(document).ready(function () {
	getProducttypes();
})

