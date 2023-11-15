using System;

namespace homework2
{
    class Line : Shape
    {
        private int _positionX1;
        private int _positionY1;

        private int _positionX2;
        private int _positionY2;

        // constructor
        public Line(int positionX1, int positionY1, int positionX2, int positionY2)
        {
            const string SHAPE_NAME = "線";
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
            graphics.DrawLine(_positionX1, _positionY1, _positionX2, _positionY2);
        }

        // DrawSelectedBorder
        public override void DrawSelectedBorder(IGraphics graphics)
        {
            graphics.DrawSelectedBorder(_positionX1, _positionY1, _positionX2, _positionY2);
        }

        // IsPointInsideShape
        public override bool IsPointInsideShape(double positionX, double positionY)
        {
            const int SQUARE = 2;

            double lineLength = Math.Sqrt(Math.Pow(_positionX2 - _positionX1, SQUARE) + Math.Pow(_positionY2 - _positionY1, SQUARE));

            double distanceToFirstPoint = Math.Sqrt(Math.Pow(positionX - _positionX1, SQUARE) + Math.Pow(positionY - _positionY1, SQUARE));
            double distanceToSecondPoint = Math.Sqrt(Math.Pow(positionX - _positionX2, SQUARE) + Math.Pow(positionY - _positionY2, SQUARE));

            const double MIN_DISTANCE = 10; 
            return Math.Abs(distanceToFirstPoint + distanceToSecondPoint - lineLength) < MIN_DISTANCE;
        }
    }
}
