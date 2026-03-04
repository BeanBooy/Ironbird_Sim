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
            this.label1 = new System.Windows.Forms.Label();
            this.l_title = new System.Windows.Forms.Label();
            this.pb_image = new System.Windows.Forms.PictureBox();
            this.tlp_data = new System.Windows.Forms.TableLayoutPanel();
            this.l_text = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_image)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
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
            this.l_title.BackColor = System.Drawing.Color.Transparent;
            this.l_title.Font = new System.Drawing.Font("Leelawadee UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_title.ForeColor = System.Drawing.Color.White;
            this.l_title.Location = new System.Drawing.Point(98, 75);
            this.l_title.Name = "l_title";
            this.l_title.Size = new System.Drawing.Size(845, 50);
            this.l_title.TabIndex = 0;
            this.l_title.Text = "Title";
            // 
            // pb_image
            // 
            this.pb_image.BackColor = System.Drawing.Color.Transparent;
            this.pb_image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pb_image.Location = new System.Drawing.Point(107, 201);
            this.pb_image.Name = "pb_image";
            this.pb_image.Size = new System.Drawing.Size(951, 502);
            this.pb_image.TabIndex = 6;
            this.pb_image.TabStop = false;
            // 
            // tlp_data
            // 
            this.tlp_data.BackColor = System.Drawing.Color.Transparent;
            this.tlp_data.ColumnCount = 2;
            this.tlp_data.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.22625F));
            this.tlp_data.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.77375F));
            this.tlp_data.Font = new System.Drawing.Font("Leelawadee UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlp_data.ForeColor = System.Drawing.Color.White;
            this.tlp_data.Location = new System.Drawing.Point(1128, 273);
            this.tlp_data.Name = "tlp_data";
            this.tlp_data.RowCount = 1;
            this.tlp_data.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_data.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_data.Size = new System.Drawing.Size(663, 430);
            this.tlp_data.TabIndex = 7;
            // 
            // l_text
            // 
            this.l_text.BackColor = System.Drawing.Color.Black;
            this.l_text.Font = new System.Drawing.Font("Leelawadee UI", 20.25F);
            this.l_text.ForeColor = System.Drawing.Color.White;
            this.l_text.Location = new System.Drawing.Point(100, 761);
            this.l_text.Name = "l_text";
            this.l_text.Padding = new System.Windows.Forms.Padding(10);
            this.l_text.Size = new System.Drawing.Size(1691, 238);
            this.l_text.TabIndex = 8;
            this.l_text.Text = "Description";
            // 
            // SlideDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.l_text);
            this.Controls.Add(this.tlp_data);
            this.Controls.Add(this.pb_image);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.l_title);
            this.Name = "SlideDetails";
            this.Size = new System.Drawing.Size(1920, 1080);
            ((System.ComponentModel.ISupportInitialize)(this.pb_image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label l_title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pb_image;
        private System.Windows.Forms.TableLayoutPanel tlp_data;
        private System.Windows.Forms.Label l_text;
    }
}
