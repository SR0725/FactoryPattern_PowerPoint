using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    class PointState : IState
    {
        private bool _isMouseDown = false;
        private int _originMousePositionX;
        private int _originMousePositionY;
        private int _originShapePositionX1;
        private int _originShapePositionY1;
        private int _originShapePositionX2;
        private int _originShapePositionY2;

        // get select shape position
        private void GetSelectShapePosition(Shape shape)
        {
            if (shape == null)
            {
                return;
            }
            shape.GetPosition(
                ref _originShapePositionX1,
                ref _originShapePositionY1,
                ref _originShapePositionX2,
                ref _originShapePositionY2
            );
        }

        // set select shape
        private void SetSelectShape(PowerPointModal powerPointModal, Shape shape)
        {
            powerPointModal.SelectShape(shape);
            GetSelectShapePosition(shape);
        }

        // find select shape
        private void FindSelectShape(PowerPointModal powerPointModal, double positionX, double positionY)
        {
            foreach (var shape in powerPointModal._shapes)
            {
                if (shape.IsPointInsideShape(positionX, positionY))
                {
                    SetSelectShape(powerPointModal, shape);
                    return;
                }
            }
        }

        // on mouse down
        public override Shape HandleMouseDown(PowerPointModal powerPointModal, ToolBar toolBar, double positionX, double positionY)
        {
            _originMousePositionX = (int)positionX;
            _originMousePositionY = (int)positionY;
            _isMouseDown = true;
            FindSelectShape(powerPointModal, positionX, positionY);
            return null;
        }

        // on mouse move
        public override Shape HandleMouseMove(PowerPointModal powerPointModal, ToolBar toolBar, double positionX, double positionY)
        {
            if (!_isMouseDown || powerPointModal.SelectedShape == null)
            {
                return null;
            }

            if (powerPointModal.SelectedShape.IsPointInsideShape(positionX, positionY))
            {
                powerPointModal.MoveSelectedShape(
                    _originShapePositionX1 + ((int)positionX - _originMousePositionX),
                    _originShapePositionY1 + ((int)positionY - _originMousePositionY),
                    _originShapePositionX2 + ((int)positionX - _originMousePositionX),
                    _originShapePositionY2 + ((int)positionY - _originMousePositionY)
                );
            }
            return powerPointModal.SelectedShape;
        }

        // on mouse down
        public override Shape HandleMouseUp(PowerPointModal powerPointModal, ToolBar toolBar, double positionX, double positionY)
        {
            _isMouseDown = false;
            _originMousePositionX = (int)positionX;
            _originMousePositionY = (int)positionY;

            Shape selectShape = powerPointModal.SelectedShape;
            GetSelectShapePosition(selectShape);
            return null;
        }
    }
}
