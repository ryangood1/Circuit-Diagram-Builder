using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Circuits
{
    public class Compound : Gate
    {
        List<Gate> compGatesList = new List<Gate>();
        public Compound(int x, int y)
        {
        }
        public override void Draw(Graphics paper)
        {
        }

        public override void MoveTo(int x, int y)
        {
            foreach (Gate g in compGatesList)
            {
                g.MoveTo(x, y);
            }
        }

        public override bool Evaluate()
        {
            //This checks to see if the input pin is not connected to a wire
            if (pins[0].InputWire == null)
            {
                MessageBox.Show("There is no input to the gate's pin");
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

        public void AddGate(Gate cgate)
        {
            compGatesList.Add(cgate);
        }

        public override bool Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                foreach (Gate gate in compGatesList)
                {
                    gate.selected = value;
                }
            }
        }
    }
}
