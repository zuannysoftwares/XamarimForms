using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

using Xamarin.Forms;
using App_Mimica.Model;

namespace App_Mimica.ViewModel
{
    public class JogoViewModel : INotifyPropertyChanged
    {
        public string NomeGrupo { get; set; }
        private byte _palavraPontuacao;
        public byte PalavraPontuacao
        {
            get
            {
                return _palavraPontuacao;
            } set
            {
                _palavraPontuacao = value;
                OnPropertyChanged("PalavraPontuacao");
            }
        }

        private string _Palavra;
        public string Palavra
        {
            get
            {
                return _Palavra;
            }
            set
            {
                _Palavra = value;
                OnPropertyChanged("Palavra");
            }
        }

        private string _TextoContagem;
        public string TextoContagem
        {
            get
            {
                return _TextoContagem;
            }
            set
            {
                _TextoContagem = value;
                OnPropertyChanged("TextoContagem");
            }
        }

        private bool _IsVisibleContainerContagem;
        public bool IsVisibleContainerContagem
        {
            get
            {
                return _IsVisibleContainerContagem;
            }
            set
            {
                _IsVisibleContainerContagem = value;
                OnPropertyChanged("IsVisibleContainerContagem");
            }
        }

        private bool _IsVisibleContainerIniciar;
        public bool IsVisibleContainerIniciar
        {
            get
            {
                return _IsVisibleContainerIniciar;
            }
            set
            {
                _IsVisibleContainerIniciar = value;
                OnPropertyChanged("IsVisibleContainerIniciar");
            }
        }

        private bool _IsVisibleMostrar;
        public bool IsVisibleMostrar
        {
            get
            {
                return _IsVisibleMostrar;
            }
            set
            {
                _IsVisibleMostrar = value;
                OnPropertyChanged("IsVisibleMostrar");
            }
        }

        public GrupoModel GrupoModel { get; set; }

        public Command MostrarPalavra { get; set; }
        public Command Acertou { get; set; }
        public Command Errou { get; set; }
        public Command Iniciar { get; set; }
        public JogoViewModel(GrupoModel grupo)
        {
            NomeGrupo = grupo.NomeGrupo;
            IsVisibleContainerContagem = false;
            IsVisibleContainerIniciar = false;
            IsVisibleMostrar = true;

            Palavra = "****************";

            GrupoModel = grupo;

            MostrarPalavra  = new Command(MostarPalavraAction);
            Iniciar         = new Command(IniciarAction);
            Acertou         = new Command(AcertouAction);
            Errou           = new Command(ErrouAction);
        }

        Random random = new Random();

        private void MostarPalavraAction()
        {
            PalavraPontuacao = 3;
            Palavra = "Sentar";

            var numNivel = Armazenamento.Armazenamento.Jogo.NivelNumerico;
            
            switch (numNivel)
            {
                case 0://ALEATRóIO
                    Random rdAl = new Random();
                    int niv = rdAl.Next(0, 2);
                    int indAl = rdAl.Next(0, Armazenamento.Armazenamento.Palavras[niv].Length);

                    Palavra = Armazenamento.Armazenamento.Palavras[niv][indAl];
                    PalavraPontuacao = (byte)((niv == 0) ? 1 : (niv == 1) ? 3 : 5);

                    break;

                case 1: //FÁCIL
                    Random rd = new Random();
                    int indFacil = rd.Next(0, Armazenamento.Armazenamento.Palavras[numNivel = -1].Length);

                    Palavra = Armazenamento.Armazenamento.Palavras[numNivel = -1][indFacil];
                    PalavraPontuacao = 1;

                    break;

                case 2: //MÉDIO
                    Random rdMedio= new Random();
                    int indMedio = rdMedio.Next(0, Armazenamento.Armazenamento.Palavras[numNivel = -1].Length);

                    Palavra = Armazenamento.Armazenamento.Palavras[numNivel = -1][indMedio];
                    PalavraPontuacao = 3;

                    break;

                case 3://DIFÍCIL
                    Random rdDificil = new Random();
                    int indDificil = rdDificil.Next(0, Armazenamento.Armazenamento.Palavras[numNivel = -1].Length);

                    Palavra = Armazenamento.Armazenamento.Palavras[numNivel = -1][indDificil];
                    PalavraPontuacao = 5;

                    break;

                default:
                    break;
            }

            IsVisibleMostrar = false;
            IsVisibleContainerIniciar = true;
        }

        private void IniciarAction()
        {
            IsVisibleContainerIniciar = false;
            IsVisibleContainerContagem = true;

            int i = Armazenamento.Armazenamento.Jogo.Tempo;
            Device.StartTimer(TimeSpan.FromSeconds(1), () => 
            {
                TextoContagem = i.ToString();
                i--;//Contagem regressiva

                if(i < 0)
                {
                    TextoContagem = "Tempo esgotado";
                }

                return true;
            });
        }

        private void AcertouAction()
        {
            GrupoModel.Pontuacao += PalavraPontuacao;

            GoProximoGrupo();
        }

        private void GoProximoGrupo()
        {
            GrupoModel group;
            if (Armazenamento.Armazenamento.Jogo.Grupo1 == GrupoModel)
            {
                group = Armazenamento.Armazenamento.Jogo.Grupo2;
            }
            else
            {
                group = Armazenamento.Armazenamento.Jogo.Grupo1;
                Armazenamento.Armazenamento.RodadaAtual++;
            }
            if(Armazenamento.Armazenamento.RodadaAtual > Armazenamento.Armazenamento.Jogo.Rodadas)
            {
                App.Current.MainPage = new View.Resultado();
            }
            {
                App.Current.MainPage = new View.Jogo(group);
            }
        }

        private void ErrouAction()
        {
            GoProximoGrupo();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string NameProperty)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(NameProperty));
            }
        }
    }
}
