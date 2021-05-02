using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WheelofFortune.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WheelofFortune
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //Routing through a tabbar. 
            Routing.RegisterRoute(nameof(WheelPage), typeof(WheelPage));
            Routing.RegisterRoute(nameof(PrizeHistoryPage), typeof(PrizeHistoryPage));
        }
    }
}