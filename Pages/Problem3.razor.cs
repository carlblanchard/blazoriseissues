using Blazorise.Charts;
using BlazoriseIssues.Problem3Assets;
using Microsoft.AspNetCore.Components;

namespace BlazoriseIssues.Pages
{
    public class Problem3Base : ComponentBase
    {
        private bool isAlreadyInitialised;

        public LineChart<ChartDataItem> LineChart { get; set; }

      
        public LineChartOptions GetLineChartOptions()
        {
            var options = new LineChartOptions();

            options.Parsing = new ChartParsing
            {
                XAxisKey = nameof(ChartDataItem.Date).ToLower(),    // <-------- If you change this to datestring it fails to even render the chart
                YAxisKey = nameof(ChartDataItem.Count).ToLower(),
            };

            ////////////////////////////////////////////////////////////////
            /// I've tried to manually set the axis but it doesn't work
            ////////////////////////////////////////////////////////////////
            //options.Scales = new ChartScales
            //{
            //    X = new ChartAxis
            //    {

            //        Time = new ChartAxisTime
            //        {
            //            Unit = "Day",
            //            Round = true,
            //            DisplayFormat = new ChartAxisTimeDisplayFormat
            //            {
            //                Day = "dd/MM/yyyy"
            //            }
            //        }
            //    }
            //};

            //I even went down the label route but that was just a head ache.

            return options;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            
            if (!isAlreadyInitialised)
            {
                isAlreadyInitialised = true;

                await HandleRedraw();
            }
           
        }

        public async Task HandleRedraw()
        {
            Console.WriteLine("LineChart: HandleRedraw Started");

            await LineChart.Clear();

            await AddOrUpdateChartData("No Warning", -1);
            await AddOrUpdateChartData("Low Severity", 1);
            await AddOrUpdateChartData("Medium Severity", 2);
            await AddOrUpdateChartData("High Severity", 3);

            await LineChart.Update();

            Console.WriteLine("LineChart: HandleRedraw Completed ");
        }

        public async Task AddOrUpdateChartData(string labelText, int severityCode)
        {           
            //Add the datasource from oldest (left) newest (right)
            var ds = GetLineChartDataset(labelText, severityCode, backgroundColorsAll, borderColorsAll);
            ds.Data.Reverse();

            await LineChart.AddDataSet(ds);
         
        }

        public LineChartDataset<ChartDataItem> GetLineChartDataset(string label, int severityLevel, List<string> backgroundColors, List<string> borderColors)
        {
            return new LineChartDataset<ChartDataItem>
            {
                Label = label,
                Data = GetData().FindAll(x => x.Severity == (severityLevel == -1 ? x.Severity : severityLevel)),
                BackgroundColor = backgroundColors,
                BorderColor = borderColors,
                Fill = true,
                PointRadius = 3,
                BorderWidth = 1,
                PointBorderColor = Enumerable.Repeat(borderColors.First(), 6).ToList(),
                CubicInterpolationMode = "monotone"
            };
        }

        private readonly List<string> backgroundColorsAll = new List<string>
        {
            ChartColor.FromRgba(75, 192, 192, 0.2f),
            ChartColor.FromRgba(54, 162, 235, 0.2f),
            ChartColor.FromRgba(255, 206, 86, 0.2f),
            ChartColor.FromRgba(255, 99, 132, 0.2f),
            ChartColor.FromRgba(153, 102, 255, 0.2f),
            ChartColor.FromRgba(255, 159, 64, 0.2f)
        };

        private readonly List<string> borderColorsAll = new List<string>
        {
            ChartColor.FromRgba(75, 192, 192, 1f),
            ChartColor.FromRgba(54, 162, 235, 1f),
            ChartColor.FromRgba(255, 206, 86, 1f),
            ChartColor.FromRgba(255, 99, 132, 1f),
            ChartColor.FromRgba(153, 102, 255, 1f),
            ChartColor.FromRgba(255, 159, 64, 1f)
        };

        private List<ChartDataItem> GetData()
        {
            return new List<ChartDataItem>
            {
                new ChartDataItem { Date = new DateTime(2024, 5, 2), Count = 0, Severity = 3 },
                new ChartDataItem { Date = new DateTime(2024, 5, 2), Count = 0, Severity = 2 },
                new ChartDataItem { Date = new DateTime(2024, 5, 2), Count = 0, Severity = 1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 2), Count = 0, Severity = -1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 3), Count = 0, Severity = 3 },
                new ChartDataItem { Date = new DateTime(2024, 5, 3), Count = 0, Severity = 2 },
                new ChartDataItem { Date = new DateTime(2024, 5, 3), Count = 0, Severity = 1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 3), Count = 0, Severity = -1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 4), Count = 0, Severity = 3 },
                new ChartDataItem { Date = new DateTime(2024, 5, 4), Count = 0, Severity = 2 },
                new ChartDataItem { Date = new DateTime(2024, 5, 4), Count = 0, Severity = 1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 4), Count = 0, Severity = -1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 5), Count = 0, Severity = 3 },
                new ChartDataItem { Date = new DateTime(2024, 5, 5), Count = 0, Severity = 2 },
                new ChartDataItem { Date = new DateTime(2024, 5, 5), Count = 0, Severity = 1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 5), Count = 0, Severity = -1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 6), Count = 0, Severity = 3 },
                new ChartDataItem { Date = new DateTime(2024, 5, 6), Count = 0, Severity = 2 },
                new ChartDataItem { Date = new DateTime(2024, 5, 6), Count = 0, Severity = 1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 6), Count = 0, Severity = -1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 7), Count = 0, Severity = 2 },
                new ChartDataItem { Date = new DateTime(2024, 5, 7), Count = 0, Severity = 1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 7), Count = 0, Severity = -1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 7), Count = 1, Severity = 3 },
                new ChartDataItem { Date = new DateTime(2024, 5, 8), Count = 0, Severity = 3 },
                new ChartDataItem { Date = new DateTime(2024, 5, 8), Count = 0, Severity = 2 },
                new ChartDataItem { Date = new DateTime(2024, 5, 8), Count = 0, Severity = 1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 8), Count = 0, Severity = -1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 9), Count = 0, Severity = 3 },
                new ChartDataItem { Date = new DateTime(2024, 5, 9), Count = 0, Severity = 2 },
                new ChartDataItem { Date = new DateTime(2024, 5, 9), Count = 0, Severity = 1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 9), Count = 2, Severity = -1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 10), Count = 0, Severity = 3 },
                new ChartDataItem { Date = new DateTime(2024, 5, 10), Count = 0, Severity = 2 },
                new ChartDataItem { Date = new DateTime(2024, 5, 10), Count = 0, Severity = 1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 10), Count = 0, Severity = -1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 11), Count = 0, Severity = 3 },
                new ChartDataItem { Date = new DateTime(2024, 5, 11), Count = 0, Severity = 2 },
                new ChartDataItem { Date = new DateTime(2024, 5, 11), Count = 0, Severity = 1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 11), Count = 0, Severity = -1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 12), Count = 0, Severity = 3 },
                new ChartDataItem { Date = new DateTime(2024, 5, 12), Count = 0, Severity = 2 },
                new ChartDataItem { Date = new DateTime(2024, 5, 12), Count = 0, Severity = 1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 12), Count = 0, Severity = -1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 13), Count = 0, Severity = 3 },
                new ChartDataItem { Date = new DateTime(2024, 5, 13), Count = 0, Severity = 2 },
                new ChartDataItem { Date = new DateTime(2024, 5, 13), Count = 0, Severity = 1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 13), Count = 0, Severity = -1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 14), Count = 0, Severity = 3 },
                new ChartDataItem { Date = new DateTime(2024, 5, 14), Count = 0, Severity = 2 },
                new ChartDataItem { Date = new DateTime(2024, 5, 14), Count = 0, Severity = 1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 14), Count = 0, Severity = -1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 15), Count = 0, Severity = 2 },
                new ChartDataItem { Date = new DateTime(2024, 5, 15), Count = 0, Severity = 1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 15), Count = 0, Severity = -1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 15), Count = 1, Severity = 3 },
                new ChartDataItem { Date = new DateTime(2024, 5, 16), Count = 0, Severity = 3 },
                new ChartDataItem { Date = new DateTime(2024, 5, 16), Count = 0, Severity = 2 },
                new ChartDataItem { Date = new DateTime(2024, 5, 16), Count = 0, Severity = 1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 16), Count = 5, Severity = -1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 17), Count = 0, Severity = 3 },
                new ChartDataItem { Date = new DateTime(2024, 5, 17), Count = 0, Severity = 2 },
                new ChartDataItem { Date = new DateTime(2024, 5, 17), Count = 0, Severity = 1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 17), Count = 1, Severity = -1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 18), Count = 0, Severity = 3 },
                new ChartDataItem { Date = new DateTime(2024, 5, 18), Count = 0, Severity = 2 },
                new ChartDataItem { Date = new DateTime(2024, 5, 18), Count = 0, Severity = 1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 18), Count = 0, Severity = -1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 19), Count = 0, Severity = 3 },
                new ChartDataItem { Date = new DateTime(2024, 5, 19), Count = 0, Severity = 2 },
                new ChartDataItem { Date = new DateTime(2024, 5, 19), Count = 0, Severity = 1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 19), Count = 0, Severity = -1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 20), Count = 0, Severity = 3 },
                new ChartDataItem { Date = new DateTime(2024, 5, 20), Count = 0, Severity = 2 },
                new ChartDataItem { Date = new DateTime(2024, 5, 20), Count = 0, Severity = 1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 20), Count = 0, Severity = -1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 21), Count = 0, Severity = 3 },
                new ChartDataItem { Date = new DateTime(2024, 5, 21), Count = 0, Severity = 2 },
                new ChartDataItem { Date = new DateTime(2024, 5, 21), Count = 0, Severity = 1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 21), Count = 0, Severity = -1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 22), Count = 0, Severity = 3 },
                new ChartDataItem { Date = new DateTime(2024, 5, 22), Count = 0, Severity = 2 },
                new ChartDataItem { Date = new DateTime(2024, 5, 22), Count = 0, Severity = 1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 22), Count = 0, Severity = -1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 23), Count = 0, Severity = 3 },
                new ChartDataItem { Date = new DateTime(2024, 5, 23), Count = 0, Severity = 2 },
                new ChartDataItem { Date = new DateTime(2024, 5, 23), Count = 0, Severity = 1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 23), Count = 0, Severity = -1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 24), Count = 0, Severity = 3 },
                new ChartDataItem { Date = new DateTime(2024, 5, 24), Count = 0, Severity = 2 },
                new ChartDataItem { Date = new DateTime(2024, 5, 24), Count = 0, Severity = 1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 24), Count = 0, Severity = -1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 25), Count = 0, Severity = 3 },
                new ChartDataItem { Date = new DateTime(2024, 5, 25), Count = 0, Severity = 2 },
                new ChartDataItem { Date = new DateTime(2024, 5, 25), Count = 0, Severity = 1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 25), Count = 0, Severity = -1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 26), Count = 0, Severity = 3 },
                new ChartDataItem { Date = new DateTime(2024, 5, 26), Count = 0, Severity = 2 },
                new ChartDataItem { Date = new DateTime(2024, 5, 26), Count = 0, Severity = 1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 26), Count = 0, Severity = -1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 27), Count = 0, Severity = 2 },
                new ChartDataItem { Date = new DateTime(2024, 5, 27), Count = 0, Severity = 1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 27), Count = 1, Severity = -1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 27), Count = 1, Severity = 3 },
                new ChartDataItem { Date = new DateTime(2024, 5, 28), Count = 0, Severity = 3 },
                new ChartDataItem { Date = new DateTime(2024, 5, 28), Count = 0, Severity = 2 },
                new ChartDataItem { Date = new DateTime(2024, 5, 28), Count = 0, Severity = 1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 28), Count = 0, Severity = -1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 29), Count = 0, Severity = 3 },
                new ChartDataItem { Date = new DateTime(2024, 5, 29), Count = 0, Severity = 2 },
                new ChartDataItem { Date = new DateTime(2024, 5, 29), Count = 0, Severity = 1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 29), Count = 0, Severity = -1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 30), Count = 0, Severity = 3 },
                new ChartDataItem { Date = new DateTime(2024, 5, 30), Count = 0, Severity = 2 },
                new ChartDataItem { Date = new DateTime(2024, 5, 30), Count = 0, Severity = 1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 30), Count = 0, Severity = -1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 31), Count = 0, Severity = 3 },
                new ChartDataItem { Date = new DateTime(2024, 5, 31), Count = 0, Severity = 2 },
                new ChartDataItem { Date = new DateTime(2024, 5, 31), Count = 0, Severity = 1 },
                new ChartDataItem { Date = new DateTime(2024, 5, 31), Count = 0, Severity = -1 }
            };
        }
    }
}
