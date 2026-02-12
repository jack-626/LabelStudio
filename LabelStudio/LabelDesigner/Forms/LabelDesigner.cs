using LabelStudio.Printing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

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
        private PrintQueue queue = new PrintQueue();

        public LabelDesigner()
        {
            InitializeComponent();
            InitTemplate();

            printDocument1.PrinterSettings.Duplex = Duplex.Vertical;

            Debug.WriteLine(printDocument1.PrinterSettings.CanDuplex);

            panelDesigner.BackColor = Color.White;
            panelDesigner.BorderStyle = BorderStyle.FixedSingle;

            //set panel size using template scale
            panelDesigner.Width = (int)LabelRenderer.MMtoPx(_template.LabelWidth, _designDPI);
            panelDesigner.Height = (int)LabelRenderer.MMtoPx(_template.LabelHeight, _designDPI);


            queue = new PrintQueue
            {
                Template = _template
            };

            queue.Plants.Add(new Databases.Plant
            {
                ID = 0,
                Type = "Test 1"
            });

            queue.Plants.Add(new Databases.Plant
            {
                ID = 3,
                Type = "Test 2"
            });

            queue.Plants.Add(new Databases.Plant
            {
                ID = 2,
                Type = "Test 3"
            });
        }

        private void InitTemplate()
        {
            _template = new LabelTemplate
            {
                LabelWidth = 40f,
                LabelHeight = 136f,
                Columns = 5,
                Rows = 2,
                GapX = 1f,
                GapY = 2f,
                MarginLeft = 3f,
                MarginTop = 10f
            };
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
            //e.Graphics.DrawRectangle(Pens.Black, 0, 0, w, h);

            //Highlight selected element
            if (_selectedElement != null)
            {
                RectangleF r = _designRenderer.GetElementRect(_selectedElement, _designDPI);
                using var pen = new Pen(Color.Blue)
                {
                    DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
                };
                var state = e.Graphics.Save();
                e.Graphics.TranslateTransform(r.X + r.Width / 2, r.Y + r.Height / 2);
                e.Graphics.RotateTransform(_selectedElement.RotationDeg);
                e.Graphics.TranslateTransform(-(r.X + r.Width / 2), -(r.Y + r.Height / 2));
                e.Graphics.DrawRectangle(pen, r.X, r.Y, r.Width, r.Height);
                e.Graphics.Restore(state);
            }
        }

        //Select element when clicked
        private void panelDesigner_MouseDown(object sender, MouseEventArgs e)
        {
            //Set previously selected element to null
            _selectedElement = null;
            _dragging = false;

            //Reverse loop through all elements and select the one under the mouse cursor.
            for (int i = _template.Elements.Count - 1; i >= 0; i--)
            {
                var element = _template.Elements[i];
                if (_designRenderer.HitTestElement(element, e.Location, _designDPI))
                {
                    _selectedElement = element;
                    _dragging = true;
                    _lastMouse = e.Location;
                    break;
                }
            }
            panelDesigner.Invalidate();
        }

        //Mouse dragging
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

            _designRenderer.ClampToLabel(_selectedElement, _template, _designDPI);

            panelDesigner.Invalidate();
        }

        //Set dragging to false on mouse up
        private void panelDesigner_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private int _pageIndex;
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            var printRenderer = new PrintRenderer();
            //printRenderer.DrawPage(e.Graphics, e.Graphics.DpiX, _template, true);
            //e.HasMorePages = false;

            if (_pageIndex == 0)
            {
                printRenderer.DrawPage(e.Graphics, e.Graphics.DpiX, _template, true, queue);
            }
            else if (_pageIndex == 1)
            {
                printRenderer.DrawPage(e.Graphics, e.Graphics.DpiX, _template, true, queue);
            }
            _pageIndex++;
            e.HasMorePages = _pageIndex < 2;
        }

        // Right Click -> New Element -> Text
        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _template.Elements.Add(new LabelTextElement
            {
                DataType = "Unassigned Text Element",
                X = 0,
                Y = 0,
                Width = 30,
                Height = 10,
                FontSize = 12,
                RotationDeg = 0f
            });

            panelDesigner.Invalidate();
        }

        // File -> Print
        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Width = 1000;
            printPreviewDialog1.Height = 800;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
        {
            _pageIndex = 0;
        }

        private void panelDesigner_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_selectedElement != null)
            {
                if(_selectedElement is LabelTextElement _element)
                {
                    using (var form = new EditTextElement(_element))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            panelDesigner.Invalidate();
                        }
                    }
                } else if (_selectedElement is LabelImageElement)
                {
                    // edit image form
                }
            }
        }
    }
}