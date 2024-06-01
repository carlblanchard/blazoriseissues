namespace BlazoriseIssues.Problem3Assets
{
    public class ChartDataItem
    {

        public DateTime Date { get; set; }

        public int Count { get; set; }

        public int Severity { get; set; }

        public string DateString { get { return Date.ToString("dd/MM/yyyy"); } }


    }
}
