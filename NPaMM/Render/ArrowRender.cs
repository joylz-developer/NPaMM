using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPaMM {
  class ArrowRender : Render {
    public SizeF length { get; set; }

    protected PointF end = new PointF();
    public SizeF endShift { get; set; }
    protected Color col = Color.Black;
    protected float width = 2;
    protected float sizeArrow = 30;
    protected float sizeArrowWidth = 20;

    public ArrowRender(DiagramEntity obj, string text) : base(obj, text) {
      length = new SizeF(30, 0);
      endShift = new SizeF(0, 0);
      collision = length + new SizeF(5, 5);
      onText = RenderText;
    }

    public override void Draw(PaintEventArgs e) {
      onEntity(e);
      onText(e);
    }

    public override SizeF GetSize() {
      return length;
    }

    public ArrowRender SetEntity(PointF end) {
      this.end = end;
      angle = (float)CalculateAngle();
      return this;
    }

    public double CalculateAngle() {
      return Math.Atan2(obj.position.Y - end.Y, obj.position.X - end.X);
    }

    protected override void RenderEntity(PaintEventArgs e) {
      Graphics g = e.Graphics;
      Pen pen = new Pen(col, width);
      var startP = obj.position + shift;
      var endP = end + endShift;
      g.DrawLine(pen, startP, endP);

      SolidBrush brush = new SolidBrush(Color.Black);
      var p2 = new PointF(endP.X + sizeArrow, endP.Y + sizeArrowWidth);
      p2.X = (float)(endP.X + (p2.X - endP.X) * Math.Cos(angle) - (p2.Y - endP.Y) * Math.Sin(angle));
      p2.Y = (float)(endP.Y + (p2.Y - endP.Y) * Math.Cos(angle) + (p2.X - endP.X) * Math.Sin(angle));
      var p3 = new PointF(endP.X + sizeArrow, endP.Y - sizeArrowWidth);
      p3.X = (float)(endP.X + (p3.X - endP.X) * Math.Cos(angle) - (p3.Y - endP.Y) * Math.Sin(angle));
      p3.Y = (float)(endP.Y + (p3.Y - endP.Y) * Math.Cos(angle) + (p3.X - endP.X) * Math.Sin(angle));
      PointF[] points = new PointF[] {
        new PointF(endP.X, endP.Y), p2, p3
      };

      g.FillPolygon(brush, points);

      pen.Dispose();
      brush.Dispose();
    }

    protected new void RenderText(PaintEventArgs e) {
      Graphics g = e.Graphics;
      Font drawFont = new Font("Arial", 10);
      SolidBrush drawBrush = new SolidBrush(Color.Black);
      StringFormat drawFormat = new StringFormat {
        Alignment = StringAlignment.Center,
        LineAlignment = StringAlignment.Center
      };
      g.DrawString(text, drawFont, drawBrush, GetCenterPosition(), drawFormat);

      drawFont.Dispose();
      drawBrush.Dispose();
      drawFormat.Dispose();
    }

    public PointF GetCenterPosition() {
      var x = (obj.position.X + end.X) / 2;
      var y = (obj.position.Y + end.Y) / 2;
      return new PointF(x, y);
    }
  }
}
