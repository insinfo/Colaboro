//namespace Colaboro.Droid.CustomRenderer
using System;
using Android.Content;
using Android.Hardware;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
//parametro 1 é o controle implementado no projeto colabore Xamarin.Forms
//parametro 2 é o renderizador expecifico da plataforma que vai mapear pro controle da plataforma 
[assembly: ExportRenderer(typeof(Colaboro.ColabControls.ColabCameraView), typeof(Colaboro.Droid.CoDroidRenderer.CoDroidCameraViewRenderer))]
namespace Colaboro.Droid.CoDroidRenderer
{
    //parametro 1 é o controle implementado no projeto colabore Xamarin.Forms
    //parametro 2 é controle expecifico da plataforma que vai mapear pro controle Xamarin.Forms
    public class CoDroidCameraViewRenderer : ViewRenderer<Colaboro.ColabControls.ColabCameraView, Colaboro.Droid.CoDroidControls.CoDroidCameraView>
    {
        Colaboro.Droid.CoDroidControls.CoDroidCameraView cameraPreview;

        public CoDroidCameraViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Colaboro.ColabControls.ColabCameraView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                cameraPreview = new Colaboro.Droid.CoDroidControls.CoDroidCameraView(Context);
                SetNativeControl(cameraPreview);
            }

            if (e.OldElement != null)
            {
                // Unsubscribe
                cameraPreview.Click -= OnCameraPreviewClicked;
            }
            if (e.NewElement != null)
            {
                Control.Preview = Camera.Open((int)e.NewElement.Camera);

                // Subscribe
                cameraPreview.Click += OnCameraPreviewClicked;
            }
        }

        void OnCameraPreviewClicked(object sender, EventArgs e)
        {
            if (cameraPreview.IsPreviewing)
            {
                cameraPreview.Preview.StopPreview();
                cameraPreview.IsPreviewing = false;
            }
            else
            {
                cameraPreview.Preview.StartPreview();
                cameraPreview.IsPreviewing = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Control.Preview.Release();
            }
            base.Dispose(disposing);
        }
    }
}
