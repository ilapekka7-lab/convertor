using Convertor.Models;
using System.Text.Json;


namespace Convertor
{
    public partial class Form1 : Form
    {
        double Price = 0;
        string In = "";
        string Out = "";
        ValuteList _valutes;
        List<string> valutesKeys = new List<string>();
        public Form1()
        {
            InitializeComponent();
            cbOut.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIn.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIn.Items.Clear();
            cbOut.Items.Clear();
            convert.Text = "конвертировать";
            UpdateValutes();
            UpdateRateFromCbr();
            btnUpdate.Text = "Обновить";
            lb2.Text = "Курс";

        }


        private async void UpdateRateFromCbr()
        {
            if(In != string.Empty && Out != string.Empty)
            {
                try
                {
                    using var client = new HttpClient();
                    var json = await client.GetStringAsync("https://www.cbr-xml-daily.ru/daily_json.js");


                    using var document = JsonDocument.Parse(json);
                    var valuteObj = document.RootElement.GetProperty("Valute");

                    var Value1 = valuteObj.EnumerateObject()
                        .First(x => x.Value.GetProperty("Name").GetString() == In)
                        .Value.GetProperty("Value").GetDouble();

                    var Value2 = valuteObj.EnumerateObject()
                        .First(x => x.Value.GetProperty("Name").GetString() == Out)
                        .Value.GetProperty("Value").GetDouble();

                    Price = Value1 / Value2;
                    lb2.Text = $"{Price:F2} {In} за {Out}";


                }
                catch
                {
                    MessageBox.Show(" Ошибка загрузки. Используется курс по умолчанию.");
                }
            }
           
        }

        private async void UpdateValutes()
        {
            try
            {
                using var client = new HttpClient();
                var json = await client.GetStringAsync("https://www.cbr-xml-daily.ru/daily_json.js");

                _valutes = JsonSerializer.Deserialize<ValuteList>(json);


                // List<string> valutesKeys = new List<string>();


                foreach (var valute in _valutes.Valute)
                {
                    valutesKeys.Add(valute.Value.Name.ToString());
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
                MessageBox.Show(" Ошибка загрузки. Не удаётся загрузить валюты");
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

            UpdateValutes();

        }

        private void cbIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            In = cbIn.Text;
            lb2.Text = $"{Price:F2} {In} за {Out}";
            UpdateRateFromCbr();
        }
    }
}
