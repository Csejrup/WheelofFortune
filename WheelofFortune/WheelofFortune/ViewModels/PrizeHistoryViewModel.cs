using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WheelofFortune.Models;
using Xamarin.Forms;

namespace WheelofFortune.ViewModels
{
    public class PrizeHistoryViewModel : BaseViewModel
    {
        ObservableCollection<Prize> prizes = new ObservableCollection<Prize>();
        public ObservableCollection<Prize> Prizes { get { return prizes; } }

        #region
        public ICommand RefreshCommand { get; private set; }
        #endregion

        public PrizeHistoryViewModel(){
     

            LoadPrizes();
            RefreshCommand = new Command(async () => await Refresh());
        }

        void LoadPrizes()
        {
           
            Prizes.Add(new Prize { Points = 100, Date = DateTime.Now });
            Prizes.Add(new Prize { Points = 100, Date = DateTime.Now });
            Prizes.Add(new Prize { Points = 100, Date = DateTime.Now });
            Prizes.Add(new Prize { Points = 100, Date = DateTime.Now });
            Prizes.Add(new Prize { Points = 100, Date = DateTime.Now });

        }
       async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(200);

            LoadPrizes();
            IsBusy = false;

        }
    }
}
