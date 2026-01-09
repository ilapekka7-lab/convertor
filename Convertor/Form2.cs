using Convertor.Models;
using System.Text.Json;

namespace Convertor
{
    public partial class Form2 : Form
    {

        ValuteList _valutes;
        private int rectX = 0;  
        private int direction = 1; 
        private int colorIndex = 0;

        private Color[] colors = { Color.Black, Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Magenta, Color.Cyan };

        private System.Windows.Forms.Timer moveTimer = new System.Windows.Forms.Timer();

        public Form2()
        {
            InitializeComponent();
            this.Size = new Size(800, 600);
           
            this.DoubleBuffered = true;  

            moveTimer.Interval = 20;  
            moveTimer.Tick += MoveTimer_Tick;
            moveTimer.Start();

            this.Paint += Form1_Paint;
        }

        private void MoveTimer_Tick(object sender, EventArgs e)
        {
           
            rectX += 10 * direction;

           
            if (rectX <= 0)
            {
                rectX = 0;
                direction = 1;  
                colorIndex = (colorIndex + 1) % colors.Length;
            }
            if (rectX >= this.ClientSize.Width - 60)
            {
                rectX = this.ClientSize.Width - 60;
                direction = -1;  
                colorIndex = (colorIndex + 1) % colors.Length;
            }

            this.Invalidate();  
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            int rectY = this.ClientSize.Height / 2 + 50;
            Rectangle rect = new Rectangle(rectX, rectY, 60, 30);

            e.Graphics.FillRectangle(new SolidBrush(colors[colorIndex]), rect);
            e.Graphics.DrawRectangle(Pens.Gray, rect);
        }




        private async void UpdateReturn()
        {
            try
            {
                using var client = new HttpClient();
                var json = await client.GetStringAsync("https://www.cbr-xml-daily.ru/daily_json.js");

                _valutes = JsonSerializer.Deserialize<ValuteList>(json);

                if (_valutes != null)
                {
                    Form1 newForm = new Form1();
                    this.Hide();
                    newForm.Show();
                }



            }

            catch { }
        }
       

        private void bt3_Click(object sender, EventArgs e)
        {
            UpdateReturn();
        }
    }
}
