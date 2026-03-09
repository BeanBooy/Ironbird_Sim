using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;


namespace EurofighterCockpit.Slides
{
    public partial class SlideDetails : BaseSlide
    {
        public SlideDetails(byte[] data, Image image) {
            InitializeComponent();

            string json = Encoding.UTF8.GetString(data);
            var detail = JsonSerializer.Deserialize<SlideDetailJson>(json);

            l_title.Text = detail.Title;
            l_text.Text = detail.Description;
            PopulateTable(tlp_data, detail.Data);
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

        //public static void PopulateTable(TableLayoutPanel table, Dictionary<string, object> data) {
        //    table.SuspendLayout();
        //    table.Visible = false;

        //    table.Controls.Clear();
        //    table.RowStyles.Clear();
        //    table.ColumnStyles.Clear();

        //    table.ColumnCount = 2;
        //    table.RowCount = data.Count;

        //    table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
        //    table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));

        //    var italicFont = new Font(table.Font, FontStyle.Italic);

        //    int row = 0;

        //    foreach (var kvp in data) {
        //        table.RowStyles.Add(new RowStyle(SizeType.AutoSize));

        //        var keyLabel = new Label {
        //            Text = kvp.Key,
        //            Dock = DockStyle.Fill,
        //            AutoSize = false,
        //            TextAlign = ContentAlignment.MiddleLeft,
        //            Padding = new Padding(3)
        //        };

        //        var valueLabel = new Label {
        //            Text = kvp.Value?.ToString() ?? "null",
        //            Dock = DockStyle.Fill,
        //            AutoSize = false,
        //            Font = italicFont,
        //            TextAlign = ContentAlignment.MiddleLeft,
        //            Padding = new Padding(3)
        //        };

        //        table.Controls.Add(keyLabel, 0, row);
        //        table.Controls.Add(valueLabel, 1, row);

        //        row++;
        //    }

        //    table.Visible = true;
        //    table.ResumeLayout();
        //}

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
