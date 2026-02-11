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
            this.screenNumber.BackColor = System.Drawing.Color.RosyBrown;
            this.screenNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screenNumber.Font = new System.Drawing.Font("Consolas", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.screenNumber.Location = new System.Drawing.Point(0, 0);
            this.screenNumber.Name = "screenNumber";
            this.screenNumber.Size = new System.Drawing.Size(250, 250);
            this.screenNumber.TabIndex = 0;
            this.screenNumber.Text = "X";
            this.screenNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScreenIndicator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 250);
            this.Controls.Add(this.screenNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScreenIndicator";
            this.Text = "ScreenIndicator";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label screenNumber;
    }
}