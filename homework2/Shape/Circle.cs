using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace homework2
{
    class Circle : Shape
    {
        private int _positionX1;
        private int _positionY1;

        private int _positionX2;
        private int _positionY2;

        // constructor
        public Circle(int positionX1, int positionY1, int positionX2, int positionY2)
        {
            const string SHAPE_NAME = "圓形";
            _shapeName = SHAPE_NAME;
            SetPosition(positionX1, positionY1, positionX2, positionY2);
        }

        // set position
        public override void SetPosition(int positionX1, int positionY1, int positionX2, int positionY2)
        {
            _positionX1 = positionX1;
            _positionY1 = positionY1;
            _positionX2 = positionX2;
            _positionY2 = positionY2;
        }

        // get position
        public override void GetPosition(ref int positionX1, ref int positionY1, ref int positionX2, ref int positionY2)
        {
            positionX1 = _positionX1;
            positionX2 = _positionX2;
            positionY1 = _positionY1;
            positionY2 = _positionY2;
        }

        // get Position String Info 
        public override string GetInfo()
        {
            const string INFO_TEMPLATE = "({0},{1}),({2},{3})";
            return string.Format(INFO_TEMPLATE, _positionX1, _positionY1, _positionX2, _positionY2);
        }

        // get Shape Name
        public override string GetShapeName()
        {
            return _shapeName;
        }

        // draw
        public override void Draw(IGraphics graphics)
        {
            int width = Math.Abs(_positionX2 - _positionX1);
            int height = Math.Abs(_positionY2 - _positionY1);
            int positionX = Math.Min(_positionX1, _positionX2);
            int positionY = Math.Min(_positionY1, _positionY2);

            graphics.DrawEllipse(positionX, positionY, width, height);
        }

        // DrawSelectedBorder
        public override void DrawSelectedBorder(IGraphics graphics)
        {
            graphics.DrawSelectedBorder(_positionX1, _positionY1, _positionX2, _positionY2);
        }

        // IsPointInsideShape
        public override bool IsPointInsideShape(double positionX, double positionY)
        {
            const double HALF = 0.5;
            const int SQUARE = 2;
            double centerX = (_positionX1 + _positionX2) * HALF;
            double centerY = (_positionY1 + _positionY2) * HALF;

            double radius = Math.Sqrt(Math.Pow(_positionX2 - _positionX1, SQUARE) + Math.Pow(_positionY2 - _positionY1, SQUARE)) * HALF;

            double distance = Math.Sqrt(Math.Pow(positionX - centerX, SQUARE) + Math.Pow(positionY - centerY, SQUARE));

            return distance <= radius;
        }
    }
}
