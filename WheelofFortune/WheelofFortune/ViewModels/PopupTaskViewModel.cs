using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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

        #region Commands
        public ICommand ClaimPrizeCommand { get; set; }
        #endregion

        public PopupTaskViewModel(string Number)
        {
            this.number = Number;
            ClaimPrizeCommand = new Command(async () => await ClaimPrize());
        }
        /// <summary>
        /// Async Method for Claíming the points 
        /// and put it into SQLite Database
        /// </summary>
        /// <returns></returns>
       public async Task ClaimPrize()
        {
            try
            {
                
                Console.WriteLine(number);

                await PopupNavigation.Instance.PopAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"ClaimPrize THREW: {ex.Message}");
            }
        }

    }
}
