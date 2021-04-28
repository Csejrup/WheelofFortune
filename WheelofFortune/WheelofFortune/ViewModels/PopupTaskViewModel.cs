using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WheelofFortune.Interfaces;
using WheelofFortune.Models;
using Xamarin.Forms;

namespace WheelofFortune.ViewModels
{
    public class PopupTaskViewModel : BaseViewModel
    {
        #region Properties
        private string number;
        public string Number
        {
            get => number; set
            {
                SetProperty(ref number, value);
            }
        }
        #endregion
        private Prize prize;
        public Prize Prize
        {
            get { return prize; }
            set { prize = value; OnPropertyChanged(); }
        }

        private PrizeViewModel _viewModel;
        private IPrizeData _prizeData;
        #region Commands
        public ICommand AddPrizeCommand { get; private set; }
        
        #endregion
        public PopupTaskViewModel(IPrizeData prizeData, PrizeViewModel viewModel)
        {
            _viewModel = viewModel;
            _prizeData = prizeData;
            AddPrizeCommand = new Command(async () => await AddPrize());
        }
        public PopupTaskViewModel()
        {
            
        }
        /// <summary>
        /// Async Method for Claíming the points 
        /// and put it into SQLite Database
        /// </summary>
        /// <returns></returns>
        public async Task AddPrize()
        {
            Prize = new Prize
            {
                Id = _viewModel.Id,
                Number = _viewModel.Number,
                Date = _viewModel.Datetime
            };

            //await PopupNavigation.Instance.PopAsync();
            try
            {
                if(Prize.Id == 0)
                {
                    await _prizeData.AddPrize(Prize).ConfigureAwait(false);
                }
                else
                {
                    await _prizeData.UpdatePrize(Prize).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ClaimPrize THREW: {ex.Message}");
                
            }
            finally
            {
                await PopupNavigation.Instance.PopAsync();
            }
        }
    }
}
