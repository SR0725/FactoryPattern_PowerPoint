using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    public class PowerPointModal
    {
        // shapes
        public List<Shape> _shapes
        {
            get;
            set;
        }

        // constructor
        public PowerPointModal()
        {
            _shapes = new List<Shape>();
        }

        // add Shape with random position, but position1 must be smaller than position2
        public Shape AddShape(ShapeFactory.ShapeType shapeType)
        {
            Shape shape = ShapeFactory.CreateShape(shapeType);
            if (shape == null)
            {
                return null;
            }

            int positionX1 = 0;
            int positionY1 = 0;
            int positionX2 = 0;
            int positionY2 = 0;
            Utility.GetRandomPosition(ref positionX1, ref positionY1, ref positionX2, ref positionY2);
            shape.SetPosition(positionX1, positionY1, positionX2, positionY2);

            _shapes.Add(shape);
            return shape;
        }

        // delete Shape
        public bool DeleteShape(int index)
        {
            if (index < 0 || index >= _shapes.Count)
            {
                return false;
            }

            _shapes.RemoveAt(index);
            return true;
        }

    }
}
