using System.Windows.Forms;
using System.Drawing;

namespace homework2
{
    class WindowsFormsGraphicsAdaptor : IGraphics
    {
        Graphics _graphics;
        float _scale;

        public WindowsFormsGraphicsAdaptor(Graphics graphics, float scale)
        {
            this._graphics = graphics;
            this._scale = scale;
        }

        // clear all
        public void ClearAll()
        {
            // 重新繪圖時會自動清除畫面，因此不需實作
        }

        // draw line
        public void DrawLine(int x1, int y1, int x2, int y2)
        {
            _graphics.DrawLine(Pens.Red, (float)x1 * _scale, (float)y1 * _scale, (float)x2 * _scale, (float)y2 * _scale);
        }

        // draw rectangle
        public void DrawRectangle(int x1, int y1, int x2, int y2)
        {
            _graphics.DrawRectangle(Pens.Red, (float)x1 * _scale, (float)y1 * _scale, (float)x2 * _scale, (float)y2 * _scale);
        }

        // draw rectangle
        public void DrawEllipse(int x1, int y1, int width, int height)
        {
            _graphics.DrawEllipse(Pens.Red, (float)x1 * _scale, (float)y1 * _scale, (float)width * _scale, (float)height * _scale);
        }

        // DrawSelectedBorder
        public void DrawSelectedBorder(int x1, int y1, int x2, int y2)
        {
            const float HALF = 0.5f;
            const float CIRCLE_RADIUS = 10.0f;
            _graphics.DrawEllipse(Pens.Gray, ((float)x1 - CIRCLE_RADIUS * HALF) * _scale, ((float)y1 - CIRCLE_RADIUS * HALF) * _scale, CIRCLE_RADIUS * _scale, CIRCLE_RADIUS * _scale);
            _graphics.DrawEllipse(Pens.Gray, ((float)x1 - CIRCLE_RADIUS * HALF) * _scale, ((float)y2 - CIRCLE_RADIUS * HALF) * _scale, CIRCLE_RADIUS * _scale, CIRCLE_RADIUS * _scale);
            _graphics.DrawEllipse(Pens.Gray, ((float)x2 - CIRCLE_RADIUS * HALF) * _scale, ((float)y1 - CIRCLE_RADIUS * HALF) * _scale, CIRCLE_RADIUS * _scale, CIRCLE_RADIUS * _scale);
            _graphics.DrawEllipse(Pens.Gray, ((float)x2 - CIRCLE_RADIUS * HALF) * _scale, ((float)y2 - CIRCLE_RADIUS * HALF) * _scale, CIRCLE_RADIUS * _scale, CIRCLE_RADIUS * _scale);
        }
    }
}