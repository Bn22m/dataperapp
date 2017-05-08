'use strict';

// main entry page:
function MainController($scope)
{
    //alert("main startUpController... :");
}

function myCtlr($scope)
{
    //alert("my startUpController... :");
    $scope.info = [];
    $scope.info.push("New Accounts.");
    $scope.info.push("View data.");
    $scope.info.push("Update info.");
    $scope.info.push("Delete data.");
    $scope.viewService = function(service)
    {
        alert(service);
        if(service == "New Accounts.")
        {
           window.open("frmNewp.aspx");
        }
        else
        {
           window.open("hperson.aspx");
        }
    };
    
}
