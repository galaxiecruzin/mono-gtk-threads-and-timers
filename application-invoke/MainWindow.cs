using System;
using System.Diagnostics;
using System.Threading;
using Gtk;

public partial class MainWindow: Gtk.Window
{
	private static Label label;
	private static int inc;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		//Initial value
		inc = 0;
		this.label1.Text = "Running thread in background. Ui should remain responsive.";
		label = this.label1;
		// Create and start the thread
		Thread thr = new Thread (new ThreadStart (ThreadRoutine));
		thr.IsBackground = true;
		thr.Start ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	static void ThreadRoutine ()
	{
		LargeComputation ();
		Gtk.Application.Invoke (delegate {
			Debug.WriteLine("ThreadDone");
			label.Text = "Done";
		});
	}
	
	static void LargeComputation ()
	{
		// lots of processing here
		int x = 0;
		int y = 0;
		for(x=0;x<500;x++){
			for(y=0;y<100;y++){
				Debug.Write(".");
			}
		}
		Debug.WriteLine("|");
	}

	protected void OnButtonClicked (object sender, EventArgs e)
	{
		//throw new System.NotImplementedException ();
		Debug.WriteLine("OnButtonClicked");
		inc++;
		button.Label = "Clicked "+inc.ToString();
	}
}
