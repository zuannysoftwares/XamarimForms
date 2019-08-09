using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class DetalheViewModel : BaseViewModel
    {
        public Veiculo Carro { get; set; }

        public DetalheViewModel(Veiculo carro)
        {
            this.Carro = carro;
            ProximoComando = new Command(() =>
            {
                MessagingCenter.Send(carro, "Proximo");
            });
        }

        public string TextoFreio
        {
            get
            {
                return string.Format("Freio ABS - R$: {0} reais", Carro.FREIO_ABS);
            }
        }

        public bool TemFreioAbs
        {
            get
            {
                return Carro.temFreioAbs;
            }
            set
            {
                Carro.temFreioAbs = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Total));
            }
        }

        public bool TemArCond
        {
            get
            {
                return Carro.temArCond;
            }
            set
            {
                Carro.temArCond = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Total));
            }
        }

        public bool TemRadio
        {
            get
            {
                return Carro.temRadio;
            }
            set
            {
                Carro.temRadio = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Total));
            }
        }

        public string TextoArCond
        {
            get
            {
                return string.Format("Ar condicionado - R$: {0} reais", Carro.AR_CONDICIONADO);
            }
        }

        public string TextoRadio
        {
            get
            {
                return string.Format("Auto Rádio USB - R$: {0} reais", Carro.AUTO_RADIO);
            }
        }

        public string Total
        {
            get
            {
                return Carro.PrecoTotalFormatado;
            }
        }

        public ICommand ProximoComando { get; set; }
    }
}
