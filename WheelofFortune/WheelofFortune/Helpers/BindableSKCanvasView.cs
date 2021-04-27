using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WheelofFortune.Helpers
{
    public class BindableSKCanvasView : SKCanvasView
    {
        public static readonly BindableProperty ColorProperty =
                BindableProperty.Create("Color", typeof(SKColor), typeof(BindableSKCanvasView), default(SKPaint), propertyChanged: RedrawCanvas);
        SKCanvasView canvasview = new SKCanvasView();
        public SKColor Color
        {
            get => (SKColor)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        private static void RedrawCanvas(BindableObject bindable, object oldvalue, object newvalue)
        {
            BindableSKCanvasView bindableCanvas = bindable as BindableSKCanvasView;
            bindableCanvas?.canvasview.InvalidateSurface();
        }
    }
}
