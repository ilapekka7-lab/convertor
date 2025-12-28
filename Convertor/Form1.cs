using Convertor.Models;
using System.Text.Json;


namespace Convertor
{
    public partial class Form1 : Form
    {
        double price = 78;
        ValuteList _valutes;
        public Form1()
        {
            InitializeComponent();
            cbOut.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIn.DropDownStyle = ComboBoxStyle.DropDownList;
            
            convert.Text = "конвертировать";
            lb2.Text = $"{price} рублей за доллар";
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
                var usdValue = document.RootElement
                    .GetProperty("Valute")
                    .GetProperty("USD")
                    .GetProperty("Value")
                    .GetDouble(); 

                price = usdValue;
                lb2.Text = $"{price:F2} рублей за доллар";

                _valutes = JsonSerializer.Deserialize<ValuteList>(json);

               
                List<string> valutesNames = new List<string>();
                
                foreach ( var valute in _valutes.Valute )
                {
                   
                    valutesNames.Add(valute.Key.ToString());
                }

                cbIn.Items.Clear();
                cbOut.Items.Clear();

               foreach(var item in valutesNames)
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

            if (cbOut.Text == "доллары в рубли")
                result = a * price;

            if (cbOut.Text == "рубли в доллары")
                result = a / price;

            lb1.Text = result.ToString("F2");
        }

        private void cb1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate.Text = "Курс обновлён";
            UpdateRateFromCbr();
            
        }
    }
}
