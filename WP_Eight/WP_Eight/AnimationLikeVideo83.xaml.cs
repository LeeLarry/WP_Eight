using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;

namespace WP_Eight
{
    public partial class AnimationLikeVideo83 : PhoneApplicationPage
    {
        TimeSpan startTime;

        public AnimationLikeVideo83()
        {
            InitializeComponent();

            CompositionTarget.Rendering += CompositionTarget_Rendering;
            /*表示您的应用程序的显示图面。
             * CompositionTarget 是一个类，表示正在其上绘制您的应用程序的显示图面。 
             * WPF 动画引擎为创建基于帧的动画提供了许多功能。 但是，在有些应用程序方案中，
             * 您需要根据每个帧控制呈现。 使用 CompositionTarget 对象，可以基于每个帧回调来创建自定义动画。
             */
        }

        void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            TimeSpan renderingTime = (e as RenderingEventArgs).RenderingTime;

            if (startTime.Ticks == 0)
            {
                startTime = renderingTime;
            }
            else
            {
                TimeSpan elapseTime = renderingTime - startTime;
                rotate.Angle = 180 * elapseTime.TotalSeconds % 360;
            }
        }
    }
}