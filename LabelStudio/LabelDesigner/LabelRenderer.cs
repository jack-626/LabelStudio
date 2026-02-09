using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Drawing2D;

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

                //Save graphics state
                var state = g.Save(); 
                //Translate to element center
                g.TranslateTransform(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
                //Rotate element
                g.RotateTransform(element.RotationDeg);
                //Reverse translation
                g.TranslateTransform(-(rect.X + rect.Width / 2), -(rect.Y + rect.Height / 2));


                //Draw black rectangle around element
                g.DrawRectangle(Pens.Black, rect);

                //Check element type

                //Text element
                if(element is LabelTextElement text)
                {
                    using var font = new Font(
                        text.FontName,
                        text.FontSize,
                        FontStyle.Regular);

                    g.DrawString(text.Text, font, Brushes.Black, rect);
                }

                //Image element
                if(element is LabelImageElement image)
                {
                    
                }

                // Restore graphics state
                g.Restore(state); 
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

        public bool HitTestElement(LabelElement el, PointF mousePx, float dpi)
        {
            RectangleF rect = GetElementRect(el, dpi);

            float cx = rect.X + rect.Width / 2f;
            float cy = rect.Y + rect.Height / 2f;

            using var matrix = new Matrix();
            matrix.RotateAt(-el.RotationDeg, new PointF(cx, cy));
            PointF[] pts = { mousePx };
            matrix.TransformPoints(pts);
            return rect.Contains(pts[0]);
        }
    }
}
