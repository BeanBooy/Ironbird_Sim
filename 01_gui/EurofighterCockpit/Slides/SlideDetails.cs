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
        private Bitmap scaledImage;

        public SlideDetails(byte[] data, Image image) {
            InitializeComponent();

            string json = Encoding.UTF8.GetString(data);
            var detail = JsonSerializer.Deserialize<SlideDetailJson>(json);

            l_title.Text = detail.Title;
            l_text.Text = detail.Description;
            PopulateTable(tlp_data, detail.Data);
            this.image = image;
            pb_image.Image = image;
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
                    TextAlign = ContentAlignment.TopLeft,
                    Padding = new Padding(3)
                };

                var valueLabel = new Label() {
                    Text = kvp.Value?.ToString() ?? "null",
                    Dock = DockStyle.Fill,
                    AutoSize = true,
                    Font = new Font(table.Font, FontStyle.Italic),
                    TextAlign = ContentAlignment.TopLeft,
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
