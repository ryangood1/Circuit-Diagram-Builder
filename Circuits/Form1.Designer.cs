namespace Circuits
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonAnd = new System.Windows.Forms.ToolStripButton();
            this.buttonOr = new System.Windows.Forms.ToolStripButton();
            this.buttonNot = new System.Windows.Forms.ToolStripButton();
            this.buttonInputSource = new System.Windows.Forms.ToolStripButton();
            this.buttomLamp = new System.Windows.Forms.ToolStripButton();
            this.buttonEvaluate = new System.Windows.Forms.ToolStripButton();
            this.buttonCopy = new System.Windows.Forms.ToolStripButton();
            this.buttonStartGroup = new System.Windows.Forms.ToolStripButton();
            this.buttonEndGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonAnd,
            this.buttonOr,
            this.buttonNot,
            this.buttonInputSource,
            this.buttomLamp,
            this.buttonEvaluate,
            this.buttonCopy,
            this.buttonStartGroup,
            this.buttonEndGroup});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(472, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // buttonAnd
            // 
            this.buttonAnd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonAnd.Image = ((System.Drawing.Image)(resources.GetObject("buttonAnd.Image")));
            this.buttonAnd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAnd.Name = "buttonAnd";
            this.buttonAnd.Size = new System.Drawing.Size(23, 22);
            this.buttonAnd.Text = "And";
            this.buttonAnd.Click += new System.EventHandler(this.buttonAnd_Click);
            // 
            // buttonOr
            // 
            this.buttonOr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonOr.Image = ((System.Drawing.Image)(resources.GetObject("buttonOr.Image")));
            this.buttonOr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonOr.Name = "buttonOr";
            this.buttonOr.Size = new System.Drawing.Size(23, 22);
            this.buttonOr.Text = "Or";
            this.buttonOr.Click += new System.EventHandler(this.buttonOr_Click);
            // 
            // buttonNot
            // 
            this.buttonNot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonNot.Image = ((System.Drawing.Image)(resources.GetObject("buttonNot.Image")));
            this.buttonNot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonNot.Name = "buttonNot";
            this.buttonNot.Size = new System.Drawing.Size(23, 22);
            this.buttonNot.Text = "Not";
            this.buttonNot.Click += new System.EventHandler(this.buttonNot_Click);
            // 
            // buttonInputSource
            // 
            this.buttonInputSource.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonInputSource.Image = ((System.Drawing.Image)(resources.GetObject("buttonInputSource.Image")));
            this.buttonInputSource.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonInputSource.Name = "buttonInputSource";
            this.buttonInputSource.Size = new System.Drawing.Size(23, 22);
            this.buttonInputSource.Text = "Input Source";
            this.buttonInputSource.Click += new System.EventHandler(this.buttonInputSource_Click);
            // 
            // buttomLamp
            // 
            this.buttomLamp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttomLamp.Image = ((System.Drawing.Image)(resources.GetObject("buttomLamp.Image")));
            this.buttomLamp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttomLamp.Name = "buttomLamp";
            this.buttomLamp.Size = new System.Drawing.Size(23, 22);
            this.buttomLamp.Text = "Output Lamp";
            this.buttomLamp.Click += new System.EventHandler(this.buttomLamp_Click);
            // 
            // buttonEvaluate
            // 
            this.buttonEvaluate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonEvaluate.Image = ((System.Drawing.Image)(resources.GetObject("buttonEvaluate.Image")));
            this.buttonEvaluate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonEvaluate.Name = "buttonEvaluate";
            this.buttonEvaluate.Size = new System.Drawing.Size(23, 22);
            this.buttonEvaluate.Text = "Evaluate";
            this.buttonEvaluate.Click += new System.EventHandler(this.buttonEvaluate_Click);
            // 
            // buttonCopy
            // 
            this.buttonCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonCopy.Image = ((System.Drawing.Image)(resources.GetObject("buttonCopy.Image")));
            this.buttonCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(23, 22);
            this.buttonCopy.Text = "Copy";
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // buttonStartGroup
            // 
            this.buttonStartGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonStartGroup.Image = ((System.Drawing.Image)(resources.GetObject("buttonStartGroup.Image")));
            this.buttonStartGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonStartGroup.Name = "buttonStartGroup";
            this.buttonStartGroup.Size = new System.Drawing.Size(23, 22);
            this.buttonStartGroup.Text = "Start Group";
            this.buttonStartGroup.Click += new System.EventHandler(this.buttonStartGroup_Click);
            // 
            // buttonEndGroup
            // 
            this.buttonEndGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonEndGroup.Image = ((System.Drawing.Image)(resources.GetObject("buttonEndGroup.Image")));
            this.buttonEndGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonEndGroup.Name = "buttonEndGroup";
            this.buttonEndGroup.Size = new System.Drawing.Size(23, 22);
            this.buttonEndGroup.Text = "End Group";
            this.buttonEndGroup.Click += new System.EventHandler(this.buttonEndGroup_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(472, 307);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Digital Circuits 104";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonAnd;
        private System.Windows.Forms.ToolStripButton buttonOr;
        private System.Windows.Forms.ToolStripButton buttonNot;
        private System.Windows.Forms.ToolStripButton buttonInputSource;
        private System.Windows.Forms.ToolStripButton buttomLamp;
        private System.Windows.Forms.ToolStripButton buttonEvaluate;
        private System.Windows.Forms.ToolStripButton buttonCopy;
        private System.Windows.Forms.ToolStripButton buttonStartGroup;
        protected internal System.Windows.Forms.ToolStripButton buttonEndGroup;
    }
}

