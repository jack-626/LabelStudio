using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Drawing2D;
using LabelStudio.Databases;
using System.Data;

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

        public static float PxtoMM(float px, float dpi)
        {
            return px * mmPerInch / dpi;
        }

        // Draw all elements. 
        public void DrawElements(Graphics g, float dpi, LabelTemplate template, float offsetX, float offsetY, DataRow data = null)
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

                    string value;
                    if(data != null)
                    {
                        value = text.GetTextFromData(data);
                    } else
                    {
                        value = text.DataType;
                    }
                    g.DrawString(value, font, Brushes.Black, rect);
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

        public PointF[] GetCorners(RectangleF rect, float rotationDeg)
        {
            float cx = rect.X + rect.Width / 2f;
            float cy = rect.Y + rect.Height / 2f;

            PointF[] corners =
            {
                new PointF(rect.Left, rect.Top),
                new PointF(rect.Right, rect.Top),
                new PointF(rect.Right, rect.Bottom),
                new PointF(rect.Left, rect.Bottom)
            };

            using var m = new Matrix();
            m.RotateAt(rotationDeg, new PointF(cx, cy));
            m.TransformPoints(corners);

            return corners;
        }

        public void ClampToLabel(LabelElement el, LabelTemplate template, float dpi)
        {
            RectangleF elementRect = GetElementRect(el, dpi);
            RectangleF labelRect = new RectangleF(
                0,
                0,
                MMtoPx(template.LabelWidth, dpi),
                MMtoPx(template.LabelHeight, dpi)
            );

            PointF[] corners = GetCorners(elementRect, el.RotationDeg);

            float dx = 0;
            float dy = 0;

            foreach (var point in corners)
            {
                if (point.X < labelRect.Left)
                {
                    dx = Math.Max(dx, labelRect.Left - point.X);
                }
                if (point.X > labelRect.Right)
                {
                    dx = Math.Min(dx, labelRect.Right - point.X);
                }
                if (point.Y < labelRect.Top)
                {
                    dy = Math.Max(dy, labelRect.Top - point.Y);
                }
                if (point.Y > labelRect.Bottom)
                {
                    dy = Math.Min(dy, labelRect.Bottom - point.Y);
                }
            }

            el.X += PxtoMM(dx, dpi);
            el.Y += PxtoMM(dy, dpi);
        }
    }
}