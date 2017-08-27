
var removeProducttype = function(producttype) {
	deleteProducttype(producttype.ProducttypeID);
	setView("ProducttypeList");
}
var setView = function (view) {
	userModel.currentView(view);
}
var editProducttype = function (producttype) {
	setView("ProducttypeEdit");
	saveProducttype(producttype,
		function() {
			setView("ProducttypeList");
		});
}
var createProducttype = function() {
	editProducttype(userModel.newProducttype);
}


