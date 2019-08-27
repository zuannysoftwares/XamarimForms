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
using MySql.Data.MySqlClient;

namespace ZYHotelAndroid
{
    [Activity(Label = "Movimentacoes")]
    public class Movimentacoes : Activity
    {
        Variaveis var = new Variaveis();
        Conexao con = new Conexao();

        CalendarView calendar;
        ListView list;
        TextView txtEntrada, txtSaida, txtTotal;
        double totalEntrada, totalSaida, total;
        string dataCalendar;
        List<string> listaMov = new List<string>();
        ArrayAdapter<string> adapter;
        ArrayAdapter<string> adapterSemDados;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Movimentacoes);

            txtEntrada  = FindViewById<TextView>(Resource.Id.txtEntrada);
            txtSaida    = FindViewById<TextView>(Resource.Id.txtSaida);
            txtTotal    = FindViewById<TextView>(Resource.Id.txtTotal);

            calendar = FindViewById<CalendarView>(Resource.Id.data);
            list = FindViewById<ListView>(Resource.Id.lista);

            calendar.DateChange += Calendar_DateChange;

            dataCalendar = DateTime.Today.ToString();

            BuscarData();
        }

        private void Calendar_DateChange(object sender, CalendarView.DateChangeEventArgs e)
        {
            dataCalendar = e.DayOfMonth + "/" + (e.Month + 1) + "/" + e.Year;
            BuscarData();
        }

        private void BuscarData()
        {
            con.AbreConexao();

            MySqlCommand cmdVerificar;
            MySqlDataReader reader;

            cmdVerificar = new MySqlCommand("SELECT * FROM movimentacoes WHERE data = @data", con.conex);
            cmdVerificar.Parameters.AddWithValue("@data", Convert.ToDateTime(dataCalendar));

            reader = cmdVerificar.ExecuteReader();

            list.Adapter = adapterSemDados; //Usado somente para inicializar a lista sem valores
            if (reader.HasRows)
            {
                listaMov.Clear();
                
                while (reader.Read())
                {
                    //Busca as informações do banco
                    listaMov.Add(reader["tipo"].ToString() + "  |  " + reader["movimento"].ToString() + "   |   " + reader["valor"].ToString());
                    adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, listaMov);

                    //Popula um listview
                    list.Adapter = adapter;
                }
            }

            con.FechaConexao();

            TotalEntradas();
            TotalSaidas();
            Totalizar();
        }

        private void TotalEntradas()
        {
            MySqlCommand cmdVerificar;
            MySqlDataReader reader;

            con.AbreConexao();

            cmdVerificar = new MySqlCommand("SELECT id, sum(valor) as valor_total FROM movimentacoes WHERE data = @data and tipo = @tipo", con.conex);
            cmdVerificar.Parameters.AddWithValue("@tipo", "Entrada");
            cmdVerificar.Parameters.AddWithValue("@data", Convert.ToDateTime(dataCalendar));

            reader = cmdVerificar.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader["valor_total"].ToString() == "")
                        totalEntrada = 0;
                    else
                        totalEntrada = Convert.ToDouble(reader["valor_total"].ToString());

                    txtEntrada.Text = "Entradas: " + totalEntrada.ToString("C2");
                }
            }
            con.FechaConexao();
        }

        private void TotalSaidas()
        {
            MySqlCommand cmdVerificar;
            MySqlDataReader reader;

            con.AbreConexao();

            cmdVerificar = new MySqlCommand("SELECT id, sum(valor) as valor_total FROM movimentacoes WHERE data = @data and tipo = @tipo", con.conex);
            cmdVerificar.Parameters.AddWithValue("@tipo", "Saída");
            cmdVerificar.Parameters.AddWithValue("@data", Convert.ToDateTime(dataCalendar));

            reader = cmdVerificar.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader["valor_total"].ToString() == "")
                        totalSaida = 0;
                    else
                        totalSaida = Convert.ToDouble(reader["valor_total"].ToString());

                    txtSaida.Text = "Saídas: " + totalSaida.ToString("C2");
                }
            }
            con.FechaConexao();
        }

        private void Totalizar()
        {
            total = totalEntrada - totalSaida;
            txtTotal.Text = "Total: " + total.ToString("C2");

            if (total < 0)
            {
                txtTotal.SetTextColor(Android.Graphics.Color.Red);
            }
            else
            {
                txtTotal.SetTextColor(Android.Graphics.Color.DarkGreen);
            }
        }
    }
}