<%@ Page
	Language           = "C#"
	AutoEventWireup    = "false"
	Inherits           = "personh.welcome"
	ValidateRequest    = "false"
	EnableSessionState = "false"
%>


<!DOCTYPE html>
<html lang="en" data-ng-app="myTicApp">
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>DataPerApp</title>
        <link rel="stylesheet" href="css/app.css"/>
        <link rel="stylesheet" href="css/bootstrap.css"/>
        <style type="text/css">
            body 
            {
                padding-top: 60px;
                padding-bottom: 40px;
            }
        </style>
        <link href="css/bootstrap-responsive.css" rel="stylesheet">
        <script src="js/controllers.js" type="text/javascript"></script>
    </head>
    <body>
        <div id="header">
            <div class="navbar navbar-inverse navbar-fixed-top">
                <div class="navbar-inner">
                    <div class="container">
                        <ul class="nav">
                            <li><a class="active" href="#/info"><img src="img/dataperapp.png"></a></li>
                            <li><a href="#/info">Info</a></li>
                            <li><a href="hperson.aspx">Administration</a></li>
                            <li><a href="frmNewp.aspx">New Account</a></li>
                            <li><a href="hperson.aspx">Update</a></li> 
                            <li><a href="#/help">help</a></li>
                            <li><a href="index.html">DataPerApp</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <hr>
        <div data-ng-view></div>
        <hr>
		<form id="Form_welcome" method="post" runat="server">

			<table>

				<tr>
					<td colspan="2">
						Test...
					</td>
				</tr>

				<tr>
				<td>
						Name:
					</td>
					<td>
						<input id="_Input_Name" runat="server" />
					</td>
				</tr>

				<tr>
					<td colspan="2">
						<input id="_Button_No" type="submit" value="Oh No!" runat="server" />
						<input id="_Button_Ok" type="submit" value="Ok" runat="server" />
					</td>
				</tr>

				<tr>
					<td colspan="2" align="center">
						<a href="?" >Test Here</a>
					</td>
				</tr>

			</table>

		</form>
		<br>
        <script src="lib/angular/angular.js"></script>
        <script src="lib/angular/angular-resource.js"></script>
        <script src="lib/jquery/jquery.js"></script>
        <script src="lib/bootstrap/bootstrap.js"></script>
        <script src="js/app.js"></script>
        <script src="js/services.js"></script>
        <script src="js/filters.js"></script>
        <script src="js/directives.js"></script>
        
	</body>
</html>
