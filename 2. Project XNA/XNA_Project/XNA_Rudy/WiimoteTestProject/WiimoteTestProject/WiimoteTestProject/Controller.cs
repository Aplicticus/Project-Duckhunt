using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using WiimoteLib;

namespace WiimoteTestProject
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
            if (useWiimote1 == true)
            {
                InitWiimote(wiiM1);
            }
            else if (useWiimote2)
            {
                InitWiimote(wiiM2);
            }
        }

        public void InitWiimote(Wiimote wm)
        {
            wm.Connect();
            wm.SetReportType(InputReport.ButtonsAccel, true);
            wm.SetLEDs(true, true, false, false);

            BurstRumble(wm, 200);
            wm.SetRumble(false);
        }

        public void BurstRumble(Wiimote wm, int burstTime)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            while (stopWatch.ElapsedMilliseconds <= burstTime)
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
