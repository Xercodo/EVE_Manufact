namespace EVE_Manufact
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.grpRepro = new System.Windows.Forms.GroupBox();
			this.trackRepro = new System.Windows.Forms.TrackBar();
			this.grpReproEff = new System.Windows.Forms.GroupBox();
			this.trackReproEff = new System.Windows.Forms.TrackBar();
			this.numTrit = new System.Windows.Forms.NumericUpDown();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.lblMorph = new System.Windows.Forms.Label();
			this.numMorph = new System.Windows.Forms.NumericUpDown();
			this.lblMega = new System.Windows.Forms.Label();
			this.numMega = new System.Windows.Forms.NumericUpDown();
			this.lblZyd = new System.Windows.Forms.Label();
			this.numZyd = new System.Windows.Forms.NumericUpDown();
			this.lblNocx = new System.Windows.Forms.Label();
			this.numNocx = new System.Windows.Forms.NumericUpDown();
			this.lblIso = new System.Windows.Forms.Label();
			this.numIso = new System.Windows.Forms.NumericUpDown();
			this.lblMex = new System.Windows.Forms.Label();
			this.numMex = new System.Windows.Forms.NumericUpDown();
			this.lblPyer = new System.Windows.Forms.Label();
			this.numPyer = new System.Windows.Forms.NumericUpDown();
			this.lblTrit = new System.Windows.Forms.Label();
			this.txtMain = new System.Windows.Forms.TextBox();
			this.chkCompressed = new System.Windows.Forms.CheckBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.btnRefresh = new System.Windows.Forms.Button();
			this.btnCharImport = new System.Windows.Forms.Button();
			this.comboRegions = new System.Windows.Forms.ComboBox();
			this.btnHTML = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.numBaseRepro = new System.Windows.Forms.NumericUpDown();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.openXML = new System.Windows.Forms.OpenFileDialog();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.numTax = new System.Windows.Forms.NumericUpDown();
			this.saveHTML = new System.Windows.Forms.SaveFileDialog();
			this.button1 = new System.Windows.Forms.Button();
			this.btnPaste = new System.Windows.Forms.Button();
			this.grpRepro.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackRepro)).BeginInit();
			this.grpReproEff.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackReproEff)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numTrit)).BeginInit();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numMorph)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMega)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numZyd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numNocx)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numIso)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMex)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numPyer)).BeginInit();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numBaseRepro)).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numTax)).BeginInit();
			this.SuspendLayout();
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.propertyGrid1.Location = new System.Drawing.Point(572, 12);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Categorized;
			this.propertyGrid1.Size = new System.Drawing.Size(300, 404);
			this.propertyGrid1.TabIndex = 1;
			// 
			// grpRepro
			// 
			this.grpRepro.Controls.Add(this.trackRepro);
			this.grpRepro.Location = new System.Drawing.Point(12, 12);
			this.grpRepro.Name = "grpRepro";
			this.grpRepro.Size = new System.Drawing.Size(180, 64);
			this.grpRepro.TabIndex = 3;
			this.grpRepro.TabStop = false;
			this.grpRepro.Text = "Reprocessing Level";
			// 
			// trackRepro
			// 
			this.trackRepro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.trackRepro.Dock = System.Windows.Forms.DockStyle.Top;
			this.trackRepro.Location = new System.Drawing.Point(3, 16);
			this.trackRepro.Maximum = 5;
			this.trackRepro.Name = "trackRepro";
			this.trackRepro.Size = new System.Drawing.Size(174, 45);
			this.trackRepro.TabIndex = 12;
			this.trackRepro.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.trackRepro.ValueChanged += new System.EventHandler(this.trackRepro_ValueChanged);
			// 
			// grpReproEff
			// 
			this.grpReproEff.Controls.Add(this.trackReproEff);
			this.grpReproEff.Location = new System.Drawing.Point(12, 82);
			this.grpReproEff.Name = "grpReproEff";
			this.grpReproEff.Size = new System.Drawing.Size(183, 65);
			this.grpReproEff.TabIndex = 4;
			this.grpReproEff.TabStop = false;
			this.grpReproEff.Text = "Reprocessing Efficiency Level";
			// 
			// trackReproEff
			// 
			this.trackReproEff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.trackReproEff.Dock = System.Windows.Forms.DockStyle.Top;
			this.trackReproEff.Location = new System.Drawing.Point(3, 16);
			this.trackReproEff.Maximum = 5;
			this.trackReproEff.Name = "trackReproEff";
			this.trackReproEff.Size = new System.Drawing.Size(177, 45);
			this.trackReproEff.TabIndex = 13;
			this.trackReproEff.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.trackReproEff.ValueChanged += new System.EventHandler(this.trackReproEff_ValueChanged);
			// 
			// numTrit
			// 
			this.numTrit.Location = new System.Drawing.Point(63, 19);
			this.numTrit.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
			this.numTrit.Name = "numTrit";
			this.numTrit.Size = new System.Drawing.Size(120, 20);
			this.numTrit.TabIndex = 5;
			this.numTrit.ValueChanged += new System.EventHandler(this.ValueChanged);
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.lblMorph);
			this.groupBox3.Controls.Add(this.numMorph);
			this.groupBox3.Controls.Add(this.lblMega);
			this.groupBox3.Controls.Add(this.numMega);
			this.groupBox3.Controls.Add(this.lblZyd);
			this.groupBox3.Controls.Add(this.numZyd);
			this.groupBox3.Controls.Add(this.lblNocx);
			this.groupBox3.Controls.Add(this.numNocx);
			this.groupBox3.Controls.Add(this.lblIso);
			this.groupBox3.Controls.Add(this.numIso);
			this.groupBox3.Controls.Add(this.lblMex);
			this.groupBox3.Controls.Add(this.numMex);
			this.groupBox3.Controls.Add(this.lblPyer);
			this.groupBox3.Controls.Add(this.numPyer);
			this.groupBox3.Controls.Add(this.lblTrit);
			this.groupBox3.Controls.Add(this.numTrit);
			this.groupBox3.Location = new System.Drawing.Point(12, 310);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(554, 106);
			this.groupBox3.TabIndex = 6;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Required Minerals";
			// 
			// lblMorph
			// 
			this.lblMorph.AutoSize = true;
			this.lblMorph.Location = new System.Drawing.Point(375, 52);
			this.lblMorph.Name = "lblMorph";
			this.lblMorph.Size = new System.Drawing.Size(48, 13);
			this.lblMorph.TabIndex = 20;
			this.lblMorph.Text = "Morphite";
			// 
			// numMorph
			// 
			this.numMorph.Location = new System.Drawing.Point(429, 45);
			this.numMorph.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
			this.numMorph.Name = "numMorph";
			this.numMorph.Size = new System.Drawing.Size(120, 20);
			this.numMorph.TabIndex = 19;
			this.numMorph.ValueChanged += new System.EventHandler(this.ValueChanged);
			// 
			// lblMega
			// 
			this.lblMega.AutoSize = true;
			this.lblMega.Location = new System.Drawing.Point(369, 26);
			this.lblMega.Name = "lblMega";
			this.lblMega.Size = new System.Drawing.Size(54, 13);
			this.lblMega.TabIndex = 18;
			this.lblMega.Text = "Megacyte";
			// 
			// numMega
			// 
			this.numMega.Location = new System.Drawing.Point(429, 19);
			this.numMega.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
			this.numMega.Name = "numMega";
			this.numMega.Size = new System.Drawing.Size(120, 20);
			this.numMega.TabIndex = 17;
			this.numMega.ValueChanged += new System.EventHandler(this.ValueChanged);
			// 
			// lblZyd
			// 
			this.lblZyd.AutoSize = true;
			this.lblZyd.Location = new System.Drawing.Point(195, 78);
			this.lblZyd.Name = "lblZyd";
			this.lblZyd.Size = new System.Drawing.Size(42, 13);
			this.lblZyd.TabIndex = 16;
			this.lblZyd.Text = "Zydrine";
			// 
			// numZyd
			// 
			this.numZyd.Location = new System.Drawing.Point(243, 71);
			this.numZyd.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
			this.numZyd.Name = "numZyd";
			this.numZyd.Size = new System.Drawing.Size(120, 20);
			this.numZyd.TabIndex = 15;
			this.numZyd.ValueChanged += new System.EventHandler(this.ValueChanged);
			// 
			// lblNocx
			// 
			this.lblNocx.AutoSize = true;
			this.lblNocx.Location = new System.Drawing.Point(189, 52);
			this.lblNocx.Name = "lblNocx";
			this.lblNocx.Size = new System.Drawing.Size(48, 13);
			this.lblNocx.TabIndex = 14;
			this.lblNocx.Text = "Nocxium";
			// 
			// numNocx
			// 
			this.numNocx.Location = new System.Drawing.Point(243, 45);
			this.numNocx.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
			this.numNocx.Name = "numNocx";
			this.numNocx.Size = new System.Drawing.Size(120, 20);
			this.numNocx.TabIndex = 13;
			this.numNocx.ValueChanged += new System.EventHandler(this.ValueChanged);
			// 
			// lblIso
			// 
			this.lblIso.AutoSize = true;
			this.lblIso.Location = new System.Drawing.Point(198, 26);
			this.lblIso.Name = "lblIso";
			this.lblIso.Size = new System.Drawing.Size(39, 13);
			this.lblIso.TabIndex = 12;
			this.lblIso.Text = "Isogen";
			// 
			// numIso
			// 
			this.numIso.Location = new System.Drawing.Point(243, 19);
			this.numIso.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
			this.numIso.Name = "numIso";
			this.numIso.Size = new System.Drawing.Size(120, 20);
			this.numIso.TabIndex = 11;
			this.numIso.ValueChanged += new System.EventHandler(this.ValueChanged);
			// 
			// lblMex
			// 
			this.lblMex.AutoSize = true;
			this.lblMex.Location = new System.Drawing.Point(8, 78);
			this.lblMex.Name = "lblMex";
			this.lblMex.Size = new System.Drawing.Size(49, 13);
			this.lblMex.TabIndex = 10;
			this.lblMex.Text = "Mexallon";
			// 
			// numMex
			// 
			this.numMex.Location = new System.Drawing.Point(63, 71);
			this.numMex.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
			this.numMex.Name = "numMex";
			this.numMex.Size = new System.Drawing.Size(120, 20);
			this.numMex.TabIndex = 9;
			this.numMex.ValueChanged += new System.EventHandler(this.ValueChanged);
			// 
			// lblPyer
			// 
			this.lblPyer.AutoSize = true;
			this.lblPyer.Location = new System.Drawing.Point(18, 52);
			this.lblPyer.Name = "lblPyer";
			this.lblPyer.Size = new System.Drawing.Size(39, 13);
			this.lblPyer.TabIndex = 8;
			this.lblPyer.Text = "Pyerite";
			// 
			// numPyer
			// 
			this.numPyer.Location = new System.Drawing.Point(63, 45);
			this.numPyer.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
			this.numPyer.Name = "numPyer";
			this.numPyer.Size = new System.Drawing.Size(120, 20);
			this.numPyer.TabIndex = 7;
			this.numPyer.ValueChanged += new System.EventHandler(this.ValueChanged);
			// 
			// lblTrit
			// 
			this.lblTrit.AutoSize = true;
			this.lblTrit.Location = new System.Drawing.Point(7, 26);
			this.lblTrit.Name = "lblTrit";
			this.lblTrit.Size = new System.Drawing.Size(50, 13);
			this.lblTrit.TabIndex = 6;
			this.lblTrit.Text = "Tritanium";
			// 
			// txtMain
			// 
			this.txtMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtMain.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMain.Location = new System.Drawing.Point(207, 12);
			this.txtMain.Multiline = true;
			this.txtMain.Name = "txtMain";
			this.txtMain.ReadOnly = true;
			this.txtMain.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtMain.Size = new System.Drawing.Size(359, 292);
			this.txtMain.TabIndex = 7;
			this.txtMain.WordWrap = false;
			// 
			// chkCompressed
			// 
			this.chkCompressed.AutoSize = true;
			this.chkCompressed.Location = new System.Drawing.Point(12, 269);
			this.chkCompressed.Name = "chkCompressed";
			this.chkCompressed.Size = new System.Drawing.Size(109, 17);
			this.chkCompressed.TabIndex = 8;
			this.chkCompressed.Text = "Compressed Ores";
			this.chkCompressed.UseVisualStyleBackColor = true;
			this.chkCompressed.CheckedChanged += new System.EventHandler(this.chkCompressed_CheckedChanged);
			// 
			// btnRefresh
			// 
			this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRefresh.BackgroundImage")));
			this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnRefresh.FlatAppearance.BorderSize = 0;
			this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRefresh.Location = new System.Drawing.Point(652, 12);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(24, 24);
			this.btnRefresh.TabIndex = 10;
			this.toolTip1.SetToolTip(this.btnRefresh, "Refresh Market Data");
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// btnCharImport
			// 
			this.btnCharImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCharImport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCharImport.BackgroundImage")));
			this.btnCharImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnCharImport.FlatAppearance.BorderSize = 0;
			this.btnCharImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCharImport.Location = new System.Drawing.Point(682, 12);
			this.btnCharImport.Name = "btnCharImport";
			this.btnCharImport.Size = new System.Drawing.Size(24, 24);
			this.btnCharImport.TabIndex = 12;
			this.toolTip1.SetToolTip(this.btnCharImport, "Import character data from EVEMon");
			this.btnCharImport.UseVisualStyleBackColor = true;
			this.btnCharImport.Click += new System.EventHandler(this.btnCharImport_Click);
			// 
			// comboRegions
			// 
			this.comboRegions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboRegions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboRegions.FormattingEnabled = true;
			this.comboRegions.Location = new System.Drawing.Point(742, 15);
			this.comboRegions.Name = "comboRegions";
			this.comboRegions.Size = new System.Drawing.Size(130, 21);
			this.comboRegions.TabIndex = 13;
			this.toolTip1.SetToolTip(this.comboRegions, "Select region to get market data from");
			// 
			// btnHTML
			// 
			this.btnHTML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnHTML.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHTML.BackgroundImage")));
			this.btnHTML.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnHTML.FlatAppearance.BorderSize = 0;
			this.btnHTML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnHTML.Location = new System.Drawing.Point(712, 12);
			this.btnHTML.Name = "btnHTML";
			this.btnHTML.Size = new System.Drawing.Size(24, 24);
			this.btnHTML.TabIndex = 14;
			this.toolTip1.SetToolTip(this.btnHTML, "Export shopping list for IGB");
			this.btnHTML.UseVisualStyleBackColor = true;
			this.btnHTML.Click += new System.EventHandler(this.btnHTML_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.numBaseRepro);
			this.groupBox4.Location = new System.Drawing.Point(12, 153);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(189, 52);
			this.groupBox4.TabIndex = 5;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Base Refine";
			// 
			// numBaseRepro
			// 
			this.numBaseRepro.Location = new System.Drawing.Point(6, 19);
			this.numBaseRepro.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.numBaseRepro.Name = "numBaseRepro";
			this.numBaseRepro.Size = new System.Drawing.Size(171, 20);
			this.numBaseRepro.TabIndex = 2;
			this.numBaseRepro.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.numBaseRepro.ValueChanged += new System.EventHandler(this.numBaseRepro_ValueChanged);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 421);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(884, 22);
			this.statusStrip1.TabIndex = 11;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripProgressBar1
			// 
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			this.toolStripProgressBar1.Size = new System.Drawing.Size(500, 16);
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(19, 17);
			this.toolStripStatusLabel1.Text = "    ";
			// 
			// openXML
			// 
			this.openXML.Filter = "Character Data|*.xml";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.numTax);
			this.groupBox1.Location = new System.Drawing.Point(12, 211);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(189, 52);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Station Tax (%)";
			// 
			// numTax
			// 
			this.numTax.Location = new System.Drawing.Point(6, 19);
			this.numTax.Name = "numTax";
			this.numTax.Size = new System.Drawing.Size(171, 20);
			this.numTax.TabIndex = 2;
			this.numTax.ValueChanged += new System.EventHandler(this.numTax_ValueChanged);
			// 
			// saveHTML
			// 
			this.saveHTML.Filter = "Web Page|*.html";
			// 
			// button1
			// 
			this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
			this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(177, 269);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(24, 24);
			this.button1.TabIndex = 15;
			this.toolTip1.SetToolTip(this.button1, "Calculate");
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnPaste
			// 
			this.btnPaste.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnPaste.Enabled = false;
			this.btnPaste.FlatAppearance.BorderSize = 0;
			this.btnPaste.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPaste.Image = ((System.Drawing.Image)(resources.GetObject("btnPaste.Image")));
			this.btnPaste.Location = new System.Drawing.Point(147, 269);
			this.btnPaste.Name = "btnPaste";
			this.btnPaste.Size = new System.Drawing.Size(24, 24);
			this.btnPaste.TabIndex = 16;
			this.toolTip1.SetToolTip(this.btnPaste, "Import data from Clipboard");
			this.btnPaste.UseVisualStyleBackColor = true;
			this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 443);
			this.Controls.Add(this.btnPaste);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnHTML);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.comboRegions);
			this.Controls.Add(this.btnCharImport);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.btnRefresh);
			this.Controls.Add(this.chkCompressed);
			this.Controls.Add(this.txtMain);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.grpReproEff);
			this.Controls.Add(this.grpRepro);
			this.Controls.Add(this.propertyGrid1);
			this.MinimumSize = new System.Drawing.Size(900, 39);
			this.Name = "MainForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Manufacturing Ore Calculator";
			this.Activated += new System.EventHandler(this.MainForm_Activated);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.grpRepro.ResumeLayout(false);
			this.grpRepro.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackRepro)).EndInit();
			this.grpReproEff.ResumeLayout(false);
			this.grpReproEff.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackReproEff)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numTrit)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numMorph)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMega)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numZyd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numNocx)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numIso)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMex)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numPyer)).EndInit();
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numBaseRepro)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numTax)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.GroupBox grpRepro;
		private System.Windows.Forms.GroupBox grpReproEff;
		private System.Windows.Forms.NumericUpDown numTrit;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label lblMorph;
		private System.Windows.Forms.NumericUpDown numMorph;
		private System.Windows.Forms.Label lblMega;
		private System.Windows.Forms.NumericUpDown numMega;
		private System.Windows.Forms.Label lblZyd;
		private System.Windows.Forms.NumericUpDown numZyd;
		private System.Windows.Forms.Label lblNocx;
		private System.Windows.Forms.NumericUpDown numNocx;
		private System.Windows.Forms.Label lblIso;
		private System.Windows.Forms.NumericUpDown numIso;
		private System.Windows.Forms.Label lblMex;
		private System.Windows.Forms.NumericUpDown numMex;
		private System.Windows.Forms.Label lblPyer;
		private System.Windows.Forms.NumericUpDown numPyer;
		private System.Windows.Forms.Label lblTrit;
		private System.Windows.Forms.TextBox txtMain;
		private System.Windows.Forms.CheckBox chkCompressed;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.TrackBar trackRepro;
		private System.Windows.Forms.TrackBar trackReproEff;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.NumericUpDown numBaseRepro;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.Button btnCharImport;
		private System.Windows.Forms.OpenFileDialog openXML;
		private System.Windows.Forms.ComboBox comboRegions;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.NumericUpDown numTax;
		private System.Windows.Forms.Button btnHTML;
		private System.Windows.Forms.SaveFileDialog saveHTML;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btnPaste;
	}
}

