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
using System.Resources;
using System.Text.RegularExpressions;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace personh
{
	public class hperson : System.Web.UI.Page
	{
		protected HtmlInputButton btnOk;
		protected HtmlInputText inpServer;
		protected HtmlInputText inpName;
		protected HtmlInputText inpID;
		protected HtmlInputButton btnDelete;
		protected HtmlInputButton btnHelp;
		protected HtmlInputButton btnUpdate;
		protected TextBox txbIdentity1;
		protected TextBox txbFirstName2;
		protected TextBox txbSurname3;
		protected TextBox txbAge4;
		protected TextBox txbSex5;
		protected TextBox txbMobile6;
		protected TextBox txbActive7;
		protected TextBox txbExtra8;
		protected TextBox txbSumMore9;
		protected HtmlTextArea txaLog;
		protected FileInfo fliPage;
		protected Label lblIdentityE1;
		protected Label lblFirstNameE2;
		protected Label lblAgeE4;
		protected Label lblSexE5;
		protected Label lblMobileE6;
		protected Label lblActiveE7;
			
		
		
		
		List<String> perList = new List<string>();
		string pname = "Person1";
		string serverNameDs = "Data_Source";
		string pid = "0";
		//String[] datap;
		int pn = 0;
		
		
		//string fileN = "Person.csv";
		FileInfo fileNi = new FileInfo("Person.csv");
		String fileN = ".../personv2.csv";
		
		
		int lineN = 0;
		static int cp = 0;
		int cp2 = 4;
		static String ppName = "ppName";
		static string dsName = "MSSQL";
		string  color = @"<FONT COLOR="+"Yellow"+">";
		
		//OleDbConnection connp = null;
		SqlConnection sconnp = null;
		
		public hperson()
		{
			Page.Init += new System.EventHandler(initPage);
			pn++;
			
		}
		
		private void initPage(object sender, EventArgs e)
		{
			initializePg();
		}
		
		private void initializePg()
		{
			//
			cp++;//1
			Response.Write(color+"<h2>Welcome to wwwPerson site.</h2></font>");
			txaLog.Value += cp++ + " Initializing...\n";//2
			this.Error += new EventHandler(Page_Err);
			btnOk.ServerClick += new EventHandler(Click_btnOk);
			inpID.ServerChange += new EventHandler(Changed_inpID);
			btnUpdate.ServerClick += new EventHandler(upDate_Click);
			btnHelp.ServerClick += new EventHandler(Click_btnHelp);
			btnDelete.ServerClick += new EventHandler(Click_btnDelete);
			inpServer.ServerChange += new EventHandler(Changed_inpServer);
			//
			lblIdentityE1.Visible = false;
			lblFirstNameE2.Visible = false;
			lblAgeE4.Visible = false;
			lblSexE5.Visible = false;
			lblMobileE6.Visible = false;
			lblActiveE7.Visible = false;
			fileN = AppRelativeVirtualPath;
			fileN = MapPath(fileN);
			txaLog.Value += cp++ + " File path = " + fileN + "...\n";//3
			cp2 = 3;
			if (cp == (cp2 + 1)) {
				txaLog.Value += cp++ + " ApplicationException : " + cp + "...\n";//4	
				throw new ApplicationException("Error...person# " + cp);
			}
		   
		}
		
		private void Page_Err(Object sender, EventArgs e)
		{
			Exception exc = Server.GetLastError();
			Response.Write("Controlled exception #PageErr001... ... \n<br>" +
			exc.Message + "<br>");
			//Server.ClearError();
			//initializePg();
			//Response.Redirect("ww23p.aspx");
			
		}
		
		
		protected void Click_btnOk(object sender, EventArgs e)
		{
			pn++;
			pname = inpName.Value;
		     
			clearFrm1();
			if (pname != "") {
				txbFirstName2.Text = pname;
				ppName = pname;
			}
			if (inpServer.Value != "")
				dsName = @inpServer.Value;
			pid = inpID.Value;
			txbIdentity1.Text = pid;
			//fillUp();
			readFilep(fileN);
		    
		}
		
		protected void Click_btnHelp(object sender, EventArgs e)
		{
			pn++;
			clearFrm1();
			if (inpID.Value == "")
				inpID.Value = "0";
			readFilep(fileN);
		    
		}
		
		protected void Changed_inpID(object sender, EventArgs e)
		{
			pn++;
			txaLog.Value += cp++ + " ( " + inpName.Value + " ...online!..." + pn + " )\n";
			try {
				int id = Int32.Parse(inpID.Value);
				btnUpdate.Visible = true;
				btnDelete.Visible = true;
				
			} catch {
				inpID.Value = "0";				
				cp++;
				txaLog.Value += cp++ + " " + " int value needed for this input ID...\n";
				txaLog.Focus();
				
			}
		}
	
		protected void Changed_inpServer(object sender, EventArgs e)
		{
			if (inpServer.Value != "") {
				dsName = @inpServer.Value;
				txaLog.Value += cp++ + " SQLServer = " + @dsName + "...\n";
			}
		}
		
		protected void upDate_Click(object sender, EventArgs e)
		{
			txaLog.Value += cp++ + " list size = " + perList.Count + " \n ";
			
			pn++;
			int errp = 0;
			Char p1 = '"';
			//Char p2 = ' ';
			string newtxb;
			
			lblIdentityE1.Visible = false;
			if (txbIdentity1.Text == "0")
				txbIdentity1.Text = "";
			try {
				int id = Int32.Parse(txbIdentity1.Text);
			} catch { 
				errp++;
				txbIdentity1.Text = "";
				txbIdentity1.Focus();
				lblIdentityE1.Visible = true;
			}
			
			lblFirstNameE2.Visible = false;
			if (txbFirstName2.Text == "") { 
				errp++;
				txaLog.Value += cp++ + " " + " ...Please Enter your Name...\n";
				txbFirstName2.Focus();
				lblFirstNameE2.Visible = true;			
			} else if (txbFirstName2.Text.Contains(p1.ToString())) {
				newtxb = txbFirstName2.Text;
				txbFirstName2.Text = newtxb.Trim(p1);
			}
			//
			if (txbSurname3.Text != "") { 	
				if (txbSurname3.Text.Contains(p1.ToString())) {
					newtxb = txbSurname3.Text.Trim(p1);
					txbSurname3.Text = newtxb;
				}
			}
			//
			lblAgeE4.Visible = false;
			if (txbAge4.Text != "")
				try {
					int age = Int32.Parse(txbAge4.Text);
				} catch {
					errp++;
					txaLog.Value += cp++ + " " + " ..Please enter your Age in numbers...\n";
					txbAge4.Text = "";
					txbAge4.Focus(); 
					lblAgeE4.Visible = true;
				}
			
			lblSexE5.Visible = false;
			if (txbSex5.Text != "") {
				//
				if (txbSex5.Text.Contains(p1.ToString())) {
					newtxb = txbSex5.Text.Trim(p1);
					txbSex5.Text = newtxb;
				}
				//
				
				Regex regSex = new Regex("^MALE$|^FEMALE$|^\"M\"$|^\"F\"$|^M$|^F$");
				string sx = txbSex5.Text.ToUpper();
				Match sxM = regSex.Match(sx);
				if (!sxM.Success) {
					errp++;
					txaLog.Value += cp++ + " " + sxM + " ..Please enter: M or F ...\n";
					txbSex5.Text = "";
					txbSex5.Focus();
					lblSexE5.Visible = true;
				}
			}
			
			lblMobileE6.Visible = false;
			if (txbMobile6.Text != "") {
				Regex regMobi = new Regex("^0\\d{9}$");
				string mb = txbMobile6.Text;
				Match mbM = regMobi.Match(mb);
				if (!mbM.Success) {
					errp++;
					txaLog.Value += cp++ + " " + mbM + " ..Please enter your mobile# eg... 0821234567 ...\n";
					txbMobile6.Text = "";
					txbMobile6.Focus();
					lblMobileE6.Visible = true;			    
				}
			}
			
			lblActiveE7.Visible = false;
			if (txbActive7.Text != "") {
				Regex regActive = new Regex("^TRUE$|^FALSE$");
				string mAct = txbActive7.Text.ToUpper();
				Match mbM = regActive.Match(mAct);
				if (!mbM.Success) {
					errp++;
					txaLog.Value += cp++ + " " + mbM + " ..Please enter TRUE OR FALSE ...\n";
					txbActive7.Text = "";
					txbActive7.Focus();
					lblActiveE7.Visible = true;
				}
			}
			
			txaLog.Value += "\n" + cp++ + " errp = " + errp + "\n//////\\\\\\////\n";
			if (errp == 0) {
				txaLog.Value += "\n" + cp++ + " Updating......\n";
				txaLog.Value += cp++ + " list size = " + perList.Count + " \n ";
				upDatep();
				inpID.Value = "";
				btnUpdate.Visible = false;
				btnDelete.Visible = false;
				clearFrm1();
			}
		}
		//////////////////////////////		
			
		protected void upDatep()
		{
			string upD = "";
			
			int idD = Int32.Parse(txbIdentity1.Text);
			upD += txbIdentity1.Text + "," + txbFirstName2.Text + "," +
			txbSurname3.Text + "," + txbAge4.Text + "," +
			txbSex5.Text + "," + txbMobile6.Text + "," +
			txbActive7.Text + "," + txbExtra8.Text + ",";
			txaLog.Value += cp++ + "#@ " + upD + "\n";
			inpID.Value = idD.ToString();
			//fileN = AppRelativeVirtualPath;
			//txaLog.Value += cp++ +" File path = " + fileN + "...\n";
			readFilep(fileN);
			txaLog.Value += cp++ + " @UpD list size = " + perList.Count + " \n ";
			txaLog.Value += cp++ + " old list =  " + perList[idD] + "\n";
			perList[idD] = upD;
			txaLog.Value += cp++ + " new list = " + perList[idD] + "\n";
			string pfilep = "personv2.csv";
			fileNi = new FileInfo(fileN);
			string pfile = fileNi.DirectoryName + @"/" + pfilep;
			//FileStream filpStream = new FileStream(pfile,FileMode.Open, FileAccess.Write);
			//
			//StreamWriter stmWrite = new StreamWriter (filpStream);
			StreamWriter strWrite = new StreamWriter(pfile, false);
			
			for (int i = 0; i < perList.Count; i++) {
			
				if (perList[i] != "")
					strWrite.WriteLine(perList[i]);
				
			}
			strWrite.Close();
			readFilep(fileN);
			//
			string age = "0";
			if (txbAge4.Text != "")
				age = txbAge4.Text;
		    
			string pCommand = @"UPDATE [PERSON33].[SCPERSON].[TBPERSON] " +
			                  @"SET " +
			                  @" FirstName ='" + @txbFirstName2.Text + @"'," +
			                  @" Surname ='" + @txbSurname3.Text + @"'," +
			                  @" Age =" + @age + @"," +
			                  @" Sex ='" + @txbSex5.Text + @"'," +
			                  @" Mobile ='" + @txbMobile6.Text + @"'," +
			                  @" Active ='" + @txbActive7.Text + @"'" +
			                  @" WHERE [Identity] =" + @txbIdentity1.Text;
			
			
			
			modQNewp(pCommand);
			
			
		}
		///////////////// 
		public void modQNewp(string pqCommand)
		{
			//
			txaLog.Value += cp++ + " " + "saving ........\n";
			string pfilep = @"person33.mdf";
			string dbmsv = @"SqlServer2012";
			serverNameDs = @dsName;
				
			fileNi = new FileInfo(fileN);
			string pfile = fileNi.DirectoryName + @"/" + pfilep;
			//string pconnstr = @"Provider=SQLOLEDB;User Id=newp22;Password=newp22;Integrated Security=SSPI;Data Source="+serverNameDs;    
			//OleDbDataReader dbReadp = null;
			string pconnstr = @"Initial Catalog=person33;User Id=sa;Password=pwd;Integrated Security=SSPI;Data Source=" + serverNameDs;
			//string pconnstr = @"User Id=newp22;Password=newp22;Initial Catalog=person33;Integrated Security=SSPI;Data Source="+@serverNameDs;
			SqlDataReader dbReadp = null;
			try {                
				          
				//connp = new OleDbConnection(pconnstr);
				//connp.Open();
				sconnp = new SqlConnection(pconnstr);
				sconnp.Open();
				txaLog.Value += cp++ + " " + "connecting........\n";
				//OleDbCommand cmdp = connp.CreateCommand();
				SqlCommand cmdp = sconnp.CreateCommand();
				cmdp.CommandText = pqCommand;
				dbReadp = cmdp.ExecuteReader();
				//int qr = cmdp.ExecuteNonQuery();
				txaLog.Value += cp++ + " cols = " + dbReadp.FieldCount.ToString() + "......\n";
				//txaLog.Value += cp++ +" rows = "+ qr.ToString() +"......\n";
				//connp.Close();
				sconnp.Close();
				txaLog.Value += cp++ + " execute reader = done......\n";
				
			} catch (Exception e) {
				txaLog.Value += cp++ + " " + "saving exception ...\n" + e.Message + " \n";
				txaLog.Value += cp++ + " Connect..or Attach.. " + @pfile + "......\n";	
				txaLog.Value += cp++ + " @.. " + @dbmsv + "......\n";               
			}
			
		}
		/////////////////////// 
		
		protected void Click_btnDelete(object sender, EventArgs e)
		{
			//
			try {
				lblIdentityE1.Visible = false;
				int idD = Int32.Parse(txbIdentity1.Text);
				string pDdeletep = @"Delete FROM [person33].[scperson].[tbPerson]" +
				                   @" WHERE [Identity] =" + @txbIdentity1.Text;
				modQNewp(pDdeletep);
				deletePp();
				txaLog.Value += cp++ + " " + "Deleting ...\n";
			    
			} catch (Exception ed) {
				txaLog.Value += cp++ + " " + "Delete exception ...\n" + e.ToString() +
				" " + ed.Message + " \n";
				lblIdentityE1.Visible = true;
			}
			
		}
		
		public void readFilep(String pfile)
		{
			
			string pfilep = "personv2.csv";
			fileNi = new FileInfo(pfile);
			try {
				try { 
					txaLog.Value += cp++ + " " + fileNi.DirectoryName + "\n";
					txaLog.Value += cp++ + " " + fileNi.FullName + "\n";
					txaLog.Value += cp++ + " " + fileNi.Name + "\n";
					txaLog.Value += cp++ + " " + fileNi.Length + "\n";
				} catch (Exception e) {
					txaLog.Value += cp++ + " " + e.Message + "...\n";
				}
					
				pfile = fileNi.DirectoryName + @"/" + pfilep;
				FileStream filpStream = new FileStream(pfile, FileMode.Open, FileAccess.Read);
				//
				StreamReader stmRead = new StreamReader(filpStream);
			   
				String line = stmRead.ReadLine();
				perList.Add(line);
			    
				while (line != null) {
					line = stmRead.ReadLine();
					if (line != "") {
						perList.Add(line);
						lineN++; 
					}
				  
				} 
				lineN -= 1;
				txaLog.Value += cp++ + " lines# : " + lineN + "\n";
				txaLog.Value += cp++ + " list size = " + perList.Count + " \n ";
			     
				fillUp();    
				stmRead.Close();
             
			} catch (Exception e) {
				//
				txaLog.Value += cp++ + " " + " ..#..System offline.....\n" +
				e.Message + "...\n";
			}	
			
		}
		
		public void fillUp()
		{
			try {
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
				//
				if (infoL.Length >= 8) {
					txbExtra8.Text = infoL[7];
					if (infoL.Length >= 9)
						txbSumMore9.Text = infoL[8];
					//inpID.Value = "";
				}
				txaLog.Value += cp++ + " ( records size = " + infoL.Length + ")\n";
				txaLog.Value += cp++ + " list size = " + perList.Count + " \n ";
			} catch {
				txaLog.Value += cp++ + " " + " ..System Offline...\n";
				
			}
		}
		
		protected void deletePp()
		{
			try {
				lineN = 0;
				string dp = txbIdentity1.Text;
				int rdp = Int32.Parse(dp);
				dp += @",DELETED,DELETED," +
				"0" + "," + "" + "," + "" + "," + "" + "," + "" + ",";
				string pfilep = "personv2.csv";
			
				fileNi = new FileInfo(fileN);
				List<string> deletedL = new List<string>();
			
			
				string pfile = fileNi.DirectoryName + @"/" + pfilep;
				FileStream filpStream = new FileStream(pfile, FileMode.Open, FileAccess.Read);
				//
				StreamReader stmRead = new StreamReader(filpStream);
			   
				String line = stmRead.ReadLine();
				deletedL.Add(line);
				lineN++;
				while (line != null) {
					line = stmRead.ReadLine();
					if (line != "") {
						if (lineN == rdp)
							deletedL.Add(dp);
						else
							deletedL.Add(line);
						lineN++; 
					}
				  
				}
				stmRead.Close();
				//
				StreamWriter strWrite = new StreamWriter(pfile, false);
			
				for (int i = 0; i < deletedL.Count; i++) {
			
					if (deletedL[i] != "")
						strWrite.WriteLine(deletedL[i]);
				
				}
				strWrite.Close();
				readFilep(fileN);
				inpID.Value = "";
				btnUpdate.Visible = false;
				btnDelete.Visible = false;
				clearFrm1();
			    
				//
			} catch (Exception e) {
				txaLog.Value += cp++ + " " + " ..**System Offline**...\n" +
				e.Message + "\n";
			}
			    
		}
		////// ///
		
		
		protected void clearFrm1()
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
				
	}
	////////////////....class.../////////////////////////////////
	//////	                                            /////////
}
//////////////////..namaspace....//////////////////////////////
	