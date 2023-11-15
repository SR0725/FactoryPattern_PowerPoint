using System.Windows.Forms;

namespace homework2
{
    public interface IGraphics
    {
        // clear all
        void ClearAll();
        
        // draw line
        void DrawLine(int x1, int y1, int x2, int y2);

        // draw rectangle
        void DrawRectangle(int x1, int y1, int x2, int y2);

        // draw rectangle
        void DrawEllipse(int x1, int y1, int width, int height);

        // DrawSelectedBorder
        void DrawSelectedBorder(int x1, int y1, int x2, int y2);
    }
}