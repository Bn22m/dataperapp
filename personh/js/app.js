'use strict';

// Declare application level module which depends on services and directives
angular.module('myTicApp', ['myTicApp.services', 'myTicApp.directives']);

// configure application's routeProvider:
angular.module('myTicApp').config(['$routeProvider', function($routeProvider) 
  {
    // info page:
    $routeProvider.when('/info', 
        {
            templateUrl: 'view/info.html', 
            controller: myCtlr
        });
     
     // help page:
    $routeProvider.when('/help', 
        { 
            templateUrl: 'view/help.html', 
            controller: myCtlr
        });
     
     // admin page:
    $routeProvider.when('/admin', 
        {
            templateUrl: 'hperson.aspx', 
            controller: MainController
        });
    
    // new page:
    $routeProvider.when('/new', 
        {
            templateUrl: 'frmNewp.aspx', 
            controller: MainController
        });

    // default fallback page:
    $routeProvider.otherwise(
        {
            redirectTo: '/info'
        });
    
  }]);
