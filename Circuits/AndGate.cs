using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Circuits
{
    /// <summary>
    /// This class implements an AND gate with two inputs
    /// and one output.
    /// </summary>
    public class AndGate : Gate
    {
        public AndGate(int x, int y)
        {
            pins.Add(new Pin(this, true, 20));
            pins.Add(new Pin(this, true, 20));
            pins.Add(new Pin(this, false, 20));
            MoveTo(x, y); // move the gate and position the pins
        }
 
        public override void Draw(Graphics paper)
        {
            //If selected, the And Gate will be redrawn in red
            if (selected)
            {
                paper.DrawImage(Properties.Resources.AndGateAllRed, left, top);
            }
            else
            {
                paper.DrawImage(Properties.Resources.AndGate, left, top);
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
            pins[0].Y = y + GAP;
            pins[1].X = x - GAP - GAP + 1;
            pins[1].Y = y + HEIGHT;
            pins[2].X = x + WIDTH + GAP * 3;
            pins[2].Y = y + HEIGHT / 2 + 5;
        }

        public override bool Evaluate()
        {
            //This checks to see if any of the input pins are not connected to a wire
            if (pins[0].InputWire == null)
            {
                MessageBox.Show("There is no input to the AND gate's first pin");
                return false;    
            }
            else if (pins[1].InputWire == null)
            {
                MessageBox.Show("There is no input to the AND gate's second pin");
                return false;
            }
            
            //Creates some new gates which are assigned the values from the input pins
            Gate gateA = pins[0].InputWire.FromPin.Owner;
            Gate gateB = pins[1].InputWire.FromPin.Owner;
            //This does the functionality of the And gate, ie. both inputs must be true for the overall result to be true
            if (gateA.Evaluate() == true && gateB.Evaluate() == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override Gate Clone()
        {
            Gate newGate = new AndGate(0, 0);
            pins.Add(new Pin(this, true, 20));
            pins.Add(new Pin(this, true, 20));
            pins.Add(new Pin(this, false, 20));
            return newGate;
        }
    }
}
