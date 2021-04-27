using System.IO;
using System;
using WheelofFortune.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WheelofFortune.Data;
namespace WheelofFortune
{
    public partial class App : Application
    {
        static WheelofFortuneDatabase database;
        // Create the database connection as a singleton.
        public static WheelofFortuneDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new WheelofFortuneDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "WheelofFortune.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            DependencyService.Register<MockDataPrize>();
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
