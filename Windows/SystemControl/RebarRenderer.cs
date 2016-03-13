using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.VisualStyles;
using System.Drawing;

namespace Windows.SystemControl
{
    public class RebarRenderer
    {
        [ThreadStatic]
        private static VisualStyleRenderer visualStyleRenderer = null;
        private static readonly VisualStyleElement RebarElement = VisualStyleElement.Rebar.Band.Normal;
        public static bool IsSupported
        {
            get
            {
                return VisualStyleRenderer.IsSupported;
            }
        }
        private RebarRenderer()
        {
        }
        public static void DrawBackground(Graphics g, Rectangle bounds)
        {
            InitializeRenderer(VisualStyleElement.Rebar.Band.Normal, 0);
            visualStyleRenderer.DrawBackground(g, bounds);
        }
        private static void InitializeRenderer(VisualStyleElement element, int state)
        {
            if (visualStyleRenderer == null)
            {
                visualStyleRenderer = new VisualStyleRenderer(element.ClassName, element.Part, state);
            }
            else
            {
                visualStyleRenderer.SetParameters(element.ClassName, element.Part, state);
            }
        }
    }

    public delegate void MenuItemEventHandler(object sender, ToolBoxButton btn);
}
