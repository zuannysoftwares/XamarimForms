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
    [Activity(Label = "Menu")]
    public class Menu : Activity
    {
        ImageView imgUsuario, imgMov;
        TextView txtUsuario, txtCargo, txtEntrada, txtSaida, txtTotal;
        ImageButton imgGastos, imgMoviment, imgCheckin, imgReservas;

        Variaveis var = new Variaveis();
        Conexao con = new Conexao();

        double totalEntrada, totalSaida, total;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Menu);

            imgUsuario  = FindViewById<ImageView>(Resource.Id.imgUsuario);
            imgMov      = FindViewById<ImageView>(Resource.Id.imgMov);
            imgGastos   = FindViewById<ImageButton>(Resource.Id.imgGastos);
            imgMoviment = FindViewById<ImageButton>(Resource.Id.imgMoviment);
            imgCheckin  = FindViewById<ImageButton>(Resource.Id.imgCheckIn);
            imgReservas = FindViewById<ImageButton>(Resource.Id.imgReservas);

            txtUsuario  = FindViewById<TextView>(Resource.Id.txtUsuario);
            txtCargo    = FindViewById<TextView>(Resource.Id.txtCargo);
            txtEntrada  = FindViewById<TextView>(Resource.Id.txtEntrada);
            txtSaida    = FindViewById<TextView>(Resource.Id.txtSaida);
            txtTotal    = FindViewById<TextView>(Resource.Id.txtTotal);

            //Recupera os parâmetros vindos da MainActivity
            var.nomeUsuario = Intent.GetStringExtra("nome");
            var.cargoUsuario = Intent.GetStringExtra("cargo");

            //Coloca as imagens para os comandos do sistema
            imgUsuario.SetImageResource(Resource.Drawable.users);
            imgMov.SetImageResource(Resource.Drawable.movimentacoes);
            imgGastos.SetImageResource(Resource.Drawable.Gastos);
            imgMoviment.SetImageResource(Resource.Drawable.Movimentacao);
            imgCheckin.SetImageResource(Resource.Drawable.CheckIn);
            imgReservas.SetImageResource(Resource.Drawable.Reservas);

            //Retorna os dados do banco
            txtUsuario.Text = var.nomeUsuario;
            txtCargo.Text   = var.cargoUsuario;

            //Seta uma cor para os controles Entrada e Saída ao logar no sistema
            txtEntrada.SetTextColor(Android.Graphics.Color.DarkGreen);
            txtSaida.SetTextColor(Android.Graphics.Color.Red);

            imgMoviment.Click += ImgMoviment_Click;
            imgGastos.Click += ImgGastos_Click;
            imgReservas.Click += ImgReservas_Click;
            imgCheckin.Click += ImgCheckin_Click;

            TotalEntradas();
            TotalSaidas();
            Totalizar();
        }

        private void ImgCheckin_Click(object sender, EventArgs e)
        {
            //TODO: Listar CHECKIN
        }

        private void ImgReservas_Click(object sender, EventArgs e)
        {
            //TODO: LISTAR RESERVAS
        }

        private void ImgGastos_Click(object sender, EventArgs e)
        {
            var gastos = new Intent(this, typeof(Gastos));
            gastos.PutExtra("nome", var.nomeUsuario);
            StartActivity(gastos);
        }

        private void ImgMoviment_Click(object sender, EventArgs e)
        {
            var mov = new Intent(this, typeof(Movimentacoes));
            StartActivity(mov);
        }

        private void TotalEntradas()
        {
            MySqlCommand cmdVerificar;
            MySqlDataReader reader;

            con.AbreConexao();

            cmdVerificar = new MySqlCommand("SELECT id, sum(valor) as valor_total FROM movimentacoes WHERE data = curDate() and tipo = @tipo", con.conex);
            cmdVerificar.Parameters.AddWithValue("@tipo", "Entrada");

            reader = cmdVerificar.ExecuteReader();

            if(reader.HasRows)
            {
                while(reader.Read())
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

            cmdVerificar = new MySqlCommand("SELECT id, sum(valor) as valor_total FROM movimentacoes WHERE data = curDate() and tipo = @tipo", con.conex);
            cmdVerificar.Parameters.AddWithValue("@tipo", "Saída");

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