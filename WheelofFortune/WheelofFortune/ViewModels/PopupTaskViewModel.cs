using Rg.Plugins.Popup.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using WheelofFortune.Services;

namespace WheelofFortune.ViewModels
{
    /// <summary>
    /// Class - ViewModel - for the PopupTaskView
    /// </summary>
    public class PopupTaskViewModel : BaseViewModel
    {
        #region Properties
        public int Id { get; set; }

        int points;
        public int Points
        {
            get => points; set
            {
                SetProperty(ref points, value);
            }
        }
        DateTime datetime;
        public DateTime Datetime
        {
            get => datetime; set
            {
                SetProperty(ref datetime, value);
            }
        }

        #endregion
        #region Commands
        public ICommand AddPointsCommand { get; private set; }

        #endregion
        public PopupTaskViewModel(string number)
        {
            this.points = Int32.Parse(number);
            AddPointsCommand = new Command(async () => await AddPrizePoints());
            
        }
        /// <summary>
        /// Async Method for Claíming the points 
        /// and insert it into SQLite Database
        /// </summary>
        /// <returns></returns>
        async Task AddPrizePoints()
        {
            try
            {
                datetime = DateTime.Now;
                await PrizeService.AddPrize(points, datetime).ConfigureAwait(false);
                
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
