using System.Drawing;

namespace homework2
{
    public class PresentationModel
    {
        private readonly PowerPointModal _powerPointModal;
        public Toolbar toolbar = new Toolbar();

        // constructor
        public PresentationModel(PowerPointModal powerPointModal)
        {
            _powerPointModal = powerPointModal;
        }

        // OnDrawButtonChecked
        public void SetToolbar(Toolbar.ToolbarType selectedShapeType)
        {
            if (selectedShapeType == toolbar.checkedType)
            {
                toolbar.checkedType = Toolbar.ToolbarType.None;
            }
            else
            {
                toolbar.checkedType = selectedShapeType;
            }
            _powerPointModal.HandleChangeContext(toolbar);
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

        // delete selected shape
        public void DeleteSelectedShape()
        {
            _powerPointModal.DeleteSelectedShape();
        }

        // render all shape
        public void RenderAllShape(Graphics graphics)
        {
            foreach (Shape shape in _powerPointModal._shapes)
            {
                shape.Draw(new WindowsFormsGraphicsAdaptor(graphics));
            }
            if (_powerPointModal._selectedShape != null)
            {
                _powerPointModal._selectedShape.DrawSelectedBorder(new WindowsFormsGraphicsAdaptor(graphics));
            }
        }

        // mouse down
        public Shape HandleMouseDown(double positionX, double positionY)
        {
            return _powerPointModal.HandleMouseDown(toolbar, positionX, positionY);
        }

        // mouse move
        public Shape HandleMouseMove(double positionX, double positionY)
        {
            return _powerPointModal.HandleMouseMove(toolbar, positionX, positionY);
        }

        // mouse up
        public Shape HandleMouseUp(double positionX, double positionY)
        {
            return _powerPointModal.HandleMouseUp(toolbar, positionX, positionY);
        }

        // get shape in list index
        public int GetShapeIndex(Shape shape)
        {
            return _powerPointModal.GetShapeIndex(shape);
        }

        // get is adding new shape
        public bool IsAddingNewShape()
        {
            return _powerPointModal.IsAddingNewShape();
        }
    }
}
