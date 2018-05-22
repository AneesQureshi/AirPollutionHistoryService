using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace AqiTransferData
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
          
            try
            {
#if DEBUG
                ActionForDebug();
                        #else
                ServiceBase[] ServicesToRun;
                    ServicesToRun = new ServiceBase[]
                    {
                        new AqiWindowService()
                    };
                    ServiceBase.Run(ServicesToRun);
                        #endif
            }
            catch (Exception ex)
            {
               
            }
        }
        static void ActionForDebug()
        {
            try
            {
                TransferData.MainActivity();
                 Scheduler schedule = new Scheduler();
                schedule.ScheduleService();
            }
            catch (Exception ex)
            {
               
            }
        }
    }
}
