//
//
"use strict";
//
 var ref = 1; 
           var mes = "OLSystem : ";
           var mes2 = "SqlServer2012";           
           var info = "bmb21bmb@gmail.com";
           function init() {
            document.getElementById("btnHelp").onclick = function(){
            var b2 = document.getElementById("btnHelp");
            //window.alert(mes+" "+"ref#"+ref);  
            document.forms.frmWw23p.elements.txaLog.value += " \n For more please consult:"+"\n"+info+"\n"+mes+mes2+"\n";
            var txa22 = document.forms.frmWw23p.elements.txaLog.value;   
            window.alert(txa22);
            
            ref++;
            window.open("frmNewp.aspx");
            b2.form.onsubmit = function () { document.forms.frmWw23p.elements.txaLog.value += "\n Opening...new frm..."+ ref + " ..\n...." };
            };
          };  
           
           window.onload = function(){
             init();
            };
    


