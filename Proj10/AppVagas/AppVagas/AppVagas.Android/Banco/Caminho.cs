using AppVagas.DAO;
using AppVagas.Droid.Banco;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(Caminho))]
namespace AppVagas.Droid.Banco
{
    public class Caminho : ICaminho
    {
        public string GetCaminho(string NomeBanco)
        {
            string pastaDB = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string db = Path.Combine(pastaDB, NomeBanco);

            return db;
        }
    }

}