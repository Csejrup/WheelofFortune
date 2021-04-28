using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using WheelofFortune.Interfaces;
using WheelofFortune.Models;

namespace WheelofFortune.ViewModels
{
    public class PrizeHistoryViewModel : BaseViewModel
    {
       
        private Prize prize;
        public Prize Prize
        {
            get { return prize; }
            set { prize = value; OnPropertyChanged(); }
        }

        private IPrizeData _prizeData;
        private bool _isDataLoaded;

        public ObservableCollection<PrizeViewModel> Prizes { get; private set; } = new ObservableCollection<PrizeViewModel>();

        public async Task LoadPrizeData()
        {
            if (_isDataLoaded)
            {
                return;
            }
            _isDataLoaded = true;
            var prizes = await _prizeData.GetPrizesAsync();
            foreach (var prize in prizes)
            {
                Prizes.Add(new PrizeViewModel(prize));
            }
        }
    }
}
