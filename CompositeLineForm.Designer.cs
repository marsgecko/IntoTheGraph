namespace Graph
{
    partial class CompositeLineForm
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
            this.gbLine = new System.Windows.Forms.GroupBox();
            this.lblTicksInterval = new System.Windows.Forms.Label();
            this.udXTicksInterval = new System.Windows.Forms.NumericUpDown();
            this.cbLineXTicks = new System.Windows.Forms.CheckBox();
            this.lblXAxisSpace = new System.Windows.Forms.Label();
            this.udLinePointSpacing = new System.Windows.Forms.NumericUpDown();
            this.cbLineCurve = new System.Windows.Forms.CheckBox();
            this.lblLineWidth = new System.Windows.Forms.Label();
            this.udLineWidth = new System.Windows.Forms.NumericUpDown();
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
            this.gbLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udXTicksInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLinePointSpacing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLineWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // preview
            // 
            this.preview.Location = new System.Drawing.Point(12, 298);
            this.preview.Size = new System.Drawing.Size(144, 135);
            // 
            // gbLine
            // 
            this.gbLine.Controls.Add(this.lblTicksInterval);
            this.gbLine.Controls.Add(this.udXTicksInterval);
            this.gbLine.Controls.Add(this.cbLineXTicks);
            this.gbLine.Controls.Add(this.lblXAxisSpace);
            this.gbLine.Controls.Add(this.udLinePointSpacing);
            this.gbLine.Controls.Add(this.cbLineCurve);
            this.gbLine.Controls.Add(this.lblLineWidth);
            this.gbLine.Controls.Add(this.udLineWidth);
            this.gbLine.Location = new System.Drawing.Point(193, 408);
            this.gbLine.Name = "gbLine";
            this.gbLine.Size = new System.Drawing.Size(464, 102);
            this.gbLine.TabIndex = 29;
            this.gbLine.TabStop = false;
            this.gbLine.Text = "Line";
            // 
            // lblTicksInterval
            // 
            this.lblTicksInterval.AutoSize = true;
            this.lblTicksInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTicksInterval.Location = new System.Drawing.Point(169, 62);
            this.lblTicksInterval.Name = "lblTicksInterval";
            this.lblTicksInterval.Size = new System.Drawing.Size(65, 20);
            this.lblTicksInterval.TabIndex = 46;
            this.lblTicksInterval.Text = "Interval:";
            // 
            // udXTicksInterval
            // 
            this.udXTicksInterval.DecimalPlaces = 2;
            this.udXTicksInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udXTicksInterval.Location = new System.Drawing.Point(240, 60);
            this.udXTicksInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.udXTicksInterval.Name = "udXTicksInterval";
            this.udXTicksInterval.Size = new System.Drawing.Size(70, 26);
            this.udXTicksInterval.TabIndex = 45;
            this.udXTicksInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udXTicksInterval.ValueChanged += new System.EventHandler(this.udXTicksInterval_ValueChanged);
            // 
            // cbLineXTicks
            // 
            this.cbLineXTicks.AutoSize = true;
            this.cbLineXTicks.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbLineXTicks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLineXTicks.Location = new System.Drawing.Point(335, 60);
            this.cbLineXTicks.Name = "cbLineXTicks";
            this.cbLineXTicks.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbLineXTicks.Size = new System.Drawing.Size(116, 24);
            this.cbLineXTicks.TabIndex = 44;
            this.cbLineXTicks.Text = "X Axis Ticks:";
            this.cbLineXTicks.UseVisualStyleBackColor = true;
            this.cbLineXTicks.CheckedChanged += new System.EventHandler(this.cbLineXTicks_CheckedChanged);
            // 
            // lblXAxisSpace
            // 
            this.lblXAxisSpace.AutoSize = true;
            this.lblXAxisSpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXAxisSpace.Location = new System.Drawing.Point(158, 21);
            this.lblXAxisSpace.Name = "lblXAxisSpace";
            this.lblXAxisSpace.Size = new System.Drawing.Size(119, 20);
            this.lblXAxisSpace.TabIndex = 43;
            this.lblXAxisSpace.Text = "X Axis Spacing:";
            // 
            // udLinePointSpacing
            // 
            this.udLinePointSpacing.DecimalPlaces = 2;
            this.udLinePointSpacing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udLinePointSpacing.Location = new System.Drawing.Point(279, 19);
            this.udLinePointSpacing.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.udLinePointSpacing.Name = "udLinePointSpacing";
            this.udLinePointSpacing.Size = new System.Drawing.Size(70, 26);
            this.udLinePointSpacing.TabIndex = 42;
            this.udLinePointSpacing.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLinePointSpacing.ValueChanged += new System.EventHandler(this.udLinePointSpacing_ValueChanged);
            // 
            // cbLineCurve
            // 
            this.cbLineCurve.AutoSize = true;
            this.cbLineCurve.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbLineCurve.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLineCurve.Location = new System.Drawing.Point(378, 20);
            this.cbLineCurve.Name = "cbLineCurve";
            this.cbLineCurve.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbLineCurve.Size = new System.Drawing.Size(73, 24);
            this.cbLineCurve.TabIndex = 41;
            this.cbLineCurve.Text = "Curve:";
            this.cbLineCurve.UseVisualStyleBackColor = true;
            this.cbLineCurve.CheckedChanged += new System.EventHandler(this.cbLineCurve_CheckedChanged);
            // 
            // lblLineWidth
            // 
            this.lblLineWidth.AutoSize = true;
            this.lblLineWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLineWidth.Location = new System.Drawing.Point(9, 21);
            this.lblLineWidth.Name = "lblLineWidth";
            this.lblLineWidth.Size = new System.Drawing.Size(54, 20);
            this.lblLineWidth.TabIndex = 38;
            this.lblLineWidth.Text = "Width:";
            // 
            // udLineWidth
            // 
            this.udLineWidth.DecimalPlaces = 2;
            this.udLineWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udLineWidth.Location = new System.Drawing.Point(69, 19);
            this.udLineWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.udLineWidth.Name = "udLineWidth";
            this.udLineWidth.Size = new System.Drawing.Size(70, 26);
            this.udLineWidth.TabIndex = 37;
            this.udLineWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLineWidth.ValueChanged += new System.EventHandler(this.udLineWidth_ValueChanged);
            // 
            // CompositeLineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1477, 532);
            this.Controls.Add(this.gbLine);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "CompositeLineForm";
            this.Text = "Composite Line Graph";
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
            this.Controls.SetChildIndex(this.gbLine, 0);
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
            this.gbLine.ResumeLayout(false);
            this.gbLine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udXTicksInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLinePointSpacing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLineWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLine;
        protected System.Windows.Forms.Label lblLineWidth;
        protected System.Windows.Forms.NumericUpDown udLineWidth;
        protected System.Windows.Forms.CheckBox cbLineCurve;
        protected System.Windows.Forms.Label lblXAxisSpace;
        protected System.Windows.Forms.NumericUpDown udLinePointSpacing;
        protected System.Windows.Forms.Label lblTicksInterval;
        protected System.Windows.Forms.NumericUpDown udXTicksInterval;
        protected System.Windows.Forms.CheckBox cbLineXTicks;


    }
}

