using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    public class PowerPointModal
    {

        public delegate void ModelChangedEventHandler();
        public event ModelChangedEventHandler _modelChanged;
        private Shape _workShape;
        private double _firstPointX;
        private double _firstPointY;

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
            _shapes.Add(shape);
            NotifyModelChanged();
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
            NotifyModelChanged();
            return true;
        }

        // add new shape when pointer pressed
        public Shape AddWorkPaintShape(ShapeFactory.ShapeType shapeType, double positionX, double positionY)
        {
            _workShape = AddShape(shapeType);
            _workShape.SetPosition((int)_firstPointX, (int)_firstPointY, (int)positionX, (int)positionY);
            _firstPointX = positionX;
            _firstPointY = positionY;
            NotifyModelChanged();
            return _workShape;
        }

        // set new shape when pointer move
        public Shape MoveWorkPaintShape(double positionX, double positionY)
        {
            if (_workShape == null)
            {
                return null;
            }

            _workShape.SetPosition(
                (int)_firstPointX,
                (int)_firstPointY,
                (int)positionX,
                (int)positionY
            );
            NotifyModelChanged();
            return _workShape;
        }

        // finish new shape when pointer move
        public Shape FinishWorkPaintShape(double positionX, double positionY)
        {
            _workShape.SetPosition(
                (int)_firstPointX,
                (int)_firstPointY,
                (int)positionX,
                (int)positionY
            );
            _workShape = null;
            NotifyModelChanged();
            return _workShape;
        }

        // get is adding new shape
        public bool IsAddingNewShape()
        {
            if (_workShape == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // notify model changed
        public void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }
    }
}
