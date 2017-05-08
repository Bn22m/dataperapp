'use strict';
//
// create new module with its dependencies:
angular.module('myTicApp.services', ['ngResource']);

var ticNumber = document.form3.ynumber.value;
var n = ticNumber;
n++;
//alert(n);
document.form3.ynumber.value = n;
//add some services :
