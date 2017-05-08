
using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;

namespace personh
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : HttpApplication
	{
		//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		#region global
		/// <summary>
		/// Required designer variable.
		/// </summary>
		//private System.ComponentModel.IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}

		#endregion
		//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		protected void Application_Start(Object sender, EventArgs e)
		{

		}

		protected void Session_Start(Object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_Error(Object sender, EventArgs e)
		{
			try{
			    string strf = Server.MapPath("logp2.txt");
			    System.IO.StreamWriter log = new System.IO.StreamWriter(strf);
			    Exception exc = Server.GetLastError();
			    log.WriteLine(exc.ToString());
			    Response.Write("<br> Message #TRY01 <br> ");
			}
			catch(Exception exm)
			   {
				//
				Response.Write("<br> Message #EXC02 <br> "+ exm.Message + " <br>");
				Response.Redirect("frmNewp.aspx");
			    }
			
			Server.ClearError();
			Response.Write("<br> Message #APPE03 <br> " );
			Response.Redirect("frmNewp.aspx");


			

		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}

		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

		}
		#endregion
	}
}
