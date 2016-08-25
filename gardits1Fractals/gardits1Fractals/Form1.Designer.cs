namespace gardits1Fractals
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
            this.btnTriangle = new System.Windows.Forms.Button();
            this.tbDepth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSnowflake = new System.Windows.Forms.Button();
            this.btnTree = new System.Windows.Forms.Button();
            this.btnDragon = new System.Windows.Forms.Button();
            this.btnCesàro = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTriangle
            // 
            this.btnTriangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTriangle.Location = new System.Drawing.Point(23, 90);
            this.btnTriangle.Margin = new System.Windows.Forms.Padding(2);
            this.btnTriangle.Name = "btnTriangle";
            this.btnTriangle.Size = new System.Drawing.Size(124, 35);
            this.btnTriangle.TabIndex = 0;
            this.btnTriangle.Text = "Triangle";
            this.btnTriangle.UseVisualStyleBackColor = true;
            this.btnTriangle.Click += new System.EventHandler(this.btnTriangle_Click);
            // 
            // tbDepth
            // 
            this.tbDepth.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDepth.Location = new System.Drawing.Point(23, 37);
            this.tbDepth.Margin = new System.Windows.Forms.Padding(2);
            this.tbDepth.Name = "tbDepth";
            this.tbDepth.Size = new System.Drawing.Size(124, 32);
            this.tbDepth.TabIndex = 0;
            this.tbDepth.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Depth";
            // 
            // btnSnowflake
            // 
            this.btnSnowflake.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSnowflake.Location = new System.Drawing.Point(23, 144);
            this.btnSnowflake.Margin = new System.Windows.Forms.Padding(2);
            this.btnSnowflake.Name = "btnSnowflake";
            this.btnSnowflake.Size = new System.Drawing.Size(124, 35);
            this.btnSnowflake.TabIndex = 3;
            this.btnSnowflake.Text = "Snowflake";
            this.btnSnowflake.UseVisualStyleBackColor = true;
            this.btnSnowflake.Click += new System.EventHandler(this.btnSnowflake_Click);
            // 
            // btnTree
            // 
            this.btnTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTree.Location = new System.Drawing.Point(23, 200);
            this.btnTree.Margin = new System.Windows.Forms.Padding(2);
            this.btnTree.Name = "btnTree";
            this.btnTree.Size = new System.Drawing.Size(124, 35);
            this.btnTree.TabIndex = 4;
            this.btnTree.Text = "Tree";
            this.btnTree.UseVisualStyleBackColor = true;
            this.btnTree.Click += new System.EventHandler(this.btnTree_Click);
            // 
            // btnDragon
            // 
            this.btnDragon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDragon.Location = new System.Drawing.Point(23, 258);
            this.btnDragon.Margin = new System.Windows.Forms.Padding(2);
            this.btnDragon.Name = "btnDragon";
            this.btnDragon.Size = new System.Drawing.Size(124, 35);
            this.btnDragon.TabIndex = 5;
            this.btnDragon.Text = "Dragon";
            this.btnDragon.UseVisualStyleBackColor = true;
            this.btnDragon.Click += new System.EventHandler(this.btnDragon_Click);
            // 
            // btnCesàro
            // 
            this.btnCesàro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCesàro.Location = new System.Drawing.Point(23, 312);
            this.btnCesàro.Margin = new System.Windows.Forms.Padding(2);
            this.btnCesàro.Name = "btnCesàro";
            this.btnCesàro.Size = new System.Drawing.Size(124, 35);
            this.btnCesàro.TabIndex = 6;
            this.btnCesàro.Text = "Cesàro";
            this.btnCesàro.UseVisualStyleBackColor = true;
            this.btnCesàro.Click += new System.EventHandler(this.btnCesàro_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1525, 830);
            this.Controls.Add(this.btnCesàro);
            this.Controls.Add(this.btnDragon);
            this.Controls.Add(this.btnTree);
            this.Controls.Add(this.btnSnowflake);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDepth);
            this.Controls.Add(this.btnTriangle);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTriangle;
        private System.Windows.Forms.TextBox tbDepth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSnowflake;
        private System.Windows.Forms.Button btnTree;
        private System.Windows.Forms.Button btnDragon;
        private System.Windows.Forms.Button btnCesàro;
    }
}

