using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        // get random single dot position
        private static void GetRandomDotPosition(out int positionX, out int positionY)
        {
            const int MIN_NUMBER = 0;
            const int MAX_NUMBER = 600;

            Random random = new Random(Guid.NewGuid().GetHashCode());
            positionX = random.Next(MIN_NUMBER, MAX_NUMBER);
            positionY = random.Next(MIN_NUMBER, MAX_NUMBER);
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
            GetRandomDotPosition(out positionX1, out positionY1);
            GetRandomDotPosition(out positionX2, out positionY2);
            if (positionX1 > positionX2)
            {
                SwapPosition(ref positionX1, ref positionY1, ref positionX2, ref positionY2);
            }
        }
    }

}
