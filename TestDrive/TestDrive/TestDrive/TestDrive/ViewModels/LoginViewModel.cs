using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class LoginViewModel
    {
        private string usuario;

        public string Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
                ((Command)LoginApp).ChangeCanExecute();//Habilita o botão dde entrar
            }
        }

        private string senha;

        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                ((Command)LoginApp).ChangeCanExecute();//Habilita o botão dde entrar
            }
        }

        public ICommand LoginApp { get; private set; }

        public LoginViewModel()
        {
            LoginApp = new Command(async () =>
            {
                var loginService = new LoginService();
                await loginService.Logar(new Login(usuario, senha));
            }, () =>
            {
                return (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(senha) ? true : false);
            });
        }

        
    }
}
