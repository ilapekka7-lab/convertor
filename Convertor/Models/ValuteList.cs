namespace Convertor.Models
{
    public class ValuteList
    {
        public DateTimeOffset Date { get; set; }

        public DateTimeOffset PreviousDate { get; set; }

        public DateTimeOffset Timestamp { get; set; }

        public string? PreviousURL { get; set; }

        public Dictionary<string, Valute> Valute { get; set; } = new();
    }
}
