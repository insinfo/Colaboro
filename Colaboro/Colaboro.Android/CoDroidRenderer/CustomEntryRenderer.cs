using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using Android.Util;

//parametro 1 é o controle implementado no projeto colabore Xamarin.Forms
//parametro 2 é o renderizador expecifico da plataforma que vai mapear pro controle da plataforma 
[assembly: ExportRenderer(typeof(Colaboro.ColabControls.CustomEntry), typeof(Colaboro.Droid.CoDroidRenderer.CustomEntryRenderer))]
namespace Colaboro.Droid.CoDroidRenderer
{
    public class CustomEntryRenderer : EntryRenderer 
    {
        public CustomEntryRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var view = (Colaboro.ColabControls.CustomEntry)Element;

                if (view.IsCurvedCornersEnabled)
                {
                    // creating gradient drawable for the curved background
                    var _gradientBackground = new GradientDrawable();
                    _gradientBackground.SetShape(ShapeType.Rectangle);
                    //_gradientBackground.SetColor(Color.Red);//view.BackgroundColor.ToAndroid()

                    _gradientBackground.SetColors(new int[]{
                        Android.Graphics.Color.Red
                     });

                    // Thickness of the stroke line
                    _gradientBackground.SetStroke(view.BorderWidth, view.BorderColor.ToAndroid());

                    // Radius for the curves
                    _gradientBackground.SetCornerRadius(
                        DpToPixels(this.Context,
                            Convert.ToSingle(view.CornerRadius)));

                    // set the background of the label
                    Control.SetBackground(_gradientBackground);

                    /*var sdk = Android.OS.Build.VERSION.SdkInt;
                    if (sdk < Android.OS.BuildVersionCodes.JellyBean)
                    {
                        Control.SetBackgroundDrawable(_gradientBackground);
                    }
                    else
                    {
                        Control.SetBackground(_gradientBackground);
                    }*/
                }

                // Set padding for the internal text from border
                Control.SetPadding(
                    (int)DpToPixels(this.Context, Convert.ToSingle(12)),
                    Control.PaddingTop,
                    (int)DpToPixels(this.Context, Convert.ToSingle(12)),
                    Control.PaddingBottom);
            }
        }
        public static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }
}