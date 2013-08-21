using System;
using System.Diagnostics;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public bool run_clock = false;
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	
	void StartClock ()
	{
		// Every second call `update_status' (1000 milliseconds)
		run_clock = true;
		GLib.Timeout.Add (250, new GLib.TimeoutHandler (update_status));
		Debug.WriteLine ("StartClock()");
	}
	
	void StopClock ()
	{
		// Every second call `update_status' (1000 milliseconds)
		run_clock = false;
		Debug.WriteLine ("StopClock()");
	}
	
	bool update_status ()
	{
		time_label.Text = DateTime.Now.ToString ();
		
		// returning true means that the timeout routine should be invoked
		// again after the timeout period expires.   Returning false would
		// terminate the timeout.
		Debug.WriteLine ("update_status(); run_clock = "+run_clock.ToString());
		if (run_clock == true) {
			return true; //run again
		} else {
			return false; //do not run again
		}
	}
	
	protected void OnButton1Clicked (object sender, EventArgs e)
	{
		//throw new System.NotImplementedException ();
		Debug.WriteLine ("OnButton1Clicked()");
		StartClock ();
	}
	
	protected void OnButton2Clicked (object sender, EventArgs e)
	{
		//throw new System.NotImplementedException ();
		Debug.WriteLine ("OnButton2Clicked()");
		StopClock();
	}
}

