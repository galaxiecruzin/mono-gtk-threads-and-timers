#glib-timeout

This solution demonstrates how you could use Glib.Timeout to create a timer event to trigger a function to run at a given interval, as well as a mechanism to start and stop the timer.

Based on this reference:
http://www.mono-project.com/Responsive_Applications#Timeouts

#application-invoke

The goal of this solution is to be create a thread from the main class before the Gtk window is started. The thread is then able to run in the background, while MainWindow is running. On completion of the thread function, updates the label in MainWindow to notify the user that the background thread has completed. While the thread is running the gui elements should remain responsive. Try typing in the entry field and clicking the button before the thread completes.

Based on this reference:
http://www.mono-project.com/Responsive_Applications#Gtk.Application.Invoke

#thread-notify

This solution is much like the application-invoke, however it is runs the thread with a ReadyEvent triggered upon completion.

Based on this reference:
http://www.mono-project.com/Responsive_Applications#Gtk.ThreadNotify
