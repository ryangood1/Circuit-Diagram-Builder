using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Circuits
{
    class OutputLamp : Gate
    {
        //This variable stores the on/off value of the component, ie. Wether it has a high voltage going thorugh it or not.
        bool highVoltage = false;
        Brush brVoltageOn = Brushes.Yellow;
        Brush brVoltageOff = Brushes.DarkGoldenrod;

        public OutputLamp(int x, int y)
        {
            pins.Add(new Pin(this, true, 20));
            MoveTo(x, y); // move the gate and position the pins
        }
        public override void Draw(Graphics paper)
        {
            Brush brVoltage;
                //Checks to see if current voltage is on or off and then changes the lamp colour by redrawing it
                if (highVoltage == true)
                {
                    brVoltage = brVoltageOn;
                    paper.FillEllipse(brVoltage, left, top, WIDTH  + 4 / 2, HEIGHT + 4 / 2);
                }
                else
                {
                    brVoltage = brVoltageOff;
                    paper.FillEllipse(brVoltage, left, top, WIDTH + 4 / 2, HEIGHT + 4 / 2);
                }
            foreach (Pin p in pins)
                p.Draw(paper);
        }

        public override void MoveTo(int x, int y)
        {
            Debug.WriteLine("pins = " + pins.Count);
            left = x;
            top = y;
            // must move the pins too
            pins[0].X = x - GAP - GAP + 2;
            pins[0].Y = y + HEIGHT / 2;
        }

        public override bool Evaluate()
        {
            //This checks to see if the input pin is not connected to a wire
            if (pins[0].InputWire == null)
            {
                MessageBox.Show("There is no input to the LAMP gate's pin");
                return false;
            }

            //Creates some new gates which are assigned the values from the input pins
            Gate gateA = pins[0].InputWire.FromPin.Owner;
            //This sets the voltage of the lamp to the result from the gateA, which is the value from the input pin
            highVoltage = gateA.Evaluate();
            return highVoltage;
        }

        public override Gate Clone()
        {
            Gate newGate = new OutputLamp(0, 0);
            pins.Add(new Pin(this, true, 20));
            return newGate;
        }
    }
}
