using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    public class ShapeFactory
    {
        public enum ShapeType : int
        {
            Rectangle = 0,
            Line = 1
        }

        // create Shape
        public static Shape CreateShape(ShapeType shapeName)
        {
            Shape newShape = null;
            switch (shapeName)
            {
                case ShapeType.Rectangle:
                    newShape = new Rectangle();
                    break;
                case ShapeType.Line:
                    newShape = new Line();
                    break;
                default:
                    return null;
            }
            return newShape;
        }
    }

}
