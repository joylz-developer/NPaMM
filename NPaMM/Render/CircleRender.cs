using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPaMM {
  class CircleRender : Render {
    public SizeF radius { get; set; }

    protected RectangleF rect = new RectangleF();
    protected Color col = Color.Blue;
    protected float width = 2;

    public CircleRender(DiagramEntity obj, string text) : base(obj, text) {
      radius = new SizeF(30, 30);
      collision = radius + new SizeF(5, 5);
    }

    public override SizeF GetSize() {
      return radius;
    }

    public override void Draw(PaintEventArgs e) {
      onEntity(e);
      onCenter(e);
      onText(e);
    }

    protected override void RenderEntity(PaintEventArgs e) {
      Graphics g = e.Graphics;
      Pen pen = new Pen(col, width);
      RectangleF rect = new RectangleF(
        obj.position - radius + shift,
        new SizeF(radius.Width * 2, radius.Height * 2)
      );
      g.DrawEllipse(pen, rect);

      pen.Dispose();
    }

    public CircleRender SetEntity(RectangleF rect) {
      this.rect = rect;
      return this;
    }

    public CircleRender SetEntity(SizeF radius) {
      this.radius = radius;
      return this;
    }

    public CircleRender SetEntity(Color col) {
      this.col = col;
      return this;
    }

    public CircleRender SetEntity(float width) {
      this.width = width;
      return this;
    }


  }
}
