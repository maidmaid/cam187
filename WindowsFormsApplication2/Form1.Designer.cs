namespace WindowsFormsApplication2
{
    partial class Form1
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.prbOriginal = new System.Windows.Forms.ProgressBar();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radWeb = new System.Windows.Forms.RadioButton();
            this.radLocal = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDetectionZoneH = new System.Windows.Forms.TextBox();
            this.txtDetectionZoneW = new System.Windows.Forms.TextBox();
            this.txtDetectionZoneY = new System.Windows.Forms.TextBox();
            this.txtDetectionZoneX = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pbxOriginal = new System.Windows.Forms.PictureBox();
            this.flowLayoutEdit = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtSizeMax = new System.Windows.Forms.TextBox();
            this.txtSizeMin = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtRotate = new System.Windows.Forms.TextBox();
            this.txtCropX = new System.Windows.Forms.TextBox();
            this.txtCropY = new System.Windows.Forms.TextBox();
            this.txtCropW = new System.Windows.Forms.TextBox();
            this.txtCropH = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxOriginal)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // prbOriginal
            // 
            this.prbOriginal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.prbOriginal.Location = new System.Drawing.Point(0, 616);
            this.prbOriginal.Name = "prbOriginal";
            this.prbOriginal.Size = new System.Drawing.Size(990, 23);
            this.prbOriginal.Step = 1;
            this.prbOriginal.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prbOriginal.TabIndex = 6;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Controls.Add(this.groupBox3);
            this.flowLayoutPanel1.Controls.Add(this.groupBox4);
            this.flowLayoutPanel1.Controls.Add(this.btnStart);
            this.flowLayoutPanel1.Controls.Add(this.btnStop);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(180, 616);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radWeb);
            this.groupBox1.Controls.Add(this.radLocal);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 66);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source";
            // 
            // radWeb
            // 
            this.radWeb.AutoSize = true;
            this.radWeb.Checked = true;
            this.radWeb.Location = new System.Drawing.Point(9, 42);
            this.radWeb.Name = "radWeb";
            this.radWeb.Size = new System.Drawing.Size(48, 17);
            this.radWeb.TabIndex = 4;
            this.radWeb.TabStop = true;
            this.radWeb.Text = "Web";
            this.radWeb.UseVisualStyleBackColor = true;
            // 
            // radLocal
            // 
            this.radLocal.AutoSize = true;
            this.radLocal.Location = new System.Drawing.Point(9, 19);
            this.radLocal.Name = "radLocal";
            this.radLocal.Size = new System.Drawing.Size(51, 17);
            this.radLocal.TabIndex = 3;
            this.radLocal.Text = "Local";
            this.radLocal.UseVisualStyleBackColor = true;
            this.radLocal.CheckedChanged += new System.EventHandler(this.radLocal_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDetectionZoneH);
            this.groupBox2.Controls.Add(this.txtDetectionZoneW);
            this.groupBox2.Controls.Add(this.txtDetectionZoneY);
            this.groupBox2.Controls.Add(this.txtDetectionZoneX);
            this.groupBox2.Location = new System.Drawing.Point(3, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(156, 76);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Zone de détection";
            // 
            // txtDetectionZoneH
            // 
            this.txtDetectionZoneH.Location = new System.Drawing.Point(81, 46);
            this.txtDetectionZoneH.Name = "txtDetectionZoneH";
            this.txtDetectionZoneH.Size = new System.Drawing.Size(65, 20);
            this.txtDetectionZoneH.TabIndex = 3;
            this.txtDetectionZoneH.Text = "120";
            // 
            // txtDetectionZoneW
            // 
            this.txtDetectionZoneW.Location = new System.Drawing.Point(10, 46);
            this.txtDetectionZoneW.Name = "txtDetectionZoneW";
            this.txtDetectionZoneW.Size = new System.Drawing.Size(65, 20);
            this.txtDetectionZoneW.TabIndex = 2;
            this.txtDetectionZoneW.Text = "180";
            // 
            // txtDetectionZoneY
            // 
            this.txtDetectionZoneY.Location = new System.Drawing.Point(81, 20);
            this.txtDetectionZoneY.Name = "txtDetectionZoneY";
            this.txtDetectionZoneY.Size = new System.Drawing.Size(65, 20);
            this.txtDetectionZoneY.TabIndex = 1;
            this.txtDetectionZoneY.Text = "375";
            // 
            // txtDetectionZoneX
            // 
            this.txtDetectionZoneX.Location = new System.Drawing.Point(10, 20);
            this.txtDetectionZoneX.Name = "txtDetectionZoneX";
            this.txtDetectionZoneX.Size = new System.Drawing.Size(65, 20);
            this.txtDetectionZoneX.TabIndex = 0;
            this.txtDetectionZoneX.Text = "400";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(3, 333);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(84, 333);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Controls.Add(this.pbxOriginal);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(180, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(810, 616);
            this.flowLayoutPanel.TabIndex = 9;
            // 
            // pbxOriginal
            // 
            this.pbxOriginal.Location = new System.Drawing.Point(3, 3);
            this.pbxOriginal.Name = "pbxOriginal";
            this.pbxOriginal.Size = new System.Drawing.Size(450, 338);
            this.pbxOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxOriginal.TabIndex = 6;
            this.pbxOriginal.TabStop = false;
            // 
            // flowLayoutEdit
            // 
            this.flowLayoutEdit.AutoScroll = true;
            this.flowLayoutEdit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutEdit.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutEdit.Location = new System.Drawing.Point(180, 493);
            this.flowLayoutEdit.Name = "flowLayoutEdit";
            this.flowLayoutEdit.Size = new System.Drawing.Size(810, 123);
            this.flowLayoutEdit.TabIndex = 10;
            this.flowLayoutEdit.WrapContents = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtSizeMax);
            this.groupBox3.Controls.Add(this.txtSizeMin);
            this.groupBox3.Location = new System.Drawing.Point(3, 157);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(156, 50);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Grandeur de l\'objet détecté";
            // 
            // txtSizeMax
            // 
            this.txtSizeMax.Location = new System.Drawing.Point(81, 20);
            this.txtSizeMax.Name = "txtSizeMax";
            this.txtSizeMax.Size = new System.Drawing.Size(65, 20);
            this.txtSizeMax.TabIndex = 1;
            this.txtSizeMax.Text = "1000";
            // 
            // txtSizeMin
            // 
            this.txtSizeMin.Location = new System.Drawing.Point(10, 20);
            this.txtSizeMin.Name = "txtSizeMin";
            this.txtSizeMin.Size = new System.Drawing.Size(65, 20);
            this.txtSizeMin.TabIndex = 0;
            this.txtSizeMin.Text = "200";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtCropH);
            this.groupBox4.Controls.Add(this.txtCropW);
            this.groupBox4.Controls.Add(this.txtCropY);
            this.groupBox4.Controls.Add(this.txtCropX);
            this.groupBox4.Controls.Add(this.txtRotate);
            this.groupBox4.Location = new System.Drawing.Point(3, 213);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(156, 114);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Actions d\'exportation";
            // 
            // txtRotate
            // 
            this.txtRotate.Location = new System.Drawing.Point(10, 20);
            this.txtRotate.Name = "txtRotate";
            this.txtRotate.Size = new System.Drawing.Size(65, 20);
            this.txtRotate.TabIndex = 0;
            this.txtRotate.Text = "55";
            // 
            // txtCropX
            // 
            this.txtCropX.Location = new System.Drawing.Point(10, 46);
            this.txtCropX.Name = "txtCropX";
            this.txtCropX.Size = new System.Drawing.Size(65, 20);
            this.txtCropX.TabIndex = 1;
            this.txtCropX.Text = "0";
            // 
            // txtCropY
            // 
            this.txtCropY.Location = new System.Drawing.Point(81, 46);
            this.txtCropY.Name = "txtCropY";
            this.txtCropY.Size = new System.Drawing.Size(65, 20);
            this.txtCropY.TabIndex = 2;
            this.txtCropY.Text = "0";
            // 
            // txtCropW
            // 
            this.txtCropW.Location = new System.Drawing.Point(10, 72);
            this.txtCropW.Name = "txtCropW";
            this.txtCropW.Size = new System.Drawing.Size(65, 20);
            this.txtCropW.TabIndex = 3;
            this.txtCropW.Text = "180";
            // 
            // txtCropH
            // 
            this.txtCropH.Location = new System.Drawing.Point(81, 72);
            this.txtCropH.Name = "txtCropH";
            this.txtCropH.Size = new System.Drawing.Size(65, 20);
            this.txtCropH.TabIndex = 4;
            this.txtCropH.Text = "120";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(990, 639);
            this.Controls.Add(this.flowLayoutEdit);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.prbOriginal);
            this.Name = "Form1";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.flowLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxOriginal)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayout;
        private System.Windows.Forms.FlowLayoutPanel flowPanelBox;
        private System.Windows.Forms.ProgressBar prbOriginal;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radWeb;
        private System.Windows.Forms.RadioButton radLocal;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.PictureBox pbxOriginal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDetectionZoneH;
        private System.Windows.Forms.TextBox txtDetectionZoneW;
        private System.Windows.Forms.TextBox txtDetectionZoneY;
        private System.Windows.Forms.TextBox txtDetectionZoneX;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutEdit;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtSizeMax;
        private System.Windows.Forms.TextBox txtSizeMin;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtCropH;
        private System.Windows.Forms.TextBox txtCropW;
        private System.Windows.Forms.TextBox txtCropY;
        private System.Windows.Forms.TextBox txtCropX;
        private System.Windows.Forms.TextBox txtRotate;

    }
}

