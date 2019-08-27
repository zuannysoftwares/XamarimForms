using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ZYHotelAndroid
{
    public class Conexao
    {
        //public string conec = "SERVER=mysql465.umbler.com; DATABASE=hotel_sistema2; UID=hugohotel; PWD=sistemahotelhugo; PORT=41890;";
        //public MySqlConnection con = null;

        public string conn = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ZYHotel; user id=sa; password=123456;MultipleActiveResultSets=true";

        public SqlConnection conex = null;

        public void AbreConexao()
        {
            try
            {
                conex = new SqlConnection(conn);
                conex.Open();
                //Toast.MakeText(Application.Context, "Conectado no SQL Server", ToastLength.Long).Show();
            }
            catch (Exception e)
            {
                Toast.MakeText(Application.Context, "Erro ao conectar " + e, ToastLength.Long).Show();
            }
        }

        public void FechaConexao()
        {
            try
            {
                conex = new SqlConnection(conn);
                conex.Close();
            }
            catch (Exception e)
            {
                Toast.MakeText(Application.Context, "Erro ao fechar conexão " + e, ToastLength.Long).Show();
            }
        }

    }
}