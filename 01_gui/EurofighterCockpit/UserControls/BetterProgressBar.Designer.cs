namespace EurofighterCockpit
{
    partial class BetterProgressBar
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
            this.p_progress = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // p_progress
            // 
            this.p_progress.BackColor = System.Drawing.Color.Orange;
            this.p_progress.Dock = System.Windows.Forms.DockStyle.Left;
            this.p_progress.Location = new System.Drawing.Point(0, 0);
            this.p_progress.Name = "p_progress";
            this.p_progress.Size = new System.Drawing.Size(138, 45);
            this.p_progress.TabIndex = 0;
            // 
            // BetterProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.p_progress);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Name = "BetterProgressBar";
            this.Size = new System.Drawing.Size(321, 45);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_progress;
    }
}
