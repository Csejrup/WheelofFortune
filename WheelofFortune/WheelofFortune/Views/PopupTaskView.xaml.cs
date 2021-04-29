using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WheelofFortune.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WheelofFortune.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupTaskView : PopupPage
    {
        public PopupTaskView(string number)
        {
            InitializeComponent();
            BindingContext = new PopupTaskViewModel(number);
        }
      

    }
}