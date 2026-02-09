using LabelStudio.LabelDesigner;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LabelStudio.Printing
{
    public class PrintRenderer
    {
        public void DrawPage(Graphics g, float dpi, LabelTemplate template, bool drawBounds)
        {
            g.PageUnit = GraphicsUnit.Pixel;

            var labelRenderer = new LabelRenderer();

            for (int row = 0; row < template.Rows; row++)
            {
                for (int col = 0; col < template.Columns; col++)
                {
                    //Draw one label

                    //Calculate margin and gap offsets

                    float offsetX = template.MarginLeft + col * (template.LabelWidth + template.GapX);
                    float offsetY = template.MarginTop + row * (template.LabelHeight + template.GapY);

                    //Draw label bounds
                    if (drawBounds)
                    {
                        float x = LabelRenderer.MMtoPx(offsetX, dpi);
                        float y = LabelRenderer.MMtoPx(offsetY, dpi);
                        float w = LabelRenderer.MMtoPx(template.LabelWidth, dpi);
                        float h = LabelRenderer.MMtoPx(template.LabelHeight, dpi);

                        using var pen = new Pen(Color.Black, 5);
                        g.DrawRectangle(pen, x, y, w, h);
                    }

                    labelRenderer.DrawElements(g, dpi, template, offsetX, offsetY);
                }
            }
        }
    }
}
