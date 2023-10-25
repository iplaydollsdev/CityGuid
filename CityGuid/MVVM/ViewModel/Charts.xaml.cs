using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CityGuid.MVVM.View
{
    /// <summary>
    /// Interaction logic for Charts.xaml
    /// </summary>
    public partial class Charts : Window
    {
        public Charts(OrganizationFinance organizationFinance)
        {
            InitializeComponent();

            FillChartData(RevenueSeries, organizationFinance.Revenue);
            FillChartData(ExpensesSeries, organizationFinance.Expenses);
            FillChartData(ProfitSeries, organizationFinance.Profit);
        }
        private void FillChartData(LineSeries line, List<KeyValuePair<string, int>> data)
        {
            line.ItemsSource = data;
        }
    }
}
