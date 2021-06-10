using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Circuits
{
    class NotGate : Gate
    {
        public NotGate(int x, int y)
        {
            pins.Add(new Pin(this, true, 20));
            pins.Add(new Pin(this, false, 20));
            MoveTo(x, y); // move the gate and position the pins
        }
        public override void Draw(Graphics paper)
        {
            //If selected, the Or Gate will be redrawn in red
            if (selected)
            {
                paper.DrawImage(Properties.Resources.NotGateAllRed, left, top);
            }
            else
            {
                paper.DrawImage(Properties.Resources.NotGate, left, top);
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
            pins[0].X = x - GAP - GAP + 1;
            pins[0].Y = y + HEIGHT / 2 + 5;
            pins[1].X = x + WIDTH + GAP * 3 + 2;
            pins[1].Y = y + HEIGHT / 2 + 5;
        }

        public override bool Evaluate()
        {
            //This checks to see if the input pin is not connected to a wire
            if (pins[0].InputWire == null)
            {
                MessageBox.Show("There is no input to the NOT gate's pin");
                return false;
            }

            //Creates some new gates which are assigned the values from the input pins
            Gate gateA = pins[0].InputWire.FromPin.Owner;
            //This does the functionality of the Not gate, ie. if the input is true, make the output false, or if input is false, set the output to be true
            if (gateA.Evaluate() == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override Gate Clone()
        {
            Gate newGate = new NotGate(0, 0);
            pins.Add(new Pin(this, true, 20));
            pins.Add(new Pin(this, false, 20));
            return newGate;
        }
    }
}
