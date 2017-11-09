using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

using VisualEffects;
using VisualEffects.Animations.Effects;
using VisualEffects.Easing;

namespace Hummingbird.WinFormsClient.Controls
{
    class LabelAnimation
    {
        public Control Control { get; private set; }
        public Size MaxSize { get; set; }
        public Size MinSize { get; set; }
        public int Duration { get; set; }
        public int Delay { get; set; }

        public LabelAnimation(Control control)
        {
            this.Control = control;
            this.MaxSize = control.Size;
            this.MinSize = control.MinimumSize;
            this.Duration = 1000;
            this.Delay = 0;
        }

        public void Perform()
        {
            this.Control.Animate(new YLocationEffect(), EasingFunctions.CubicEaseInOut, Control.Top - 10, 2, 0);
            //this.Control.Animate(new FontSizeEffect(), EasingFunctions.CubicEaseInOut, 8, 2, 0);
        }
    }
}
