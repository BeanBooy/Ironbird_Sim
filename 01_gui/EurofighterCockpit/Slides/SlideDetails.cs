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
        public SlideDetails(byte[] data) {
            InitializeComponent();

            string json = Encoding.UTF8.GetString(data);
            var detail = JsonSerializer.Deserialize<SlideDetailJson>(json);

            l_title.Text = detail.Title;
            tb_text.Text = detail.Description;
            foreach (var item in detail.Data) {
                tb_data.AppendText(item.ToString() + Environment.NewLine);
            }

            string resourceName = "EurofighterCockpit.Resources.SlideDetails." + detail.Image;
            p_image.BackgroundImage = Image.FromFile(resourceName);

            //Assembly assembly = Assembly.GetExecutingAssembly();
            //Stream stream = assembly.GetManifestResourceStream(resourceName);

            //if (stream != null) {
            //    try {
            //        // Bild aus Stream laden
            //        Image img = Image.FromStream(stream);

            //        // In PictureBox anzeigen
            //        p_image.BackgroundImage = img;
            //    }
            //    catch {
            //        throw new Exception();
            //    }
            //    finally {
            //        // Stream unbedingt schließen
            //        stream.Dispose();
            //    }
            //}
            //else {
            //    MessageBox.Show("Bild konnte nicht gefunden werden: " + resourceName);
            //}
        }

        private void SlideDetails_Load(object sender, EventArgs e) {

        }

    }

    public class SlideDetailJson
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("data")]
        public Dictionary<string, object> Data { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
