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
            if (In != string.Empty && Out != string.Empty)
            {
                try
                {
                    using var client = new HttpClient();
                    var json = await client.GetStringAsync("https://www.cbr-xml-daily.ru/daily_json.js");


                    using var document = JsonDocument.Parse(json);
                    var valuteObj = document.RootElement.GetProperty("Valute");
                    double Value1;
                    double Value2;
                    if (In == "Российский Рубль") Value1 = 1;

                    else
                    {
                        Value1 = valuteObj.EnumerateObject()
                        .First(x => x.Value.GetProperty("Name").GetString() == In)
                        .Value.GetProperty("Value").GetDouble();
                    }

                    if (Out == "Российский Рубль") Value2 = 1;

                    else
                    {
                        Value2 = valuteObj.EnumerateObject()
                        .First(x => x.Value.GetProperty("Name").GetString() == Out)
                        .Value.GetProperty("Value").GetDouble();
                    }


                    Price = Value1 / Value2;
                    lb2.Text = $"{Price:F2} {Out} за {In}";


                }
                catch
                {
                    MessageBox.Show(" Ошибка загрузки. Используется курс по умолчанию.");
                    Form2 errorForm = new Form2();
                    this.Hide();
                    errorForm.Show();
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


               
                cbIn.Items.Clear();
                cbOut.Items.Clear();

                valutesKeys.Add("Российский Рубль");
                foreach (var valute in _valutes.Valute)
                {
                    valutesKeys.Add(valute.Value.Name.ToString());
                }
                valutesKeys.Sort();

                foreach (var item in valutesKeys)
                {
                    cbIn.Items.Add(item);
                    cbOut.Items.Add(item);
                }

            }
            catch
            {
                MessageBox.Show(" Ошибка загрузки. Не удаётся загрузить валюты");
                Form2 errorForm = new Form2();
                this.Hide();
                errorForm.Show();
            }
        }

        private void ConvertValue()
        {
            double result = 0;

            double input = 1;

            if(tb1.Text != "")
            {
                input = Convert.ToDouble(tb1.Text);
            }
            if (input <= 0)
            {
                MessageBox.Show("Введите корректную сумму!");
                return;
            }
            if (input == null)
            {
                input = 1;
               
            }
            if (cbIn.Text == "" || cbOut.Text == "")
            {
                MessageBox.Show("Выберите тип валюты!");
                return;

            }


            result = input / Price;

            tb2.Text = result.ToString("F2");

        }
        private void convert_Click(object sender, EventArgs e)
        {

            ConvertValue();


        }

        private void cbOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            Out = cbOut.Text;

            UpdateRateFromCbr();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            btnUpdate.Text = "Курс обновлён";

            if (cbIn.Items.Count == 0 && cbOut.Items.Count == 0)
                UpdateValutes();

            UpdateRateFromCbr();
            
            if(tb1.Text != "" && tb2.Text != "")
            {
                double result = 0;

                result = Convert.ToDouble(tb1.Text) / Price;

                tb2.Text = result.ToString("F2");
            }
           

        }

        private void cbIn_SelectedIndexChanged(object sender, EventArgs e)
        {

            In = cbIn.Text;

            UpdateRateFromCbr();
        }

       
    }
  
}
