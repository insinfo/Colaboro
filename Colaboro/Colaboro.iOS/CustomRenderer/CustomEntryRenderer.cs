﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;

using Xamarin.Forms.Platform.iOS;
using CoreGraphics;

//parametro 1 é o controle implementado no projeto colabore Xamarin.Forms
//parametro 2 é o renderizador expecifico da plataforma que vai mapear pro controle da plataforma 
[assembly: ExportRenderer(typeof(Colaboro.ColabControls.CustomEntry), typeof(Colaboro.iOS.CoDroidRenderer.CustomEntryRenderer))]
namespace Colaboro.iOS.CoDroidRenderer
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var view = (Colaboro.ColabControls.CustomEntry)Element;

                Control.LeftView = new UIView(new CGRect(0f, 0f, 9f, 20f));
                Control.LeftViewMode = UITextFieldViewMode.Always;

                Control.KeyboardAppearance = UIKeyboardAppearance.Dark;
                Control.ReturnKeyType = UIReturnKeyType.Done;

                Control.Layer.CornerRadius = Convert.ToSingle(view.CornerRadius);
                Control.Layer.BorderColor = view.BorderColor.ToCGColor();
                Control.Layer.BorderWidth = view.BorderWidth;
                Control.ClipsToBounds = true;
            }
        }
    }
}