"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/dashboardHub").build();


$(function () {
	connection.start().then(function () {
		InvokeProducts();
		InvokeSales();
		InvokeCustomers();
	}).catch(function (err) {
		return console.error(err.toString());
	});
});

//Product		
function InvokeProducts() {
	connection.invoke("SendProducts").catch(function (err) {
		return console.error(err.toString());
	});
}

connection.on("ReceivedProducts", function (products) {
	BindProductsToGrid(products);
});

function BindProductsToGrid(products) {
	$('#tblProduct tbody').empty();

	var tr;
	$.each(products, function (index, product) {
		tr = $('<tr/>');
		tr.append(`<td>${(index + 1)}</td>`);
		tr.append(`<td>${product.name}</td>`);
		tr.append(`<td>${product.category}</td>`);
		tr.append(`<td>${product.price}</td>`);
		$('#tblProduct').append(tr);
	});
}
//end Product


//Sales
function InvokeSales() {
	connection.invoke("SendSales").catch(function (err) {
		return console.error(err.toString());
	});
}

connection.on("ReceivedSales", function (sales) {
	BindSalesToGrid(sales);
});


function BindSalesToGrid(sales) {
	$('#tblSale tbody').empty();

	var tr;
	$.each(sales, function (index, sale) {
		tr = $('<tr/>');
		tr.append(`<td>${(index + 1)}</td>`);
		tr.append(`<td>${sale.customer}</td>`);
		tr.append(`<td>${sale.amount}</td>`);
		tr.append(`<td>${sale.purchaseOn}</td>`);
		$('#tblSale').append(tr);
	});
}


//End Sales



//Customer
function InvokeCustomers() {
	connection.invoke("SendCustomers").catch(function (err) {
		return console.error(err.toString());
	});
}

connection.on("ReceivedCustomers", function (customers) {
	BindCustomerToGrid(customers);
});


function BindCustomerToGrid(customers) {
	$('#tblCustomer tbody').empty();

	var tr;
	$.each(customers, function (index, customer) {
		tr = $('<tr/>');
		tr.append(`<td>${(index + 1)}</td>`);
		tr.append(`<td>${customer.name}</td>`);
		tr.append(`<td>${customer.gender}</td>`);
		tr.append(`<td>${customer.mobile}</td>`);
		$('#tblCustomer').append(tr);
	});
}

//End Customer