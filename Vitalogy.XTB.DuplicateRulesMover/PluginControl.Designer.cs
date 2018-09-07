namespace Vitalogy.XTB.DuplicateRulesMover
{
    partial class PluginControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginControl));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbLoadDupeRules = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbTransferDupeRules = new System.Windows.Forms.ToolStripButton();
            this.grpSourceSolution = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSource = new System.Windows.Forms.Label();
            this.lvDedupeRules = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSelectTarget = new System.Windows.Forms.Button();
            this.grpTargetSelection = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblTarget = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.gbLogs = new System.Windows.Forms.GroupBox();
            this.lbLogs = new System.Windows.Forms.ListBox();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1.SuspendLayout();
            this.grpSourceSolution.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpTargetSelection.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.gbLogs.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLoadDupeRules,
            this.toolStripSeparator2,
            this.tsbTransferDupeRules});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbLoadDupeRules
            // 
            this.tsbLoadDupeRules.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoadDupeRules.Image")));
            this.tsbLoadDupeRules.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoadDupeRules.Name = "tsbLoadDupeRules";
            this.tsbLoadDupeRules.Size = new System.Drawing.Size(128, 22);
            this.tsbLoadDupeRules.Text = "Load Dedupe Rules";
            this.tsbLoadDupeRules.Click += new System.EventHandler(this.TsbLoadDedupeRulesClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbTransferDupeRules
            // 
            this.tsbTransferDupeRules.Image = ((System.Drawing.Image)(resources.GetObject("tsbTransferDupeRules.Image")));
            this.tsbTransferDupeRules.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTransferDupeRules.Name = "tsbTransferDupeRules";
            this.tsbTransferDupeRules.Size = new System.Drawing.Size(152, 22);
            this.tsbTransferDupeRules.Text = "Transfer Dedupe Rule(s)";
            this.tsbTransferDupeRules.Click += new System.EventHandler(this.TsbTransferDupeRulesClick);
            // 
            // grpSourceSolution
            // 
            this.grpSourceSolution.BackColor = System.Drawing.SystemColors.Control;
            this.grpSourceSolution.Controls.Add(this.panel1);
            this.grpSourceSolution.Controls.Add(this.label1);
            this.grpSourceSolution.Controls.Add(this.lblSource);
            this.grpSourceSolution.Controls.Add(this.lvDedupeRules);
            this.grpSourceSolution.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSourceSolution.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpSourceSolution.Location = new System.Drawing.Point(0, 25);
            this.grpSourceSolution.Name = "grpSourceSolution";
            this.grpSourceSolution.Size = new System.Drawing.Size(800, 385);
            this.grpSourceSolution.TabIndex = 1;
            this.grpSourceSolution.TabStop = false;
            this.grpSourceSolution.Text = "Duplicate Detection Rules";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(6, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(785, 23);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(26, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(410, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Click on \"Load Dedupe Rules\" to display and select dedupe rule(s) to transfer";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(3, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Source environment";
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblSource.ForeColor = System.Drawing.Color.Red;
            this.lblSource.Location = new System.Drawing.Point(136, 49);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(89, 13);
            this.lblSource.TabIndex = 3;
            this.lblSource.Text = "Not selected yet";
            // 
            // lvDedupeRules
            // 
            this.lvDedupeRules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDedupeRules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvDedupeRules.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lvDedupeRules.FullRowSelect = true;
            this.lvDedupeRules.HideSelection = false;
            this.lvDedupeRules.Location = new System.Drawing.Point(6, 65);
            this.lvDedupeRules.Name = "lvDedupeRules";
            this.lvDedupeRules.ShowItemToolTips = true;
            this.lvDedupeRules.Size = new System.Drawing.Size(785, 311);
            this.lvDedupeRules.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvDedupeRules.TabIndex = 2;
            this.lvDedupeRules.UseCompatibleStateImageBehavior = false;
            this.lvDedupeRules.View = System.Windows.Forms.View.Details;
            this.lvDedupeRules.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvDedupeRules_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 400;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Base Entity";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Matching Entity";
            this.columnHeader3.Width = 150;
            // 
            // btnSelectTarget
            // 
            this.btnSelectTarget.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnSelectTarget.Location = new System.Drawing.Point(6, 49);
            this.btnSelectTarget.Name = "btnSelectTarget";
            this.btnSelectTarget.Size = new System.Drawing.Size(111, 25);
            this.btnSelectTarget.TabIndex = 3;
            this.btnSelectTarget.Text = "Select target";
            this.btnSelectTarget.UseVisualStyleBackColor = true;
            this.btnSelectTarget.Click += new System.EventHandler(this.BtnSelectTargetClick);
            // 
            // grpTargetSelection
            // 
            this.grpTargetSelection.Controls.Add(this.panel2);
            this.grpTargetSelection.Controls.Add(this.lblTarget);
            this.grpTargetSelection.Controls.Add(this.btnSelectTarget);
            this.grpTargetSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTargetSelection.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTargetSelection.Location = new System.Drawing.Point(0, 410);
            this.grpTargetSelection.Name = "grpTargetSelection";
            this.grpTargetSelection.Size = new System.Drawing.Size(800, 82);
            this.grpTargetSelection.TabIndex = 4;
            this.grpTargetSelection.TabStop = false;
            this.grpTargetSelection.Text = "Target environment";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Info;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(6, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(785, 23);
            this.panel2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(26, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(497, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Click on \"Select target\" to select the organisation where to import the selected " +
    "dedupe rule(s)\r\n";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblTarget.ForeColor = System.Drawing.Color.Red;
            this.lblTarget.Location = new System.Drawing.Point(136, 55);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(89, 13);
            this.lblTarget.TabIndex = 4;
            this.lblTarget.Text = "Not selected yet";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "DamSimIcon.png");
            // 
            // gbLogs
            // 
            this.gbLogs.Controls.Add(this.lbLogs);
            this.gbLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbLogs.Location = new System.Drawing.Point(0, 492);
            this.gbLogs.Margin = new System.Windows.Forms.Padding(2);
            this.gbLogs.Name = "gbLogs";
            this.gbLogs.Padding = new System.Windows.Forms.Padding(2);
            this.gbLogs.Size = new System.Drawing.Size(800, 88);
            this.gbLogs.TabIndex = 5;
            this.gbLogs.TabStop = false;
            this.gbLogs.Text = "Logs";
            // 
            // lbLogs
            // 
            this.lbLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLogs.FormattingEnabled = true;
            this.lbLogs.Location = new System.Drawing.Point(2, 15);
            this.lbLogs.Margin = new System.Windows.Forms.Padding(2);
            this.lbLogs.Name = "lbLogs";
            this.lbLogs.Size = new System.Drawing.Size(796, 71);
            this.lbLogs.TabIndex = 0;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Status";
            // 
            // PluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbLogs);
            this.Controls.Add(this.grpTargetSelection);
            this.Controls.Add(this.grpSourceSolution);
            this.Controls.Add(this.toolStrip1);
            this.Name = "PluginControl";
            this.Size = new System.Drawing.Size(800, 580);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.grpSourceSolution.ResumeLayout(false);
            this.grpSourceSolution.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpTargetSelection.ResumeLayout(false);
            this.grpTargetSelection.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.gbLogs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.GroupBox grpSourceSolution;
        private System.Windows.Forms.ListView lvDedupeRules;
        private System.Windows.Forms.Button btnSelectTarget;
        private System.Windows.Forms.GroupBox grpTargetSelection;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton tsbLoadDupeRules;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbTransferDupeRules;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox gbLogs;
        private System.Windows.Forms.ListBox lbLogs;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}
