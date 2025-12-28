using Convertor.Models;
using System.Text.Json;


namespace Convertor
{
    public partial class Form1 : Form
    {
        double Price = 0;
        string In = "AUD";
        string Out = "AUD";
        ValuteList _valutes;
        public Form1()
        {
            InitializeComponent();
            cbOut.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIn.DropDownStyle = ComboBoxStyle.DropDownList;
           
            convert.Text = "конвертировать";
            
            UpdateRateFromCbr();
            btnUpdate.Text = "Обновить";

        }


        private async void UpdateRateFromCbr()
        {
            try
            {
                using var client = new HttpClient();
                var json = await client.GetStringAsync("https://www.cbr-xml-daily.ru/daily_json.js");


                using var document = JsonDocument.Parse(json);
                var Value1 = document.RootElement
                    .GetProperty("Valute")
                    .GetProperty(In)
                    .GetProperty("Value")
                    .GetDouble();
                var Value2 = document.RootElement
                   .GetProperty("Valute")
                   .GetProperty(Out)
                   .GetProperty("Value")
                   .GetDouble();

                Price = Value1 / Value2;
                lb2.Text = $"{Price:F2} {In} за {Out}";

                _valutes = JsonSerializer.Deserialize<ValuteList>(json);


                List<string> valutesKeys = new List<string>();
              

                foreach (var valute in _valutes.Valute)
                {
                    valutesKeys.Add(valute.Key.ToString());
                }

                cbIn.Items.Clear();
                cbOut.Items.Clear();

                foreach (var item in valutesKeys)
                {
                    cbIn.Items.Add(item);
                    cbOut.Items.Add(item);
                }

            }
            catch
            {
                MessageBox.Show(" Ошибка загрузки. Используется курс по умолчанию.");
            }
        }




        private void convert_Click(object sender, EventArgs e)
        {



            double result = 0;

            if (!double.TryParse(tb1.Text, out double a) || a <= 0)
            {
                MessageBox.Show("Введите корректную сумму!");
                return;
            }

            result = Convert.ToDouble(tb1.Text) * Price;

            lb1.Text = result.ToString("F2");
        }

        private void cbOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            Out = cbOut.Text;
            lb2.Text = $"{Price:F2} {In} за {Out}";
            UpdateRateFromCbr();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate.Text = "Курс обновлён";
            UpdateRateFromCbr();

        }

        private void cbIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            In = cbIn.Text;
            lb2.Text = $"{Price:F2} {In} за {Out}";
            UpdateRateFromCbr();
        }
    }
}
