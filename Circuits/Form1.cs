using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Circuits
{
    /// <summary>
    /// The main GUI for the COMP104 digital circuits editor.
    /// This has a toolbar, containing buttons called buttonAnd, buttonOr, etc.
    /// The contents of the circuit are drawn directly onto the form.
    /// 
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The (x,y) mouse position of the last MouseDown event.
        /// </summary>
        protected int startX, startY;

        /// <summary>
        /// If this is non-null, we are inserting a wire by
        /// dragging the mouse from startPin to some output Pin.
        /// </summary>
        protected Pin startPin = null;

        /// <summary>
        /// The (x,y) position of the current gate, just before we started dragging it.
        /// </summary>
        protected int currentX, currentY;

        /// <summary>
        /// The set of gates in the circuit
        /// </summary>
        protected List<Gate> gate = new List<Gate>();

        /// <summary>
        /// The set of connector wires in the circuit
        /// </summary>
        protected List<Wire> wires = new List<Wire>();

        /// <summary>
        /// The currently selected gate, or null if no gate is selected.
        /// </summary>
        protected Gate current = null;

        /// <summary>
        /// The new gate that is about to be inserted into the circuit
        /// </summary>
        protected Gate newGate = null;
        bool checkCGate = false;
        Compound newCompound;
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        /// <summary>
        /// Finds the pin that is close to (x,y), or returns
        /// null if there are no pins close to the position.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Pin findPin(int x, int y)
        {
            foreach (Gate g in gate)
            {
                foreach (Pin p in g.Pins)
                {
                    if (p.isMouseOn(x, y))
                        return p;
                }
            }
            return null;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Gate g in gate)
            {
                g.Draw(e.Graphics);
            } 
            foreach (Wire w in wires)
            {
                w.Draw(e.Graphics);
            }
            if (startPin != null)
            {
                e.Graphics.DrawLine(Pens.White, 
                    startPin.X, startPin.Y, 
                    currentX, currentY);
            }
            if (newGate != null)
            {
                // show the gate that we are dragging into the circuit
                newGate.MoveTo(currentX, currentY);
                newGate.Draw(e.Graphics);
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (current != null)
            {
                //If you click on a gate and that current gate is an input source, it's voltage will be flipped
                if (current is InputSource)
                {
                    if (current.IsMouseOn(e.X, e.Y))
                    {
                        //This casts the current gate as an Input Source so it can use it's FlipVoltage method
                        InputSource s = (InputSource)current;
                        s.FlipVoltage();
                    }
                }
                this.Invalidate();
                
            }
            // See if we are inserting a new gate
            if (newGate != null)
            {
                newGate.MoveTo(e.X, e.Y);
                gate.Add(newGate);
                newGate = null;
                this.Invalidate();
            }
            else
            {
                bool b = false;
                // search for the first gate under the mouse position
                foreach (Gate g in gate)
                {
                    if (g.IsMouseOn(e.X, e.Y))
                    {
                        g.Selected = true;
                        current = g;
                        if (current.parentCompound != null)
                        {
                            current = current.parentCompound;
                        }
                        this.Invalidate();
                        b = true;
                        break;
                    }
                }
                if (b == false && current != null)
                {
                    current.Selected = false;
                    current = null;
                }                
            }
            if (checkCGate == true)
            {
                newCompound.AddGate(current);
                current.parentCompound = newCompound;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (current == null)
            {
                // try to start adding a wire
                startPin = findPin(e.X, e.Y);
            }
            else if (current.IsMouseOn(e.X, e.Y))
            {
                // start dragging the current object around
                startX = e.X;
                startY = e.Y;
                currentX = current.Left;
                currentY = current.Top;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Console.WriteLine(current != null);
            if (startPin != null)
            {
                Debug.WriteLine("wire from "+startPin+" to " + e.X + "," + e.Y);
                currentX = e.X;
                currentY = e.Y;
                this.Invalidate();  // this will draw the line
            }
            else if (startX >= 0 && startY >= 0 && current != null)
            {
                Debug.WriteLine("mouse move to " + e.X + "," + e.Y);
                current.MoveTo(currentX + (e.X - startX), currentY + (e.Y - startY));
                this.Invalidate();
            }
            else if (newGate != null)
            {
                currentX = e.X;
                currentY = e.Y;
                this.Invalidate();
            }
        }

        private void buttonOr_Click(object sender, EventArgs e)
        {
            newGate = new OrGate(0, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonNot_Click(object sender, EventArgs e)
        {
            newGate = new NotGate(0, 0);
        }

        private void buttonInputSource_Click(object sender, EventArgs e)
        {
            newGate = new InputSource(0, 0);
        }

        private void buttomLamp_Click(object sender, EventArgs e)
        {
            newGate = new OutputLamp(0, 0);
        }

        private void buttonEvaluate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gate.Count; i++)
            {
                //Check to make sure current gate is an Output Lamp so that calling the Evaluate method recursively works from the Lamp backwards, and then forwards
                if (gate[i] is OutputLamp)
                {
                    gate[i].Evaluate();
                }
            }
            this.Invalidate();
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
               //This makes a new gate and is given all the properties of the current gate from the Clone method
               Gate clonedGate = current.Clone();
               //This adds the new cloned gate into the gates list with all the other gates and then sets the current focus to the new gate
               gate.Add(clonedGate);
               current = clonedGate;
               this.Invalidate();
        }

        private void buttonStartGroup_Click(object sender, EventArgs e)
        {
            checkCGate = true;

            newCompound = new Compound(0, 0);
            gate.Add(newCompound);
        }

        private void buttonEndGroup_Click(object sender, EventArgs e)
        {
            checkCGate = false;
            newCompound = null;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (startPin != null)
            {
                // see if we can insert a wire
                Pin endPin = findPin(e.X, e.Y);
                if (endPin != null)
                {
                    Debug.WriteLine("Trying to connect " + startPin + " to " + endPin);
                    Pin input, output;
                    if (startPin.IsOutput)
                    {
                        input = endPin;
                        output = startPin;
                    }
                    else
                    {
                        input = startPin;
                        output = endPin;
                    }
                    if (input.IsInput && output.IsOutput)
                    {
                        if (input.InputWire == null)
                        {
                            Wire newWire = new Wire(output, input);
                            input.InputWire = newWire;
                            wires.Add(newWire);
                        }
                        else
                        {
                            MessageBox.Show("That input is already used.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: you must connect an output pin to an input pin.");
                    }
                }
                startPin = null;
                this.Invalidate();
            }
            // We have finished moving/dragging
            startX = -1;
            startY = -1;
            currentX = 0;
            currentY = 0;
        }

        private void buttonAnd_Click(object sender, EventArgs e)
        {
            newGate = new AndGate(0, 0);
        }
        
    }
    //Questions:
    //1. It is better to fully document the Gate class as you can inherit comments from the super class. 
    //This means that all subclasses can see the comments, so writing them again would waste time and space
    //2. Using an abstarct method forces each subclass to implement a version of that method. This means that all subclasses are capable of doing that method, guaranteed.
    //Using a virutal method means that not all the gates have to have the necessary methods, but abstract means they have to. Abstract methods are not so good for when
    //you don't want all the subclasses to implement a particular method, just some. Virtual is much better for this purpose.
    //3. If a class declares an abstract method, that class HAS to be abstract inorder to do so. However you do not have to be an abstract subclass to override the abstract method
    //4. Can deal with a COmpound Gate that features a compound gate
}