namespace Graph
{
    partial class PieForm
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
            this.gbPieChart = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.udDoughnutSize = new System.Windows.Forms.NumericUpDown();
            this.cbDoughnut = new System.Windows.Forms.CheckBox();
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
            this.gbPieChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udDoughnutSize)).BeginInit();
            this.SuspendLayout();
            // 
            // gbBars
            // 
            this.gbBars.Location = new System.Drawing.Point(134, 118);
            // 
            // gbTicks
            // 
            this.gbTicks.Location = new System.Drawing.Point(19, 263);
            // 
            // preview
            // 
            this.preview.Location = new System.Drawing.Point(767, 72);
            // 
            // gbPieChart
            // 
            this.gbPieChart.Controls.Add(this.label27);
            this.gbPieChart.Controls.Add(this.udDoughnutSize);
            this.gbPieChart.Controls.Add(this.cbDoughnut);
            this.gbPieChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPieChart.Location = new System.Drawing.Point(308, 431);
            this.gbPieChart.Name = "gbPieChart";
            this.gbPieChart.Size = new System.Drawing.Size(396, 67);
            this.gbPieChart.TabIndex = 26;
            this.gbPieChart.TabStop = false;
            this.gbPieChart.Text = "Pie Chart";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(171, 28);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(119, 20);
            this.label27.TabIndex = 24;
            this.label27.Text = "Doughnut Size:";
            // 
            // udDoughnutSize
            // 
            this.udDoughnutSize.DecimalPlaces = 1;
            this.udDoughnutSize.Location = new System.Drawing.Point(315, 26);
            this.udDoughnutSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.udDoughnutSize.Name = "udDoughnutSize";
            this.udDoughnutSize.Size = new System.Drawing.Size(75, 26);
            this.udDoughnutSize.TabIndex = 23;
            this.udDoughnutSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udDoughnutSize.ValueChanged += new System.EventHandler(this.udDoughnutSize_ValueChanged);
            // 
            // cbDoughnut
            // 
            this.cbDoughnut.AutoSize = true;
            this.cbDoughnut.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbDoughnut.Location = new System.Drawing.Point(5, 26);
            this.cbDoughnut.Name = "cbDoughnut";
            this.cbDoughnut.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbDoughnut.Size = new System.Drawing.Size(103, 24);
            this.cbDoughnut.TabIndex = 1;
            this.cbDoughnut.Text = "Doughnut:";
            this.cbDoughnut.UseVisualStyleBackColor = true;
            this.cbDoughnut.CheckedChanged += new System.EventHandler(this.cbDoughnut_CheckedChanged);
            // 
            // PieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1433, 556);
            this.Controls.Add(this.gbPieChart);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "PieForm";
            this.Text = "PieForm";
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
            this.Controls.SetChildIndex(this.gbPieChart, 0);
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
            this.gbPieChart.ResumeLayout(false);
            this.gbPieChart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udDoughnutSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPieChart;
        protected System.Windows.Forms.CheckBox cbDoughnut;
        protected System.Windows.Forms.Label label27;
        protected System.Windows.Forms.NumericUpDown udDoughnutSize;
    }
}