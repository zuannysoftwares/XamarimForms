using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TIM_Jonata.Views.Custom;
using TIM_Jonata.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EntryField), typeof(EntryRender))]
namespace TIM_Jonata.Droid.Renderers
{
    public class EntryRender : EntryRenderer
    {
        public EntryRender(Context context) : base(context)
        {
           
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            //if(Control != null)
            //{
            //    Control.SetBackgroundColor(Android.Graphics.Color.WhiteSmoke);
            //}

            if (Control != null)
            {
                Control.Background.Mutate().SetColorFilter(Android.Graphics.Color.White, PorterDuff.Mode.SrcIn);
            }
        }
    }
}