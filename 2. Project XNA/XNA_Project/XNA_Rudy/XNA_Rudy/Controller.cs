using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WiimoteLib;
using System.Threading;
using System.Diagnostics;

namespace XNA_Rudy
{
    public class Controller
    {
        public static Boolean useWiimote1 = true;
        public static Boolean useWiimote2 = false;
        public static Wiimote wiiM1 = new Wiimote();
        public static Wiimote wiiM2 = new Wiimote();
        public static WiimoteState wiimoteState = new WiimoteState();
        
        public Controller()
        {
            if(useWiimote1 == true)
            {
                InitWiimote(wiiM1);
            }
            else if(useWiimote2)
            {
                InitWiimote(wiiM2);
            }
        }

        public void InitWiimote(Wiimote wm)
        {
            //do
            //{
                wm.Connect();
                wm.SetReportType(InputReport.ButtonsAccel, true);   

            //} while();

            wm.SetLEDs(true, true, true, true);

            BurstRumble(wm, 200);
            wm.SetRumble(false);
        }

        public void BurstRumble(Wiimote wm, int burstTime)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            
            while(stopWatch.ElapsedMilliseconds <= burstTime)
            {
                wm.SetRumble(true);
            }
            wm.SetRumble(false);
            stopWatch.Stop();
        }

        public void GetButton()
        {
            //wiiM.
        }
        
        //public void GetPressedButton

        public String SendMessage()
        {
            return "No connection";
        }
    }
}
