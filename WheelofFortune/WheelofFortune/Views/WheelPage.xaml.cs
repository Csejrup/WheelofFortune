using Rg.Plugins.Popup.Services;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WheelofFortune.Helpers;
using WheelofFortune.Models;
using WheelofFortune.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WheelofFortune.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WheelPage : ContentPage
    {
        protected WheelViewModel vm;
        Stopwatch stopwatch = new Stopwatch();
        private readonly Random random = new Random();
        bool pageIsActive;
        float degress;

        public WheelPage()
        {
            InitializeComponent();
            vm = new WheelViewModel();
        }
        
        async Task AnimationLoop(int ex = 0)
        {
            //Check if the wheel is spinning, if so, return
            if (vm.IsSpinning)
            {
                return;
            }
            vm.IsSpinning = true;
            stopwatch.Reset();
            stopwatch.Start();

            double nextDuration = (random.NextDouble() * 10) + 8; 
            if (ex != 0)
            {
                nextDuration = ex;
            }
            else
            {
                vm.RefreshRate = WheelConstants.DefaultRefreshRate;
            }
            while (pageIsActive && stopwatch.Elapsed < TimeSpan.FromSeconds(nextDuration))
            {
                skiaView.InvalidateSurface();
                await Task.Delay(TimeSpan.FromMilliseconds(vm.RefreshRate)); 
                //Slow downs the wheel
                if (stopwatch.Elapsed.TotalSeconds > nextDuration * 3 / 4)
                {
                    vm.RefreshRate += vm.RefreshRate / 15;
                    if (vm.RefreshRate > WheelConstants.DefaultRefreshRate * 25)
                    {
                        vm.RefreshRate = WheelConstants.DefaultRefreshRate;
                    }
                }
            }
            stopwatch.Stop();

            int rounder = (int)Math.Round(degress + 3.6f, MidpointRounding.AwayFromZero);
            if (vm.InvalidPoints.Contains(rounder))
            { 
                await Task.Delay(100);
                vm.IsSpinning = false;
                await AnimationLoop(5);
            }
            else
            {
                GetPrize();
                vm.IsSpinning = false;
            }
        }
        /// <summary>
        /// This method is trigged when the canvas needs to be redrawn 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void CanvasSurfacePaint(object sender, SKPaintSurfaceEventArgs args)
        {

            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            var y = info.Height / 2;

            canvas.Clear();

            SKPoint center = new SKPoint(info.Width / 2, info.Height / 2);
            float radius = Math.Min(info.Width / 2, info.Height / 2) - 2 * WheelConstants.ExplodeOffset;
            SKRect rect = new SKRect(center.X - radius, center.Y - radius,
                                     center.X + radius, center.Y + radius);
            float startAngle = -90; 
            float xCenter = info.Width / 2;
            float yCenter = info.Height / 2;

            foreach (ChartData item in vm.ChartData)
            {
                float sweepAngle = 360f / vm.ChartData.Count;

                using (SKPath path = new SKPath())
                using (SKPaint fillPaint = new SKPaint())
                using (SKPaint outlinePaint = new SKPaint())
                using (SKPaint text = new SKPaint())
                {
                    path.MoveTo(center);
                    path.ArcTo(rect, startAngle, sweepAngle, false);

                    path.Close();

                    fillPaint.Style = SKPaintStyle.Fill;
                    fillPaint.Color = item.Color;

                    outlinePaint.Style = SKPaintStyle.Stroke;
                    outlinePaint.StrokeWidth = 5;
                    outlinePaint.Color = SKColors.White;

                    #region Text Writer

                    text.TextSize = 40;
                    text.StrokeWidth = 1;
                    text.Color = SKColors.White;

                    //Adjusting Text Size by SKReact
                    SKRect textBounds = new SKRect();
                    text.MeasureText(item.Text, ref textBounds);
                    float yText = yCenter - textBounds.Height / 2 - textBounds.Top;
                    #endregion 
                    canvas.Save();
                    DrawWheel(canvas, path, fillPaint, outlinePaint, item, degress, (int)center.X, y);
                    float sweepAngleText = 360f / vm.ChartData.Count;
                    float priceText = sweepAngleText - sweepAngleText / 2;
                    foreach (ChartData sect in vm.ChartData)
                    {
                        canvas.Save();
                        canvas.RotateDegrees(priceText + degress - 90, xCenter, yCenter);

                        if (sect.Text.Trim().Length > 6)
                        {
                            text.TextSize = 30;
                        }
                        else
                        {
                            text.TextSize = 40;
                        }
                        canvas.DrawText(sect.Text, xCenter, yText, text);
                        canvas.Restore();
                        if (priceText > 360)
                        {
                            priceText = priceText - 360;
                        }
                        priceText += sweepAngleText;
                    }
                    canvas.Restore();
                }
                startAngle += sweepAngle;
            }
            #region Marker
            //SKPaint objects for Drawing the Marker
            using (SKPaint drawMarkCircleInner = new SKPaint())
            using (SKPaint drawMarkCircleOuter = new SKPaint())
            using (SKPaint drawMarkTriangle = new SKPaint())
            {
                drawMarkCircleInner.Style = SKPaintStyle.StrokeAndFill;
                drawMarkCircleOuter.Style = SKPaintStyle.StrokeAndFill;
                drawMarkTriangle.Color = Color.FromHex("#ffffff").ToSKColor();

                List<SKColor> colors = new List<SKColor>();

                foreach (var col in vm.Colors)
                {
                    colors.Add(Color.FromHex(col).ToSKColor());
                }
                //draw outer circle
                canvas.DrawCircle(args.Info.Width / 2, args.Info.Height / 2, 60, drawMarkCircleOuter); //outer
                //draw triangle
                drawMarkTriangle.Style = SKPaintStyle.StrokeAndFill;
                drawMarkTriangle.Color = Color.FromHex("#ffffff").ToSKColor();
                SKPath markTriangle = new SKPath();
                markTriangle.MoveTo((args.Info.Width / 2) - 55, args.Info.Height / 2);
                markTriangle.LineTo((args.Info.Width / 2) - 55, args.Info.Height / 2);
                markTriangle.LineTo((args.Info.Width / 2) + 55, args.Info.Height / 2);
                markTriangle.LineTo(args.Info.Width / 2, (float)(args.Info.Height / 2.5));
                markTriangle.Close();
                canvas.DrawPath(markTriangle, drawMarkTriangle);
                //draw inner circle
                SKPoint circle_center = new SKPoint(info.Rect.MidX, info.Rect.MidY);
                drawMarkCircleInner.Shader = SKShader.CreateSweepGradient(circle_center, colors.ToArray());
               // fillMarkCirclePaint.Color = Color.FromHex("#ffffff").ToSKColor();
                canvas.DrawCircle(args.Info.Width / 2, args.Info.Height / 2, 50, drawMarkCircleInner); //inner   
            }
            #endregion
            //Get the current prize.
            float prize_degree = degress + (360 / vm.ChartData.Count / 2);

            if (degress == 0 || Math.Round(degress, MidpointRounding.AwayFromZero) == 360)
            {
                prize_degree = degress;
            }
            var segment = ((prize_degree / 360f) * vm.ChartData.Count);
            var int_segment2 = Math.Round(segment, MidpointRounding.AwayFromZero);
            var realIndex = vm.ChartData.Count == vm.ChartData.Count - (int)int_segment2 ? 0 : vm.ChartData.Count - (int)int_segment2;
            vm.Number = vm.ChartData[realIndex].Sector; //add back
           
            IncrementDegrees();

        }
      
        private void IncrementDegrees()
        {
            if (degress >= 360)
            {
                degress = degress - 360;
            }
            degress += 3.6f;
        }

        /// <summary>
        /// Method that rotates the outer wheel parts 
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="path"></param>
        /// <param name="fill"></param>
        /// <param name="outline"></param>
        /// <param name="item"></param>
        /// <param name="degrees"></param>
        /// <param name="cx"></param>
        /// <param name="cy"></param>
        
        void DrawWheel(SKCanvas canvas, SKPath path, SKPaint fill, SKPaint outline, ChartData item, float degrees, int cx, int cy)
        {
            var identity = SKMatrix.CreateIdentity();
            var translate = SKMatrix.CreateTranslation(-cx, -cy);
            var rotate = SKMatrix.CreateRotationDegrees(degrees);

            //angleBox.Text = degrees.ToString();
            var translate2 = SKMatrix.CreateTranslation(cx, cy);

            SKMatrix.PostConcat(ref identity, translate);
            SKMatrix.PostConcat(ref identity, rotate);
            SKMatrix.PostConcat(ref identity, translate2);


            path.Transform(identity);
            canvas.DrawPath(path, fill);
            canvas.DrawPath(path, outline);
        }

        private async void GetPrize()
        {
            string number = vm.Number?.number.ToString();


            await PopupNavigation.PushAsync(new PopupTaskView(number));
            //await DisplayAlert("Winner!", "You won the following Prize! Congratulations!: " + number + "yes", "no");
         
        }
        private async void btn_Click_Spinwheel(object sender, EventArgs e)
        {
            //General.DoHaptic(HapticFeedbackType.LongPress);
            pageIsActive = true;
            await AnimationLoop();
        }
        
    }
}