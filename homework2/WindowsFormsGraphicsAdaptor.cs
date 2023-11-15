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
        public void DrawEllipse(int x1, int y1, int width, int height)
        {
            _graphics.DrawEllipse(Pens.Red, (float)x1, (float)y1, (float)width, (float)height);
        }

        // DrawSelectedBorder
        public void DrawSelectedBorder(int x1, int y1, int x2, int y2)
        {
            const float CIRCLE_RADIUS = 10.0f;
            _graphics.DrawEllipse(Pens.Gray, (float)x1 - CIRCLE_RADIUS / 2.0f, (float)y1 - CIRCLE_RADIUS / 2.0f, CIRCLE_RADIUS, CIRCLE_RADIUS);
            _graphics.DrawEllipse(Pens.Gray, (float)x1 - CIRCLE_RADIUS / 2.0f, (float)y2 - CIRCLE_RADIUS / 2.0f, CIRCLE_RADIUS, CIRCLE_RADIUS);
            _graphics.DrawEllipse(Pens.Gray, (float)x2 - CIRCLE_RADIUS / 2.0f, (float)y1 - CIRCLE_RADIUS / 2.0f, CIRCLE_RADIUS, CIRCLE_RADIUS);
            _graphics.DrawEllipse(Pens.Gray, (float)x2 - CIRCLE_RADIUS / 2.0f, (float)y2 - CIRCLE_RADIUS / 2.0f, CIRCLE_RADIUS, CIRCLE_RADIUS);
        }
    }
}