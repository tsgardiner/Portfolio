namespace GrayScottSimulator
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gbLaplacians = new System.Windows.Forms.GroupBox();
            this.rbDeltaMeans = new System.Windows.Forms.RadioButton();
            this.rbConvolution = new System.Windows.Forms.RadioButton();
            this.rbPerpendicular = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbGreyScale = new System.Windows.Forms.RadioButton();
            this.rbRedBlack = new System.Windows.Forms.RadioButton();
            this.rbGreenBlack = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbKillB = new System.Windows.Forms.TextBox();
            this.tbFeedA = new System.Windows.Forms.TextBox();
            this.btnRunSimulation = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAuto = new System.Windows.Forms.Button();
            this.tbTimeSteps = new System.Windows.Forms.TextBox();
            this.lbDisplayTimeSteps = new System.Windows.Forms.Label();
            this.gbLaplacians.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // gbLaplacians
            // 
            this.gbLaplacians.Controls.Add(this.rbDeltaMeans);
            this.gbLaplacians.Controls.Add(this.rbConvolution);
            this.gbLaplacians.Controls.Add(this.rbPerpendicular);
            this.gbLaplacians.Location = new System.Drawing.Point(528, 217);
            this.gbLaplacians.Name = "gbLaplacians";
            this.gbLaplacians.Size = new System.Drawing.Size(138, 186);
            this.gbLaplacians.TabIndex = 4;
            this.gbLaplacians.TabStop = false;
            this.gbLaplacians.Text = "Laplacians";
            // 
            // rbDeltaMeans
            // 
            this.rbDeltaMeans.AutoSize = true;
            this.rbDeltaMeans.Location = new System.Drawing.Point(24, 140);
            this.rbDeltaMeans.Name = "rbDeltaMeans";
            this.rbDeltaMeans.Size = new System.Drawing.Size(85, 17);
            this.rbDeltaMeans.TabIndex = 6;
            this.rbDeltaMeans.Text = "Delta Means";
            this.rbDeltaMeans.UseVisualStyleBackColor = true;
            // 
            // rbConvolution
            // 
            this.rbConvolution.AutoSize = true;
            this.rbConvolution.Location = new System.Drawing.Point(24, 86);
            this.rbConvolution.Name = "rbConvolution";
            this.rbConvolution.Size = new System.Drawing.Size(81, 17);
            this.rbConvolution.TabIndex = 5;
            this.rbConvolution.Text = "Convolution";
            this.rbConvolution.UseVisualStyleBackColor = true;
            // 
            // rbPerpendicular
            // 
            this.rbPerpendicular.AutoSize = true;
            this.rbPerpendicular.Checked = true;
            this.rbPerpendicular.Location = new System.Drawing.Point(24, 32);
            this.rbPerpendicular.Name = "rbPerpendicular";
            this.rbPerpendicular.Size = new System.Drawing.Size(90, 17);
            this.rbPerpendicular.TabIndex = 4;
            this.rbPerpendicular.TabStop = true;
            this.rbPerpendicular.Text = "Perpendicular";
            this.rbPerpendicular.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbGreyScale);
            this.groupBox2.Controls.Add(this.rbRedBlack);
            this.groupBox2.Controls.Add(this.rbGreenBlack);
            this.groupBox2.Location = new System.Drawing.Point(672, 217);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(138, 186);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pattern Colours";
            // 
            // rbGreyScale
            // 
            this.rbGreyScale.AutoSize = true;
            this.rbGreyScale.Checked = true;
            this.rbGreyScale.Location = new System.Drawing.Point(21, 32);
            this.rbGreyScale.Name = "rbGreyScale";
            this.rbGreyScale.Size = new System.Drawing.Size(77, 17);
            this.rbGreyScale.TabIndex = 7;
            this.rbGreyScale.TabStop = true;
            this.rbGreyScale.Text = "Grey Scale";
            this.rbGreyScale.UseVisualStyleBackColor = true;
            // 
            // rbRedBlack
            // 
            this.rbRedBlack.AutoSize = true;
            this.rbRedBlack.Location = new System.Drawing.Point(21, 86);
            this.rbRedBlack.Name = "rbRedBlack";
            this.rbRedBlack.Size = new System.Drawing.Size(75, 17);
            this.rbRedBlack.TabIndex = 8;
            this.rbRedBlack.Text = "Red Black";
            this.rbRedBlack.UseVisualStyleBackColor = true;
            // 
            // rbGreenBlack
            // 
            this.rbGreenBlack.AutoSize = true;
            this.rbGreenBlack.Location = new System.Drawing.Point(21, 140);
            this.rbGreenBlack.Name = "rbGreenBlack";
            this.rbGreenBlack.Size = new System.Drawing.Size(84, 17);
            this.rbGreenBlack.TabIndex = 9;
            this.rbGreenBlack.Text = "Green Black";
            this.rbGreenBlack.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(549, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "killB";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(549, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "feedA";
            // 
            // tbKillB
            // 
            this.tbKillB.Location = new System.Drawing.Point(693, 160);
            this.tbKillB.Name = "tbKillB";
            this.tbKillB.Size = new System.Drawing.Size(100, 20);
            this.tbKillB.TabIndex = 3;
            // 
            // tbFeedA
            // 
            this.tbFeedA.Location = new System.Drawing.Point(693, 118);
            this.tbFeedA.Name = "tbFeedA";
            this.tbFeedA.Size = new System.Drawing.Size(100, 20);
            this.tbFeedA.TabIndex = 2;
            // 
            // btnRunSimulation
            // 
            this.btnRunSimulation.Location = new System.Drawing.Point(528, 469);
            this.btnRunSimulation.Name = "btnRunSimulation";
            this.btnRunSimulation.Size = new System.Drawing.Size(282, 56);
            this.btnRunSimulation.TabIndex = 11;
            this.btnRunSimulation.Text = "Run Simulation";
            this.btnRunSimulation.UseVisualStyleBackColor = true;
            this.btnRunSimulation.Click += new System.EventHandler(this.btnRunSimulation_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(549, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Number of time steps";
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(528, 409);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(282, 56);
            this.btnAuto.TabIndex = 10;
            this.btnAuto.Text = "Automated Simulation";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // tbTimeSteps
            // 
            this.tbTimeSteps.Location = new System.Drawing.Point(693, 79);
            this.tbTimeSteps.Name = "tbTimeSteps";
            this.tbTimeSteps.Size = new System.Drawing.Size(100, 20);
            this.tbTimeSteps.TabIndex = 0;
            // 
            // lbDisplayTimeSteps
            // 
            this.lbDisplayTimeSteps.AutoSize = true;
            this.lbDisplayTimeSteps.Location = new System.Drawing.Point(620, 28);
            this.lbDisplayTimeSteps.Name = "lbDisplayTimeSteps";
            this.lbDisplayTimeSteps.Size = new System.Drawing.Size(106, 13);
            this.lbDisplayTimeSteps.TabIndex = 12;
            this.lbDisplayTimeSteps.Text = "Number of time steps";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 537);
            this.Controls.Add(this.lbDisplayTimeSteps);
            this.Controls.Add(this.tbTimeSteps);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRunSimulation);
            this.Controls.Add(this.tbFeedA);
            this.Controls.Add(this.tbKillB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbLaplacians);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pattern Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbLaplacians.ResumeLayout(false);
            this.gbLaplacians.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox gbLaplacians;
        private System.Windows.Forms.RadioButton rbDeltaMeans;
        private System.Windows.Forms.RadioButton rbConvolution;
        private System.Windows.Forms.RadioButton rbPerpendicular;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbGreyScale;
        private System.Windows.Forms.RadioButton rbRedBlack;
        private System.Windows.Forms.RadioButton rbGreenBlack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbKillB;
        private System.Windows.Forms.TextBox tbFeedA;
        private System.Windows.Forms.Button btnRunSimulation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.TextBox tbTimeSteps;
        private System.Windows.Forms.Label lbDisplayTimeSteps;
    }
}

