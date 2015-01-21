using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WiimoteLib;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNA_Rudy
{
    class Controller
    {
        public Boolean useWiimote1 = true;
        public Boolean useWiimote2 = false;
        public Wiimote wiiM1 = new Wiimote();
       
        //public Wiimote wiiM2;
 
        Microsoft.Xna.Framework.Point IRPoint1 = new Microsoft.Xna.Framework.Point(0, 0);
        Microsoft.Xna.Framework.Point IRPoint2 = new Microsoft.Xna.Framework.Point(0, 0);
        Microsoft.Xna.Framework.Point IRPointMidpoint = new Microsoft.Xna.Framework.Point(0, 0);

        float x0Old;
        float y0Old;
        float x1Old;
        float y1Old;
        float midXOld;
        float midYOld;


        public Controller()
        {
            if (useWiimote1 == true)
            {
                InitWiimote(wiiM1);
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
                    wm.SetReportType(InputReport.ButtonsAccel, true);
                    wm.SetReportType(InputReport.IRExtensionAccel, true);
                    wm.SetReportType(InputReport.IRAccel, true);
                    wm.WiimoteState.IRState.Mode = IRMode.Extended;
                    connected = true;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }while(!connected);

            wm.SetLEDs(true, true, false, false);

            Process ExternalProcess = new Process();
            ExternalProcess.StartInfo.FileName = "WiinRemote.exe";
            ExternalProcess.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            ExternalProcess.Start();
            ExternalProcess.WaitForExit();


            BurstRumble(wm, 150);
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
        public Vector2 GetIRResultsMidpoint(Wiimote wm)
        {
            return new Vector2(wm.WiimoteState.IRState.RawMidpoint.X, wm.WiimoteState.IRState.RawMidpoint.Y);
        }

        public Wiimote GetWiimote(Wiimote wm)
        {
            return wm;
        }
        

        public Vector2 GetPos0(Wiimote wm, GraphicsDeviceManager graphics)
        {
            Vector2 pos;

            float x0 = wm.WiimoteState.IRState.IRSensors[0].RawPosition.X;
            float y0 = wm.WiimoteState.IRState.IRSensors[0].RawPosition.Y;
            float x1 = wm.WiimoteState.IRState.IRSensors[1].RawPosition.X;
            float y1 = wm.WiimoteState.IRState.IRSensors[1].RawPosition.Y;
            float midx = wm.WiimoteState.IRState.Midpoint.X;
            float midy = wm.WiimoteState.IRState.Midpoint.Y;
            
            if (x0 != 1023)
            {
                x0Old = x0;
            }
            if (y0 != 768)
            {
                y0Old = y0;
            }
            if (x1 != 1023)
            {
                x1Old = x1;
            }
            if (y1 != 1023)
            {
                y1Old = y1;
            }
            if (midx != 1023)
            {
                midXOld = x0;
            }
            if (midy != 1023)
            {
                midYOld = x0;
            }
            
            float xTest = (((1023 - x0Old) / 1023) * graphics.PreferredBackBufferWidth);
            float yTest = ((1-(768 - y0Old) / 768)) * graphics.PreferredBackBufferHeight;

            //float x = (1 - ((x0Old + x1Old) * midXOld)) * 1024 * graphics.PreferredBackBufferWidth;
            //float y = (((y0Old + y1Old) * midYOld) / 768) * graphics.PreferredBackBufferHeight;

            pos.X = xTest;
            pos.Y = yTest;

            return pos;
        }

        public Vector2 GetPos1(Wiimote wm, GraphicsDeviceManager graphics)
        {
            Vector2 pos;

            float x0 = wm.WiimoteState.IRState.IRSensors[0].RawPosition.X;
            float y0 = wm.WiimoteState.IRState.IRSensors[0].RawPosition.Y;
            float x1 = wm.WiimoteState.IRState.IRSensors[1].RawPosition.X;
            float y1 = wm.WiimoteState.IRState.IRSensors[1].RawPosition.Y;
            float midx = wm.WiimoteState.IRState.Midpoint.X;
            float midy = wm.WiimoteState.IRState.Midpoint.Y;

            
            if (x1 != 1023)
            {
                x1Old = x1;
            }
            if (y1 != 768)
            {
                y1Old = y1;
            }
          

            float xTest = (((1023 - x1Old) / 1023) * graphics.PreferredBackBufferWidth);
            float yTest = ((1 - (768 - y1Old) / 768)) * graphics.PreferredBackBufferHeight;

            //float x = (1 - ((x0Old + x1Old) * midXOld)) * 1024 * graphics.PreferredBackBufferWidth;
            //float y = (((y0Old + y1Old) * midYOld) / 768) * graphics.PreferredBackBufferHeight;

            pos.X = xTest;
            pos.Y = yTest;

            return pos;
        }

        public Vector2 GetPosM(Wiimote wm, GraphicsDeviceManager graphics)
        {
            Vector2 pos;

            float x0 = wm.WiimoteState.IRState.IRSensors[0].RawPosition.X;
            float y0 = wm.WiimoteState.IRState.IRSensors[0].RawPosition.Y;
            float x1 = wm.WiimoteState.IRState.IRSensors[1].RawPosition.X;
            float y1 = wm.WiimoteState.IRState.IRSensors[1].RawPosition.Y;
            float midx = wm.WiimoteState.IRState.Midpoint.X;
            float midy = wm.WiimoteState.IRState.Midpoint.Y;

           
            if (midx != 1023)
            {
                midXOld = midx;
            }
            if (midy != 768)
            {
                midYOld = midx;
            }
            

            float xTest = (((1023 - midXOld) / 1023) * graphics.PreferredBackBufferWidth);
            float yTest = ((1 - (768 - midYOld) / 768)) * graphics.PreferredBackBufferHeight;

            //float x = (1 - ((x0Old + x1Old) * midXOld)) * 1024 * graphics.PreferredBackBufferWidth;
            //float y = (((y0Old + y1Old) * midYOld) / 768) * graphics.PreferredBackBufferHeight;

            pos.X = xTest;
            pos.Y = yTest;

            return pos;
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
    }
}
