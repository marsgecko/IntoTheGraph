namespace Graph
{
    partial class LineForm
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
            this.gbBarValue = new System.Windows.Forms.GroupBox();
            this.btnBarValueFontColour = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.label128 = new System.Windows.Forms.Label();
            this.udValueFontSize = new System.Windows.Forms.NumericUpDown();
            this.label127 = new System.Windows.Forms.Label();
            this.udValueMargin = new System.Windows.Forms.NumericUpDown();
            this.cbValueCentered = new System.Windows.Forms.CheckBox();
            this.cbValueBelowTop = new System.Windows.Forms.CheckBox();
            this.cbValueAboveTop = new System.Windows.Forms.CheckBox();
            this.gbOrigin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udOriginY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udOriginX)).BeginInit();
            this.gbAxes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udAxisLineWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udYAxisHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udXAxisWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMaxValue)).BeginInit();
            this.gbBars.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udBarMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udBarWidth)).BeginInit();
            this.gbTicks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udTickLineWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTickLabelMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTickFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udYAxisLabelMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udYAxisLableFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udColumnLabelMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udColumnLabelFontSize)).BeginInit();
            this.gbLegend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udLegendTextMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLegendMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLegendFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLegendKeySize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLegendVerticalSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udBorderWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.preview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udYAxisScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udColumnLabelAngle)).BeginInit();
            this.gbBarValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udValueFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udValueMargin)).BeginInit();
            this.SuspendLayout();
            // 
            // gbBarValue
            // 
            this.gbBarValue.Controls.Add(this.btnBarValueFontColour);
            this.gbBarValue.Controls.Add(this.label27);
            this.gbBarValue.Controls.Add(this.label128);
            this.gbBarValue.Controls.Add(this.udValueFontSize);
            this.gbBarValue.Controls.Add(this.label127);
            this.gbBarValue.Controls.Add(this.udValueMargin);
            this.gbBarValue.Controls.Add(this.cbValueCentered);
            this.gbBarValue.Controls.Add(this.cbValueBelowTop);
            this.gbBarValue.Controls.Add(this.cbValueAboveTop);
            this.gbBarValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBarValue.Location = new System.Drawing.Point(193, 418);
            this.gbBarValue.Name = "gbBarValue";
            this.gbBarValue.Size = new System.Drawing.Size(464, 98);
            this.gbBarValue.TabIndex = 26;
            this.gbBarValue.TabStop = false;
            this.gbBarValue.Text = "Bar Value";
            // 
            // btnBarValueFontColour
            // 
            this.btnBarValueFontColour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnBarValueFontColour.Location = new System.Drawing.Point(265, 44);
            this.btnBarValueFontColour.Name = "btnBarValueFontColour";
            this.btnBarValueFontColour.Size = new System.Drawing.Size(40, 40);
            this.btnBarValueFontColour.TabIndex = 40;
            this.btnBarValueFontColour.UseVisualStyleBackColor = false;
            this.btnBarValueFontColour.Click += new System.EventHandler(this.btnBarValueFontColour_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(163, 54);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(96, 20);
            this.label27.TabIndex = 39;
            this.label27.Text = "Font Colour:";
            // 
            // label128
            // 
            this.label128.AutoSize = true;
            this.label128.Location = new System.Drawing.Point(311, 54);
            this.label128.Name = "label128";
            this.label128.Size = new System.Drawing.Size(81, 20);
            this.label128.TabIndex = 38;
            this.label128.Text = "Font Size:";
            // 
            // udValueFontSize
            // 
            this.udValueFontSize.DecimalPlaces = 1;
            this.udValueFontSize.Location = new System.Drawing.Point(398, 52);
            this.udValueFontSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.udValueFontSize.Name = "udValueFontSize";
            this.udValueFontSize.Size = new System.Drawing.Size(53, 26);
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
            this.label127.Location = new System.Drawing.Point(330, 22);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(61, 20);
            this.label127.TabIndex = 36;
            this.label127.Text = "Margin:";
            // 
            // udValueMargin
            // 
            this.udValueMargin.DecimalPlaces = 1;
            this.udValueMargin.Location = new System.Drawing.Point(398, 20);
            this.udValueMargin.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.udValueMargin.Name = "udValueMargin";
            this.udValueMargin.Size = new System.Drawing.Size(53, 26);
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
            this.cbValueCentered.Location = new System.Drawing.Point(151, 22);
            this.cbValueCentered.Name = "cbValueCentered";
            this.cbValueCentered.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbValueCentered.Size = new System.Drawing.Size(98, 24);
            this.cbValueCentered.TabIndex = 3;
            this.cbValueCentered.Text = "Centered:";
            this.cbValueCentered.UseVisualStyleBackColor = true;
            this.cbValueCentered.CheckedChanged += new System.EventHandler(this.cbValueCentered_CheckedChanged);
            // 
            // cbValueBelowTop
            // 
            this.cbValueBelowTop.AutoSize = true;
            this.cbValueBelowTop.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbValueBelowTop.Location = new System.Drawing.Point(13, 53);
            this.cbValueBelowTop.Name = "cbValueBelowTop";
            this.cbValueBelowTop.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbValueBelowTop.Size = new System.Drawing.Size(106, 24);
            this.cbValueBelowTop.TabIndex = 2;
            this.cbValueBelowTop.Text = "Below Top:";
            this.cbValueBelowTop.UseVisualStyleBackColor = true;
            this.cbValueBelowTop.CheckedChanged += new System.EventHandler(this.cbValueBelowTop_CheckedChanged);
            // 
            // cbValueAboveTop
            // 
            this.cbValueAboveTop.AutoSize = true;
            this.cbValueAboveTop.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbValueAboveTop.Location = new System.Drawing.Point(11, 21);
            this.cbValueAboveTop.Name = "cbValueAboveTop";
            this.cbValueAboveTop.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbValueAboveTop.Size = new System.Drawing.Size(108, 24);
            this.cbValueAboveTop.TabIndex = 1;
            this.cbValueAboveTop.Text = "Above Top:";
            this.cbValueAboveTop.UseVisualStyleBackColor = true;
            this.cbValueAboveTop.CheckedChanged += new System.EventHandler(this.cbValueAboveTop_CheckedChanged);
            // 
            // LineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1477, 532);
            this.Controls.Add(this.gbBarValue);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "LineForm";
            this.Text = "Bar Graph";
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.preview, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.btnFont, 0);
            this.Controls.SetChildIndex(this.lblFont, 0);
            this.Controls.SetChildIndex(this.lblLegend, 0);
            this.Controls.SetChildIndex(this.btnImport, 0);
            this.Controls.SetChildIndex(this.gbOrigin, 0);
            this.Controls.SetChildIndex(this.gbAxes, 0);
            this.Controls.SetChildIndex(this.cbNoAuto, 0);
            this.Controls.SetChildIndex(this.gbBars, 0);
            this.Controls.SetChildIndex(this.gbTicks, 0);
            this.Controls.SetChildIndex(this.gbLegend, 0);
            this.Controls.SetChildIndex(this.gbBarValue, 0);
            this.gbOrigin.ResumeLayout(false);
            this.gbOrigin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udOriginY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udOriginX)).EndInit();
            this.gbAxes.ResumeLayout(false);
            this.gbAxes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udAxisLineWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udYAxisHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udXAxisWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMaxValue)).EndInit();
            this.gbBars.ResumeLayout(false);
            this.gbBars.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udBarMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udBarWidth)).EndInit();
            this.gbTicks.ResumeLayout(false);
            this.gbTicks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udTickLineWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTickLabelMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTickFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udYAxisLabelMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udYAxisLableFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udColumnLabelMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udColumnLabelFontSize)).EndInit();
            this.gbLegend.ResumeLayout(false);
            this.gbLegend.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udLegendTextMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLegendMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLegendFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLegendKeySize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLegendVerticalSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udBorderWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.preview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udYAxisScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udColumnLabelAngle)).EndInit();
            this.gbBarValue.ResumeLayout(false);
            this.gbBarValue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udValueFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udValueMargin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbBarValue;
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

