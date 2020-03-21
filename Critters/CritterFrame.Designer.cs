namespace Critters
{
    partial class CritterFrame
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
            this.components = new System.ComponentModel.Container();
            this.start = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.step = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.slider = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.debug = new System.Windows.Forms.Button();
            this.next100 = new System.Windows.Forms.Button();
            this.p = new System.Windows.Forms.TableLayoutPanel();
            this.myPicture = new Critters.CritterPanel();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).BeginInit();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.start.Location = new System.Drawing.Point(256, 527);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 0;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.Start_Click);
            // 
            // stop
            // 
            this.stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stop.Location = new System.Drawing.Point(338, 527);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 23);
            this.stop.TabIndex = 1;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // step
            // 
            this.step.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.step.Location = new System.Drawing.Point(420, 526);
            this.step.Name = "step";
            this.step.Size = new System.Drawing.Size(75, 23);
            this.step.TabIndex = 2;
            this.step.Text = "Step";
            this.step.UseVisualStyleBackColor = true;
            this.step.Click += new System.EventHandler(this.Step_Click);
            // 
            // reset
            // 
            this.reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.reset.Location = new System.Drawing.Point(502, 525);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(75, 23);
            this.reset.TabIndex = 3;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // slider
            // 
            this.slider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.slider.Location = new System.Drawing.Point(59, 516);
            this.slider.Maximum = 100;
            this.slider.Name = "slider";
            this.slider.Size = new System.Drawing.Size(104, 45);
            this.slider.TabIndex = 4;
            this.slider.TickFrequency = 10;
            this.slider.Value = 20;
            this.slider.ValueChanged += new System.EventHandler(this.Slider_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 527);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Slow";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 527);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Fast";
            // 
            // debug
            // 
            this.debug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.debug.Location = new System.Drawing.Point(583, 527);
            this.debug.Name = "debug";
            this.debug.Size = new System.Drawing.Size(75, 23);
            this.debug.TabIndex = 7;
            this.debug.Text = "Debug";
            this.debug.UseVisualStyleBackColor = true;
            this.debug.Click += new System.EventHandler(this.Debug_Click);
            // 
            // next100
            // 
            this.next100.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.next100.Location = new System.Drawing.Point(664, 525);
            this.next100.Name = "next100";
            this.next100.Size = new System.Drawing.Size(75, 23);
            this.next100.TabIndex = 8;
            this.next100.Text = "Next 100";
            this.next100.UseVisualStyleBackColor = true;
            this.next100.Click += new System.EventHandler(this.Next100_Click);
            // 
            // p
            // 
            this.p.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.p.ColumnCount = 1;
            this.p.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.p.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.p.Location = new System.Drawing.Point(825, 3);
            this.p.Name = "p";
            this.p.RowCount = 2;
            this.p.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.27933F));
            this.p.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.72067F));
            this.p.Size = new System.Drawing.Size(107, 389);
            this.p.TabIndex = 9;
            // 
            // myPicture
            // 
            this.myPicture.Location = new System.Drawing.Point(12, 12);
            this.myPicture.Name = "myPicture";
            this.myPicture.Size = new System.Drawing.Size(659, 371);
            this.myPicture.TabIndex = 10;
            // 
            // CritterFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(933, 577);
            this.Controls.Add(this.myPicture);
            this.Controls.Add(this.p);
            this.Controls.Add(this.next100);
            this.Controls.Add(this.debug);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.slider);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.step);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.start);
            this.Name = "CritterFrame";
            this.Text = "Critter simulation";
            ((System.ComponentModel.ISupportInitialize)(this.slider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button step;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar slider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button debug;
        private System.Windows.Forms.Button next100;
        private System.Windows.Forms.TableLayoutPanel p;
        private CritterPanel myPicture;
    }
}

