using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WheelofFortune.Models;
using WheelofFortune.Services;
using Xamarin.Forms;

namespace WheelofFortune.ViewModels
{
    public class PrizeHistoryViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Prize> Prize { get; set; }
        ObservableCollection<Prize> prizes = new ObservableCollection<Prize>();
        public ObservableCollection<Prize> Prizes { get { return prizes; } }

        #region
        public ICommand RefreshCommand { get; private set; }
        #endregion

        public PrizeHistoryViewModel()
        {
            Prize = new ObservableRangeCollection<Prize>();

            LoadPrizes();
            RefreshCommand = new Command(async () => await Refresh());
        }

        async void LoadPrizes()
        {
            try
            {
                var prizes = await PrizeService.GetPrizes();
                foreach (var item in prizes)
                {
                    Prize.Add(item);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"ClaimPrize THREW: {ex.Message}");

            }
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
