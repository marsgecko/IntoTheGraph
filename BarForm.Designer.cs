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
            this.label128 = new System.Windows.Forms.Label();
            this.udValueFontSize = new System.Windows.Forms.NumericUpDown();
            this.label127 = new System.Windows.Forms.Label();
            this.udValueMargin = new System.Windows.Forms.NumericUpDown();
            this.cbValueCentered = new System.Windows.Forms.CheckBox();
            this.cbValueBelowTop = new System.Windows.Forms.CheckBox();
            this.cbValueAboveTop = new System.Windows.Forms.CheckBox();
            this.btnBarValueFontColour = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udOriginY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udOriginX)).BeginInit();
            this.groupAxes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udAxisLineWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udYAxisHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udXAxisWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMaxValue)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udBarMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udBarWidth)).BeginInit();
            this.groupTicks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udTickLineWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTickLabelMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTickFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udYAxisLabelMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udYAxisLableFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udColumnLabelMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udColumnLabelFontSize)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udLegendTextMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLegendMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLegendFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLegendKeySize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLegendVerticalSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udBorderWidth)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udValueFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udValueMargin)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnBarValueFontColour);
            this.groupBox6.Controls.Add(this.label27);
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
            this.groupBox6.Text = "Bar Value";
            // 
            // label128
            // 
            this.label128.AutoSize = true;
            this.label128.Location = new System.Drawing.Point(263, 43);
            this.label128.Name = "label128";
            this.label128.Size = new System.Drawing.Size(54, 13);
            this.label128.TabIndex = 38;
            this.label128.Text = "Font Size:";
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
            // label127
            // 
            this.label127.AutoSize = true;
            this.label127.Location = new System.Drawing.Point(274, 20);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(42, 13);
            this.label127.TabIndex = 36;
            this.label127.Text = "Margin:";
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
            // cbValueCentered
            // 
            this.cbValueCentered.AutoSize = true;
            this.cbValueCentered.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbValueCentered.Location = new System.Drawing.Point(124, 19);
            this.cbValueCentered.Name = "cbValueCentered";
            this.cbValueCentered.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbValueCentered.Size = new System.Drawing.Size(72, 17);
            this.cbValueCentered.TabIndex = 3;
            this.cbValueCentered.Text = "Centered:";
            this.cbValueCentered.UseVisualStyleBackColor = true;
            this.cbValueCentered.CheckedChanged += new System.EventHandler(this.cbValueCentered_CheckedChanged);
            // 
            // cbValueBelowTop
            // 
            this.cbValueBelowTop.AutoSize = true;
            this.cbValueBelowTop.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbValueBelowTop.Location = new System.Drawing.Point(8, 39);
            this.cbValueBelowTop.Name = "cbValueBelowTop";
            this.cbValueBelowTop.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbValueBelowTop.Size = new System.Drawing.Size(80, 17);
            this.cbValueBelowTop.TabIndex = 2;
            this.cbValueBelowTop.Text = "Below Top:";
            this.cbValueBelowTop.UseVisualStyleBackColor = true;
            this.cbValueBelowTop.CheckedChanged += new System.EventHandler(this.cbValueBelowTop_CheckedChanged);
            // 
            // cbValueAboveTop
            // 
            this.cbValueAboveTop.AutoSize = true;
            this.cbValueAboveTop.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbValueAboveTop.Location = new System.Drawing.Point(6, 19);
            this.cbValueAboveTop.Name = "cbValueAboveTop";
            this.cbValueAboveTop.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbValueAboveTop.Size = new System.Drawing.Size(82, 17);
            this.cbValueAboveTop.TabIndex = 1;
            this.cbValueAboveTop.Text = "Above Top:";
            this.cbValueAboveTop.UseVisualStyleBackColor = true;
            this.cbValueAboveTop.CheckedChanged += new System.EventHandler(this.cbValueAboveTop_CheckedChanged);
            // 
            // btnBarValueFontColour
            // 
            this.btnBarValueFontColour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnBarValueFontColour.Location = new System.Drawing.Point(180, 39);
            this.btnBarValueFontColour.Name = "btnBarValueFontColour";
            this.btnBarValueFontColour.Size = new System.Drawing.Size(20, 20);
            this.btnBarValueFontColour.TabIndex = 40;
            this.btnBarValueFontColour.UseVisualStyleBackColor = false;
            this.btnBarValueFontColour.Click += new System.EventHandler(this.btnBarValueFontColour_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(110, 43);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(64, 13);
            this.label27.TabIndex = 39;
            this.label27.Text = "Font Colour:";
            // 
            // BarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 427);
            this.Controls.Add(this.groupBox6);
            this.Name = "BarForm";
            this.Text = "Bar Graph";
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.btnFont, 0);
            this.Controls.SetChildIndex(this.lblFont, 0);
            this.Controls.SetChildIndex(this.lblLegend, 0);
            this.Controls.SetChildIndex(this.btnImport, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupAxes, 0);
            this.Controls.SetChildIndex(this.cbNoAuto, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupTicks, 0);
            this.Controls.SetChildIndex(this.groupBox5, 0);
            this.Controls.SetChildIndex(this.groupBox6, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udOriginY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udOriginX)).EndInit();
            this.groupAxes.ResumeLayout(false);
            this.groupAxes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udAxisLineWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udYAxisHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udXAxisWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMaxValue)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udBarMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udBarWidth)).EndInit();
            this.groupTicks.ResumeLayout(false);
            this.groupTicks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udTickLineWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTickLabelMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTickFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udYAxisLabelMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udYAxisLableFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udColumnLabelMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udColumnLabelFontSize)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udLegendTextMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLegendMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLegendFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLegendKeySize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLegendVerticalSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udBorderWidth)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udValueFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udValueMargin)).EndInit();
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
        protected System.Windows.Forms.Button btnBarValueFontColour;
        protected System.Windows.Forms.Label label27;

    }
}

