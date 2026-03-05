namespace EurofighterCockpit
{
    partial class Infotainment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Infotainment));
            this.p_content = new System.Windows.Forms.Panel();
            this.btn_Eurofighter = new System.Windows.Forms.Button();
            this.p_SlideSelector = new System.Windows.Forms.Panel();
            this.btn_Engine = new System.Windows.Forms.Button();
            this.btn_Movie = new System.Windows.Forms.Button();
            this.btn_Joystick = new System.Windows.Forms.Button();
            this.btn_Weaponry = new System.Windows.Forms.Button();
            this.btn_Systems = new System.Windows.Forms.Button();
            this.p_SlideSelector.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_content
            // 
            this.p_content.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.p_content.Dock = System.Windows.Forms.DockStyle.Right;
            this.p_content.Location = new System.Drawing.Point(320, 0);
            this.p_content.Margin = new System.Windows.Forms.Padding(2);
            this.p_content.Name = "p_content";
            this.p_content.Size = new System.Drawing.Size(1600, 1080);
            this.p_content.TabIndex = 1;
            // 
            // btn_Eurofighter
            // 
            this.btn_Eurofighter.BackColor = System.Drawing.Color.Black;
            this.btn_Eurofighter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Eurofighter.FlatAppearance.BorderSize = 3;
            this.btn_Eurofighter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Eurofighter.Font = new System.Drawing.Font("Leelawadee UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Eurofighter.ForeColor = System.Drawing.Color.White;
            this.btn_Eurofighter.Location = new System.Drawing.Point(19, 20);
            this.btn_Eurofighter.Margin = new System.Windows.Forms.Padding(10);
            this.btn_Eurofighter.Name = "btn_Eurofighter";
            this.btn_Eurofighter.Size = new System.Drawing.Size(280, 65);
            this.btn_Eurofighter.TabIndex = 0;
            this.btn_Eurofighter.Text = "EF 2000";
            this.btn_Eurofighter.UseVisualStyleBackColor = false;
            this.btn_Eurofighter.Click += new System.EventHandler(this.btn_Click);
            // 
            // p_SlideSelector
            // 
            this.p_SlideSelector.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("p_SlideSelector.BackgroundImage")));
            this.p_SlideSelector.Controls.Add(this.btn_Engine);
            this.p_SlideSelector.Controls.Add(this.btn_Movie);
            this.p_SlideSelector.Controls.Add(this.btn_Joystick);
            this.p_SlideSelector.Controls.Add(this.btn_Weaponry);
            this.p_SlideSelector.Controls.Add(this.btn_Systems);
            this.p_SlideSelector.Controls.Add(this.btn_Eurofighter);
            this.p_SlideSelector.Dock = System.Windows.Forms.DockStyle.Left;
            this.p_SlideSelector.Location = new System.Drawing.Point(0, 0);
            this.p_SlideSelector.Margin = new System.Windows.Forms.Padding(2);
            this.p_SlideSelector.Name = "p_SlideSelector";
            this.p_SlideSelector.Padding = new System.Windows.Forms.Padding(10);
            this.p_SlideSelector.Size = new System.Drawing.Size(320, 1080);
            this.p_SlideSelector.TabIndex = 0;
            // 
            // btn_Engine
            // 
            this.btn_Engine.BackColor = System.Drawing.Color.Black;
            this.btn_Engine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Engine.FlatAppearance.BorderSize = 3;
            this.btn_Engine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Engine.Font = new System.Drawing.Font("Leelawadee UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Engine.ForeColor = System.Drawing.Color.White;
            this.btn_Engine.Location = new System.Drawing.Point(19, 280);
            this.btn_Engine.Margin = new System.Windows.Forms.Padding(10);
            this.btn_Engine.Name = "btn_Engine";
            this.btn_Engine.Size = new System.Drawing.Size(280, 65);
            this.btn_Engine.TabIndex = 5;
            this.btn_Engine.Text = "Triebwerk";
            this.btn_Engine.UseVisualStyleBackColor = false;
            this.btn_Engine.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn_Movie
            // 
            this.btn_Movie.BackColor = System.Drawing.Color.Black;
            this.btn_Movie.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Movie.FlatAppearance.BorderSize = 3;
            this.btn_Movie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Movie.Font = new System.Drawing.Font("Leelawadee UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Movie.ForeColor = System.Drawing.Color.White;
            this.btn_Movie.Location = new System.Drawing.Point(19, 450);
            this.btn_Movie.Margin = new System.Windows.Forms.Padding(10);
            this.btn_Movie.Name = "btn_Movie";
            this.btn_Movie.Size = new System.Drawing.Size(280, 65);
            this.btn_Movie.TabIndex = 4;
            this.btn_Movie.Text = "Video";
            this.btn_Movie.UseVisualStyleBackColor = false;
            this.btn_Movie.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn_Joystick
            // 
            this.btn_Joystick.BackColor = System.Drawing.Color.Black;
            this.btn_Joystick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Joystick.FlatAppearance.BorderSize = 3;
            this.btn_Joystick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Joystick.Font = new System.Drawing.Font("Leelawadee UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Joystick.ForeColor = System.Drawing.Color.White;
            this.btn_Joystick.Location = new System.Drawing.Point(19, 365);
            this.btn_Joystick.Margin = new System.Windows.Forms.Padding(10);
            this.btn_Joystick.Name = "btn_Joystick";
            this.btn_Joystick.Size = new System.Drawing.Size(280, 65);
            this.btn_Joystick.TabIndex = 3;
            this.btn_Joystick.Text = "Joystick";
            this.btn_Joystick.UseVisualStyleBackColor = false;
            this.btn_Joystick.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn_Weaponry
            // 
            this.btn_Weaponry.BackColor = System.Drawing.Color.Black;
            this.btn_Weaponry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Weaponry.FlatAppearance.BorderSize = 3;
            this.btn_Weaponry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Weaponry.Font = new System.Drawing.Font("Leelawadee UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Weaponry.ForeColor = System.Drawing.Color.White;
            this.btn_Weaponry.Location = new System.Drawing.Point(19, 195);
            this.btn_Weaponry.Margin = new System.Windows.Forms.Padding(10);
            this.btn_Weaponry.Name = "btn_Weaponry";
            this.btn_Weaponry.Size = new System.Drawing.Size(280, 65);
            this.btn_Weaponry.TabIndex = 2;
            this.btn_Weaponry.Text = "Bewaffnung";
            this.btn_Weaponry.UseVisualStyleBackColor = false;
            this.btn_Weaponry.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn_Systems
            // 
            this.btn_Systems.BackColor = System.Drawing.Color.Black;
            this.btn_Systems.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Systems.FlatAppearance.BorderSize = 3;
            this.btn_Systems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Systems.Font = new System.Drawing.Font("Leelawadee UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Systems.ForeColor = System.Drawing.Color.White;
            this.btn_Systems.Location = new System.Drawing.Point(19, 110);
            this.btn_Systems.Margin = new System.Windows.Forms.Padding(10);
            this.btn_Systems.Name = "btn_Systems";
            this.btn_Systems.Size = new System.Drawing.Size(280, 65);
            this.btn_Systems.TabIndex = 1;
            this.btn_Systems.Text = "Systeme";
            this.btn_Systems.UseVisualStyleBackColor = false;
            this.btn_Systems.Click += new System.EventHandler(this.btn_Click);
            // 
            // Infotainment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.p_content);
            this.Controls.Add(this.p_SlideSelector);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Infotainment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Infotainment";
            this.p_SlideSelector.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel p_content;
        private System.Windows.Forms.Button btn_Eurofighter;
        private System.Windows.Forms.Panel p_SlideSelector;
        private System.Windows.Forms.Button btn_Systems;
        private System.Windows.Forms.Button btn_Movie;
        private System.Windows.Forms.Button btn_Joystick;
        private System.Windows.Forms.Button btn_Weaponry;
        private System.Windows.Forms.Button btn_Engine;
    }
}