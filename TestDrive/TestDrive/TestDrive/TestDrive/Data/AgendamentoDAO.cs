using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using TestDrive.Models;
using TestDrive.Views;

namespace TestDrive.Data
{
    public class AgendamentoDAO
    {
        private readonly SQLiteConnection _conexao;
        private List<Agendamento> lista;

        public List<Agendamento> Lista
        {
            get
            {
                return _conexao.Table<Agendamento>().ToList();
            }
            private set { lista = value; }
        }

        public AgendamentoDAO(SQLiteConnection connection)
        {
            this._conexao = connection;
            this._conexao.CreateTable<Agendamento>();
        }

        public void Salvar(Agendamento agendamento)
        {
            if (_conexao.Find<Agendamento>(agendamento.ID) == null)
            {
                _conexao.Insert(agendamento);
            }
            else
            {
                _conexao.Update(agendamento);
            }
        }
    }
}
