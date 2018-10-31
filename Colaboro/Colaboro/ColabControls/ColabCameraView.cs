using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Colaboro.ColabControls
{
    //controle customizado Xamarin.Forms
    public class ColabCameraView : View
    {
        public static readonly BindableProperty CameraProperty = BindableProperty.Create(
        propertyName: "Camera",
        returnType: typeof(CameraOptions),
        declaringType: typeof(ColabCameraView),
        defaultValue: CameraOptions.Rear);

        public CameraOptions Camera
        {
            get { return (CameraOptions)GetValue(CameraProperty); }
            set { SetValue(CameraProperty, value); }
        }
    }
}
