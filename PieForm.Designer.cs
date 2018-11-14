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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbDoughnut = new System.Windows.Forms.CheckBox();
            this.label27 = new System.Windows.Forms.Label();
            this.udDoughnutSize = new System.Windows.Forms.NumericUpDown();
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
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udDoughnutSize)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.udDoughnutSize);
            this.groupBox2.Controls.Add(this.cbDoughnut);
            this.groupBox2.Location = new System.Drawing.Point(261, 346);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(396, 67);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pie Chart";
            // 
            // cbDoughnut
            // 
            this.cbDoughnut.AutoSize = true;
            this.cbDoughnut.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbDoughnut.Location = new System.Drawing.Point(38, 19);
            this.cbDoughnut.Name = "cbDoughnut";
            this.cbDoughnut.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbDoughnut.Size = new System.Drawing.Size(76, 17);
            this.cbDoughnut.TabIndex = 1;
            this.cbDoughnut.Text = "Doughnut:";
            this.cbDoughnut.UseVisualStyleBackColor = true;
            this.cbDoughnut.CheckedChanged += new System.EventHandler(this.cbDoughnut_CheckedChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(14, 43);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(80, 13);
            this.label27.TabIndex = 24;
            this.label27.Text = "Doughnut Size:";
            // 
            // udDoughnutSize
            // 
            this.udDoughnutSize.DecimalPlaces = 1;
            this.udDoughnutSize.Location = new System.Drawing.Point(100, 41);
            this.udDoughnutSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.udDoughnutSize.Name = "udDoughnutSize";
            this.udDoughnutSize.Size = new System.Drawing.Size(53, 20);
            this.udDoughnutSize.TabIndex = 23;
            this.udDoughnutSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udDoughnutSize.ValueChanged += new System.EventHandler(this.udDoughnutSize_ValueChanged);
            // 
            // PieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 427);
            this.Controls.Add(this.groupBox2);
            this.Name = "PieForm";
            this.Text = "PieForm";
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
            this.Controls.SetChildIndex(this.groupBox2, 0);
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udDoughnutSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        protected System.Windows.Forms.CheckBox cbDoughnut;
        protected System.Windows.Forms.Label label27;
        protected System.Windows.Forms.NumericUpDown udDoughnutSize;
    }
}