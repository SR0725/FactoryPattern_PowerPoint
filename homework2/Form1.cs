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
        private PresentationModel _presentationModel;

        public Form1(PowerPointModal powerPointModal, PresentationModel presentationModel)
        {
            _presentationModel = presentationModel;
            InitializeComponent();

            powerPointModal._modelChanged += HandleModelChanged;
            powerPointModal._modelChanged += HandleChangeDrawButtonState;
            powerPointModal._modelChanged += HandleCursorStateChange;
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
            const float NORMAL_SCALE = 1.0f;
            _presentationModel.RenderAllShape(e.Graphics, NORMAL_SCALE);
            _presentationModel.RenderSelectShape(e.Graphics, NORMAL_SCALE);
        }

        //  handle child canvas render
        private void HandleChildCanvasPaint(object sender, PaintEventArgs e)
        {
            const float SMALL_SCALE = 0.15f;
            _presentationModel.RenderAllShape(e.Graphics, SMALL_SCALE);
            _presentationModel.RenderSelectShape(e.Graphics, SMALL_SCALE);
        }

        // handel model change
        public void HandleModelChanged()
        {
            Invalidate(true);
        }

        // handle line tool strip button click
        private void HandleLineToolStripButtonClick(object sender, EventArgs e)
        {
            _presentationModel.SetToolBar(ToolBar.ToolBarType.Line);
            HandleChangeDrawButtonState();
        }

        // handle rectangle tool strip button click
        private void HandleRectangleToolStripButtonClick(object sender, EventArgs e)
        {
            _presentationModel.SetToolBar(ToolBar.ToolBarType.Rectangle);
            HandleChangeDrawButtonState();
        }

        // handle circle tool strip button click
        private void HandleCircleToolStripButtonClick(object sender, EventArgs e)
        {
            _presentationModel.SetToolBar(ToolBar.ToolBarType.Circle);
            HandleChangeDrawButtonState();
        }

        // handle arrow tool strip button click
        private void HandleArrowToolStripButtonClick(object sender, EventArgs e)
        {
            _presentationModel.SetToolBar(ToolBar.ToolBarType.PointState);
            HandleChangeDrawButtonState();
        }

        // handle canvas mouse down
        private void HandleChangeDrawButtonState()
        {
            _lineToolStripButton.Checked = _presentationModel._toolBar.checkedType == ToolBar.ToolBarType.Line;
            _rectangleToolStripButton.Checked = _presentationModel._toolBar.checkedType == ToolBar.ToolBarType.Rectangle;
            _circleToolStripButton.Checked = _presentationModel._toolBar.checkedType == ToolBar.ToolBarType.Circle;
            _arrowToolStripButton.Checked = _presentationModel._toolBar.checkedType == ToolBar.ToolBarType.PointState;
        }

        // handle key down
        public void HandleKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Delete)
            {
                _presentationModel.DeleteSelectedShape();
            }
        }

        // handle canvas mouse down
        private void HandleMouseDown(object sender, MouseEventArgs e)
        {
            Shape workShape = _presentationModel.HandleMouseDown(e.X, e.Y);

            if (workShape != null)
            {
                const string DELETE_BUTTON_STRING = "刪除";
                _shapesDataGridView.Rows.Add(DELETE_BUTTON_STRING, workShape.GetShapeName(), workShape.GetInfo());
            }
        }

        // UpdateShapesDataGrid
        private void UpdateShapesDataGrid(Shape shape)
        {
            if (shape == null)
            {
                return;
            }
            int shapesDataGridViewRowIndex = _presentationModel.GetShapeIndex(shape);
            const int SECOND = 2;
            _shapesDataGridView.Rows[shapesDataGridViewRowIndex].Cells[SECOND].Value = shape.GetInfo();
        }

        // handle canvas mouse move
        private void HandleMouseMove(object sender, MouseEventArgs e)
        {
            UpdateShapesDataGrid(_presentationModel.HandleMouseMove(e.X, e.Y));
        }

        // handle canvas mouse up
        private void HandleMouseUp(object sender, MouseEventArgs e)
        {
            UpdateShapesDataGrid(_presentationModel.HandleMouseUp(e.X, e.Y));
        }

        // handle render panel mouse enter
        private void HandleRenderPanelMouseEnter(object sender, EventArgs e)
        {
            if (_presentationModel._toolBar.checkedType == ToolBar.ToolBarType.None)
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
