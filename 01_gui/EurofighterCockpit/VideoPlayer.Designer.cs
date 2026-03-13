namespace EurofighterCockpit
{
    partial class VideoPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoPlayer));
            videoView = new LibVLCSharp.WinForms.VideoView();
            ((System.ComponentModel.ISupportInitialize)videoView).BeginInit();
            SuspendLayout();
            // 
            // videoView
            // 
            videoView.BackColor = System.Drawing.Color.Black;
            videoView.Dock = System.Windows.Forms.DockStyle.Fill;
            videoView.Location = new System.Drawing.Point(0, 0);
            videoView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            videoView.MediaPlayer = null;
            videoView.Name = "videoView";
            videoView.Size = new System.Drawing.Size(1920, 1080);
            videoView.TabIndex = 0;
            videoView.Text = "videoView1";
            // 
            // VideoPlayer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1920, 1080);
            Controls.Add(videoView);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "VideoPlayer";
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "VLCPlayer";
            ((System.ComponentModel.ISupportInitialize)videoView).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private LibVLCSharp.WinForms.VideoView videoView;
    }
}