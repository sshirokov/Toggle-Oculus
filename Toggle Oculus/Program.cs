using System;
using System.ServiceProcess;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Toggle_Oculus
{
    class Program
    {
        static void Main(string[] args)
        {
            // From https://msdn.microsoft.com/en-us/library/system.serviceprocess.servicecontroller.stop(v=vs.110).aspx
            // Because computers are hard, but I'm very angry

            // Toggle the Oculus service - 
            // If it is started (running, paused, etc), stop the service.
            // If it is stopped, start the service.
            ServiceController sc = new ServiceController("OVRService");

            if ((sc.Status.Equals(ServiceControllerStatus.Stopped)) ||
                 (sc.Status.Equals(ServiceControllerStatus.StopPending)))
            {
                sc.Start();
            }
            else
            {
                sc.Stop();
            }

            // Refresh and display the current service status.
            sc.Refresh();
            MessageBox.Show(
                $"The Oculus service status is now set to {sc.Status.ToString()}.",
                "Oculus Service Toggled",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}