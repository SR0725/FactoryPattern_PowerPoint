using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    class DrawingState : IState
    {

        // on mouse down
        public override Shape HandleMouseDown(PowerPointModal powerPointModal, ToolBar toolBar, double positionX, double positionY)
        {
            if (toolBar.checkedType == ToolBar.ToolBarType.None)
            {
                return null;
            }
            return powerPointModal.AddWorkPaintShape((ShapeFactory.ShapeType)toolBar.checkedType, positionX, positionY);
        }

        // on mouse move
        public override Shape HandleMouseMove(PowerPointModal powerPointModal, ToolBar toolBar, double positionX, double positionY)
        {
            if (toolBar.checkedType == ToolBar.ToolBarType.None)
            {
                return null;
            }

            return powerPointModal.MoveWorkPaintShape(positionX, positionY);
        }

        // on mouse down
        public override Shape HandleMouseUp(PowerPointModal powerPointModal, ToolBar toolBar, double positionX, double positionY)
        {
            if (toolBar.checkedType == ToolBar.ToolBarType.None)
            {
                return null;
            }
            toolBar.checkedType = ToolBar.ToolBarType.None;
            return powerPointModal.FinishWorkPaintShape(positionX, positionY);
        }
    }
}
