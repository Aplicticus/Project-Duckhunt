using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WiimoteLib;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WiiMouseUtils.WiimotesPipedComm;

namespace XNA_Rudy
{
    class Controller
    {
        public Boolean useWiimote1 = true;
        public Boolean useWiimote2 = false;
        public Wiimote wiiM1 = new Wiimote();
        public Wiimote wiiM2;

        Microsoft.Xna.Framework.Point IRPoint1 = new Microsoft.Xna.Framework.Point(0, 0);
        Microsoft.Xna.Framework.Point IRPoint2 = new Microsoft.Xna.Framework.Point(0, 0);
        Microsoft.Xna.Framework.Point IRPointMidpoint = new Microsoft.Xna.Framework.Point(0, 0);

        //WiiMouseClient wClien = new WiiMouseClient();

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
            bool connected = false;

            



            do
            {
                try 
                {
                    wm.Connect();
                    //wm.InitializeMotionPlus();
                    wm.SetReportType(InputReport.ButtonsAccel, true);
                    wm.SetReportType(InputReport.IRAccel, true);
                    
                    connected = true;
                }
                catch(Exception e)
                {
                
                }
            }while(!connected);

            
            wm.SetLEDs(true, false, false, false);

            BurstRumble(wm, 200);
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

        public string GetPressedButton(Wiimote wm)
        {
            if (wm.WiimoteState.ButtonState.A)
            {
                return "A";
            }
            else if (wm.WiimoteState.ButtonState.B)
            {
                return "B";
            }
            else if (wm.WiimoteState.ButtonState.Down)
            {
                return "Down";
            }
            else if (wm.WiimoteState.ButtonState.Home)
            {
                
                return "Home";
            }
            else if (wm.WiimoteState.ButtonState.Left)
            {
                return "Left";
            }
            else if (wm.WiimoteState.ButtonState.Minus)
            {
                return "Minus";
            }
            else if (wm.WiimoteState.ButtonState.One)
            {
                return "One";
            }
            else if (wm.WiimoteState.ButtonState.Plus)
            {
                return "Plus";
            }
            else if (wm.WiimoteState.ButtonState.Right)
            {
                return "Right";
            }
            else if (wm.WiimoteState.ButtonState.Two)
            {
                return "Two";
            }
            else if (wm.WiimoteState.ButtonState.Up)
            {
                return "Up";
            }
            else
                return "No Buttons Found";
        }

        public WiimoteLib.Point GetIRResultsS1(Wiimote wm)
        {
            return wm.WiimoteState.IRState.IRSensors[0].RawPosition;
        }

        public WiimoteLib.Point GetIRResultsS2(Wiimote wm)
        {
            return wm.WiimoteState.IRState.IRSensors[1].RawPosition;
        }

        //public WiimoteLib.Point GetIRResultsS3(Wiimote wm)
        //{
        //    return wm.WiimoteState.IRState.IRSensors[2].RawPosition;
        //}

        public Vector2 GetIRX(Wiimote wm, Vector2 oldVector)
        {
            float xPercent;
            float yPercent;
            


            if(wm.WiimoteState.IRState.IRSensors[1].Position.X >= 1)
                xPercent = 1;            
            else
                xPercent = wm.WiimoteState.IRState.IRSensors[1].Position.X;
           
            if (wm.WiimoteState.IRState.IRSensors[1].Position.Y >= 1)
                yPercent = 1;
            else
                yPercent = wm.WiimoteState.IRState.IRSensors[1].Position.Y;

            return new Vector2(xPercent, yPercent) * oldVector;


        }
       
        public Vector2 GetPos(Wiimote wm)
        {
            Vector2 pos;
            float x = 0 - ((wm.WiimoteState.IRState.IRSensors[1].RawPosition.X + wm.WiimoteState.IRState.IRSensors[0].RawPosition.X) / 2) + 1023;
            pos.X = x;
            pos.Y = wm.WiimoteState.IRState.IRSensors[1].RawPosition.Y + wm.WiimoteState.IRState.IRSensors[0].RawPosition.Y / 2;
            return pos;
        }


    }
}
