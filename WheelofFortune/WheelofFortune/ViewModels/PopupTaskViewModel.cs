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
        private Sector number;
        public Sector Number
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

        public PopupTaskViewModel()
        {
            ClaimPrizeCommand = new Command(async () => await ClaimPrize());
        }
        /// <summary>
        /// Async Method for claiming a prize (number) from the wheel of fortune
        /// </summary>
        /// <returns></returns>
       public async Task ClaimPrize()
        {
            try
            {
                string number = Number?.number.ToString();
                Console.WriteLine(number);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"ClaimPrize THREW: {ex.Message}");
            }
        }

    }
}
