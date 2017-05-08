//
//
//
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data.Sql;
using System.Data.SqlClient;




namespace personh
{
	/// <summary>
	/// Description of frmNewp
	/// </summary>
	public class frmNewp : System.Web.UI.Page
	{
		//protected Button btnOK3;
		protected HtmlInputButton	 btnOk;
		protected HtmlInputText      inpServer;
		protected HtmlInputText      inpName;
		protected HtmlInputText      inpID;
		protected HtmlInputButton	 btnCancel;
		protected HtmlInputButton    btnAdd;
		protected TextBox            txbIdentity1;
		protected TextBox            txbFirstName2;
		protected TextBox            txbSurname3;
		protected TextBox            txbAge4;
		protected TextBox            txbSex5;
		protected TextBox            txbMobile6;
		protected TextBox            txbActive7;
		protected TextBox            txbExtra8;
		protected TextBox            txbSumMore9;
		protected HtmlTextArea       txaLog;
		protected FileInfo           fliPage;
		protected Label              lblIdentityE1;
		protected Label              lblFirstNameE2;
		protected Label              lblAgeE4;
		protected Label              lblSexE5;
		protected Label              lblMobileE6;
		protected Label              lblActiveE7;
	
		
		
		List<String> perList = new List<string>();
		string pname = "Person1";
		string serverNameDs ="Data_Source";
		static string pid ="0";
		//String[] datap;
		int pn = 0;
		
		//string fileNa = "Person.csv";
		FileInfo fileNi = new FileInfo("Person.csv");
		String fileN = ".../.../personv2.csv";
		
		static int lineN;
		static string dsName = "MSSQL";
		int cp;
		
		//OleDbConnection connp = null;
		//OdbcConnection oconnp = null;
		SqlConnection sconnp = null;
		
		
		public frmNewp()
		{
			Page.Init += new System.EventHandler(initPage);
			pn++;
		
			
		}
		
		private void initPage(object sender, EventArgs e )
		{
			initializePg();
		}
		
		private void initializePg()
		{
			//
			lineN = 0;
			cp = 0;
			cp++; 
			Response.Write("<h3>Welcome to New DataPerApp.</h3>");
			txaLog.Value += cp++ + " Initializing...\n";
			btnOk.ServerClick	 += new EventHandler(Click_btnOk);
			inpID.ServerChange += new EventHandler(Changed_inpID);
			btnAdd.ServerClick += new EventHandler(Click_btnAdd);
			btnCancel.ServerClick += new EventHandler(Click_btnCancel);
			inpServer.ServerChange += new EventHandler(Changed_inpServer);
		    //
		    lblIdentityE1.Visible = false;
		    lblFirstNameE2.Visible = false;
		    lblAgeE4.Visible = false;
		    lblSexE5.Visible = false;
		    lblMobileE6.Visible = false;
		    lblActiveE7.Visible = false;
		    //
		    fileN = AppRelativeVirtualPath;
		    fileN = MapPath(fileN);
			txaLog.Value += cp++ +" File path = " + fileN + "...\n";
			inpID.Value = "0";
			readFilep(fileN);//1
			clearFrm2();//2
			inpID.Value = lineN.ToString();//3
			txbIdentity1.Text = inpID.Value;
			//readFilep(fileN);
		    
		}
		
		
		protected void Click_btnOk(object sender, EventArgs e)
		{
			 pn++;
		     pname = inpName.Value;
		     pid = inpID.Value;
		     clearFrm2();
		     if(pname != "")
		     {
		      txbFirstName2.Text = pname;
		     }
		     if(inpServer.Value !="")
		     	dsName = @inpServer.Value;
		     txbIdentity1.Text = pid;
		     //
		     readFilep(fileN);
		     //fillUp();
		     btnCancel.Visible = true;
		     btnAdd.Visible = true;
		    
		}
		
		protected void Click_btnCancel(object sender, EventArgs e)
		{
			clearFrm2();
		    
		}
		
		protected void Changed_inpID(object sender, EventArgs e)
		{
			pn++;
			try
			{
				int id = Int32.Parse(inpID.Value);
				
			}
			catch
			{
				inpID.Value = "0";
				txaLog.Focus();
				cp++;
				txaLog.Value += cp++ +" "+" int value needed for this input...\n";
					
			}
		}
		
		protected void Changed_inpServer(object sender, EventArgs e)
		{
			if(inpServer.Value !="")
			{
		       dsName = @inpServer.Value;
			   txaLog.Value += cp++ +" SQLServer = "+@dsName +"...\n";
			}
		}
	
		protected void Click_btnAdd(object sender, EventArgs e)
		{
			txaLog.Value += cp++ +" list size = " + perList.Count +" \n ";
			Char p1 = '"';
			//Char p2 = ' ';
			pn++;
			int errp = 0;
			btnCancel.Visible = true;
			lblIdentityE1.Visible = false;
			if (txbIdentity1.Text == "0")
				txbIdentity1.Text = "";
			try{int id = Int32.Parse(txbIdentity1.Text);}
			catch{ 
				   errp++;
				   txbIdentity1.Text = "";
				   txbIdentity1.Focus();
			       lblIdentityE1.Visible = true;
			    }
			
			lblFirstNameE2.Visible = false;
			string newtxb;
			
			if (txbFirstName2.Text == "")
	          { 
				errp++;
				txaLog.Value += cp++ +" "+" ...Please Enter your Name...\n";
				txbFirstName2.Focus();
                lblFirstNameE2.Visible = true;			
			  }
			    else
			    	if (txbFirstName2.Text.Contains(p1.ToString()))
			    {
			    	newtxb = txbFirstName2.Text.Trim(p1);    	
			    	txbFirstName2.Text = newtxb;
			    }
			    
			    //
            if (txbSurname3.Text != "")
	          { 	
				if(txbSurname3.Text.Contains(p1.ToString()))
			    	{
					  newtxb = txbSurname3.Text.Trim(p1);
				      txbSurname3.Text = newtxb;
				    }
             }
			//
			    
			lblAgeE4.Visible = false;
			if (txbAge4.Text != "")
			   try{ int age = Int32.Parse( txbAge4.Text);}
			   catch{
				     errp++;
				     txaLog.Value += cp++ +" "+" ..Please enter your Age in numbers...\n";
				     txbAge4.Text = "";
			         txbAge4.Focus(); 
				     lblAgeE4.Visible = true;
			        }
			
			lblSexE5.Visible = false;
			if (txbSex5.Text != "")
			 {
				//
                if (txbSex5.Text.Contains(p1.ToString()))
			    	  {
					    newtxb = txbSurname3.Text.Trim(p1);
				        txbSex5.Text = newtxb;
				      }
			      //
				
				Regex regSex = new Regex ("^MALE$|^FEMALE$|^\"M\"$|^\"F\"$|^M$|^F$");
				string sx =  txbSex5.Text.ToUpper();
				 Match sxM = regSex.Match(sx);
				 if (!sxM.Success){
				 	       errp++;
				           txaLog.Value += cp++ +" "+ sxM +" ..Please enter: M or F ...\n";
				           txbSex5.Text = "";
				           txbSex5.Focus();
				           lblSexE5.Visible = true;
				          }
			  }
			
			lblMobileE6.Visible = false;
			if(txbMobile6.Text != "")
			{
				Regex regMobi = new Regex ("^0\\d{9}$");
				string mb = txbMobile6.Text;
				Match mbM = regMobi.Match(mb);
				 if (!mbM.Success){
					       errp++;
				           txaLog.Value += cp++ +" "+ mbM +" ..Please enter your mobile# eg... 0821234567 ...\n";
				           txbMobile6.Text = "";
	              		   txbMobile6.Focus();
	                       lblMobileE6.Visible = true;			    
				          }
			}
			
			lblActiveE7.Visible = false;
			if (txbActive7.Text != "")
			{
				Regex regActive = new Regex ("^TRUE$|^FALSE$");
				string mAct = txbActive7.Text.ToUpper();
				Match mbM = regActive.Match(mAct);
				 if (!mbM.Success){
					       errp++;
				           txaLog.Value += cp++ +" "+ mbM +" ..Please enter TRUE OR FALSE ...\n";
				           txbActive7.Text = "";
	              		   txbActive7.Focus();
				           lblActiveE7.Visible = true;
				          }
			}
			
			txaLog.Value += "\n"+cp++ +" errp = "+errp +"\n//////\\\\\\////\n";
			if(errp == 0)
			{
				txaLog.Value += "\n"+ cp++ + " Updating......\n";
				txaLog.Value += cp++ +" list size = " + perList.Count +" \n ";
				addNewp();
				btnCancel.Visible = false;
				btnAdd.Visible = false;
			}
			
		}////     ///
		//////////////////// 
		protected void addNewp()
		{
			string upD = "";
			
			txbIdentity1.Text = lineN.ToString();
			int idD = Int32.Parse( txbIdentity1.Text );
			upD += txbIdentity1.Text +","+ txbFirstName2.Text +","+
				 txbSurname3.Text +","+ txbAge4.Text +","+
				 txbSex5.Text +","+ txbMobile6.Text +","+
				 txbActive7.Text +","+ txbExtra8.Text +",";
			txaLog.Value += cp++ +"#@ "+ upD +"\n";
			inpID.Value = idD.ToString();
			//fileN = AppRelativeVirtualPath;
			//txaLog.Value += cp++ +" File path = " + fileN + "...\n";
			//readFilep(fileN);
			txaLog.Value += cp++ +" @UpD list size = " + perList.Count +" \n ";
			//txaLog.Value += cp++ +" old list =  "+ perList[idD] +"\n";
			perList[idD] = upD;
			//txaLog.Value += cp++ +" new list = "+ perList[idD] +"\n";
			string pfilep = "personv2.csv";
			fileNi = new FileInfo(fileN);
			string pfile = fileNi.DirectoryName +  @"/"+ pfilep;
			//readFilep(pfile);
			FileStream filpStream = new FileStream(pfile,FileMode.Open, FileAccess.Write);
			//
			StreamWriter stmWrite = new StreamWriter (filpStream);
			//StreamWriter strWrite = new StreamWriter(pfile,true);
			//StreamWriter strWrite = new StreamWriter(pfile,false);
			//
			//stmWrite.WriteLine(upD);
			//strWrite.Write(upD);
			for(int i = 0; i< perList.Count; i++)
			{
				if(perList[i] != "")
				stmWrite.WriteLine(perList[i]);
				
			}
			stmWrite.Close();
			readFilep(fileN);
			//
			//insert into
		    //db.schema.tbl
		    //
		    string age = "0";
		    if(txbAge4.Text !="")
		    age = txbAge4.Text;
		    string db_sch_tbl =@"[PERSON33].[SCPERSON].[TBPERSON]";
		    //
			string pCommand = @"INSERT INTO "+db_sch_tbl+@"
		      	                  ([Identity], FirstName, Surname, Age,
                                    Sex, Mobile, Active )
		      	                  VALUES ("+@txbIdentity1.Text+"," 
		      	                   +"'"+@txbFirstName2.Text+"'," 
                                   +"'"+@txbSurname3.Text+"',"
		      	                   +@age+","
                                   +"'"+@txbSex5.Text+"',"
		      	                   +"'"+@txbMobile6.Text+"',"
                                   +"'"+@txbActive7.Text+"')";
		    
			
		      
			  modQNewp(pCommand);
			
			
		}
		///////////////// 
		public void modQNewp(string pqCommand)
		{
			//
			txaLog.Value += cp++ +" "+ "saving ........\n";
			string pfilep = @"person33.mdf";
			string dbmsv = @"SqlServer2012";
			//string pcatalog = "person33";
			fileNi = new FileInfo(fileN);
			string pfile = fileNi.DirectoryName +  @"/"+ pfilep;
			//
			serverNameDs = @dsName;
			//string pconnstr = @"User Id=newp2;Password=newp2;Initial Catalog=person33;Integrated Security=SSPI;Data Source="+@serverNameDs;
			//string pconnstr = @"Initial Catalog=person33;User Id=sa;Password=pwd;Integrated Security=SSPI;Data Source="+serverNameDs;
			string pconnstr = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=person33;Data Source="+serverNameDs;
			//string pconnstr2 = @"Provider=SQLOLEDB;Initial Catalog=person33;User Id=newp2;Password=newp2;Integrated Security=SSPI;Data Source="+serverNameDs; 
			//string pconnstr2 = @" Provider=SQLNCLI11.1;Integrated Security=SSPI;Persist Security Info=False;User ID="";Initial Catalog="+@pcatalog+@";Data Source="+@serverNameDs+";Server SPN="";Initial File Name="+@pfile;
			//string pconnstr2 = @" Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=person33;Data Source="+@serverNameDs+";Initial File Name="+@pfile;
			//OleDbDataReader dbReadp = null;
			SqlDataReader dbReadp = null;
			try
			  {
				
				//connp = new OleDbConnection(pconnstr2);
				//connp.Open();
				sconnp = new SqlConnection(pconnstr);
				sconnp.Open();
				
				txaLog.Value += cp++ +" "+ "connecting........\n";
				//OleDbCommand cmdp = connp.CreateCommand();
				SqlCommand cmdp = sconnp.CreateCommand();
				cmdp.CommandText = pqCommand;
				dbReadp = cmdp.ExecuteReader();
				//int qr = cmdp.ExecuteNonQuery();
				txaLog.Value += cp++ +" cols = "+ dbReadp.FieldCount.ToString() +"......\n";
				//txaLog.Value += cp++ +" rows = "+ qr.ToString() +"......\n";
				//connp.Close();
				sconnp.Close();
				txaLog.Value += cp++ +" "+ "done........\n";
		       }
			catch(Exception e)
			{
			  txaLog.Value += cp++ +" "+ "saving exception ...\n"+ e.Message +" \n";
              txaLog.Value += cp++ +" Connect.. or Attach.. "+@pfile+"......\n";
              txaLog.Value += cp++ +" @.. "+@dbmsv+"......\n";              
			}
			inpID.Value = "";
			clearFrm2();
			
		}
		/////////////////////// 
		
		
		
		public void readFilep(String pfile)
		{
			lineN = 0;
			string pfilep = "personv2.csv";
			fileNi = new FileInfo(pfile);
			try{
				try{ 
				     txaLog.Value += cp++ +" "+ fileNi.DirectoryName + "\n";
				     txaLog.Value += cp++ +" "+ fileNi.FullName + "\n";
				     txaLog.Value += cp++ +" "+ fileNi.Name +"\n";
				     txaLog.Value += cp++ +" "+ fileNi.Length + "\n";
				}catch(Exception e)
				{
					txaLog.Value += cp++ +" " + e.Message + "...\n";
				}
				
				 pfile = fileNi.DirectoryName +  @"/"+ pfilep;
			    //
			     FileStream filpStream = new FileStream(pfile,FileMode.Open, FileAccess.Read);
			    //
			     StreamReader stmRead = new StreamReader(filpStream);
			    //
			    String line = stmRead.ReadLine();
			    //txaLog.Value += line +"\n";
			    perList.Add(line);
			    lineN++;
			     while(line != null)
			     {
				    line = stmRead.ReadLine();
				    if(line != "")
				    {
				      perList.Add(line);
				      lineN++;
				    }
				     
			     }
                  lineN -= 1 ;
			      txaLog.Value += cp++ +" lines# : "+ lineN +"\n";
			      txaLog.Value += cp++ +" list size = " + perList.Count +" \n ";
			     			     
			     
			 fillUp();    
             stmRead.Close();
             
			}catch (Exception e)
			   {
				//Response.Write("...System offline...");
				txaLog.Value += cp++ +" "+" ..#..System offline.....\n"+
					                          e.Message + "...\n";
				}	
			
		}
		
		public void fillUp()
		{
		  try{
			string rd = inpID.Value;
			int r = Int32.Parse(rd);
			string infoS = perList[r];
			string[] infoL = infoS.Split(',');
			txbIdentity1.Text = infoL[0];
			txbFirstName2.Text = infoL[1];
			txbSurname3.Text = infoL[2];
			txbAge4.Text = infoL[3];
			txbSex5.Text = infoL[4];
			txbMobile6.Text = infoL[5];
			txbActive7.Text = infoL[6];
			//Response.Write("records size = "+infoL.Length);
			if(infoL.Length>=8){
			txbExtra8.Text = infoL[7];
			if(infoL.Length>=9)
			txbSumMore9.Text = infoL[8];
			//inpID.Value = "";
			}
		 }
			catch
			    {
				  txaLog.Value += cp++ +" "+" ..System Offline...\n";
				  
			    }
		}
		
		
		
		protected void clearFrm2 ()
		{
			inpName.Value = "";
			txbIdentity1.Text = "";
			txbFirstName2.Text = "";
			txbSurname3.Text = "";
			txbAge4.Text = "";
			txbSex5.Text = "";
			txbMobile6.Text = "";
			txbActive7.Text = "";
			txbExtra8.Text = "";
			txbSumMore9.Text = "";
			
		}
		

	}//////////////////////////////////
	////                             // 
	////Done.2017.v01                //
}//////////////////////////////////////