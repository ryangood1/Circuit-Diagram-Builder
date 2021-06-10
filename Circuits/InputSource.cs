using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Circuits
{
    class InputSource : Gate
    {
        //This variable stores the on/off value of the component, ie. Wether it has a high voltage going thorugh it or not.
        bool highVoltage = false;
        Brush brVoltageOn = Brushes.LimeGreen;
        Brush brVoltageOff = Brushes.LightGray;
        Pen penOn = Pens.Red;
        Pen penOff = Pens.Black;
       

        public InputSource(int x, int y)
        {
            pins.Add(new Pin(this, false, 20));
            MoveTo(x, y); // move the gate and position the pins
        }
        public override void Draw(Graphics paper)
        {
            Brush brVoltage;
            Pen pen;

            //If selected, the Input Source will be redrawn with a red outline
            if (selected)
            {
                pen = penOn;
            }
            else
            {
                pen = penOff;
            }

            //If the input bool is true then the Input Source will be coloured green
            if (highVoltage)
            {
                brVoltage = brVoltageOn;
            }
            else
            {
                brVoltage = brVoltageOff;
            }

            paper.FillRectangle(brVoltage, left, top, WIDTH - 10, HEIGHT - 10);
            paper.DrawRectangle(pen, left, top, WIDTH - 10, HEIGHT - 10);
            foreach (Pin p in pins)
                p.Draw(paper);
        }

        public override void MoveTo(int x, int y)
        {
            Debug.WriteLine("pins = " + pins.Count);
            left = x;
            top = y;
            // must move the pins too
            pins[0].X = x + WIDTH + GAP - 1;
            pins[0].Y = y + HEIGHT - 24;
        }

        public override bool Evaluate()
        {
            //This gives the current on/off position of the Input Source
            return highVoltage;
        }

        /// <summary>
        /// This method flips the high voltage it is given, so if given false, it returns true and vice versa
        /// </summary>
        public void FlipVoltage()
        {
            highVoltage = !highVoltage;
        }

        public override Gate Clone()
        {
            Gate newGate = new InputSource(0, 0);
            pins.Add(new Pin(this, false, 20));
            return newGate;
        }
    }
}
