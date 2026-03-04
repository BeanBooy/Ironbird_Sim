using EurofighterCockpit.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;


namespace EurofighterCockpit.Slides
{
    public partial class SlideDetails : BaseSlide
    {
        private Image image = null;

        public SlideDetails(byte[] data, Image image) {
            InitializeComponent();

            pb_image.Paint += Image_Paint;

            string json = Encoding.UTF8.GetString(data);
            var detail = JsonSerializer.Deserialize<SlideDetailJson>(json);

            l_title.Text = detail.Title;
            l_text.Text = detail.Description;
            PopulateTable(tlp_data, detail.Data);
            this.image = image;
            pb_image.Invalidate();
        }

        private void Image_Paint(object sender, PaintEventArgs e) {
            if (image == null)
                return;

            Rectangle container = pb_image.ClientRectangle;
            float imageRatio = (float)image.Width / image.Height;
            float containerRatio = (float)container.Width / container.Height;
            float scale;
            float offsetX = 0;
            float offsetY = 0;

            if (containerRatio > imageRatio) {
                // container is wider
                scale = (float)container.Width / image.Width;
                float scaledHeight = image.Height * scale;
                offsetY = (container.Height - scaledHeight) / 2;
            }
            else {
                // container is taller
                scale = (float)container.Height / image.Height;
                float scaledWidth = image.Width * scale;
                offsetX = (container.Width - scaledWidth) / 2;
            }

            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImage(image, offsetX, offsetY, image.Width * scale, image.Height * scale);
        }

        public static void PopulateTable(TableLayoutPanel table, Dictionary<string, object> data) {
            table.SuspendLayout();

            table.Controls.Clear();
            table.RowStyles.Clear();
            table.ColumnStyles.Clear();

            table.ColumnCount = 2;
            table.RowCount = data.Count;

            int row = 0;

            foreach (var kvp in data) {
                table.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                var keyLabel = new Label() {
                    Text = kvp.Key,
                    Dock = DockStyle.Fill,
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(3)
                };

                var valueLabel = new Label() {
                    Text = kvp.Value?.ToString() ?? "null",
                    Dock = DockStyle.Fill,
                    AutoSize = true,
                    Font = new Font(table.Font, FontStyle.Italic),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(3)
                };

                table.Controls.Add(keyLabel, 0, row);
                table.Controls.Add(valueLabel, 1, row);

                row++;
            }

            table.ResumeLayout();
        }
    }

    public class SlideDetailJson
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("data")]
        public Dictionary<string, object> Data { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
