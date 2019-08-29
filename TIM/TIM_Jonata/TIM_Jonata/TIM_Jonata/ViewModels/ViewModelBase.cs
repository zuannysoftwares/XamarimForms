using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace TIM_Jonata.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }
        public ViewModelBase()
        {

        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;

            //ResolveDependencies();
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }

        protected bool CanExecute()
        {
            return !IsBusy;
        }

        protected async void Voltar()
        {
            await NavigationService.GoBackAsync();
        }

        protected async void Sair()
        {
            await NavigationService.NavigateAsync("/NavigationPage/MainPage");
        }
    }
}
