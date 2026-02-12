using LabelStudio.LabelDesigner;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using LabelStudio.Databases;
using System.Data;

namespace LabelStudio.Printing
{
    public class PrintRenderer
    {
        public void DrawPage(Graphics g, float dpi, LabelTemplate template, bool drawBounds, PrintQueue queue)
        {
            g.PageUnit = GraphicsUnit.Pixel;
            Database db = new Database("defaultDB");
            DataTable table = db.LoadDB();
            var labelRenderer = new LabelRenderer();

            var counter = 0;

            foreach (var plant in queue.Plants)
            {
                var (offsetX, offsetY) = GetLabelOffset(template, counter);

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

                labelRenderer.DrawElements(g, dpi, template, offsetX, offsetY, table.Rows[plant.ID]);

                counter++;
            }
            /*
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
                    labelRenderer.DrawElements(g, dpi, template, offsetX, offsetY, table.Rows[0]);
                }
            }*/
        }

        public (float offsetX, float offsetY) GetLabelOffset(LabelTemplate template, int labelIndex)
        {
            int row = labelIndex / template.Columns;
            int col = labelIndex % template.Columns;

            float offsetX = template.MarginLeft + col * (template.LabelWidth + template.GapX);
            float offsetY = template.MarginTop + row * (template.LabelHeight + template.GapY);



            return (offsetX, offsetY);
        }
    }
}
