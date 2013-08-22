using System;
using System.Diagnostics;
using System.Threading;
using GLib;
using Gtk;

public partial class MainWindow: Gtk.Window
{
	private static Label label;
	private static int inc;
	private static int idleInc;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		//Initial value
		idleInc = inc = 0;
		// static of label1
		label = this.label1;

		// Create idle handler
		GLib.Idle.Add (new IdleHandler (OnIdleDoWork));
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnButtonClicked (object sender, EventArgs e)
	{
		//throw new System.NotImplementedException ();
		Debug.WriteLine("OnButtonClicked");
		inc++;
		button.Label = "Clicked "+inc.ToString();
	}

	bool OnIdleDoWork ()
	{
		// Do small bits of work
		idleInc++;
		Debug.WriteLine("OnIdleDoWork()" + idleInc.ToString());
		// lots of processing here
		int x = 0;
		int y = 0;
		for(x=0;x<10;x++){
			for(y=0;y<10;y++){
				Debug.Write(".");
			}
		}
		Debug.WriteLine("|");
		return true;
	}
}
