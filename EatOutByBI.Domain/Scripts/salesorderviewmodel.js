
$(document).ready(function () {
var Products = [];
//fetch categories from database

// get ajax call first then 


function LoadProducts() {
    if (Products.length == 0) {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '/Sales/GetProducts',
            success: function (data) {
                Products = data;
                console.log("ajax")
                console.log(data)
            },
            error: function (error) {
                console.log(error)
            }
        })
    }
    else {
        alert("else");
        //$.ajax({
        //    type: "GET",
        //    url: '/Sales/GetProducts',
        //    success: function (data) {
        //        Products = data;
        //        //render catagory

        //        renderProducts(element);

        //    }
        //})
        ////render catagory to the element
        //renderProducts(element);
    }
}




var Seats = [];
//fetch categories from database
function LoadSeats() {
    if (Seats.length == 0) {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '/Sales/GetSeats',
            success: function (data) {
                Seats = data;
                //render catagory
                //renderSeats(element);
            }
        })
    }
    else {
        alert("Seat problem")
        //render catagory to the element
        //renderSeats(element);
    }
}


var Employees = [];
//fetch categories from database
function LoadEmployees() {
    if (Employees.length == 0) {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '/Sales/GetEmployees',
            success: function (data) {
                Employees = data;
                //render catagory
                //  renderEmployees(element);
            }
        })
    }
    else {
        alert("Load employee problems")
        //render catagory to the element
        //renderEmployees(element);
    }
}


var PaymentMethods = [];
//fetch categories from database
function LoadPaymentMethods() {
    if (PaymentMethods.length == 0) {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '/Sales/GetPaymentMethods',
            success: function (data) {
                PaymentMethods = data;
                //render catagory
                //renderPaymentMethods(element);
            }
        })
    }
    else {
        alert("paymentmethod problem")
        //render catagory to the element
        //renderPaymentMethods(element);
    }
}



var ObjectState = {
    Unchanged: 0,
    Added: 1,
    Modified: 2,
    Deleted: 3
};

// LOAD PRODUCTS


var salesOrderItemMapping = {
    'SalesOrderItems': {
        key: function (salesOrderItem) {
            // alert("Salesorderitem mapping key");
            return ko.utils.unwrapObservable(salesOrderItem.SalesOrderItemId);
        },
        create: function (options) {
            console.log(options);
            return new SalesOrderItemViewModel(options.data);
        }
    }
};



SalesOrderItemViewModel = function (data) {
    //alert("salesorder item view"); // funkade
    var self = this;
    ko.mapping.fromJS(data, salesOrderItemMapping, self);
    //dd: ko.observableArray(Products);
    self.itemss = ko.observableArray(Products);
    self.selectedItem = ko.observable(self.ProductID);
    //var prod = ko.mapping.fromJS(data, productItemMapping, SalesOrderViewModel);


    //TESTAR TA BORT
    self.itemName = function () {
        var theItem = ko.utils.arrayFirst(self.itemss(), function (item) {
            return item.ProductID === self.ProductID();
        }).ProductName;
        console.log(theItem);
        return theItem;
    }




    //selecteditem = 2;

    //self.findItem = function () {
    //    console.log(self.itemss().length);
    //    var category = ko.utils.arrayFirst(self.itemss(), function (item) {
    //        return item.ProductID === self.ProductID();

    //    }).UnitPrice;
    //    console.log(category);
    //    return category * self.Quantity();
    //}




    //TESTAR TA BORT
    self.findItem = function () {
        console.log(self.itemss().length);
        var category = ko.utils.arrayFirst(self.itemss(), function (item) {
            return item.ProductID === self.ProductID();

        }).UnitPrice;
        console.log(category);
        return category * self.Quantity(); 
    }
// If UnitPrice is null. change ProductID on addsalesorderitem




    self.flagSalesOrderAsEdited = function () {
        if (self.ObjectState() !== ObjectState.Added) {
            self.ObjectState(ObjectState.Modified);
        }
        // alert("salesorder item view if");
        return true;
    };
};


SalesOrderViewModel = function (data) {
    var self = this;
    ko.mapping.fromJS(data, salesOrderItemMapping, self);
    self.seats = ko.observableArray(Seats);
    self.employees = ko.observableArray(Employees);
    self.paymentMethods = ko.observableArray(PaymentMethods);
    self.products = ko.observableArray(Products);


    //TESTAR TA BORT
    self.contactsTotal = ko.computed(function () {
        var total = 0;
        ko.utils.arrayForEach(self.SalesOrderItems(), function (SalesOrderItemViewModel) {
            total += SalesOrderItemViewModel.findItem();
        })
        return total;
    })


    self.save = function () {
        var tmpdata = ko.toJSON(self);
        
        $.ajax({
            url: "/Sales/Save/",
            type: "POST",
            data: tmpdata,
            contentType: "application/json",
            success: function (data) {
                if (data.salesOrderViewModel !== null)
                    ko.mapping.fromJS(data.salesOrderViewModel, {}, self);

                if (data.newLocation !== null)
                    window.location = data.newLocation;
            },
            error: function () {
                alert("failure post");
            }
        });
    },

    self.flagSalesOrderAsEdited = function () {
        if (self.ObjectState() !== ObjectState.Added) {
            self.ObjectState(ObjectState.Modified);
        }
        return true;
    },



    self.deleteSalesOrderItem = function (salesOrderItem) {
        self.SalesOrderItems.remove(this);

        if (salesOrderItem.SalesOrderItemId() > 0 &&
            self.SalesOrderItemsToDelete.indexOf(salesOrderItem.SalesOrderItemId()) === -1)
            self.SalesOrderItemToDelete.push(SalesOrderItemId());

    }

    //self.priceSalesOrderItems = function(salesOrderItem) {
    //    sa
    //}    
    var pId = Products[0].ProductID;
    self.addSalesOrderItem = function () {
        // alert(" add salesorder item"); // funkade
        var salesOrderItem = new SalesOrderItemViewModel({ SalesOrderItemId: 0, Quantity: 1, ProductID: pId, ObjectState: ObjectState.Added });
        self.SalesOrderItems.push(salesOrderItem);
    };

    $("form").validate({
        submitHandler: function () {
            alert("submit");
            self.save();
        },

        rules: {
            CustomerName: {
                required: true,
                maxlength: 30
            },
            Quantity: {
                required: true,
                digits: true,
                range: [1, 100000]
            },
            Seats: {
                required: true
            },
            Employees: {
                required: true
            },
            PaymentMethods: {
                required: true
            },
        },
        messages: {
            CustomerName: {
                maxlength: "Customer name must be 30 characters or shorter."
            }
        }

    });
};
//UnitPrice: 1

LoadSeats();
LoadEmployees();
LoadPaymentMethods();
LoadProducts();




});

//