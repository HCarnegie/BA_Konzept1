//Client-side-model
var model = {
	products: ko.observableArray([]),
	producttypes: ko.observableArray([]),
	authenticated: ko.observable(false),
	username: ko.observable(null),
	password: ko.observable(null),
	error: ko.observable(""),
	gotError: ko.observable(false)
};

// jQuery ready function to set up Knockout data bindings
$(document).ready(function () {
	ko.applyBindings();
	setDefaultCallbacks(
		//Default Ajax-Success-Function
		function (data) {
			if (data) {
				console.log("---Begin Success---");
				console.log(JSON.stringify(data));
				console.log("---End Success---");
			} else {
				console.log("Success (no data)");
			}
			model.gotError(false);
		},

		// Default Ajax-Errorfunction  
		function (statusCode, statusText) {
			console.log("Error: " + statusCode + " (" + statusText + ")");
			model.error(statusCode + " (" + statusText + ")");
			model.gotError(true);
		});
});
