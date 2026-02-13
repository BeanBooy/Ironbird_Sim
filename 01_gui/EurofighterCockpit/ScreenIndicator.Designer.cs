namespace EurofighterCockpit
{
    partial class ScreenIndicator
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
            this.screenNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // screenNumber
            // 
            this.screenNumber.AutoSize = true;
            this.screenNumber.BackColor = System.Drawing.Color.Orange;
            this.screenNumber.Font = new System.Drawing.Font("Consolas", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.screenNumber.Location = new System.Drawing.Point(0, 0);
            this.screenNumber.Margin = new System.Windows.Forms.Padding(0);
            this.screenNumber.MinimumSize = new System.Drawing.Size(30, 168);
            this.screenNumber.Name = "screenNumber";
            this.screenNumber.Size = new System.Drawing.Size(307, 168);
            this.screenNumber.TabIndex = 0;
            this.screenNumber.Text = "---";
            this.screenNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScreenIndicator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(592, 293);
            this.Controls.Add(this.screenNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScreenIndicator";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ScreenIndicator";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label screenNumber;
    }
}