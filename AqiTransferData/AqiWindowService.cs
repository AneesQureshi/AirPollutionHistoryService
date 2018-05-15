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

namespace AqiTransferData
{
    public partial class AqiWindowService : ServiceBase
    {
        private Timer _timer;

        public AqiWindowService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            TransferData.MainActivity();
            Scheduler schedule = new Scheduler();
            schedule.ScheduleService();

           
        }

        protected override void OnStop()
        {
        }
    }
}
