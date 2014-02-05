using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Shapes;
using System.Windows.Media;

namespace WP_Eight
{
    public partial class ManipulationEventDemo84 : PhoneApplicationPage
    {
        public ManipulationEventDemo84()
        {
            InitializeComponent();
        }

        private void Ellipse_ManipulationDelta(object sender, System.Windows.Input.ManipulationDeltaEventArgs e)
        {
            Ellipse ellipse = sender as Ellipse;
            CompositeTransform xform = ellipse.RenderTransform as CompositeTransform;
            if (e.DeltaManipulation.Scale.X > 0 || e.DeltaManipulation.Scale.Y > 0)
            {
                double maxScale = Math.Max(e.DeltaManipulation.Scale.X, e.DeltaManipulation.Scale.Y);
                xform.ScaleX *= maxScale;
                xform.ScaleY *= maxScale;
            }//这是有两个手指在屏幕上时,scale通常不为零,也就是在进行缩放

            xform.TranslateX += e.DeltaManipulation.Translation.X;
            xform.TranslateY += e.DeltaManipulation.Translation.Y;
            //这是只有一个手指时,只进行平移操作
            e.Handled = true;
        }
    }
}