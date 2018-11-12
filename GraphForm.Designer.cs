namespace Graph
{
    partial class GraphForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.btnFont = new System.Windows.Forms.Button();
            this.lblFont = new System.Windows.Forms.Label();
            this.lblLegend = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.udOriginY = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.udOriginX = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.udInterval = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.udMaxValue = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.udYAxisHeight = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.udXAxisWidth = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.udAxisLineWidth = new System.Windows.Forms.NumericUpDown();
            this.cbDrawYAxis = new System.Windows.Forms.CheckBox();
            this.cbDrawXAxis = new System.Windows.Forms.CheckBox();
            this.cbNoAuto = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.udBarWidth = new System.Windows.Forms.NumericUpDown();
            this.udBarMargin = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.udTickLineWidth = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.udTickLabelMargin = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.udTickFontSize = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.btnTickFontColour = new System.Windows.Forms.Button();
            this.btnTickLineColour = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.udXAxisLabelMargin = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.udXAxisLableFontSize = new System.Windows.Forms.NumericUpDown();
            this.btnXAxisLabelFontColour = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.btnColumnLableFontColour = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.udColumnLabelMargin = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.udColumnLabelFontSize = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udOriginY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udOriginX)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMaxValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udYAxisHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udXAxisWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udAxisLineWidth)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udBarWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udBarMargin)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udTickLineWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTickLabelMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTickFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udXAxisLabelMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udXAxisLableFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udColumnLabelMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udColumnLabelFontSize)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(939, 390);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create PDF";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fontDialog
            // 
            this.fontDialog.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontDialog.ShowEffects = false;
            // 
            // btnFont
            // 
            this.btnFont.Location = new System.Drawing.Point(290, 27);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(75, 23);
            this.btnFont.TabIndex = 1;
            this.btnFont.Text = "Font";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // lblFont
            // 
            this.lblFont.AutoSize = true;
            this.lblFont.Location = new System.Drawing.Point(10, 32);
            this.lblFont.Name = "lblFont";
            this.lblFont.Size = new System.Drawing.Size(114, 13);
            this.lblFont.TabIndex = 2;
            this.lblFont.Text = "This is the chosen font";
            // 
            // lblLegend
            // 
            this.lblLegend.AutoSize = true;
            this.lblLegend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLegend.Location = new System.Drawing.Point(10, 72);
            this.lblLegend.Name = "lblLegend";
            this.lblLegend.Size = new System.Drawing.Size(63, 20);
            this.lblLegend.TabIndex = 3;
            this.lblLegend.Text = "Legend";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(386, 27);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.udOriginY);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.udOriginX);
            this.groupBox1.Location = new System.Drawing.Point(261, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 54);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Origin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Y Offset:";
            // 
            // udOriginY
            // 
            this.udOriginY.DecimalPlaces = 1;
            this.udOriginY.Location = new System.Drawing.Point(237, 18);
            this.udOriginY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udOriginY.Name = "udOriginY";
            this.udOriginY.Size = new System.Drawing.Size(53, 20);
            this.udOriginY.TabIndex = 11;
            this.udOriginY.ValueChanged += new System.EventHandler(this.udOriginY_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "X Offset:";
            // 
            // udOriginX
            // 
            this.udOriginX.DecimalPlaces = 1;
            this.udOriginX.Location = new System.Drawing.Point(106, 18);
            this.udOriginX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udOriginX.Name = "udOriginX";
            this.udOriginX.Size = new System.Drawing.Size(53, 20);
            this.udOriginX.TabIndex = 9;
            this.udOriginX.ValueChanged += new System.EventHandler(this.udOriginX_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnColumnLableFontColour);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.udColumnLabelMargin);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.udColumnLabelFontSize);
            this.groupBox2.Controls.Add(this.btnXAxisLabelFontColour);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.udXAxisLabelMargin);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.udXAxisLableFontSize);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.udInterval);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.udMaxValue);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.udYAxisHeight);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.udXAxisWidth);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.udAxisLineWidth);
            this.groupBox2.Controls.Add(this.cbDrawYAxis);
            this.groupBox2.Controls.Add(this.cbDrawXAxis);
            this.groupBox2.Location = new System.Drawing.Point(261, 132);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(396, 208);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Axes";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(219, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Y Axis Tick Interval:";
            // 
            // udInterval
            // 
            this.udInterval.DecimalPlaces = 1;
            this.udInterval.Location = new System.Drawing.Point(323, 98);
            this.udInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.udInterval.Name = "udInterval";
            this.udInterval.Size = new System.Drawing.Size(53, 20);
            this.udInterval.TabIndex = 21;
            this.udInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udInterval.ValueChanged += new System.EventHandler(this.udInterval_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(228, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Y Axis Max Value:";
            // 
            // udMaxValue
            // 
            this.udMaxValue.DecimalPlaces = 1;
            this.udMaxValue.Location = new System.Drawing.Point(323, 72);
            this.udMaxValue.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.udMaxValue.Name = "udMaxValue";
            this.udMaxValue.Size = new System.Drawing.Size(53, 20);
            this.udMaxValue.TabIndex = 19;
            this.udMaxValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udMaxValue.ValueChanged += new System.EventHandler(this.udMaxValue_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(247, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Y Axis Height:";
            // 
            // udYAxisHeight
            // 
            this.udYAxisHeight.DecimalPlaces = 1;
            this.udYAxisHeight.Location = new System.Drawing.Point(323, 46);
            this.udYAxisHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.udYAxisHeight.Name = "udYAxisHeight";
            this.udYAxisHeight.Size = new System.Drawing.Size(53, 20);
            this.udYAxisHeight.TabIndex = 17;
            this.udYAxisHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udYAxisHeight.ValueChanged += new System.EventHandler(this.udYAxisHeight_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "X Axis Width:";
            // 
            // udXAxisWidth
            // 
            this.udXAxisWidth.DecimalPlaces = 1;
            this.udXAxisWidth.Location = new System.Drawing.Point(136, 46);
            this.udXAxisWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.udXAxisWidth.Name = "udXAxisWidth";
            this.udXAxisWidth.Size = new System.Drawing.Size(53, 20);
            this.udXAxisWidth.TabIndex = 15;
            this.udXAxisWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udXAxisWidth.ValueChanged += new System.EventHandler(this.udXAxisWidth_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Axis Line Width:";
            // 
            // udAxisLineWidth
            // 
            this.udAxisLineWidth.DecimalPlaces = 1;
            this.udAxisLineWidth.Location = new System.Drawing.Point(136, 73);
            this.udAxisLineWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udAxisLineWidth.Name = "udAxisLineWidth";
            this.udAxisLineWidth.Size = new System.Drawing.Size(53, 20);
            this.udAxisLineWidth.TabIndex = 13;
            this.udAxisLineWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udAxisLineWidth.ValueChanged += new System.EventHandler(this.udAxisLineWidth_ValueChanged);
            // 
            // cbDrawYAxis
            // 
            this.cbDrawYAxis.AutoSize = true;
            this.cbDrawYAxis.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbDrawYAxis.Location = new System.Drawing.Point(253, 21);
            this.cbDrawYAxis.Name = "cbDrawYAxis";
            this.cbDrawYAxis.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbDrawYAxis.Size = new System.Drawing.Size(86, 17);
            this.cbDrawYAxis.TabIndex = 1;
            this.cbDrawYAxis.Text = "Draw Y Axis:";
            this.cbDrawYAxis.UseVisualStyleBackColor = true;
            this.cbDrawYAxis.CheckedChanged += new System.EventHandler(this.cbDrawYAxis_CheckedChanged);
            // 
            // cbDrawXAxis
            // 
            this.cbDrawXAxis.AutoSize = true;
            this.cbDrawXAxis.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbDrawXAxis.Location = new System.Drawing.Point(64, 21);
            this.cbDrawXAxis.Name = "cbDrawXAxis";
            this.cbDrawXAxis.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbDrawXAxis.Size = new System.Drawing.Size(86, 17);
            this.cbDrawXAxis.TabIndex = 0;
            this.cbDrawXAxis.Text = "Draw X Axis:";
            this.cbDrawXAxis.UseVisualStyleBackColor = true;
            this.cbDrawXAxis.CheckedChanged += new System.EventHandler(this.cbDrawXAxis_CheckedChanged);
            // 
            // cbNoAuto
            // 
            this.cbNoAuto.AutoSize = true;
            this.cbNoAuto.Location = new System.Drawing.Point(476, 31);
            this.cbNoAuto.Name = "cbNoAuto";
            this.cbNoAuto.Size = new System.Drawing.Size(187, 17);
            this.cbNoAuto.TabIndex = 11;
            this.cbNoAuto.Text = "Don\'t Update Settings After Import";
            this.cbNoAuto.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.udBarMargin);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.udBarWidth);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(668, 72);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(351, 54);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bars";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Width:";
            // 
            // udBarWidth
            // 
            this.udBarWidth.DecimalPlaces = 1;
            this.udBarWidth.Location = new System.Drawing.Point(57, 18);
            this.udBarWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.udBarWidth.Name = "udBarWidth";
            this.udBarWidth.Size = new System.Drawing.Size(53, 20);
            this.udBarWidth.TabIndex = 16;
            this.udBarWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udBarWidth.ValueChanged += new System.EventHandler(this.udBarWidth_ValueChanged);
            // 
            // udBarMargin
            // 
            this.udBarMargin.DecimalPlaces = 1;
            this.udBarMargin.Location = new System.Drawing.Point(288, 18);
            this.udBarMargin.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.udBarMargin.Name = "udBarMargin";
            this.udBarMargin.Size = new System.Drawing.Size(53, 20);
            this.udBarMargin.TabIndex = 18;
            this.udBarMargin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udBarMargin.ValueChanged += new System.EventHandler(this.udBarMargin_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(244, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Margin:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnTickLineColour);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.btnTickFontColour);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.udTickFontSize);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.udTickLabelMargin);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.udTickLineWidth);
            this.groupBox4.Location = new System.Drawing.Point(668, 132);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(351, 106);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ticks";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Line Width:";
            // 
            // udTickLineWidth
            // 
            this.udTickLineWidth.DecimalPlaces = 1;
            this.udTickLineWidth.Location = new System.Drawing.Point(101, 19);
            this.udTickLineWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.udTickLineWidth.Name = "udTickLineWidth";
            this.udTickLineWidth.Size = new System.Drawing.Size(53, 20);
            this.udTickLineWidth.TabIndex = 17;
            this.udTickLineWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udTickLineWidth.ValueChanged += new System.EventHandler(this.udTickLineWidth_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(212, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Label Margin:";
            // 
            // udTickLabelMargin
            // 
            this.udTickLabelMargin.DecimalPlaces = 1;
            this.udTickLabelMargin.Location = new System.Drawing.Point(288, 19);
            this.udTickLabelMargin.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.udTickLabelMargin.Name = "udTickLabelMargin";
            this.udTickLabelMargin.Size = new System.Drawing.Size(53, 20);
            this.udTickLabelMargin.TabIndex = 19;
            this.udTickLabelMargin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udTickLabelMargin.ValueChanged += new System.EventHandler(this.udTickLabelMargin_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(32, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Font Size:";
            // 
            // udTickFontSize
            // 
            this.udTickFontSize.DecimalPlaces = 1;
            this.udTickFontSize.Location = new System.Drawing.Point(101, 45);
            this.udTickFontSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.udTickFontSize.Name = "udTickFontSize";
            this.udTickFontSize.Size = new System.Drawing.Size(53, 20);
            this.udTickFontSize.TabIndex = 21;
            this.udTickFontSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udTickFontSize.ValueChanged += new System.EventHandler(this.udTickFontSize_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(22, 75);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Font Colour:";
            // 
            // btnTickFontColour
            // 
            this.btnTickFontColour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnTickFontColour.Location = new System.Drawing.Point(102, 71);
            this.btnTickFontColour.Name = "btnTickFontColour";
            this.btnTickFontColour.Size = new System.Drawing.Size(20, 20);
            this.btnTickFontColour.TabIndex = 24;
            this.btnTickFontColour.UseVisualStyleBackColor = false;
            this.btnTickFontColour.Click += new System.EventHandler(this.btnTickFontColour_Click);
            // 
            // btnTickLineColour
            // 
            this.btnTickLineColour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnTickLineColour.Location = new System.Drawing.Point(285, 43);
            this.btnTickLineColour.Name = "btnTickLineColour";
            this.btnTickLineColour.Size = new System.Drawing.Size(20, 20);
            this.btnTickLineColour.TabIndex = 26;
            this.btnTickLineColour.UseVisualStyleBackColor = false;
            this.btnTickLineColour.Click += new System.EventHandler(this.button2_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(193, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 13);
            this.label14.TabIndex = 25;
            this.label14.Text = "Tick Line Colour:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(28, 102);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(103, 13);
            this.label15.TabIndex = 26;
            this.label15.Text = "X Axis Label Margin:";
            // 
            // udXAxisLabelMargin
            // 
            this.udXAxisLabelMargin.DecimalPlaces = 1;
            this.udXAxisLabelMargin.Location = new System.Drawing.Point(136, 100);
            this.udXAxisLabelMargin.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.udXAxisLabelMargin.Name = "udXAxisLabelMargin";
            this.udXAxisLabelMargin.Size = new System.Drawing.Size(53, 20);
            this.udXAxisLabelMargin.TabIndex = 25;
            this.udXAxisLabelMargin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udXAxisLabelMargin.ValueChanged += new System.EventHandler(this.udXAxisLabelMargin_ValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 129);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(115, 13);
            this.label16.TabIndex = 24;
            this.label16.Text = "X Axis Lable Font Size:";
            // 
            // udXAxisLableFontSize
            // 
            this.udXAxisLableFontSize.DecimalPlaces = 1;
            this.udXAxisLableFontSize.Location = new System.Drawing.Point(136, 127);
            this.udXAxisLableFontSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udXAxisLableFontSize.Name = "udXAxisLableFontSize";
            this.udXAxisLableFontSize.Size = new System.Drawing.Size(53, 20);
            this.udXAxisLableFontSize.TabIndex = 23;
            this.udXAxisLableFontSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udXAxisLableFontSize.ValueChanged += new System.EventHandler(this.udXAxisLableFontSize_ValueChanged);
            // 
            // btnXAxisLabelFontColour
            // 
            this.btnXAxisLabelFontColour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnXAxisLabelFontColour.Location = new System.Drawing.Point(134, 153);
            this.btnXAxisLabelFontColour.Name = "btnXAxisLabelFontColour";
            this.btnXAxisLabelFontColour.Size = new System.Drawing.Size(20, 20);
            this.btnXAxisLabelFontColour.TabIndex = 28;
            this.btnXAxisLabelFontColour.UseVisualStyleBackColor = false;
            this.btnXAxisLabelFontColour.Click += new System.EventHandler(this.btnXAxisLabelFontColour_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(5, 157);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(125, 13);
            this.label17.TabIndex = 27;
            this.label17.Text = "X Axis Label Font Colour:";
            // 
            // btnColumnLableFontColour
            // 
            this.btnColumnLableFontColour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnColumnLableFontColour.Location = new System.Drawing.Point(321, 177);
            this.btnColumnLableFontColour.Name = "btnColumnLableFontColour";
            this.btnColumnLableFontColour.Size = new System.Drawing.Size(20, 20);
            this.btnColumnLableFontColour.TabIndex = 34;
            this.btnColumnLableFontColour.UseVisualStyleBackColor = false;
            this.btnColumnLableFontColour.Click += new System.EventHandler(this.btnColumnLableFontColour_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(189, 181);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(131, 13);
            this.label18.TabIndex = 33;
            this.label18.Text = "Column Label Font Colour:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(211, 126);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(109, 13);
            this.label19.TabIndex = 32;
            this.label19.Text = "Column Label Margin:";
            // 
            // udColumnLabelMargin
            // 
            this.udColumnLabelMargin.DecimalPlaces = 1;
            this.udColumnLabelMargin.Location = new System.Drawing.Point(323, 124);
            this.udColumnLabelMargin.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.udColumnLabelMargin.Name = "udColumnLabelMargin";
            this.udColumnLabelMargin.Size = new System.Drawing.Size(53, 20);
            this.udColumnLabelMargin.TabIndex = 31;
            this.udColumnLabelMargin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udColumnLabelMargin.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(199, 153);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(121, 13);
            this.label20.TabIndex = 30;
            this.label20.Text = "Column Lable Font Size:";
            // 
            // udColumnLabelFontSize
            // 
            this.udColumnLabelFontSize.DecimalPlaces = 1;
            this.udColumnLabelFontSize.Location = new System.Drawing.Point(323, 151);
            this.udColumnLabelFontSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udColumnLabelFontSize.Name = "udColumnLabelFontSize";
            this.udColumnLabelFontSize.Size = new System.Drawing.Size(53, 20);
            this.udColumnLabelFontSize.TabIndex = 29;
            this.udColumnLabelFontSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udColumnLabelFontSize.ValueChanged += new System.EventHandler(this.udColumnLabelFontSize_ValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1028, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // GraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 427);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.cbNoAuto);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.lblLegend);
            this.Controls.Add(this.lblFont);
            this.Controls.Add(this.btnFont);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GraphForm";
            this.Text = "Graph Form";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udOriginY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udOriginX)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMaxValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udYAxisHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udXAxisWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udAxisLineWidth)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udBarWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udBarMargin)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udTickLineWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTickLabelMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTickFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udXAxisLabelMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udXAxisLableFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udColumnLabelMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udColumnLabelFontSize)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.Label lblFont;
        private System.Windows.Forms.Label lblLegend;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown udOriginY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown udOriginX;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbDrawXAxis;
        private System.Windows.Forms.CheckBox cbDrawYAxis;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown udAxisLineWidth;
        private System.Windows.Forms.CheckBox cbNoAuto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown udYAxisHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown udXAxisWidth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown udInterval;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown udMaxValue;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown udBarMargin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown udBarWidth;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown udTickLineWidth;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown udTickLabelMargin;
        private System.Windows.Forms.Button btnTickLineColour;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnTickFontColour;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown udTickFontSize;
        private System.Windows.Forms.Button btnXAxisLabelFontColour;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown udXAxisLabelMargin;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown udXAxisLableFontSize;
        private System.Windows.Forms.Button btnColumnLableFontColour;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown udColumnLabelMargin;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown udColumnLabelFontSize;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    }
}

