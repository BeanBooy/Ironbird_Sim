namespace EurofighterCockpit
{
    partial class ConfigSettings
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
            this.screenIndicator = new System.Windows.Forms.CheckBox();
            this.tb_videoFilePath = new System.Windows.Forms.TextBox();
            this.btn_browseVideoFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.tlp_infotainmentSub = new System.Windows.Forms.TableLayoutPanel();
            this.tlp_infotainment = new System.Windows.Forms.TableLayoutPanel();
            this.tlp_videoPlayer = new System.Windows.Forms.TableLayoutPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_infotainmentSub = new System.Windows.Forms.Button();
            this.btn_infotainment = new System.Windows.Forms.Button();
            this.btn_videoPlayer = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tb_logs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.l_joystickY = new System.Windows.Forms.Label();
            this.l_joystickX = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cb_trigger = new System.Windows.Forms.CheckBox();
            this.cb_sound = new System.Windows.Forms.CheckBox();
            this.cb_airbrake = new System.Windows.Forms.CheckBox();
            this.cb_rudderL = new System.Windows.Forms.CheckBox();
            this.cb_rudderM = new System.Windows.Forms.CheckBox();
            this.cb_rudderR = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel8.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // screenIndicator
            // 
            this.screenIndicator.AutoSize = true;
            this.screenIndicator.Location = new System.Drawing.Point(13, 47);
            this.screenIndicator.Margin = new System.Windows.Forms.Padding(2);
            this.screenIndicator.Name = "screenIndicator";
            this.screenIndicator.Size = new System.Drawing.Size(129, 17);
            this.screenIndicator.TabIndex = 0;
            this.screenIndicator.Text = "show screen indicator";
            this.screenIndicator.UseVisualStyleBackColor = true;
            this.screenIndicator.CheckedChanged += new System.EventHandler(this.screenIndicator_CheckedChanged);
            // 
            // tb_videoFilePath
            // 
            this.tb_videoFilePath.Location = new System.Drawing.Point(11, 51);
            this.tb_videoFilePath.Margin = new System.Windows.Forms.Padding(2);
            this.tb_videoFilePath.Name = "tb_videoFilePath";
            this.tb_videoFilePath.ReadOnly = true;
            this.tb_videoFilePath.Size = new System.Drawing.Size(276, 20);
            this.tb_videoFilePath.TabIndex = 1;
            // 
            // btn_browseVideoFile
            // 
            this.btn_browseVideoFile.Location = new System.Drawing.Point(298, 51);
            this.btn_browseVideoFile.Margin = new System.Windows.Forms.Padding(2);
            this.btn_browseVideoFile.Name = "btn_browseVideoFile";
            this.btn_browseVideoFile.Size = new System.Drawing.Size(50, 22);
            this.btn_browseVideoFile.TabIndex = 2;
            this.btn_browseVideoFile.Text = "browse";
            this.btn_browseVideoFile.UseVisualStyleBackColor = true;
            this.btn_browseVideoFile.Click += new System.EventHandler(this.btn_browseVideoFile_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(563, 37);
            this.label2.TabIndex = 4;
            this.label2.Text = "Displays";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 3;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel8.Controls.Add(this.tlp_infotainmentSub, 2, 3);
            this.tableLayoutPanel8.Controls.Add(this.tlp_infotainment, 1, 3);
            this.tableLayoutPanel8.Controls.Add(this.tlp_videoPlayer, 0, 3);
            this.tableLayoutPanel8.Controls.Add(this.label14, 2, 2);
            this.tableLayoutPanel8.Controls.Add(this.label13, 1, 2);
            this.tableLayoutPanel8.Controls.Add(this.label12, 0, 2);
            this.tableLayoutPanel8.Controls.Add(this.btn_infotainmentSub, 2, 1);
            this.tableLayoutPanel8.Controls.Add(this.btn_infotainment, 1, 1);
            this.tableLayoutPanel8.Controls.Add(this.btn_videoPlayer, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.label11, 2, 0);
            this.tableLayoutPanel8.Controls.Add(this.label10, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 73);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 4;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.60684F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.39316F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(563, 176);
            this.tableLayoutPanel8.TabIndex = 27;
            // 
            // tlp_infotainmentSub
            // 
            this.tlp_infotainmentSub.BackColor = System.Drawing.Color.Transparent;
            this.tlp_infotainmentSub.ColumnCount = 3;
            this.tlp_infotainmentSub.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_infotainmentSub.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_infotainmentSub.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_infotainmentSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_infotainmentSub.Location = new System.Drawing.Point(387, 118);
            this.tlp_infotainmentSub.Margin = new System.Windows.Forms.Padding(13, 0, 13, 0);
            this.tlp_infotainmentSub.Name = "tlp_infotainmentSub";
            this.tlp_infotainmentSub.RowCount = 1;
            this.tlp_infotainmentSub.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_infotainmentSub.Size = new System.Drawing.Size(163, 58);
            this.tlp_infotainmentSub.TabIndex = 33;
            // 
            // tlp_infotainment
            // 
            this.tlp_infotainment.BackColor = System.Drawing.Color.Transparent;
            this.tlp_infotainment.ColumnCount = 3;
            this.tlp_infotainment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_infotainment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_infotainment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_infotainment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_infotainment.Location = new System.Drawing.Point(200, 118);
            this.tlp_infotainment.Margin = new System.Windows.Forms.Padding(13, 0, 13, 0);
            this.tlp_infotainment.Name = "tlp_infotainment";
            this.tlp_infotainment.RowCount = 1;
            this.tlp_infotainment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_infotainment.Size = new System.Drawing.Size(161, 58);
            this.tlp_infotainment.TabIndex = 32;
            // 
            // tlp_videoPlayer
            // 
            this.tlp_videoPlayer.BackColor = System.Drawing.Color.Transparent;
            this.tlp_videoPlayer.ColumnCount = 3;
            this.tlp_videoPlayer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_videoPlayer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_videoPlayer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_videoPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_videoPlayer.Location = new System.Drawing.Point(13, 118);
            this.tlp_videoPlayer.Margin = new System.Windows.Forms.Padding(13, 0, 13, 0);
            this.tlp_videoPlayer.Name = "tlp_videoPlayer";
            this.tlp_videoPlayer.RowCount = 1;
            this.tlp_videoPlayer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_videoPlayer.Size = new System.Drawing.Size(161, 58);
            this.tlp_videoPlayer.TabIndex = 31;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(375, 87);
            this.label14.Margin = new System.Windows.Forms.Padding(1);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(187, 30);
            this.label14.TabIndex = 30;
            this.label14.Text = "Screen";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(188, 87);
            this.label13.Margin = new System.Windows.Forms.Padding(1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(185, 30);
            this.label13.TabIndex = 29;
            this.label13.Text = "Screen";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(1, 87);
            this.label12.Margin = new System.Windows.Forms.Padding(1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(185, 30);
            this.label12.TabIndex = 28;
            this.label12.Text = "Screen";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_infotainmentSub
            // 
            this.btn_infotainmentSub.BackColor = System.Drawing.Color.Crimson;
            this.btn_infotainmentSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_infotainmentSub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_infotainmentSub.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_infotainmentSub.Location = new System.Drawing.Point(387, 45);
            this.btn_infotainmentSub.Margin = new System.Windows.Forms.Padding(13);
            this.btn_infotainmentSub.Name = "btn_infotainmentSub";
            this.btn_infotainmentSub.Size = new System.Drawing.Size(163, 28);
            this.btn_infotainmentSub.TabIndex = 27;
            this.btn_infotainmentSub.Text = "OFF";
            this.btn_infotainmentSub.UseVisualStyleBackColor = false;
            this.btn_infotainmentSub.Click += new System.EventHandler(this.anyWindowToggle_Click);
            // 
            // btn_infotainment
            // 
            this.btn_infotainment.BackColor = System.Drawing.Color.Crimson;
            this.btn_infotainment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_infotainment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_infotainment.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_infotainment.Location = new System.Drawing.Point(200, 45);
            this.btn_infotainment.Margin = new System.Windows.Forms.Padding(13);
            this.btn_infotainment.Name = "btn_infotainment";
            this.btn_infotainment.Size = new System.Drawing.Size(161, 28);
            this.btn_infotainment.TabIndex = 26;
            this.btn_infotainment.Text = "OFF";
            this.btn_infotainment.UseVisualStyleBackColor = false;
            this.btn_infotainment.Click += new System.EventHandler(this.anyWindowToggle_Click);
            // 
            // btn_videoPlayer
            // 
            this.btn_videoPlayer.BackColor = System.Drawing.Color.Crimson;
            this.btn_videoPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_videoPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_videoPlayer.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_videoPlayer.Location = new System.Drawing.Point(13, 45);
            this.btn_videoPlayer.Margin = new System.Windows.Forms.Padding(13);
            this.btn_videoPlayer.Name = "btn_videoPlayer";
            this.btn_videoPlayer.Size = new System.Drawing.Size(161, 28);
            this.btn_videoPlayer.TabIndex = 25;
            this.btn_videoPlayer.Text = "OFF";
            this.btn_videoPlayer.UseVisualStyleBackColor = false;
            this.btn_videoPlayer.Click += new System.EventHandler(this.anyWindowToggle_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(375, 1);
            this.label11.Margin = new System.Windows.Forms.Padding(1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(187, 30);
            this.label11.TabIndex = 18;
            this.label11.Text = "Infotainment 2";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(188, 1);
            this.label10.Margin = new System.Windows.Forms.Padding(1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(185, 30);
            this.label10.TabIndex = 17;
            this.label10.Text = "Infotainment 1";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1, 1);
            this.label9.Margin = new System.Windows.Forms.Padding(1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(185, 30);
            this.label9.TabIndex = 16;
            this.label9.Text = "Video Player";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tableLayoutPanel8);
            this.panel1.Controls.Add(this.screenIndicator);
            this.panel1.Location = new System.Drawing.Point(13, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(563, 264);
            this.panel1.TabIndex = 28;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Location = new System.Drawing.Point(13, 475);
            this.panel2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(361, 135);
            this.panel2.TabIndex = 29;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.btn_browseVideoFile);
            this.panel3.Controls.Add(this.tb_videoFilePath);
            this.panel3.Location = new System.Drawing.Point(13, 289);
            this.panel3.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(361, 174);
            this.panel3.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(361, 37);
            this.label3.TabIndex = 28;
            this.label3.Text = "Video";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gray;
            this.panel4.Controls.Add(this.tb_logs);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(388, 289);
            this.panel4.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(660, 382);
            this.panel4.TabIndex = 30;
            // 
            // tb_logs
            // 
            this.tb_logs.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_logs.Location = new System.Drawing.Point(15, 60);
            this.tb_logs.Margin = new System.Windows.Forms.Padding(2);
            this.tb_logs.Multiline = true;
            this.tb_logs.Name = "tb_logs";
            this.tb_logs.ReadOnly = true;
            this.tb_logs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_logs.Size = new System.Drawing.Size(633, 254);
            this.tb_logs.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(657, 37);
            this.label1.TabIndex = 28;
            this.label1.Text = "Logs";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gray;
            this.panel5.Controls.Add(this.cb_rudderR);
            this.panel5.Controls.Add(this.cb_rudderM);
            this.panel5.Controls.Add(this.cb_rudderL);
            this.panel5.Controls.Add(this.cb_airbrake);
            this.panel5.Controls.Add(this.cb_sound);
            this.panel5.Controls.Add(this.cb_trigger);
            this.panel5.Controls.Add(this.progressBar1);
            this.panel5.Controls.Add(this.l_joystickY);
            this.panel5.Controls.Add(this.l_joystickX);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(590, 12);
            this.panel5.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(486, 264);
            this.panel5.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Gray;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(591, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(484, 37);
            this.label4.TabIndex = 28;
            this.label4.Text = "Controller";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "joystickX";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(27, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "joystickY";
            // 
            // l_joystickY
            // 
            this.l_joystickY.AutoSize = true;
            this.l_joystickY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_joystickY.Location = new System.Drawing.Point(93, 100);
            this.l_joystickY.Name = "l_joystickY";
            this.l_joystickY.Size = new System.Drawing.Size(28, 16);
            this.l_joystickY.TabIndex = 3;
            this.l_joystickY.Text = "000";
            // 
            // l_joystickX
            // 
            this.l_joystickX.AutoSize = true;
            this.l_joystickX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_joystickX.Location = new System.Drawing.Point(93, 73);
            this.l_joystickX.Name = "l_joystickX";
            this.l_joystickX.Size = new System.Drawing.Size(28, 16);
            this.l_joystickX.TabIndex = 2;
            this.l_joystickX.Text = "000";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(195, 81);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(125, 23);
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Value = 40;
            // 
            // cb_trigger
            // 
            this.cb_trigger.AutoSize = true;
            this.cb_trigger.Location = new System.Drawing.Point(41, 160);
            this.cb_trigger.Name = "cb_trigger";
            this.cb_trigger.Size = new System.Drawing.Size(55, 17);
            this.cb_trigger.TabIndex = 5;
            this.cb_trigger.Text = "trigger";
            this.cb_trigger.UseVisualStyleBackColor = true;
            // 
            // cb_sound
            // 
            this.cb_sound.AutoSize = true;
            this.cb_sound.Location = new System.Drawing.Point(41, 183);
            this.cb_sound.Name = "cb_sound";
            this.cb_sound.Size = new System.Drawing.Size(55, 17);
            this.cb_sound.TabIndex = 6;
            this.cb_sound.Text = "sound";
            this.cb_sound.UseVisualStyleBackColor = true;
            // 
            // cb_airbrake
            // 
            this.cb_airbrake.AutoSize = true;
            this.cb_airbrake.Location = new System.Drawing.Point(41, 206);
            this.cb_airbrake.Name = "cb_airbrake";
            this.cb_airbrake.Size = new System.Drawing.Size(64, 17);
            this.cb_airbrake.TabIndex = 7;
            this.cb_airbrake.Text = "airbrake";
            this.cb_airbrake.UseVisualStyleBackColor = true;
            // 
            // cb_rudderL
            // 
            this.cb_rudderL.AutoSize = true;
            this.cb_rudderL.Location = new System.Drawing.Point(127, 160);
            this.cb_rudderL.Name = "cb_rudderL";
            this.cb_rudderL.Size = new System.Drawing.Size(73, 17);
            this.cb_rudderL.TabIndex = 8;
            this.cb_rudderL.Text = "rudder left";
            this.cb_rudderL.UseVisualStyleBackColor = true;
            // 
            // cb_rudderM
            // 
            this.cb_rudderM.AutoSize = true;
            this.cb_rudderM.Location = new System.Drawing.Point(127, 183);
            this.cb_rudderM.Name = "cb_rudderM";
            this.cb_rudderM.Size = new System.Drawing.Size(82, 17);
            this.cb_rudderM.TabIndex = 9;
            this.cb_rudderM.Text = "rudder reset";
            this.cb_rudderM.UseVisualStyleBackColor = true;
            // 
            // cb_rudderR
            // 
            this.cb_rudderR.AutoSize = true;
            this.cb_rudderR.Location = new System.Drawing.Point(127, 206);
            this.cb_rudderR.Name = "cb_rudderR";
            this.cb_rudderR.Size = new System.Drawing.Size(79, 17);
            this.cb_rudderR.TabIndex = 10;
            this.cb_rudderR.Text = "rudder right";
            this.cb_rudderR.UseVisualStyleBackColor = true;
            // 
            // ConfigSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1582, 690);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ConfigSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConfigSettings";
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox screenIndicator;
        private System.Windows.Forms.TextBox tb_videoFilePath;
        private System.Windows.Forms.Button btn_browseVideoFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Button btn_infotainmentSub;
        private System.Windows.Forms.Button btn_infotainment;
        private System.Windows.Forms.Button btn_videoPlayer;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TableLayoutPanel tlp_infotainmentSub;
        private System.Windows.Forms.TableLayoutPanel tlp_infotainment;
        private System.Windows.Forms.TableLayoutPanel tlp_videoPlayer;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox tb_logs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label l_joystickY;
        private System.Windows.Forms.Label l_joystickX;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox cb_trigger;
        private System.Windows.Forms.CheckBox cb_sound;
        private System.Windows.Forms.CheckBox cb_rudderL;
        private System.Windows.Forms.CheckBox cb_airbrake;
        private System.Windows.Forms.CheckBox cb_rudderR;
        private System.Windows.Forms.CheckBox cb_rudderM;
    }
}