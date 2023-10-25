using System.Windows.Forms;
using System.Drawing;

namespace homework2
{
    class WindowsFormsGraphicsAdaptor : IGraphics
    {
        Graphics _graphics;

        public WindowsFormsGraphicsAdaptor(Graphics graphics)
        {
            this._graphics = graphics;
        }

        // clear all
        public void ClearAll()
        {
            // 重新繪圖時會自動清除畫面，因此不需實作
        }

        // draw line
        public void DrawLine(int x1, int y1, int x2, int y2)
        {
            _graphics.DrawLine(Pens.Red, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        // draw rectangle
        public void DrawRectangle(int x1, int y1, int x2, int y2)
        {
            _graphics.DrawRectangle(Pens.Red, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        // draw rectangle
        public void DrawEllipse(int x1, int y1, int x2, int y2)
        {
            _graphics.DrawEllipse(Pens.Red, (float)x1, (float)y1, (float)x2, (float)y2);
        }
    }
}