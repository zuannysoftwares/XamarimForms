using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace TIM_Jonata.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private string usuario;
        private string senha;

        public string Usuario
        {
            get => usuario;
            set => SetProperty(ref usuario, value);
        }

        public string Senha
        {
            get => senha;
            set => SetProperty(ref senha, value);
        }

        public DelegateCommand LogarCommand { get; }

        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            LogarCommand = new DelegateCommand(Logar, CanExecute).ObservesProperty(() => IsBusy);
        }

        private async void Logar()
        {
            await NavigationService.NavigateAsync("HomePage");
        }
    }
}
