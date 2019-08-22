using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using AppVagas.Models;
using Xamarin.Forms;

namespace AppVagas.DAO
{
    public class AcessoBanco
    {
        private SQLiteConnection _connection;

        public AcessoBanco()
        {
            var dep = DependencyService.Get<ICaminho>();
            string db = dep.GetCaminho("database.sqlite");

            _connection = new SQLiteConnection(db);

            _connection.CreateTable<Vagas>();

        }

        public void CadastrarVaga(Vagas vaga)
        {
            _connection.Insert(vaga);
        }

        public void ExcluirVaga(Vagas vaga)
        {
            _connection.Delete(vaga);
        }

        public void AtualizarVagas(Vagas vaga)
        {
            _connection.Update(vaga);
        }

        public List<Vagas> ListaVagas()
        {
            return _connection.Table<Vagas>().ToList();
        }

        public Vagas ListVagasById(int id)
        {
            return _connection.Table<Vagas>().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Vagas> Pesquisar(string palavra)
        {
            return _connection.Table<Vagas>().Where(x => x.NomeVaga.Contains(palavra)).ToList();
        }
    }
}
