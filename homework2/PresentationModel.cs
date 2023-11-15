using System.Drawing;

namespace homework2
{
    public class PresentationModel
    {
        private readonly PowerPointModal _powerPointModal;

        // ToolBar
        public ToolBar _toolBar
        {
            get;
            set;
        }

        // constructor
        public PresentationModel(PowerPointModal powerPointModal)
        {
            _powerPointModal = powerPointModal;
            _toolBar = new ToolBar();
        }

        // OnDrawButtonChecked
        public void SetToolBar(ToolBar.ToolBarType selectedShapeType)
        {
            if (selectedShapeType == _toolBar.checkedType)
            {
                _toolBar.checkedType = ToolBar.ToolBarType.None;
            }
            else
            {
                _toolBar.checkedType = selectedShapeType;
            }
            _powerPointModal.HandleChangeContext(_toolBar);
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

        // render select shape
        public void RenderSelectShape(Graphics graphics, float scale)
        {
            if (_powerPointModal.SelectedShape == null)
            {
                return;
            }
            _powerPointModal.SelectedShape.DrawSelectedBorder(new WindowsFormsGraphicsAdaptor(graphics, scale));
        }

        // render all shape
        public void RenderAllShape(Graphics graphics, float scale)
        {
            foreach (Shape shape in _powerPointModal._shapes)
            {
                shape.Draw(new WindowsFormsGraphicsAdaptor(graphics, scale));
            }
        }

        // mouse down
        public Shape HandleMouseDown(double positionX, double positionY)
        {
            return _powerPointModal.HandleMouseDown(_toolBar, positionX, positionY);
        }

        // mouse move
        public Shape HandleMouseMove(double positionX, double positionY)
        {
            return _powerPointModal.HandleMouseMove(_toolBar, positionX, positionY);
        }

        // mouse up
        public Shape HandleMouseUp(double positionX, double positionY)
        {
            return _powerPointModal.HandleMouseUp(_toolBar, positionX, positionY);
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
