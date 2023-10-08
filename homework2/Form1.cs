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

        public Form1(PowerPointModal powerPointModal)
        {
            _powerPointModal = powerPointModal;
            InitializeComponent();

        }

        // add new shape
        private void AddNewShapeButtonClick(object sender, EventArgs e)
        {
            ShapeFactory.ShapeType selectedShapeIndex = (ShapeFactory.ShapeType)_addNewShapeSelector.SelectedIndex;
            Shape newShape = _powerPointModal.AddShape(selectedShapeIndex);

            if (newShape != null)
            {
                const string DELETE_BUTTON_STRING = "刪除";
                _shapesDataGridView.Rows.Add(DELETE_BUTTON_STRING, newShape.GetShapeName(), newShape.GetInfo());

            }
        }

        // delete shpae
        private void DeleteShapeButtonClick(object sender, DataGridViewCellEventArgs e)
        {
            int clickColumn = e.ColumnIndex;
            if (clickColumn != 0)
            {
                return;
            }
            int selectedRowIndex = e.RowIndex;
            _powerPointModal.DeleteShape(selectedRowIndex);
            _shapesDataGridView.Rows.RemoveAt(selectedRowIndex);
        }
    }
}
