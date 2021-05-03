using MvvmHelpers;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using WheelofFortune.Models;
using WheelofFortune.Services;
using Xamarin.Forms;

namespace WheelofFortune.ViewModels
{
    /// <summary>
    /// Class - ViewModel - for the PrizeHistoryPage View
    /// </summary>
    public class PrizeHistoryViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Prize> Prize { get; set; }

        
        #region Commands
        public ICommand RefreshCommand { get; private set; }
        #endregion 

        public PrizeHistoryViewModel()
        {
            Prize = new ObservableRangeCollection<Prize>();

            LoadPrizes();
            RefreshCommand = new Command(async () => await Refresh());
        }
        /// <summary>
        /// Async Method for retrieving data from database through PrizeService
        /// And adding it to generic collection (Prize)
        /// </summary>
        /// <returns></returns>
        private async Task LoadPrizes()
        {
            try
            {
                var prizes = await PrizeService.GetPrizes().ConfigureAwait(false);
                Prize.AddRange(prizes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ClaimPrize THREW: {ex.Message}");
            }
        }
        /// <summary>
        /// Async Method for refreshing the Collection
        /// </summary>
        /// <returns></returns>
       private async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(200);
            Prize.Clear();
            await LoadPrizes();
            IsBusy = false;

        }
    }
}
