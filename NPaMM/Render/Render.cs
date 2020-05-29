using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPaMM {
  abstract class Render {
    public DiagramEntity obj { get; set; }

    protected Paint onEntity;
    protected Paint onCenter;
    protected Paint onText;
    public delegate void Paint(PaintEventArgs e);

    public SizeF collision { get; protected set; }

    protected SizeF sizeRect = new SizeF(0, 0);
    protected Color centerCol = Color.Blue;

    public string text { get; protected set; }

    public SizeF shift { get; set; }
    public float angle { get; set; }

    public Render(DiagramEntity obj, string text) {
      this.obj = obj;
      this.text = text;
      collision = new SizeF();
      shift = new SizeF(0, 0);
      angle = 0;
      onCenter = RenderCenter;
      onEntity = RenderEntity;
      onText = RenderText;
    }

    public abstract SizeF GetSize();

    public abstract void Draw(PaintEventArgs e);

    protected void RenderCenter(PaintEventArgs e) {
      Graphics g = e.Graphics;
      Pen pen = new Pen(centerCol);
      RectangleF rect = new RectangleF(
        obj.position - this.sizeRect,
        new SizeF(this.sizeRect.Width * 2, this.sizeRect.Height * 2)
      );
      g.DrawEllipse(pen, rect);

      pen.Dispose();
    }

    protected void RenderText(PaintEventArgs e) {
      Graphics g = e.Graphics;
      Font drawFont = new Font("Arial", 12);
      SolidBrush drawBrush = new SolidBrush(Color.Black);
      StringFormat drawFormat = new StringFormat {
        Alignment = StringAlignment.Center,
        LineAlignment = StringAlignment.Center
      };
      g.DrawString(text, drawFont, drawBrush, obj.position, drawFormat);

      drawFont.Dispose();
      drawBrush.Dispose();
      drawFormat.Dispose();
    }

    public Render SetCenter(SizeF sizeRect) {
      this.sizeRect = sizeRect;
      return this;
    }

    public Render SetCenter(Color col) {
      centerCol = col;
      return this;
    }

    protected abstract void RenderEntity(PaintEventArgs e);
  }
}
