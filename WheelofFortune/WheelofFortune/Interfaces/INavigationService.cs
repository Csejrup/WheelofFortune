using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WheelofFortune.ViewModels;
using Xamarin.Forms;

namespace WheelofFortune.Services
{
    public interface INavigationService
    {
        Task<Page> RemoveViewFromStack();
        Task BackToMainPage();
        Task NavigateTo<TVM>() where TVM : BaseViewModel;
    }
}
