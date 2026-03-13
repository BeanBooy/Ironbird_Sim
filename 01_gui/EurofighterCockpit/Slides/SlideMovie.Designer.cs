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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SlideMovie));
            btn_launchMovie = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // btn_launchMovie
            // 
            btn_launchMovie.BackColor = System.Drawing.Color.Black;
            btn_launchMovie.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_launchMovie.FlatAppearance.BorderSize = 3;
            btn_launchMovie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_launchMovie.Font = new System.Drawing.Font("Leelawadee UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btn_launchMovie.ForeColor = System.Drawing.Color.White;
            btn_launchMovie.Location = new System.Drawing.Point(580, 957);
            btn_launchMovie.Margin = new System.Windows.Forms.Padding(0);
            btn_launchMovie.Name = "btn_launchMovie";
            btn_launchMovie.Size = new System.Drawing.Size(443, 75);
            btn_launchMovie.TabIndex = 2;
            btn_launchMovie.Text = "Starte interaktiven Film";
            btn_launchMovie.UseVisualStyleBackColor = false;
            btn_launchMovie.Click += btn_launchMovie_Click;
            // 
            // SlideMovie
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Gray;
            BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Controls.Add(btn_launchMovie);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "SlideMovie";
            Size = new System.Drawing.Size(1600, 1080);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_launchMovie;
    }
}
