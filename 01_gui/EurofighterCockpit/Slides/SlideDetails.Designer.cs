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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SlideDetails));
            label1 = new System.Windows.Forms.Label();
            l_title = new System.Windows.Forms.Label();
            pb_image = new System.Windows.Forms.PictureBox();
            tlp_data = new System.Windows.Forms.TableLayoutPanel();
            l_text = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)pb_image).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Font = new System.Drawing.Font("Leelawadee UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.ForeColor = System.Drawing.Color.White;
            label1.Location = new System.Drawing.Point(1111, 170);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(309, 46);
            label1.TabIndex = 1;
            label1.Text = "Technische Daten:";
            // 
            // l_title
            // 
            l_title.BackColor = System.Drawing.Color.Transparent;
            l_title.Font = new System.Drawing.Font("Leelawadee UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            l_title.ForeColor = System.Drawing.Color.White;
            l_title.Location = new System.Drawing.Point(117, 77);
            l_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            l_title.Name = "l_title";
            l_title.Size = new System.Drawing.Size(986, 58);
            l_title.TabIndex = 0;
            l_title.Text = "Title";
            // 
            // pb_image
            // 
            pb_image.BackColor = System.Drawing.Color.Transparent;
            pb_image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            pb_image.Location = new System.Drawing.Point(117, 170);
            pb_image.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pb_image.Name = "pb_image";
            pb_image.Size = new System.Drawing.Size(922, 514);
            pb_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pb_image.TabIndex = 6;
            pb_image.TabStop = false;
            // 
            // tlp_data
            // 
            tlp_data.BackColor = System.Drawing.Color.Transparent;
            tlp_data.ColumnCount = 2;
            tlp_data.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.22625F));
            tlp_data.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.77375F));
            tlp_data.Font = new System.Drawing.Font("Leelawadee UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            tlp_data.ForeColor = System.Drawing.Color.White;
            tlp_data.Location = new System.Drawing.Point(1119, 237);
            tlp_data.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tlp_data.Name = "tlp_data";
            tlp_data.RowCount = 1;
            tlp_data.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlp_data.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlp_data.Size = new System.Drawing.Size(688, 447);
            tlp_data.TabIndex = 7;
            // 
            // l_text
            // 
            l_text.BackColor = System.Drawing.Color.FromArgb(170, 0, 0, 0);
            l_text.Font = new System.Drawing.Font("Leelawadee UI", 20.25F);
            l_text.ForeColor = System.Drawing.Color.White;
            l_text.Location = new System.Drawing.Point(117, 752);
            l_text.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            l_text.Name = "l_text";
            l_text.Padding = new System.Windows.Forms.Padding(12);
            l_text.Size = new System.Drawing.Size(1690, 247);
            l_text.TabIndex = 8;
            l_text.Text = "Description";
            // 
            // SlideDetails
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(0, 0, 64);
            BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            Controls.Add(l_text);
            Controls.Add(tlp_data);
            Controls.Add(pb_image);
            Controls.Add(label1);
            Controls.Add(l_title);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "SlideDetails";
            Size = new System.Drawing.Size(1920, 1080);
            ((System.ComponentModel.ISupportInitialize)pb_image).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label l_title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pb_image;
        private System.Windows.Forms.TableLayoutPanel tlp_data;
        private System.Windows.Forms.Label l_text;
    }
}
