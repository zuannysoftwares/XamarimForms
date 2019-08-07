using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using TestDrive.Data;
using TestDrive.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_Android))]
namespace TestDrive.Droid
{
    public class SQLite_Android : ISqlite
    {
        private const string nomeArqDB = "Agendamento.db3";
        public SQLiteConnection RetornaConexao()
        {
            var caminhoDB = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.Path, nomeArqDB);

            return new SQLite.SQLiteConnection(caminhoDB);
        }
    }
}