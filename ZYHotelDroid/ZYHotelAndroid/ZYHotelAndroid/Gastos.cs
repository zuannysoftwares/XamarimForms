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
    [Activity(Label = "Gastos")]
    public class Gastos : Activity
    {
        EditText edtGasto, edtValor;
        Button btnSalvar;
        Conexao con = new Conexao();
        Variaveis var = new Variaveis();
        ListView lista;

        string ultimoIdGasto;

        List<string> listaGasto = new List<string>();
        ArrayAdapter<string> adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Gastos);

            edtGasto    = FindViewById<EditText>(Resource.Id.edtGasto);
            edtValor    = FindViewById<EditText>(Resource.Id.edtValor);
            btnSalvar   = FindViewById<Button>(Resource.Id.btnSalvar);
            lista       = FindViewById<ListView>(Resource.Id.lista);

            //Recupera o nome do usuário vindo do MENU
            var.nomeUsuario = Intent.GetStringExtra("nome");

            btnSalvar.Click += BtnSalvar_Click;

            Listar();
        }

        private void Listar()
        {
            con.AbreConexao();

            MySqlCommand cmdVerificar;
            MySqlDataReader reader;

            cmdVerificar = new MySqlCommand("SELECT * FROM gastos WHERE data = curDate()", con.conex);

            reader = cmdVerificar.ExecuteReader();

            if (reader.HasRows)
            {
                listaGasto.Clear();

                while (reader.Read())
                {
                    //Busca as informações do banco
                    listaGasto.Add(reader["descricao"].ToString() + "  |  " + Convert.ToDouble(reader["valor"].ToString()));
                    adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, listaGasto);

                    //Popula um listview
                    lista.Adapter = adapter;
                }
            }

            con.FechaConexao();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            con.AbreConexao();

            MySqlCommand cmdVerificar, cmd;
            MySqlDataReader reader;
            string sql;

            cmd = new MySqlCommand("INSERT INTO gastos (descricao, valor, funcionario, data) VALUES(@descricao, @valor, @funcionario, curDate())", con.conex);
            cmd.Parameters.AddWithValue("@descricao", edtGasto.Text);
            cmd.Parameters.AddWithValue("@valor", Convert.ToDouble(edtValor.Text));
            cmd.Parameters.AddWithValue("@funcionario", var.nomeUsuario);
            cmd.ExecuteNonQuery();


            //RECUPERAR O ULTIMO ID DO GASTO
            con.AbreConexao();
            cmdVerificar = new MySqlCommand("SELECT id FROM gastos order by id desc LIMIT 1", con.conex);

            reader = cmdVerificar.ExecuteReader();

            if (reader.HasRows)
            {
                //EXTRAINDO INFORMAÇÕES DA CONSULTA DO ULTIMO ID DO GASTO
                while (reader.Read())
                {
                    ultimoIdGasto = Convert.ToString(reader["id"]);
                }
            }

            //LANÇAR O GASTO NAS MOVIMENTAÇÕES
            con.AbreConexao();
            sql = "INSERT INTO movimentacoes (tipo, movimento, valor, funcionario, data, id_movimento) VALUES (@tipo, @movimento, @valor, @funcionario, curDate(), @id_movimento)";
            cmd = new MySqlCommand(sql, con.conex);

            cmd.Parameters.AddWithValue("@tipo", "Saída");
            cmd.Parameters.AddWithValue("@movimento", "Gasto");
            cmd.Parameters.AddWithValue("@valor", Convert.ToDouble(edtValor.Text));
            cmd.Parameters.AddWithValue("@funcionario", var.nomeUsuario);
            cmd.Parameters.AddWithValue("@id_movimento", ultimoIdGasto);
            cmd.ExecuteNonQuery();

            con.FechaConexao();

            Listar();
            Toast.MakeText(Application.Context, "Salvo com Sucesso!!", ToastLength.Long).Show();

            edtGasto.Text = "";
            edtValor.Text = "";
            edtGasto.RequestFocus();
        }
    }
}