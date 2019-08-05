using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheView : ContentPage
    {
        private int FREIO_ABS = 890;
        private int AR_CONDICIONADO = 1172;
        private int AUTO_RADIO = 548;

        public Veiculo Carro { get; set; }

        public string TextoFreio
        {
            get
            {
                return string.Format("Freio ABS - R$: {0} reais", FREIO_ABS);
            }
        }

        bool temFreioABS;
        public bool TemFreioAbs
        {
            get
            {
                return temFreioABS;
            }
            set
            {
                temFreioABS = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Total));
            }
        }

        bool temArCond;
        public bool TemArCond
        {
            get
            {
                return temArCond;
            }
            set
            {
                temArCond = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Total));
            }
        }

        bool temRadio;
        public bool TemRadio
        {
            get
            {
                return temRadio;
            }
            set
            {
                temRadio = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Total));
            }
        }

        public string TextoArCond
        {
            get
            {
                return string.Format("Ar condicionado - R$: {0} reais", AR_CONDICIONADO);
            }
        }

        public string TextoRadio
        {
            get
            {
                return string.Format("Auto Rádio USB - R$: {0} reais", AUTO_RADIO);
            }
        }

        public string Total
        {
            get
            {
                return string.Format("Valor total: R$ {0}", Carro.Preco + (TemFreioAbs ? FREIO_ABS : 0) + (TemArCond ? AR_CONDICIONADO : 0) + (TemRadio ? AUTO_RADIO : 0));
            }
        }


        public DetalheView(Veiculo carro)
        {
            InitializeComponent();

            this.Carro = carro;
            this.BindingContext = this;
        }

        private void TelaProximo(object sender, EventArgs args)
        {
            Navigation.PushAsync(new AgendamentoView(this.Carro));
        }
    }
}