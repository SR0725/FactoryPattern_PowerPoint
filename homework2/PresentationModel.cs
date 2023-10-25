using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace homework2
{
    public class PresentationModel
    {
        private readonly PowerPointModal _powerPointModal;

        private ShapeFactory.ShapeType _drawButtonCheckedType = ShapeFactory.ShapeType.None;

        // constructor
        public PresentationModel(PowerPointModal powerPointModal)
        {
            _powerPointModal = powerPointModal;
        }

        // get with type of draw button checked
        public ShapeFactory.ShapeType GetDrawButtonCheckedType()
        {
            return _drawButtonCheckedType;
        }

        // OnDrawButtonChecked
        public void ClickDrawButton(ShapeFactory.ShapeType selectedShapeType)
        {
            if (selectedShapeType == _drawButtonCheckedType)
            {
                _drawButtonCheckedType = ShapeFactory.ShapeType.None;
            }
            else
            {
                _drawButtonCheckedType = selectedShapeType;
            }
        }

        // add new shape
        public Shape AddNewShape(ShapeFactory.ShapeType selectedShapeType)
        {
            return _powerPointModal.AddShape(selectedShapeType);
        }

        // delete shape
        public void DeleteShape(int index)
        {
            _powerPointModal.DeleteShape(index);
        }

        // render all shape
        public void RenderAllShape(Graphics graphics)
        {
            foreach (Shape shape in _powerPointModal._shapes)
            {
                shape.Draw(new WindowsFormsGraphicsAdaptor(graphics));
            }
        }

        // on pointer down
        public Shape HandlePaintPointerDown(double positionX, double positionY)
        {
            if (_drawButtonCheckedType == ShapeFactory.ShapeType.None)
            {
                return null;
            }
            return _powerPointModal.AddWorkPaintShape(_drawButtonCheckedType, positionX, positionY);
        }

        // on pointer move
        public Shape HandlePaintPointerMove(double positionX, double positionY)
        {
            if (_drawButtonCheckedType == ShapeFactory.ShapeType.None)
            {
                return null;
            }

            return _powerPointModal.MoveWorkPaintShape(positionX, positionY);
        }

        // on pointer down
        public Shape HandlePaintPointerUp(double positionX, double positionY)
        {
            if (_drawButtonCheckedType == ShapeFactory.ShapeType.None)
            {
                return null;
            }
            _drawButtonCheckedType = ShapeFactory.ShapeType.None;
            return _powerPointModal.FinishWorkPaintShape(positionX, positionY);
        }

        // get is adding new shape
        public bool IsAddingNewShape()
        {
            return _powerPointModal.IsAddingNewShape();
        }
    }
}
