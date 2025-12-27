using System.Text.Json;


namespace Convertor
{
    public partial class Form1 : Form
    {
        double price = 78;
        public Form1()
        {
            InitializeComponent();
            cb1.DropDownStyle = ComboBoxStyle.DropDownList;
            cb1.Items.Clear();
            cb1.Items.Add("доллары в рубли");
            cb1.Items.Add("рубли в доллары");
            cb1.SelectedIndex = 1;
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

                // Парсим JSON
                using var document = JsonDocument.Parse(json);
                var usdValue = document.RootElement
                    .GetProperty("Valute")
                    .GetProperty("USD")
                    .GetProperty("Value")
                    .GetDouble(); // ← Реальный курс!

                price = usdValue;
                lb2.Text = $"{price:F2} рублей за доллар";


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

            if (cb1.Text == "доллары в рубли")
                result = a * price;

            if (cb1.Text == "рубли в доллары")
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
