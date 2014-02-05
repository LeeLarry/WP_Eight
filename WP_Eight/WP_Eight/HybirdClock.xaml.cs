using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Threading;
using System.Windows.Media;

namespace WP_Eight
{
    public partial class HybirdClock : PhoneApplicationPage
    {
        Point gridCenter;
        Size textSize;
        double scale;

        public HybirdClock()
        {
            InitializeComponent();

            DispatcherTimer tmr = new DispatcherTimer(); 
            tmr.Interval = TimeSpan.FromSeconds(1);
            tmr.Tick += tmr_Tick;
            tmr.Start();
        }

        void tmr_Tick(object sender, EventArgs e)
        {
            UpdateClock();
        }

        private void ContentPanel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            gridCenter = new Point(e.NewSize.Width/2,e.NewSize.Height/2);

            textSize = new Size(referenceText.ActualWidth, referenceText.ActualHeight);

            scale = Math.Min(gridCenter.X,gridCenter.Y)/textSize.Width;

            UpdateClock();
        }

        private void UpdateClock()
        {
            DateTime dt = DateTime.Now;
            double angle = 6 * dt.Second;
            SetupHand(secondHand,"THE SECOND ARE"+dt.Second,angle);
            angle = 6 * dt.Minute + angle / 60;
            SetupHand(minuteHand,"THE MINUTE IS"+dt.Minute,angle);
            angle = 30 * (dt.Hour % 12) + angle / 12;
            SetupHand(hourHand,"THE HOUR IS"+((dt.Hour+11)%12)+1,angle);
        }

        private void SetupHand(TextBlock txtblk, string text, double angle)
        {
            txtblk.Text = text;
            CompositeTransform xform = txtblk.RenderTransform as CompositeTransform;
            xform.CenterX = textSize.Height / 2; 
            xform.CenterY = textSize.Width / 2;
            xform.ScaleX = scale;
            xform.ScaleY = scale;
            xform.Rotation = angle - 90;
            xform.TranslateX = gridCenter.X - textSize.Height / 2;
            xform.TranslateY = gridCenter.Y - textSize.Width / 2;
        }
    }
}