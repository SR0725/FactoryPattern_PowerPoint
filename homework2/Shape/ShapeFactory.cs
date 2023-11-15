using System;

namespace homework2
{
    public class ShapeFactory
    {
        const int NONE = -1;
        const int RECTANGLE = 0;
        const int LINE = 1;
        const int CIRCLE = 2;

        public enum ShapeType : int
        {
            None = NONE,
            Rectangle = RECTANGLE,
            Line = LINE,
            Circle = CIRCLE
        }

        // create Shape
        public static Shape CreateShape(ShapeType shapeName)
        {
            int positionX1 = 0;
            int positionY1 = 0;
            int positionX2 = 0;
            int positionY2 = 0;
            GetRandomPosition(ref positionX1, ref positionY1, ref positionX2, ref positionY2);
            switch (shapeName)
            {
                case ShapeType.Rectangle:
                    return new Rectangle(positionX1, positionY1, positionX2, positionY2);
                case ShapeType.Line:
                    return new Line(positionX1, positionY1, positionX2, positionY2);
                case ShapeType.Circle:
                    return new Circle(positionX1, positionY1, positionX2, positionY2);
                default:
                    return null;
            }
        }

        // swap position1 and position2
        private static void SwapPosition(ref int positionX1, ref int positionY1, ref int positionX2, ref int positionY2)
        {
            int temp = positionX1;
            positionX1 = positionX2;
            positionX2 = temp;
            temp = positionY2;
            positionY2 = positionY1;
            positionY1 = temp;
        }

        // get random position
        private static void GetRandomPosition(ref int positionX1, ref int positionY1, ref int positionX2, ref int positionY2)
        {
            const int MAX_X_POSITION = 1000;
            const int MAX_Y_POSITION = 670;
            Random random = new Random(Guid.NewGuid().GetHashCode());
            positionX1 = random.Next(0, MAX_X_POSITION);
            positionX2 = random.Next(0, MAX_X_POSITION);
            positionY1 = random.Next(0, MAX_Y_POSITION);
            positionY2 = random.Next(0, MAX_Y_POSITION);

            if (positionX1 > positionX2)
            {
                SwapPosition(ref positionX1, ref positionY1, ref positionX2, ref positionY2);
            }
        }
    }

}
