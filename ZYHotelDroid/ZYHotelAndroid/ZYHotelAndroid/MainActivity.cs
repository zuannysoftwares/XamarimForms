using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using System.Data.SqlClient;
using Android.Content;
using MySql.Data.MySqlClient;

namespace ZYHotelAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ImageView imgLogo, imgUsuario, imgSenha;
        EditText edtUsuario, edtSenha;
        Button btnLogin;
        Conexao con = new Conexao();
        Variaveis var = new Variaveis();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            /*TRAZ OS CONTROLES INCLUSOS NA TELA*/
            imgLogo     = FindViewById<ImageView>(Resource.Id.ImgLogo);
            imgUsuario  = FindViewById<ImageView>(Resource.Id.imgUsuario);
            imgSenha    = FindViewById<ImageView>(Resource.Id.imgSenha);
            edtUsuario  = FindViewById<EditText>(Resource.Id.EdtUsuario);
            edtSenha    = FindViewById<EditText>(Resource.Id.EdtSenha);
            btnLogin    = FindViewById<Button>(Resource.Id.BtnLogin);

            /*SETA AS IMAGENS PARA AS VARIÁVEIS CRIADAS*/
            imgLogo.SetImageResource(Resource.Drawable.logo);
            imgUsuario.SetImageResource(Resource.Drawable.usuarios);
            imgSenha.SetImageResource(Resource.Drawable.senha);

            btnLogin.Click += BtnLogin_Click;

        }

        private void BtnLogin_Click(object sender, System.EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            if(string.IsNullOrEmpty(edtUsuario.Text.ToString().Trim()))
            {
                Toast.MakeText(Application.Context, "Por favor, insira um usuário para acessar o sistema.", ToastLength.Long).Show();
                edtUsuario.Text = "";
                edtUsuario.RequestFocus();
                return;
            }

            if (string.IsNullOrEmpty(edtSenha.Text.ToString().Trim()))
            {
                Toast.MakeText(Application.Context, "Por favor, insira a senha para acessar o sistema.", ToastLength.Long).Show();
                edtUsuario.Text = "";
                edtSenha.RequestFocus();
                return;
            }

            MySqlCommand cmdVerificar;
            MySqlDataReader reader;

            con.AbreConexao();

            cmdVerificar = new MySqlCommand("SELECT * FROM usuarios WHERE usuario = @usuario and senha = @senha", con.conex);
            cmdVerificar.Parameters.AddWithValue("@usuario", edtUsuario.Text);
            cmdVerificar.Parameters.AddWithValue("@senha", edtSenha.Text);

            reader = cmdVerificar.ExecuteReader();

            if(reader.HasRows)
            {
                while (reader.Read())
                {
                    var.nomeUsuario = reader["nome"].ToString();
                    var.cargoUsuario = reader["cargo"].ToString();
                }

                //INTENT PARA PASSAR PARÂMETROS ENTRE ACTIVITIES
                var tela = new Intent(this, typeof(Menu));
                tela.PutExtra("nome", var.nomeUsuario);
                tela.PutExtra("cargo", var.cargoUsuario);

                StartActivity(tela);

                Limpar();
            }
            else
            {
                Toast.MakeText(Application.Context, "Dados incorretos.", ToastLength.Long).Show();
                Limpar();
            }

            con.FechaConexao();
        }

        private void Limpar()
        {
            edtUsuario.Text = "";
            edtSenha.Text = "";
            edtUsuario.RequestFocus();
        }
    }
}