using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Colaboro.ColabControls
{
    public class GradientFrame : Grid
    {
        #region Outer
        public static readonly BindableProperty OuterBackgroundColorProperty =
            BindableProperty.Create("OuterBackgroundColor",
                typeof(Color),
                typeof(GradientFrame),
                Color.Transparent,
                propertyChanged: (currentControl, oldValue, newValue) =>
                {
                    var thisControl = currentControl as GradientFrame;
                    thisControl.OuterBackgroundColor = (Color)newValue;
                });

        public Color OuterBackgroundColor
        {
            get { return (Color)GetValue(OuterBackgroundColorProperty); }
            set
            {
                SetValue(OuterBackgroundColorProperty, value);
                thisOuterBackgroundColor = value.ToSKColor();
                InvalidateSurface();
            }
        }

        private SKColor thisOuterBackgroundColor;
        #endregion

        #region Inner Start
        public static readonly BindableProperty InnerBackgroundColorStartProperty =
            BindableProperty.Create("InnerBackgroundColorStart",
                typeof(Color),
                typeof(GradientFrame),
                Color.Red,
                propertyChanged: (currentControl, oldValue, newValue) =>
                {
                    var thisControl = currentControl as GradientFrame;
                    thisControl.InnerBackgroundColorStart = (Color)newValue;
                });

        public Color InnerBackgroundColorStart
        {
            get { return (Color)GetValue(InnerBackgroundColorStartProperty); }
            set
            {
                SetValue(InnerBackgroundColorStartProperty, value);
                thisInnerBackgroundColorStart = value.ToSKColor();
                InvalidateSurface();
            }
        }

        private SKColor thisInnerBackgroundColorStart;
        #endregion

        #region Inner End
        public static readonly BindableProperty InnerBackgroundColorEndProperty =
            BindableProperty.Create("InnerBackgroundColorEnd",
                typeof(Color),
                typeof(GradientFrame),
                Color.Red,
                propertyChanged: (currentControl, oldValue, newValue) =>
                {
                    var thisControl = currentControl as GradientFrame;
                    thisControl.InnerBackgroundColorEnd = (Color)newValue;
                });

        public Color InnerBackgroundColorEnd
        {
            get { return (Color)GetValue(InnerBackgroundColorEndProperty); }
            set
            {
                SetValue(InnerBackgroundColorEndProperty, value);
                thisInnerBackgroundColorEnd = value.ToSKColor();
                InvalidateSurface();
            }
        }

        private SKColor thisInnerBackgroundColorEnd;
        #endregion

        #region Border Color
        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create("BorderColor",
                typeof(Color),
                typeof(GradientFrame),
                Color.Blue,
                propertyChanged: (currentControl, oldValue, newValue) =>
                {
                    var thisControl = currentControl as GradientFrame;
                    thisControl.BorderColor = (Color)newValue;
                });

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set
            {
                SetValue(BorderColorProperty, value);
                thisBorderColor = value.ToSKColor();
                InvalidateSurface();
            }
        }

        private SKColor thisBorderColor;
        #endregion

        #region Border Width
        public static readonly BindableProperty BorderWidthProperty =
            BindableProperty.Create("BorderWidth",
                typeof(int),
                typeof(GradientFrame),
                1,
                propertyChanged: (currentControl, oldValue, newValue) =>
                {
                    var thisControl = currentControl as GradientFrame;
                    thisControl.BorderWidth = (int)newValue;
                });

        public int BorderWidth
        {
            get { return (int)GetValue(BorderWidthProperty); }
            set
            {
                SetValue(BorderWidthProperty, value);
                InvalidateSurface();
            }
        }
        #endregion

        #region Border Radius
        public static readonly BindableProperty BorderRadiusProperty =
            BindableProperty.Create("BorderRadius",
                typeof(float),
                typeof(GradientFrame),
                25f,
                propertyChanged: (currentControl, oldValue, newValue) =>
                {
                    var thisControl = currentControl as GradientFrame;
                    thisControl.BorderRadius = (float)newValue;
                });

        public float BorderRadius
        {
            get { return (float)GetValue(BorderRadiusProperty); }
            set
            {
                SetValue(BorderRadiusProperty, value);
                InvalidateSurface();
            }
        }
        #endregion

        #region Border Margin
        public static readonly BindableProperty BorderMarginProperty =
            BindableProperty.Create("BorderMargin",
                typeof(float),
                typeof(GradientFrame),
                25f,
                propertyChanged: (currentControl, oldValue, newValue) =>
                {
                    var thisControl = currentControl as GradientFrame;
                    thisControl.BorderMargin = (float)newValue;
                });

        public float BorderMargin
        {
            get { return (float)GetValue(BorderMarginProperty); }
            set
            {
                SetValue(BorderMarginProperty, value);
                InvalidateSurface();
            }
        }
        #endregion

        #region Border Padding
        public static readonly BindableProperty BorderPaddingProperty =
            BindableProperty.Create("BorderPadding",
                typeof(float),
                typeof(GradientFrame),
                25f,
                propertyChanged: (currentControl, oldValue, newValue) =>
                {
                    var thisControl = currentControl as GradientFrame;
                    thisControl.BorderPadding = (float)newValue;
                });

        public float BorderPadding
        {
            get { return (float)GetValue(BorderPaddingProperty); }
            set
            {
                SetValue(BorderPaddingProperty, value);
                InvalidateSurface();
            }
        }
        #endregion

        #region Fill Orientation
        public enum FillOrientations
        {
            Horizontal,
            Vertical
        }

        public static readonly BindableProperty FillOrientationProperty =
            BindableProperty.Create("FillOrientation",
                typeof(FillOrientations),
                typeof(GradientFrame),
                FillOrientations.Horizontal,
                propertyChanged: (currentControl, oldValue, newValue) =>
                {
                    var thisControl = currentControl as GradientFrame;
                    thisControl.FillOrientation = (FillOrientations)newValue;
                });

        public FillOrientations FillOrientation
        {
            get { return (FillOrientations)GetValue(FillOrientationProperty); }
            set
            {
                SetValue(FillOrientationProperty, value);
                InvalidateSurface();
            }
        }
        #endregion

        public GradientFrame()
        {
            this.RowDefinitions = new RowDefinitionCollection
        {
            new RowDefinition { Height = GridLength.Auto }
        };
            this.ColumnDefinitions = new ColumnDefinitionCollection
        {
            new ColumnDefinition { Width = GridLength.Auto }
        };


            canvas = new SKCanvasView()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,

            };
            canvas.PaintSurface += NewGradientFrame_OnPaintSurface;
            this.Children.Add(canvas, 0, 0);
        }

        protected override void OnChildAdded(Element child)
        {
            if (this.Children.Count > 1)
            {
                SetRow(child, 0);
                SetColumn(child, 0);
                SetRowSpan(child, 1);
                SetColumnSpan(child, 1);
                ((View)child).Margin = BorderMargin + BorderWidth + BorderPadding;
            }
            base.OnChildAdded(child);
        }

        private SKCanvasView canvas;

        private void InvalidateSurface()
        {
            if (canvas != null) canvas.InvalidateSurface();
        }

        protected void NewGradientFrame_OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear(thisOuterBackgroundColor);

            int width = info.Width;
            int height = info.Height;

            SKRect rect = new SKRect
            {
                Left = BorderMargin,
                Top = BorderMargin,
                Right = width - BorderMargin,
                Bottom = height - BorderMargin
            };

            SKPaint paintBorder = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                StrokeWidth = BorderWidth,
                Color = thisBorderColor,
                IsAntialias = true
            };
            canvas.DrawRoundRect(rect, BorderRadius, BorderRadius, paintBorder);

            var colors = new SKColor[] { thisInnerBackgroundColorStart, thisInnerBackgroundColorEnd };
            SKShader shader = null;
            if (FillOrientation.Equals(FillOrientations.Vertical))
            {
                shader = SKShader.CreateLinearGradient(
                    new SKPoint(0, 0),
                    new SKPoint(0, 100),
                    colors,
                    null,
                    SKShaderTileMode.Clamp);
            }
            else
            {
                shader = SKShader.CreateLinearGradient(
                    new SKPoint(0, 0),
                    new SKPoint(100, 0),
                    colors,
                    null,
                    SKShaderTileMode.Clamp);
            }

            var paintFill = new SKPaint()
            {
                Shader = shader,
                Style = SKPaintStyle.Fill,
                IsAntialias = true
            };

            canvas.DrawRoundRect(rect, BorderRadius, BorderRadius, paintFill);
        }
    }
}
