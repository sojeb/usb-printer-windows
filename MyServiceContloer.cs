


using System.Diagnostics;
using System.ServiceProcess;

namespace MYPRINTER
{
    internal class MyServiceContloer
    {

            
        public enum SimpleServiceCustomCommands
            { StopWorker = 128, RestartWorker, CheckWorker };
            public void start()
            {           
           

            ServiceController[] scServices;
                scServices = ServiceController.GetServices();

                foreach (ServiceController scTemp in scServices)
                {
               


                if (scTemp.ServiceName == "Simple Service")
                    {
                    System.Diagnostics.Debug.WriteLine("success: " + scTemp.ServiceName);
                    // Display properties for the Simple Service sample
                    // from the ServiceBase example.
                    ServiceController sc = new ServiceController("Simple Service");
                        Console.WriteLine("Status = " + sc.Status);
                        Console.WriteLine("Can Pause and Continue = " + sc.CanPauseAndContinue);
                        Console.WriteLine("Can ShutDown = " + sc.CanShutdown);
                        Console.WriteLine("Can Stop = " + sc.CanStop);
                        if (sc.Status == ServiceControllerStatus.Stopped)
                        {
                            sc.Start();
                            while (sc.Status == ServiceControllerStatus.Stopped)
                            {
                                Thread.Sleep(1000);
                                sc.Refresh();
                            }
                        }
                        // Issue custom commands to the service
                        // enum SimpleServiceCustomCommands
                        //    { StopWorker = 128, RestartWorker, CheckWorker };
                        sc.ExecuteCommand((int)SimpleServiceCustomCommands.StopWorker);
                        sc.ExecuteCommand((int)SimpleServiceCustomCommands.RestartWorker);
                        sc.Pause();
                        while (sc.Status != ServiceControllerStatus.Paused)
                        {
                            Thread.Sleep(1000);
                            sc.Refresh();
                        }
                        Console.WriteLine("Status = " + sc.Status);
                        sc.Continue();
                        while (sc.Status == ServiceControllerStatus.Paused)
                        {
                            Thread.Sleep(1000);
                            sc.Refresh();
                        }
                        Console.WriteLine("Status = " + sc.Status);
                        sc.Stop();
                        while (sc.Status != ServiceControllerStatus.Stopped)
                        {
                            Thread.Sleep(1000);
                            sc.Refresh();
                        }
                        Console.WriteLine("Status = " + sc.Status);
                        String[] argArray = new string[] { "ServiceController arg1", "ServiceController arg2" };
                        sc.Start(argArray);
                        while (sc.Status == ServiceControllerStatus.Stopped)
                        {
                            Thread.Sleep(1000);
                            sc.Refresh();
                        }
                        Console.WriteLine("Status = " + sc.Status);
                        // Display the event log entries for the custom commands
                        // and the start arguments.
                        EventLog el = new EventLog("Application");
                        EventLogEntryCollection elec = el.Entries;
                        foreach (EventLogEntry ele in elec)
                        {
                            if (ele.Source.IndexOf("SimpleService.OnCustomCommand") >= 0 |
                                ele.Source.IndexOf("SimpleService.Arguments") >= 0)
                                Console.WriteLine(ele.Message);
                        }
                    }
                }
            }

        }
    }

