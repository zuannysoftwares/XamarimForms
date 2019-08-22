using AppVagas.DAO;
using AppVagas.iOS.Banco;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(CaminhoIOS))]
namespace AppVagas.iOS.Banco
{
    public class CaminhoIOS : ICaminho
    {
        public string GetCaminho(string NomeBanco)
        {
            string pastaDB = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string iosLibrary = Path.Combine(pastaDB, "..", "Library");

            string db = Path.Combine(iosLibrary, NomeBanco);

            return db;
        }
    }
}