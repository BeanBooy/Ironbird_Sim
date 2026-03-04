namespace EurofighterCockpit.Slides
{
    partial class SlideMovie
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
            this.btn_launchMovie = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_launchMovie
            // 
            this.btn_launchMovie.BackColor = System.Drawing.Color.Black;
            this.btn_launchMovie.FlatAppearance.BorderSize = 3;
            this.btn_launchMovie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_launchMovie.Font = new System.Drawing.Font("Leelawadee UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_launchMovie.ForeColor = System.Drawing.Color.White;
            this.btn_launchMovie.Location = new System.Drawing.Point(192, 214);
            this.btn_launchMovie.Margin = new System.Windows.Forms.Padding(10);
            this.btn_launchMovie.Name = "btn_launchMovie";
            this.btn_launchMovie.Size = new System.Drawing.Size(371, 65);
            this.btn_launchMovie.TabIndex = 2;
            this.btn_launchMovie.Text = "Starte interaktiven Film";
            this.btn_launchMovie.UseVisualStyleBackColor = false;
            this.btn_launchMovie.Click += new System.EventHandler(this.btn_launchMovie_Click);
            // 
            // SlideMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.btn_launchMovie);
            this.Name = "SlideMovie";
            this.Size = new System.Drawing.Size(660, 333);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_launchMovie;
    }
}
