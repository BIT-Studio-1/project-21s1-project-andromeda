﻿
namespace project_andromeda
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonNorth = new System.Windows.Forms.Button();
            this.buttonEast = new System.Windows.Forms.Button();
            this.buttonSouth = new System.Windows.Forms.Button();
            this.buttonWest = new System.Windows.Forms.Button();
            this.directionalLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(776, 312);
            this.textBox1.TabIndex = 0;
            // 
            // buttonNorth
            // 
            this.buttonNorth.Location = new System.Drawing.Point(363, 348);
            this.buttonNorth.Name = "buttonNorth";
            this.buttonNorth.Size = new System.Drawing.Size(75, 23);
            this.buttonNorth.TabIndex = 1;
            this.buttonNorth.Text = "North";
            this.buttonNorth.UseVisualStyleBackColor = true;
            // 
            // buttonEast
            // 
            this.buttonEast.Location = new System.Drawing.Point(444, 377);
            this.buttonEast.Name = "buttonEast";
            this.buttonEast.Size = new System.Drawing.Size(75, 23);
            this.buttonEast.TabIndex = 2;
            this.buttonEast.Text = "East";
            this.buttonEast.UseVisualStyleBackColor = true;
            // 
            // buttonSouth
            // 
            this.buttonSouth.Location = new System.Drawing.Point(363, 406);
            this.buttonSouth.Name = "buttonSouth";
            this.buttonSouth.Size = new System.Drawing.Size(75, 23);
            this.buttonSouth.TabIndex = 3;
            this.buttonSouth.Text = "South";
            this.buttonSouth.UseVisualStyleBackColor = true;
            // 
            // buttonWest
            // 
            this.buttonWest.Location = new System.Drawing.Point(282, 377);
            this.buttonWest.Name = "buttonWest";
            this.buttonWest.Size = new System.Drawing.Size(75, 23);
            this.buttonWest.TabIndex = 4;
            this.buttonWest.Text = "West";
            this.buttonWest.UseVisualStyleBackColor = true;
            // 
            // directionalLabel
            // 
            this.directionalLabel.AutoSize = true;
            this.directionalLabel.Location = new System.Drawing.Point(373, 382);
            this.directionalLabel.Name = "directionalLabel";
            this.directionalLabel.Size = new System.Drawing.Size(54, 13);
            this.directionalLabel.TabIndex = 5;
            this.directionalLabel.Text = "Directions";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.directionalLabel);
            this.Controls.Add(this.buttonWest);
            this.Controls.Add(this.buttonSouth);
            this.Controls.Add(this.buttonEast);
            this.Controls.Add(this.buttonNorth);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "ANDROMEDA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonNorth;
        private System.Windows.Forms.Button buttonEast;
        private System.Windows.Forms.Button buttonSouth;
        private System.Windows.Forms.Button buttonWest;
        private System.Windows.Forms.Label directionalLabel;
    }
}

