using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.Models
{
    public class Veiculo
    {
        public int FREIO_ABS = 890;
        public int AR_CONDICIONADO = 1172;
        public int AUTO_RADIO = 548;
        public decimal Preco { get; set; }
        public string PrecoFormatado
        {
            get
            {
                return string.Format("R$ {0}", Preco);
            }
        }
        public string Nome { get; set; }
        public bool temFreioAbs { get; set; }
        public bool temArCond { get; set; }
        public bool temRadio { get; set; }

        public string PrecoTotalFormatado
        {
            get
            {
                return string.Format("Valor total: R$ {0}", 
                    Preco 
                    + (temFreioAbs ? FREIO_ABS : 0) 
                    + (temArCond ? AR_CONDICIONADO : 0) 
                    + (temRadio ? AUTO_RADIO : 0)
                    );
            }
        }


    }
}
