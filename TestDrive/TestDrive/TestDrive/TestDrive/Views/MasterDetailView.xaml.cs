using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterDetailView : MasterDetailPage
	{

        private readonly Usuario _usuario;
		public MasterDetailView (Usuario usuario)
		{
			InitializeComponent ();
            this._usuario = usuario;
            this.Master = new MasterView(usuario);
		}
	}
}