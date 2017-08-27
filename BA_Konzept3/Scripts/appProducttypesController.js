// client-side ProducttypeController that handles Product-Data-Transfer to Server using AJAX-Requests. 

var producttypeUrl = "/api/producttype/";

var getProducttypes = function () {
	sendRequest(producttypeUrl,
		"GET",
		null,
		function(data) {
			model.producttypes.removeAll();
			model.producttypes.push.apply(model.producttypes, data);
		});
};

var deleteProducttype = function(id) {
	sendRequest(producttypeUrl + id,
		"DELETE",
		null,
		function() {
			model.producttypes.remove(function(item) {
				return item.ProducttypeID == id;
			});
		});
};

var saveProducttype = function(producttype, successCallback) {
	sendRequest(producttypeUrl,
		"POST",
		producttype,
		function() {
			getProducttypes();
			if (successCallback) {
				successCallback();
			}
		});
};
