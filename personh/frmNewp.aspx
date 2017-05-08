<%@ Page
    Language           = "C#"
    AutoEventWireup    = "false"
    Inherits           = "personh.frmNewp"
    ValidateRequest    = "false"
    EnableSessionState = "false"
%>


<!DOCTYPE html >
<html >
    <head>
        <title>DataPerApp</title>
        <meta http-equiv="content-type" content="text/html; charset=utf-8" />
        <style type="text/css">
            body 
            {
                padding-top: 3px;
                padding-bottom: 3px;
                background-color: greenyellow;
            }
            H1{color: maroon;}
        </style>   

    </head> 
     <body> 
	
		<form id="frmNewp" method="post" runat="server">
		<!-- Coding frmNewp...! -->
		<!-- //////////////////////////////////////////////////////-->    
		                ServerName(mssql):
		                <input id="inpServer" runat="server"/>
	                	FirstName:
						<input id="inpName" runat="server" />
						Identity:
						<input id="inpID" runat="server" />
						<input id="btnOk" type="submit" value="Ok" runat="server" /><br>
						<a href="index.html">Login</a><br>
		               
		<hr> <!--///////////////////////////////////////////////////////////////////////-->
		                 
            <asp:Label id="lblIdentity1" style="Z-INDEX: 101; LEFT: 208px; POSITION: absolute; TOP: 180px" runat="server">Identity</asp:Label>
			<asp:TextBox id="txbIdentity1" style="Z-INDEX: 102; LEFT: 280px; POSITION: absolute; TOP: 180px" runat="server"></asp:TextBox>
			<asp:Label id="lblIdentityE1" style="Z-INDEX: 1102; LEFT: 500px; POSITION: absolute; TOP: 180px; color: red;" runat="server">System generated ID will be given!</asp:Label>
			<asp:Label id="lblFirstName2" style="Z-INDEX: 103; LEFT: 208px; POSITION: absolute; TOP: 230px" runat="server">FirstName</asp:Label>
			<asp:TextBox id="txbFirstName2" style="Z-INDEX: 104; LEFT: 310px; POSITION: absolute; TOP: 230px" runat="server"></asp:TextBox>
			<asp:Label id="lblFirstNameE2" style="Z-INDEX: 1104; LEFT: 500px; POSITION: absolute; TOP: 230px; color: red;" runat="server">Required field!</asp:Label>
			<asp:Label id="lblSurname3" style="Z-INDEX: 105; LEFT: 208px; POSITION: absolute; TOP: 280px" runat="server">Surname</asp:Label>
			<asp:TextBox id="txbSurname3" style="Z-INDEX: 106; LEFT: 310px; POSITION: absolute; TOP: 280px" runat="server"></asp:TextBox>		                 
		    <asp:Label id="lblAge4" style="Z-INDEX: 106; LEFT: 208px; POSITION: absolute; TOP: 330px" runat="server">Age</asp:Label>
			<asp:TextBox id="txbAge4" style="Z-INDEX: 107; LEFT: 280px; POSITION: absolute; TOP: 330px" runat="server"></asp:TextBox>
			<asp:Label id="lblAgeE4" style="Z-INDEX: 1107; LEFT: 500px; POSITION: absolute; TOP: 330px; color: red;" runat="server">Numbers only!</asp:Label>
			<asp:Label id="lblSex5" style="Z-INDEX: 108; LEFT: 208px; POSITION: absolute; TOP: 380px" runat="server">Sex</asp:Label>
			<asp:TextBox id="txbSex5" style="Z-INDEX: 109; LEFT: 280px; POSITION: absolute; TOP: 380px" runat="server"></asp:TextBox>
			<asp:Label id="lblSexE5" style="Z-INDEX: 1109; LEFT: 500px; POSITION: absolute; TOP: 380px; color: red;" runat="server">M or F!</asp:Label>
			<asp:Label id="lblMobile6" style="Z-INDEX: 110; LEFT: 208px; POSITION: absolute; TOP: 430px" runat="server">Mobile</asp:Label>
			<asp:TextBox id="txbMobile6" style="Z-INDEX: 111; LEFT: 280px; POSITION: absolute; TOP: 430px" runat="server"></asp:TextBox>		                 
   		    <asp:Label id="lblMobileE6" style="Z-INDEX: 1111; LEFT: 500px; POSITION: absolute; TOP: 430px; color: red;" runat="server">mobile# eg : 0831234567!</asp:Label>
   		    <asp:Label id="lblActive7" style="Z-INDEX: 112; LEFT: 208px; POSITION: absolute; TOP: 480px" runat="server">Active</asp:Label>
			<asp:TextBox id="txbActive7" style="Z-INDEX: 113; LEFT: 280px; POSITION: absolute; TOP: 480px" runat="server"></asp:TextBox>
			<asp:Label id="lblActiveE7" style="Z-INDEX: 1113; LEFT: 500px; POSITION: absolute; TOP: 480px; color: red;" runat="server">TRUE or FALSE!</asp:Label>
			<asp:Label id="lblExtra8" style="Z-INDEX: 114; LEFT: 208px; POSITION: absolute; TOP: 530px" runat="server">Extra</asp:Label>
			<asp:TextBox id="txbExtra8" style="Z-INDEX: 115; LEFT: 280px; POSITION: absolute; TOP: 530px" runat="server"></asp:TextBox>
			<asp:Label id="lblSumMore9" style="Z-INDEX: 116; LEFT: 208px; POSITION: absolute; TOP: 580px" runat="server">SumMore</asp:Label>
			<asp:TextBox id="txbSumMore9" style="Z-INDEX: 117; LEFT: 310px; POSITION: absolute; TOP: 580px" runat="server"></asp:TextBox>		                 
		    
		    <!--   /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////                        
		    <br> We are done... almost....<br>             
		     -->            
		     <input id="btnAdd" type="submit" value="Register" style="Z-INDEX: 118; LEFT: 280px; POSITION: absolute; TOP: 660px" runat="server"/>
			 <input id="btnCancel" type="submit" value="Cancel" style="Z-INDEX: 119; LEFT: 280px; POSITION: absolute; TOP: 710px" runat="server" />
			 <a href="hperson.aspx" style="Z-INDEX: 120; LEFT: 280px; POSITION: absolute; TOP: 760px" >Help!</a>            
            <div>		    
		         <a style="Z-INDEX: 121; LEFT: 280px; POSITION: absolute; TOP: 810px" >
		            <p> Info...<br></p> 
                     <p>
                      <textarea id="txaLog" itemtype="text" itemscope="" cols="30" rows="10" runat="server" ></textarea>  
                      <INPUT type="reset">
                     </p>		            
		        </a>
		    </div>
		    
		
		<!-- //////////////////////////////////////////////////////// -->	
		
		</form>
		    <div> 
               <footer>	
                 <p><small>               
		          <a style="Z-INDEX: 124; LEFT: 280px; POSITION: absolute; Top : 1050px" >
		            <p><br>// We are done.2017 //<br>////////wwwwwwwwwwwwww//////////<br></p>
		         </a>
		        </small><br></p>
		       </footer>
		    </div>
		    </body>
</html> 
	