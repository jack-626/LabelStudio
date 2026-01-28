using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace LabelStudio.LabelDesigner.Forms
{
    public partial class LabelDesigner : Form
    {
        private LabelTemplate _template;
        private LabelElement? _selectedElement;
        private bool _dragging;
        private Point _lastMouse;
        private const float _designDPI = 96f;
        private LabelRenderer _designRenderer = new LabelRenderer();

        public LabelDesigner()
        {
            InitializeComponent();
            InitTemplate();

            panelDesigner.BackColor = Color.White;
            panelDesigner.BorderStyle = BorderStyle.FixedSingle;

            //set panel size using template scale
            panelDesigner.Width = (int)LabelRenderer.MMtoPx(_template.LabelWidth, _designDPI);
            panelDesigner.Height = (int)LabelRenderer.MMtoPx(_template.LabelHeight, _designDPI);
        }

        private void InitTemplate()
        {
            _template = new LabelTemplate
            {
                LabelWidth = 40f,
                LabelHeight = 136f,
                Columns = 5,
                Rows = 2,
                GapXmm = 0f,
                GapYmm = 0f,
                MarginLeftMM = 0f,
                MarginTopMM = 0f
            };

            _template.Elements.Add(new LabelTextElement
            {
                Text = "Test Label",
                X = 0.5f,
                Y = 0.5f,
                Width = 40,
                Height = 10,
                FontSize = 20
            });

            _template.Elements.Add(new LabelTextElement
            {
                Text = "Test Label2",
                X = 0.5f,
                Y = 41f,
                Width = 30,
                Height = 10,
                FontSize = 12
            });

        }

        private void panelDesigner_Paint(object sender, PaintEventArgs e)
        {
            //Clear the background with White color.
            e.Graphics.Clear(Color.White);

            //Draw all elements using design DPI and template.
            _designRenderer.DrawElements(e.Graphics, _designDPI, _template, 0, 0);

            //draw border rectangle
            float w = LabelRenderer.MMtoPx(_template.LabelWidth, _designDPI);
            float h = LabelRenderer.MMtoPx(_template.LabelHeight, _designDPI);
            e.Graphics.DrawRectangle(Pens.Black, 0, 0, w, h);

            //Highlight selected element
            if (_selectedElement != null)
            {
                RectangleF r = _designRenderer.GetElementRect(_selectedElement, _designDPI);
                using var pen = new Pen(Color.Blue)
                {
                    DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
                };
                e.Graphics.DrawRectangle(pen, r.X, r.Y, r.Width, r.Height);
            }
        }

        private void panelDesigner_MouseDown(object sender, MouseEventArgs e)
        {
            //Set previously selected element to null
            _selectedElement = null;

            //Loop through all elements and select the one under the mouse cursor.
            foreach (var element in _template.Elements)
            {
                var rect = _designRenderer.GetElementRect(element, _designDPI);

                if (rect.Contains(e.Location))
                {
                    _selectedElement = element;
                    _dragging = true;
                    _lastMouse = e.Location;
                    break;
                }
            }
            panelDesigner.Invalidate();
        }

        private void panelDesigner_MouseMove(object sender, MouseEventArgs e)
        {
            //Check if not dragging or if nothing is selected, do nothing if so.
            if (!_dragging || _selectedElement == null)
            {
                return;
            }

            float dx = (e.X - _lastMouse.X) / _designDPI * LabelRenderer.mmPerInch;
            float dy = (e.Y - _lastMouse.Y) / _designDPI * LabelRenderer.mmPerInch;

            _selectedElement.X += dx;
            _selectedElement.Y += dy;

            _lastMouse = e.Location;
            panelDesigner.Invalidate();
        }

        private void panelDesigner_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Width = 1000;
            printPreviewDialog1.Height = 800;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            var printRenderer = new LabelRenderer();

            var dpi = e.Graphics.DpiX;

            for (int row = 0; row < _template.Rows; row++)
            {
                for (int col = 0; col < _template.Columns; col++)
                {
                    float offsetX = _template.MarginLeftMM + col * (_template.LabelWidth + _template.GapXmm);
                    float offsetY = _template.MarginTopMM + row * (_template.LabelHeight + _template.GapYmm);

                    // show label bounds
                    float x = LabelRenderer.MMtoPx(offsetX, dpi);
                    float y = LabelRenderer.MMtoPx(offsetY, dpi);
                    float w = LabelRenderer.MMtoPx(_template.LabelWidth, dpi);
                    float h = LabelRenderer.MMtoPx(_template.LabelHeight, dpi);

                    using var pen = new Pen(Color.Gray, 5);
                    e.Graphics.DrawRectangle(pen, x, y, w, h);

                    printRenderer.DrawElements(e.Graphics, e.Graphics.DpiX, _template, offsetX, offsetY);
                }
            }
            e.HasMorePages = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _template.Elements.Add(new LabelTextElement
            {
                Text = "Test Label23",
                X = 0.5f,
                Y = 4f,
                Width = 30,
                Height = 10,
                FontSize = 12
            });

            panelDesigner.Invalidate();
        }
    }
}