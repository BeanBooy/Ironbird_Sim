namespace EurofighterCockpit.Slides
{
    partial class SlideDetails
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            this.tb_text = new System.Windows.Forms.TextBox();
            this.tb_data = new System.Windows.Forms.TextBox();
            this.p_image = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.l_title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_text
            // 
            this.tb_text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tb_text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_text.Font = new System.Drawing.Font("Leelawadee UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_text.ForeColor = System.Drawing.Color.White;
            this.tb_text.Location = new System.Drawing.Point(107, 788);
            this.tb_text.Multiline = true;
            this.tb_text.Name = "tb_text";
            this.tb_text.ReadOnly = true;
            this.tb_text.Size = new System.Drawing.Size(1289, 196);
            this.tb_text.TabIndex = 5;
            // 
            // tb_data
            // 
            this.tb_data.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tb_data.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_data.Font = new System.Drawing.Font("Leelawadee UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_data.ForeColor = System.Drawing.Color.White;
            this.tb_data.Location = new System.Drawing.Point(1128, 274);
            this.tb_data.Multiline = true;
            this.tb_data.Name = "tb_data";
            this.tb_data.ReadOnly = true;
            this.tb_data.Size = new System.Drawing.Size(517, 416);
            this.tb_data.TabIndex = 3;
            // 
            // p_image
            // 
            this.p_image.BackColor = System.Drawing.Color.Black;
            this.p_image.Location = new System.Drawing.Point(107, 201);
            this.p_image.Name = "p_image";
            this.p_image.Size = new System.Drawing.Size(892, 489);
            this.p_image.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Leelawadee UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1121, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "Technische Daten:";
            // 
            // l_title
            // 
            this.l_title.AutoSize = true;
            this.l_title.Font = new System.Drawing.Font("Leelawadee UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_title.ForeColor = System.Drawing.Color.White;
            this.l_title.Location = new System.Drawing.Point(98, 75);
            this.l_title.Name = "l_title";
            this.l_title.Size = new System.Drawing.Size(100, 50);
            this.l_title.TabIndex = 0;
            this.l_title.Text = "Title";
            // 
            // SlideDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.tb_text);
            this.Controls.Add(this.tb_data);
            this.Controls.Add(this.p_image);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.l_title);
            this.Name = "SlideDetails";
            this.Size = new System.Drawing.Size(1920, 1080);
            this.Load += new System.EventHandler(this.SlideDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel p_image;
        private System.Windows.Forms.TextBox tb_data;
        private System.Windows.Forms.TextBox tb_text;
    }
}
