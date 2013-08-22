using System;
using System.Diagnostics;
using GLib;
using Gtk;

public partial class MainWindow: Gtk.Window
{
	private static Label label;
	private static int inc;
	private static int idleInc;
	private static bool run_clock;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		//Initial value
		idleInc = inc = 0;
		// static of label1
		label = this.label1;
		// static default for run_clock
		run_clock = true;

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
		if (run_clock == true) {
			run_clock = false;
			//Wait 1 second then run update_status
			GLib.Timeout.Add (1000, new GLib.TimeoutHandler (update_status));
			Debug.WriteLine ("StartClock()");
		}
		return true; //always run again
	}

	bool update_status ()
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
		run_clock = true;
		return false; // let idle handler determine if this should run
	}
}
