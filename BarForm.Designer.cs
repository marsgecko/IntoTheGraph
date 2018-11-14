namespace Graph
{
    partial class BarForm
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbValueAboveTop = new System.Windows.Forms.CheckBox();
            this.cbValueBelowTop = new System.Windows.Forms.CheckBox();
            this.cbValueCentered = new System.Windows.Forms.CheckBox();
            this.label127 = new System.Windows.Forms.Label();
            this.udValueMargin = new System.Windows.Forms.NumericUpDown();
            this.label128 = new System.Windows.Forms.Label();
            this.udValueFontSize = new System.Windows.Forms.NumericUpDown();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udValueMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udValueFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label128);
            this.groupBox6.Controls.Add(this.udValueFontSize);
            this.groupBox6.Controls.Add(this.label127);
            this.groupBox6.Controls.Add(this.udValueMargin);
            this.groupBox6.Controls.Add(this.cbValueCentered);
            this.groupBox6.Controls.Add(this.cbValueBelowTop);
            this.groupBox6.Controls.Add(this.cbValueAboveTop);
            this.groupBox6.Location = new System.Drawing.Point(261, 346);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(396, 67);
            this.groupBox6.TabIndex = 26;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Bar";
            // 
            // cbValueAboveTop
            // 
            this.cbValueAboveTop.AutoSize = true;
            this.cbValueAboveTop.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbValueAboveTop.Location = new System.Drawing.Point(6, 19);
            this.cbValueAboveTop.Name = "cbValueAboveTop";
            this.cbValueAboveTop.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbValueAboveTop.Size = new System.Drawing.Size(112, 17);
            this.cbValueAboveTop.TabIndex = 1;
            this.cbValueAboveTop.Text = "Value Above Top:";
            this.cbValueAboveTop.UseVisualStyleBackColor = true;
            this.cbValueAboveTop.CheckedChanged += new System.EventHandler(this.cbValueAboveTop_CheckedChanged);
            // 
            // cbValueBelowTop
            // 
            this.cbValueBelowTop.AutoSize = true;
            this.cbValueBelowTop.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbValueBelowTop.Location = new System.Drawing.Point(8, 39);
            this.cbValueBelowTop.Name = "cbValueBelowTop";
            this.cbValueBelowTop.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbValueBelowTop.Size = new System.Drawing.Size(110, 17);
            this.cbValueBelowTop.TabIndex = 2;
            this.cbValueBelowTop.Text = "Value Below Top:";
            this.cbValueBelowTop.UseVisualStyleBackColor = true;
            this.cbValueBelowTop.CheckedChanged += new System.EventHandler(this.cbValueBelowTop_CheckedChanged);
            // 
            // cbValueCentered
            // 
            this.cbValueCentered.AutoSize = true;
            this.cbValueCentered.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbValueCentered.Location = new System.Drawing.Point(124, 19);
            this.cbValueCentered.Name = "cbValueCentered";
            this.cbValueCentered.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbValueCentered.Size = new System.Drawing.Size(102, 17);
            this.cbValueCentered.TabIndex = 3;
            this.cbValueCentered.Text = "Value Centered:";
            this.cbValueCentered.UseVisualStyleBackColor = true;
            this.cbValueCentered.CheckedChanged += new System.EventHandler(this.cbValueCentered_CheckedChanged);
            // 
            // label127
            // 
            this.label127.AutoSize = true;
            this.label127.Location = new System.Drawing.Point(237, 20);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(72, 13);
            this.label127.TabIndex = 36;
            this.label127.Text = "Value Margin:";
            // 
            // udValueMargin
            // 
            this.udValueMargin.DecimalPlaces = 1;
            this.udValueMargin.Location = new System.Drawing.Point(323, 18);
            this.udValueMargin.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.udValueMargin.Name = "udValueMargin";
            this.udValueMargin.Size = new System.Drawing.Size(53, 20);
            this.udValueMargin.TabIndex = 35;
            this.udValueMargin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udValueMargin.ValueChanged += new System.EventHandler(this.udValueMargin_ValueChanged);
            // 
            // label128
            // 
            this.label128.AutoSize = true;
            this.label128.Location = new System.Drawing.Point(237, 43);
            this.label128.Name = "label128";
            this.label128.Size = new System.Drawing.Size(84, 13);
            this.label128.TabIndex = 38;
            this.label128.Text = "Value Font Size:";
            // 
            // udValueFontSize
            // 
            this.udValueFontSize.DecimalPlaces = 1;
            this.udValueFontSize.Location = new System.Drawing.Point(323, 41);
            this.udValueFontSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.udValueFontSize.Name = "udValueFontSize";
            this.udValueFontSize.Size = new System.Drawing.Size(53, 20);
            this.udValueFontSize.TabIndex = 37;
            this.udValueFontSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udValueFontSize.ValueChanged += new System.EventHandler(this.udValueFontSize_ValueChanged);
            // 
            // BarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 427);
            this.Controls.Add(this.groupBox6);
            this.Name = "BarForm";
            this.Text = "Bar Graph";
            this.Controls.SetChildIndex(this.groupBox6, 0);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udValueMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udValueFontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox cbValueCentered;
        private System.Windows.Forms.CheckBox cbValueBelowTop;
        private System.Windows.Forms.CheckBox cbValueAboveTop;
        private System.Windows.Forms.Label label128;
        private System.Windows.Forms.NumericUpDown udValueFontSize;
        private System.Windows.Forms.Label label127;
        private System.Windows.Forms.NumericUpDown udValueMargin;

    }
}

