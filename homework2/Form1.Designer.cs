
namespace homework2
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this._slideSelectionArea = new System.Windows.Forms.Panel();
            this._slider2 = new System.Windows.Forms.Button();
            this._slider1 = new System.Windows.Forms.Button();
            this._renderPanel = new DoubleBufferedPanel();
            this._slideInfoArea = new System.Windows.Forms.GroupBox();
            this._addNewShapeSelector = new System.Windows.Forms.ComboBox();
            this._addNewShapeButton = new System.Windows.Forms.Button();
            this._shapesDataGridView = new System.Windows.Forms.DataGridView();
            this._deleteColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this._shapeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._infoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._menu = new System.Windows.Forms.Panel();
            this._headMenu = new System.Windows.Forms.MenuStrip();
            this._headMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this._headMenuItemHelpChildAbout = new System.Windows.Forms.ToolStripMenuItem();
            this._toolPanel = new System.Windows.Forms.Panel();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._lineToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._rectangleToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._circleToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._slideSelectionArea.SuspendLayout();
            this._slideInfoArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._shapesDataGridView)).BeginInit();
            this._menu.SuspendLayout();
            this._headMenu.SuspendLayout();
            this._toolPanel.SuspendLayout();
            this._toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _slideSelectionArea
            // 
            this._slideSelectionArea.BackColor = System.Drawing.SystemColors.ControlDark;
            this._slideSelectionArea.Controls.Add(this._slider2);
            this._slideSelectionArea.Controls.Add(this._slider1);
            this._slideSelectionArea.Location = new System.Drawing.Point(0, 48);
            this._slideSelectionArea.Name = "_slideSelectionArea";
            this._slideSelectionArea.Size = new System.Drawing.Size(171, 728);
            this._slideSelectionArea.TabIndex = 1;
            // 
            // _slider2
            // 
            this._slider2.Location = new System.Drawing.Point(8, 105);
            this._slider2.Name = "_slider2";
            this._slider2.Size = new System.Drawing.Size(152, 78);
            this._slider2.TabIndex = 1;
            this._slider2.UseVisualStyleBackColor = true;
            // 
            // _slider1
            // 
            this._slider1.Location = new System.Drawing.Point(7, 9);
            this._slider1.Name = "_slider1";
            this._slider1.Size = new System.Drawing.Size(154, 82);
            this._slider1.TabIndex = 0;
            this._slider1.UseVisualStyleBackColor = true;
            // 
            // _renderPanel
            // 
            this._renderPanel.Location = new System.Drawing.Point(167, 48);
            this._renderPanel.Name = "_renderPanel";
            this._renderPanel.Size = new System.Drawing.Size(1009, 674);
            this._renderPanel.TabIndex = 4;
            this._renderPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.HandleCanvasPaint);
            this._renderPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HandlePaintPointerDown);
            this._renderPanel.MouseEnter += new System.EventHandler(this.HandleRenderPanelMouseEnter);
            this._renderPanel.MouseLeave += new System.EventHandler(this.HandleRenderPanelMouseLeave);
            this._renderPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HandlePaintPointerMove);
            this._renderPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HandlePaintPointerUp);
            // 
            // _slideInfoArea
            // 
            this._slideInfoArea.Controls.Add(this._addNewShapeSelector);
            this._slideInfoArea.Controls.Add(this._addNewShapeButton);
            this._slideInfoArea.Controls.Add(this._shapesDataGridView);
            this._slideInfoArea.Location = new System.Drawing.Point(1176, 48);
            this._slideInfoArea.Name = "_slideInfoArea";
            this._slideInfoArea.Size = new System.Drawing.Size(269, 680);
            this._slideInfoArea.TabIndex = 3;
            this._slideInfoArea.TabStop = false;
            this._slideInfoArea.Text = "資料顯示";
            // 
            // _addNewShapeSelector
            // 
            this._addNewShapeSelector.FormattingEnabled = true;
            this._addNewShapeSelector.Items.AddRange(new object[] {
            "矩形",
            "線",
            "圓形"});
            this._addNewShapeSelector.Location = new System.Drawing.Point(63, 30);
            this._addNewShapeSelector.Name = "_addNewShapeSelector";
            this._addNewShapeSelector.Size = new System.Drawing.Size(121, 20);
            this._addNewShapeSelector.TabIndex = 2;
            // 
            // _addNewShapeButton
            // 
            this._addNewShapeButton.Location = new System.Drawing.Point(6, 21);
            this._addNewShapeButton.Name = "_addNewShapeButton";
            this._addNewShapeButton.Size = new System.Drawing.Size(51, 36);
            this._addNewShapeButton.TabIndex = 1;
            this._addNewShapeButton.Text = "新增";
            this._addNewShapeButton.UseVisualStyleBackColor = true;
            this._addNewShapeButton.Click += new System.EventHandler(this.HandleAddNewShapeButtonClick);
            // 
            // _shapesDataGridView
            // 
            this._shapesDataGridView.AllowUserToAddRows = false;
            this._shapesDataGridView.AllowUserToDeleteRows = false;
            this._shapesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._shapesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._shapesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._deleteColumn,
            this._shapeColumn,
            this._infoColumn});
            this._shapesDataGridView.Location = new System.Drawing.Point(6, 63);
            this._shapesDataGridView.Name = "_shapesDataGridView";
            this._shapesDataGridView.ReadOnly = true;
            this._shapesDataGridView.RowHeadersVisible = false;
            this._shapesDataGridView.RowTemplate.Height = 24;
            this._shapesDataGridView.RowTemplate.ReadOnly = true;
            this._shapesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._shapesDataGridView.Size = new System.Drawing.Size(257, 611);
            this._shapesDataGridView.TabIndex = 3;
            this._shapesDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.HandleDeleteShapeButtonClick);
            // 
            // _deleteColumn
            // 
            this._deleteColumn.HeaderText = "刪除";
            this._deleteColumn.Name = "_deleteColumn";
            this._deleteColumn.ReadOnly = true;
            this._deleteColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._deleteColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._deleteColumn.Text = "刪除";
            // 
            // _shapeColumn
            // 
            this._shapeColumn.HeaderText = "形狀";
            this._shapeColumn.Name = "_shapeColumn";
            this._shapeColumn.ReadOnly = true;
            // 
            // _infoColumn
            // 
            this._infoColumn.HeaderText = "資訊";
            this._infoColumn.Name = "_infoColumn";
            this._infoColumn.ReadOnly = true;
            // 
            // _menu
            // 
            this._menu.BackColor = System.Drawing.SystemColors.ControlLight;
            this._menu.Controls.Add(this._headMenu);
            this._menu.Location = new System.Drawing.Point(0, 0);
            this._menu.Name = "_menu";
            this._menu.Size = new System.Drawing.Size(1445, 21);
            this._menu.TabIndex = 0;
            // 
            // _headMenu
            // 
            this._headMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._headMenuItemHelp});
            this._headMenu.Location = new System.Drawing.Point(0, 0);
            this._headMenu.Name = "_headMenu";
            this._headMenu.Size = new System.Drawing.Size(1445, 24);
            this._headMenu.TabIndex = 0;
            this._headMenu.Text = "_headMenu";
            // 
            // _headMenuItemHelp
            // 
            this._headMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._headMenuItemHelpChildAbout});
            this._headMenuItemHelp.Name = "_headMenuItemHelp";
            this._headMenuItemHelp.Size = new System.Drawing.Size(45, 20);
            this._headMenuItemHelp.Text = "說明";
            // 
            // _headMenuItemHelpChildAbout
            // 
            this._headMenuItemHelpChildAbout.Name = "_headMenuItemHelpChildAbout";
            this._headMenuItemHelpChildAbout.Size = new System.Drawing.Size(131, 22);
            this._headMenuItemHelpChildAbout.Text = "說明/關於";
            // 
            // _toolPanel
            // 
            this._toolPanel.Controls.Add(this._toolStrip);
            this._toolPanel.Location = new System.Drawing.Point(0, 27);
            this._toolPanel.Name = "_toolPanel";
            this._toolPanel.Size = new System.Drawing.Size(1445, 24);
            this._toolPanel.TabIndex = 0;
            // 
            // _toolStrip
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._lineToolStripButton,
            this._rectangleToolStripButton,
            this._circleToolStripButton});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(1445, 25);
            this._toolStrip.TabIndex = 0;
            this._toolStrip.Text = "_toolStrip";
            // 
            // _lineToolStripButton
            // 
            this._lineToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._lineToolStripButton.Image = global::homework2.Properties.Resources.line;
            this._lineToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._lineToolStripButton.Name = "_lineToolStripButton";
            this._lineToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._lineToolStripButton.Click += new System.EventHandler(this.HandleLineToolStripButtonClick);
            // 
            // _rectangleToolStripButton
            // 
            this._rectangleToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._rectangleToolStripButton.Image = global::homework2.Properties.Resources.Rectangle;
            this._rectangleToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._rectangleToolStripButton.Name = "_rectangleToolStripButton";
            this._rectangleToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._rectangleToolStripButton.Click += new System.EventHandler(this.HandleRectangleToolStripButtonClick);
            // 
            // _circleToolStripButton
            // 
            this._circleToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._circleToolStripButton.Image = global::homework2.Properties.Resources.circle;
            this._circleToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._circleToolStripButton.Name = "_circleToolStripButton";
            this._circleToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._circleToolStripButton.Click += new System.EventHandler(this.HandleCircleToolStripButtonClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1445, 722);
            this.Controls.Add(this._toolPanel);
            this.Controls.Add(this._menu);
            this.Controls.Add(this._renderPanel);
            this.Controls.Add(this._slideSelectionArea);
            this.Controls.Add(this._slideInfoArea);
            this.MainMenuStrip = this._headMenu;
            this.Name = "Form1";
            this.Text = "Form1";
            this._slideSelectionArea.ResumeLayout(false);
            this._slideInfoArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._shapesDataGridView)).EndInit();
            this._menu.ResumeLayout(false);
            this._menu.PerformLayout();
            this._headMenu.ResumeLayout(false);
            this._headMenu.PerformLayout();
            this._toolPanel.ResumeLayout(false);
            this._toolPanel.PerformLayout();
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel _slideSelectionArea;
        private System.Windows.Forms.Button _slider2;
        private System.Windows.Forms.Button _slider1;
        private DoubleBufferedPanel _renderPanel;
        private System.Windows.Forms.GroupBox _slideInfoArea;
        private System.Windows.Forms.ComboBox _addNewShapeSelector;
        private System.Windows.Forms.Button _addNewShapeButton;
        private System.Windows.Forms.DataGridView _shapesDataGridView;
        private System.Windows.Forms.DataGridViewButtonColumn _deleteColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _shapeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _infoColumn;
        private System.Windows.Forms.Panel _menu;
        private System.Windows.Forms.MenuStrip _headMenu;
        private System.Windows.Forms.ToolStripMenuItem _headMenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem _headMenuItemHelpChildAbout;
        private System.Windows.Forms.Panel _toolPanel;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _lineToolStripButton;
        private System.Windows.Forms.ToolStripButton _rectangleToolStripButton;
        private System.Windows.Forms.ToolStripButton _circleToolStripButton;
    }
}

