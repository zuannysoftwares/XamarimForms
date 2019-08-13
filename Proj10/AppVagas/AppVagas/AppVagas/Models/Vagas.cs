using SQLite;
using System;
using System.Collections.Generic;
using System.Text;


namespace AppVagas.Models
{
    [Table("Vaga")]
    public class Vagas
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string NomeVaga { get; set; }
        public short Quantidade { get; set; }
        public string Cidade { get; set; }
        public double Salario { get; set; }
        public string DescricaoVaga { get; set; }
        public string TipoContratacao { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Empresa { get; set; }

    }
}
