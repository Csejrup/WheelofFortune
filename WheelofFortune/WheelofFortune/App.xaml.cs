using System.IO;
using System;
using WheelofFortune.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WheelofFortune
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
