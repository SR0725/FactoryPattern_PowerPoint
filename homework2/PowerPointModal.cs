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
        public Shape _selectedShape;
        private Shape _workShape;
        private double _firstPointX;
        private double _firstPointY;
        private IContext context = new IContext(new DrawingState());

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

        // handle change context
        public void HandleChangeContext(Toolbar toolbar)
        {
            switch (toolbar.checkedType)
            {
                case Toolbar.ToolbarType.PointState:
                    context.TransitionTo(new PointState());
                    break;
                case Toolbar.ToolbarType.Circle:
                case Toolbar.ToolbarType.Line:
                case Toolbar.ToolbarType.Rectangle:
                    context.TransitionTo(new DrawingState());
                    break;
            }
        }

        // mouse down
        public Shape HandleMouseDown(Toolbar toolbar, double positionX, double positionY)
        {
            return context.HandleMouseDown(this, toolbar, positionX, positionY);
        }

        // mouse move
        public Shape HandleMouseMove(Toolbar toolbar, double positionX, double positionY)
        {
            return context.HandleMouseMove(this, toolbar, positionX, positionY);
        }

        // mouse up
        public Shape HandleMouseUp(Toolbar toolbar, double positionX, double positionY)
        {
            return context.HandleMouseUp(this, toolbar, positionX, positionY);
        }

        // delete selected shape
        public void DeleteSelectedShape()
        {
            if (_selectedShape == null)
            {
                return;
            }

            _shapes.Remove(_selectedShape);
            _selectedShape = null;
            NotifyModelChanged();
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

        // MoveSelectedShape
        public void MoveSelectedShape(int positionX1, int positionY1, int positionX2, int positionY2)
        {
            if (_selectedShape == null)
            {
                return;
            }

            _selectedShape.SetPosition(
                positionX1,
                positionY1,
                positionX2,
                positionY2
            );
            NotifyModelChanged();
        }

        // select shape
        public void SelectShape(Shape shape)
        {
            _selectedShape = shape;
            NotifyModelChanged();
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

        // get shape in list index
        public int GetShapeIndex(Shape shape)
        {
            return _shapes.IndexOf(shape);
        }

        // notify model changed
        public void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }
    }
}
