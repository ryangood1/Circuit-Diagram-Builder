using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;


namespace Circuits
{
    public abstract class Gate
    {
        protected int left;
        // public list that holds all the pins for each of the gates
        protected List<Pin> pins = new List<Pin>();
        public bool selected = false;
        // top is the top of the whole gate
        protected int top;
        // width and height of the main part of the gate
        protected const int WIDTH = 40;
        protected const int HEIGHT = 40;
        // length of the connector legs sticking out left and right
        protected const int GAP = 10;
        public Compound parentCompound = null;

        public abstract void Draw(Graphics paper);
        public abstract void MoveTo(int x, int y);

        /// <summary>
        /// Public property that checks if the current object is selected in order to do calculations on it
        /// </summary>
        public virtual bool Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                if (value && parentCompound != null)
                {
                    parentCompound.Selected = true;
                }
            }
        }

        /// <summary>
        /// This property gives the left edge of the current gate
        /// </summary>
        public int Left
        {
            get { return left; }
        }

        /// <summary>
        /// This property gives the top of the current gate
        /// </summary>
        public int Top
        {
            get { return top; }
        }

        /// <summary>
        /// This gets all the pins the current gate has
        /// </summary>
        public List<Pin> Pins
        {
            get { return pins; }
        }

        /// <summary>
        /// True if the given (x,y) position is roughly
        /// on top of this gate.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsMouseOn(int x, int y)
        {
            if (left <= x && x < left + WIDTH
                && top <= y && y < top + HEIGHT)
                return true;
            else
                return false;
        }

        /// <summary>
        /// This abstract method works out the current on/off status of the gates and returns the overall result to the superclass
        /// </summary>
        /// <returns></returns>
        public abstract bool Evaluate();

        /// <summary>
        /// This abstract method gets overriden by the subclasses to copy the current gate/s and create a new version of that gate, which is then added to the gate list
        /// </summary>
        /// <returns></returns>
        public abstract Gate Clone();
    }
}
