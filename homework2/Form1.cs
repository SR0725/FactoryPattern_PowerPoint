using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework2
{
    public partial class Form1 : Form
    {
        private PowerPointModal _powerPointModal;
        private PresentationModel _presentationModel;

        public Form1(PowerPointModal powerPointModal, PresentationModel presentationModel)
        {
            _powerPointModal = powerPointModal;
            _presentationModel = presentationModel;
            InitializeComponent();

            _powerPointModal._modelChanged += HandleModelChanged;
            _powerPointModal._modelChanged += HandleChangeDrawButtonState;
            _powerPointModal._modelChanged += HandleCursorStateChange;
        }

        // add new shape
        private void HandleAddNewShapeButtonClick(object sender, EventArgs e)
        {
            ShapeFactory.ShapeType selectedShapeType = (ShapeFactory.ShapeType)_addNewShapeSelector.SelectedIndex;
            Shape newShape = _presentationModel.AddNewShape(selectedShapeType);

            if (newShape != null)
            {
                const string DELETE_BUTTON_STRING = "刪除";
                _shapesDataGridView.Rows.Add(DELETE_BUTTON_STRING, newShape.GetShapeName(), newShape.GetInfo());
            }
        }

        // delete shpae
        private void HandleDeleteShapeButtonClick(object sender, DataGridViewCellEventArgs e)
        {
            int clickColumn = e.ColumnIndex;
            if (clickColumn != 0)
            {
                return;
            }
            int selectedRowIndex = e.RowIndex;
            _presentationModel.DeleteShape(selectedRowIndex);
            _shapesDataGridView.Rows.RemoveAt(selectedRowIndex);
        }

        // handle canvas render
        private void HandleCanvasPaint(object sender, PaintEventArgs e)
        {
            _presentationModel.RenderAllShape(e.Graphics);
        }

        // handel model change
        public void HandleModelChanged()
        {
            Invalidate(true);
        }

        // handle line tool strip button click
        private void HandleLineToolStripButtonClick(object sender, EventArgs e)
        {
            _presentationModel.ClickDrawButton(ShapeFactory.ShapeType.Line);
            HandleChangeDrawButtonState();
        }

        // handle rectangle tool strip button click
        private void HandleRectangleToolStripButtonClick(object sender, EventArgs e)
        {
            _presentationModel.ClickDrawButton(ShapeFactory.ShapeType.Rectangle);
            HandleChangeDrawButtonState();
        }

        // handle circle tool strip button click
        private void HandleCircleToolStripButtonClick(object sender, EventArgs e)
        {
            _presentationModel.ClickDrawButton(ShapeFactory.ShapeType.Circle);
            HandleChangeDrawButtonState();
        }

        // handle canvas mouse down
        private void HandleChangeDrawButtonState()
        {
            _lineToolStripButton.Checked = _presentationModel.GetDrawButtonCheckedType() == ShapeFactory.ShapeType.Line;
            _rectangleToolStripButton.Checked = _presentationModel.GetDrawButtonCheckedType() == ShapeFactory.ShapeType.Rectangle;
            _circleToolStripButton.Checked = _presentationModel.GetDrawButtonCheckedType() == ShapeFactory.ShapeType.Circle;

        }

        // handle canvas mouse down
        private void HandlePaintPointerDown(object sender, MouseEventArgs e)
        {
            Shape workShape = _presentationModel.HandlePaintPointerDown(e.X, e.Y);

            if (workShape != null)
            {
                const string DELETE_BUTTON_STRING = "刪除";
                _shapesDataGridView.Rows.Add(DELETE_BUTTON_STRING, workShape.GetShapeName(), workShape.GetInfo());
            }
        }

        // handle canvas mouse move
        private void HandlePaintPointerMove(object sender, MouseEventArgs e)
        {
            Shape workShape = _presentationModel.HandlePaintPointerMove(e.X, e.Y);
            if (workShape != null)
            {
                int lastShapesDataGridViewRowIndex = _shapesDataGridView.Rows.Count - 1;
                const int SECOND = 2;
                _shapesDataGridView.Rows[lastShapesDataGridViewRowIndex].Cells[SECOND].Value = workShape.GetInfo();
            }
        }

        // handle canvas mouse up
        private void HandlePaintPointerUp(object sender, MouseEventArgs e)
        {
            Shape workShape = _presentationModel.HandlePaintPointerUp(e.X, e.Y);
            if (workShape != null)
            {
                int lastShapesDataGridViewRowIndex = _shapesDataGridView.Rows.Count - 1;
                const int SECOND = 2;
                _shapesDataGridView.Rows[lastShapesDataGridViewRowIndex].Cells[SECOND].Value = workShape.GetInfo();
            }
        }

        // handle render panel mouse enter
        private void HandleRenderPanelMouseEnter(object sender, EventArgs e)
        {
            if (_presentationModel.GetDrawButtonCheckedType() == ShapeFactory.ShapeType.None)
            {
                return;
            }
            Cursor = Cursors.Cross;
        }

        // handle render panel mouse leave
        private void HandleRenderPanelMouseLeave(object sender, EventArgs e)
        {
            HandleCursorStateChange();
        }

        // handle render panel cursor change
        private void HandleCursorStateChange()
        {
            if (_presentationModel.IsAddingNewShape() == true)
            {
                Cursor = Cursors.Cross;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
