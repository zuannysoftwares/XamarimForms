using AppVagas.DAO;
using AppVagas.UWP.Banco;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(CaminhoUWP))]
namespace AppVagas.UWP.Banco
{
    public class CaminhoUWP : ICaminho
    {
        public string GetCaminho(string NomeBanco)
        {
            string pastaDB = ApplicationData.Current.LocalFolder.Path;

            string db = Path.Combine(pastaDB, NomeBanco);

            return db;
        }
    }
}
