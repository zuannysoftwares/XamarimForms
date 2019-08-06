using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using TestDrive.Midia;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class MasterViewModel : BaseViewModel
    {
        public string Nome
        {
            get { return this._usuario.nome; }
            set { this._usuario.nome = value; }
        }

        public string DataNascimento
        {
            get { return this._usuario.dataNascimento; }
            set { this._usuario.dataNascimento = value; }
        }

        public string Telefone
        {
            get { return this._usuario.telefone; }
            set { this._usuario.telefone = value; }
        }

        public string Email
        {
            get { return this._usuario.email; }
            set { this._usuario.email = value; }
        }

        private bool editar = false;

        public bool Editar
        {
            get { return editar; }
            private set { editar = value; OnPropertyChanged(nameof(Editar)); }
        }

        public ICommand EditarInfoPerfil { get; private set; }
        public ICommand EditarPerfil { get; private set; }
        public ICommand SalvarEdicaoPerfil { get; private set; }
        public ICommand TirarFoto { get; private set; }

        private ImageSource fotoPerfil = "perfil.png";

        public ImageSource FotoPerfil
        {
            get { return fotoPerfil; }
            private set { fotoPerfil = value; OnPropertyChanged(); }//usado pra setar a foto do perfil ao tirar com a câmera do fone }
        }

        private readonly Usuario _usuario;

        public MasterViewModel(Usuario usuario)
        {
            this._usuario = usuario;
            DefinirComandos(usuario);
        }

        private void DefinirComandos(Usuario usuario)
        {
            EditarPerfil = new Command(() =>
            {
                MessagingCenter.Send<Usuario>(usuario, "EditarPerfil");
            });

            SalvarEdicaoPerfil = new Command(() =>
            {
                this.Editar = false;
                MessagingCenter.Send<Usuario>(usuario, "SucessoSalvarPerfil");
            });

            EditarInfoPerfil = new Command(() =>
            {
                this.Editar = true;
            });

            TirarFoto = new Command(() =>
            {
                DependencyService.Get<ICamera>().TirarFoto();
            });

            MessagingCenter.Subscribe<byte[]>(this, "FotoTirada", (bytes) =>
            {
                FotoPerfil = ImageSource.FromStream(
                    () => new MemoryStream(bytes));
            });
        }



    }
}
