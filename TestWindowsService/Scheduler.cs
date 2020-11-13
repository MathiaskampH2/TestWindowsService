using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TestWindowsService
{
    /// <summary>
    /// Class scheduler
    /// has 2 methods
    /// onStart method gets executed when the service starts
    /// OnStop method gets executed when the service stops
    /// </summary>
    public partial class Scheduler : ServiceBase
    {
        // creates private variable of a timer
        private Timer timer1 = null;
        public Scheduler()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // creates new instance of timer1
            timer1 = new Timer();
            // sets timer1 interval to trigger every 30s
            this.timer1.Interval = 30000;
            // every time the timer triggers it class timer1_tick
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_tick);
            // enables the timer.
            this.timer1.Enabled = true;
            // Writes the text "Test windows service started" to the logFile.
            Library.WriteErrorLog("Test windows service started");

        }

        protected override void OnStop()
        {
            // Writes the text "Test windows service stopped" to the logFile.
            Library.WriteErrorLog("Test windows service stopped");
        }
        private void timer1_tick(object sender, ElapsedEventArgs e)
        {
            // write code here to get executed every time the timer triggers.
            Library.WriteErrorLog("Timer ticked and some jobs has been done successfully");
        }
    }
}
