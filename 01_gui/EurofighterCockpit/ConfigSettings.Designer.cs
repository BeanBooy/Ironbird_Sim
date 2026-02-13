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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_videoPlayerScreen = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.p_videoPlayerStatus = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_videoPlayerScreenReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // screenIndicator
            // 
            this.screenIndicator.AutoSize = true;
            this.screenIndicator.Location = new System.Drawing.Point(17, 49);
            this.screenIndicator.Name = "screenIndicator";
            this.screenIndicator.Size = new System.Drawing.Size(188, 24);
            this.screenIndicator.TabIndex = 0;
            this.screenIndicator.Text = "show screen indicator";
            this.screenIndicator.UseVisualStyleBackColor = true;
            this.screenIndicator.CheckedChanged += new System.EventHandler(this.screenIndicator_CheckedChanged);
            // 
            // tb_videoFilePath
            // 
            this.tb_videoFilePath.Location = new System.Drawing.Point(474, 380);
            this.tb_videoFilePath.Name = "tb_videoFilePath";
            this.tb_videoFilePath.ReadOnly = true;
            this.tb_videoFilePath.Size = new System.Drawing.Size(322, 26);
            this.tb_videoFilePath.TabIndex = 1;
            // 
            // btn_browseVideoFile
            // 
            this.btn_browseVideoFile.Location = new System.Drawing.Point(802, 380);
            this.btn_browseVideoFile.Name = "btn_browseVideoFile";
            this.btn_browseVideoFile.Size = new System.Drawing.Size(75, 34);
            this.btn_browseVideoFile.TabIndex = 2;
            this.btn_browseVideoFile.Text = "browse";
            this.btn_browseVideoFile.UseVisualStyleBackColor = true;
            this.btn_browseVideoFile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_browseVideoFile_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(474, 337);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Video Player";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Displays";
            // 
            // cb_videoPlayerScreen
            // 
            this.cb_videoPlayerScreen.FormattingEnabled = true;
            this.cb_videoPlayerScreen.Location = new System.Drawing.Point(184, 96);
            this.cb_videoPlayerScreen.Name = "cb_videoPlayerScreen";
            this.cb_videoPlayerScreen.Size = new System.Drawing.Size(139, 28);
            this.cb_videoPlayerScreen.TabIndex = 11;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(184, 126);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(139, 28);
            this.comboBox2.TabIndex = 12;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(184, 156);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(139, 28);
            this.comboBox3.TabIndex = 13;
            // 
            // checkBox4
            // 
            this.checkBox4.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox4.AutoCheck = false;
            this.checkBox4.Location = new System.Drawing.Point(310, 549);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(79, 64);
            this.checkBox4.TabIndex = 14;
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(51, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 28);
            this.label3.TabIndex = 15;
            this.label3.Text = "Video Player";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p_videoPlayerStatus
            // 
            this.p_videoPlayerStatus.BackColor = System.Drawing.Color.Crimson;
            this.p_videoPlayerStatus.Location = new System.Drawing.Point(17, 96);
            this.p_videoPlayerStatus.Name = "p_videoPlayerStatus";
            this.p_videoPlayerStatus.Size = new System.Drawing.Size(28, 28);
            this.p_videoPlayerStatus.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Crimson;
            this.panel2.Location = new System.Drawing.Point(17, 126);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(28, 28);
            this.panel2.TabIndex = 17;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Crimson;
            this.panel3.Location = new System.Drawing.Point(17, 156);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(28, 28);
            this.panel3.TabIndex = 18;
            // 
            // btn_videoPlayerScreenReset
            // 
            this.btn_videoPlayerScreenReset.Location = new System.Drawing.Point(329, 96);
            this.btn_videoPlayerScreenReset.Name = "btn_videoPlayerScreenReset";
            this.btn_videoPlayerScreenReset.Size = new System.Drawing.Size(75, 34);
            this.btn_videoPlayerScreenReset.TabIndex = 19;
            this.btn_videoPlayerScreenReset.Text = "reset";
            this.btn_videoPlayerScreenReset.UseVisualStyleBackColor = true;
            this.btn_videoPlayerScreenReset.Click += new System.EventHandler(this.btn_videoPlayerScreenReset_Click);
            // 
            // ConfigSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1460, 886);
            this.Controls.Add(this.btn_videoPlayerScreenReset);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.p_videoPlayerStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.cb_videoPlayerScreen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_browseVideoFile);
            this.Controls.Add(this.tb_videoFilePath);
            this.Controls.Add(this.screenIndicator);
            this.Name = "ConfigSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConfigSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox screenIndicator;
        private System.Windows.Forms.TextBox tb_videoFilePath;
        private System.Windows.Forms.Button btn_browseVideoFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_videoPlayerScreen;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel p_videoPlayerStatus;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_videoPlayerScreenReset;
    }
}