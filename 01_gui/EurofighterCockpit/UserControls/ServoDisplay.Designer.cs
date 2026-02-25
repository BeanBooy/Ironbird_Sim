namespace EurofighterCockpit
{
    partial class ServoDisplay
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
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.tb_bin = new System.Windows.Forms.TextBox();
            this.tb_dec = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar
            // 
            this.trackBar.AutoSize = false;
            this.trackBar.Location = new System.Drawing.Point(3, 2);
            this.trackBar.Maximum = 255;
            this.trackBar.Name = "trackBar";
            this.trackBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBar.Size = new System.Drawing.Size(118, 23);
            this.trackBar.TabIndex = 0;
            this.trackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // tb_bin
            // 
            this.tb_bin.BackColor = System.Drawing.Color.Gainsboro;
            this.tb_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_bin.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_bin.Location = new System.Drawing.Point(159, 7);
            this.tb_bin.Name = "tb_bin";
            this.tb_bin.ReadOnly = true;
            this.tb_bin.Size = new System.Drawing.Size(48, 13);
            this.tb_bin.TabIndex = 2;
            this.tb_bin.Text = "00000000";
            this.tb_bin.WordWrap = false;
            // 
            // tb_dec
            // 
            this.tb_dec.BackColor = System.Drawing.Color.Gainsboro;
            this.tb_dec.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_dec.Location = new System.Drawing.Point(245, 7);
            this.tb_dec.Name = "tb_dec";
            this.tb_dec.ReadOnly = true;
            this.tb_dec.Size = new System.Drawing.Size(20, 13);
            this.tb_dec.TabIndex = 3;
            this.tb_dec.Text = "255";
            this.tb_dec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_dec.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Leelawadee UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(217, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "dec";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Leelawadee UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(133, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "bin";
            // 
            // ServoDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_dec);
            this.Controls.Add(this.tb_bin);
            this.Controls.Add(this.trackBar);
            this.Name = "ServoDisplay";
            this.Size = new System.Drawing.Size(276, 26);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.TextBox tb_bin;
        private System.Windows.Forms.TextBox tb_dec;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
