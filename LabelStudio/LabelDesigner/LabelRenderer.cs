using System;
using System.Collections.Generic;
using System.Text;

namespace LabelStudio.LabelDesigner
{
    public class LabelRenderer
    {
        // Declare units for converting pixels to real units.
        public const float mmPerInch = 25.4f;
        // Convert design units to PX using DPI.
        public static float MMtoPx(float mm, float dpi)
        {
            return mm / mmPerInch * dpi;
        }

        // Draw all elements. 
        public void DrawElements(Graphics g, float dpi, LabelTemplate template, float offsetX, float offsetY)
        {
            g.PageUnit = GraphicsUnit.Pixel;

            foreach (var element in template.Elements)
            {
                float x = MMtoPx(element.X + offsetX, dpi);
                float y = MMtoPx(element.Y + offsetY, dpi);
                float w = MMtoPx(element.Width, dpi);
                float h = MMtoPx(element.Height, dpi);

                var rect = new RectangleF(x, y, w, h);
                g.DrawRectangle(Pens.Black, rect);

                if(element is LabelTextElement text)
                {
                    using var font = new Font(
                        text.FontName,
                        text.FontSize,
                        FontStyle.Regular);

                    g.DrawString(text.Text, font, Brushes.Black, rect);
                }
            }
        }
        
        public RectangleF GetElementRect(LabelElement el, float dpi)
        {
            return new RectangleF(
                MMtoPx(el.X, dpi),
                MMtoPx(el.Y, dpi),
                MMtoPx(el.Width, dpi),
                MMtoPx(el.Height, dpi)
            );
        }
    }
}
