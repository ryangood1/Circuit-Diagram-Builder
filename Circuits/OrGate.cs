using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Circuits
{
    class OrGate : Gate
    {
        public OrGate(int x, int y)
        {
            pins.Add(new Pin(this, true, 20));
            pins.Add(new Pin(this, true, 20));
            pins.Add(new Pin(this, false, 20));
            MoveTo(x, y); // move the gate and position the pins
        }
        public override void Draw(Graphics paper)
        {
            //If selected, the Or Gate will be redrawn in red
            if (selected)
            {
                paper.DrawImage(Properties.Resources.OrGateAllRed, left, top);
            }
            else
            {
                paper.DrawImage(Properties.Resources.OrGate, left, top);
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
            pins[0].X = x - GAP;
            pins[0].Y = y + GAP;
            pins[1].X = x - GAP;
            pins[1].Y = y + HEIGHT;
            pins[2].X = x + WIDTH + GAP * 4 + 2;
            pins[2].Y = y + HEIGHT / 2 + 5;
        }

        public override bool Evaluate()
        {
            //This checks to see if any of the input pins are not connected to a wire
            if (pins[0].InputWire == null)
            {
                MessageBox.Show("There is no input to the OR gate's first pin");
                return false;
            }
            else if (pins[1].InputWire == null)
            {
                MessageBox.Show("There is no input to the OR gate's second pin");
                return false;
            }

            //Creates some new gates which are assigned the values from the input pins
            Gate gateA = pins[0].InputWire.FromPin.Owner;
            Gate gateB = pins[1].InputWire.FromPin.Owner;
            //This does the functionality of the Or gate, ie. one of the inputs must be true for the overall result to be true
            if (gateA.Evaluate() == false && gateB.Evaluate() == false)
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
            Gate newGate = new OrGate(0, 0);
            pins.Add(new Pin(this, true, 20));
            pins.Add(new Pin(this, true, 20));
            pins.Add(new Pin(this, false, 20));
            return newGate;
        }
    }
}
