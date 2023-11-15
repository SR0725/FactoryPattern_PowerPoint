using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    class IContext
    {
        // A reference to the current state of the Context.
        private IState _state = null;

        public IContext(IState state)
        {
            this.TransitionTo(state);
        }

        public void TransitionTo(IState state)
        {
            this._state = state;
            this._state.SetContext(this);
        }

        public Shape HandleMouseDown(PowerPointModal powerPointModal, Toolbar toolbar, double positionX, double positionY) 
        {
            return this._state.HandleMouseDown(powerPointModal, toolbar, positionX, positionY);
        }

        public Shape HandleMouseMove(PowerPointModal powerPointModal, Toolbar toolbar, double positionX, double positionY)
        {
            return this._state.HandleMouseMove(powerPointModal, toolbar, positionX, positionY);
        }

        public Shape HandleMouseUp(PowerPointModal powerPointModal, Toolbar toolbar, double positionX, double positionY)
        {
            return this._state.HandleMouseUp(powerPointModal, toolbar, positionX, positionY);
        }
    }

    abstract class IState
    {
        protected IContext _context;

        public void SetContext(IContext context)
        {
            this._context = context;
        }

        public abstract Shape HandleMouseDown(PowerPointModal powerPointModal, Toolbar toolbar, double positionX, double positionY);
        public abstract Shape HandleMouseMove(PowerPointModal powerPointModal, Toolbar toolbar, double positionX, double positionY);
        public abstract Shape HandleMouseUp(PowerPointModal powerPointModal, Toolbar toolbar, double positionX, double positionY);
    }

    class DrawingState : IState
    {

        // on mouse down
        public override Shape HandleMouseDown(PowerPointModal powerPointModal, Toolbar toolbar, double positionX, double positionY)
        {
            if (toolbar.checkedType == Toolbar.ToolbarType.None)
            {
                return null;
            }
            return powerPointModal.AddWorkPaintShape((ShapeFactory.ShapeType)toolbar.checkedType, positionX, positionY);
        }

        // on mouse move
        public override Shape HandleMouseMove(PowerPointModal powerPointModal, Toolbar toolbar, double positionX, double positionY)
        {
            if (toolbar.checkedType == Toolbar.ToolbarType.None)
            {
                return null;
            }

            return powerPointModal.MoveWorkPaintShape(positionX, positionY);
        }

        // on mouse down
        public override Shape HandleMouseUp(PowerPointModal powerPointModal, Toolbar toolbar, double positionX, double positionY)
        {
            if (toolbar.checkedType == Toolbar.ToolbarType.None)
            {
                return null;
            }
            toolbar.checkedType = Toolbar.ToolbarType.None;
            return powerPointModal.FinishWorkPaintShape(positionX, positionY);
        }
    }


    class PointState : IState
    {
        private bool isMouseDown = false;
        private int originMousePositionX;
        private int originMousePositionY;
        private int originShapePositionX1;
        private int originShapePositionY1;
        private int originShapePositionX2;
        private int originShapePositionY2;

        // on mouse down
        public override Shape HandleMouseDown(PowerPointModal powerPointModal, Toolbar toolbar, double positionX, double positionY)
        {
            originMousePositionX = (int)positionX;
            originMousePositionY = (int)positionY;
            isMouseDown = true;
            foreach (var shape in powerPointModal._shapes)
            {
                if (shape.IsPointInsideShape(positionX, positionY))
                {
                    powerPointModal.SelectShape(shape);
                    shape.GetPosition(
                        ref originShapePositionX1,
                        ref originShapePositionY1,
                        ref originShapePositionX2,
                        ref originShapePositionY2
                    );
                    return null;
                }
            }
            powerPointModal.SelectShape(null);
            return null;
        }

        // on mouse move
        public override Shape HandleMouseMove(PowerPointModal powerPointModal, Toolbar toolbar, double positionX, double positionY)
        {
            if(!isMouseDown || powerPointModal._selectedShape == null)
            {
                return null;
            }
            if (powerPointModal._selectedShape.IsPointInsideShape(positionX, positionY))
            {
                powerPointModal.MoveSelectedShape(
                    originShapePositionX1 + ((int)positionX - originMousePositionX),
                    originShapePositionY1 + ((int)positionY - originMousePositionY),
                    originShapePositionX2 + ((int)positionX - originMousePositionX),
                    originShapePositionY2 + ((int)positionY - originMousePositionY)
                );
            }
            return powerPointModal._selectedShape;
        }

        // on mouse down
        public override Shape HandleMouseUp(PowerPointModal powerPointModal, Toolbar toolbar, double positionX, double positionY)
        {
            isMouseDown = false;
            originMousePositionX = (int)positionX;
            originMousePositionY = (int)positionY;

            if (powerPointModal._selectedShape != null)
            {
                powerPointModal._selectedShape.GetPosition(
                    ref originShapePositionX1,
                    ref originShapePositionY1,
                    ref originShapePositionX2,
                    ref originShapePositionY2
                );
            }
            return null;
        }
    }
}
