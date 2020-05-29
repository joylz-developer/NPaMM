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
    protected float sizeArrow = 15;
    protected float sizeArrowWidth = 5;

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

      var sin = (float)Math.Sin(angle);
      var cos = (float)Math.Cos(angle);
      //Console.WriteLine(cos);

      SolidBrush brush = new SolidBrush(Color.Black);
      var p2 = new PointF(endP.X, endP.Y);
      p2.X += sizeArrow * cos - sizeArrowWidth * sin;
      p2.Y += sizeArrowWidth * cos + sizeArrow * sin;
      var p3 = new PointF(endP.X, endP.Y);
      p3.X += sizeArrow * cos - -sizeArrowWidth * sin;
      p3.Y += -sizeArrowWidth * cos + sizeArrow * sin;
      PointF[] points = new PointF[] {
        new PointF(endP.X, endP.Y), p2, p3
      };

      g.FillPolygon(brush, points);

      pen.Dispose();
      brush.Dispose();
    }

    protected new void RenderText(PaintEventArgs e) {
      Graphics g = e.Graphics;

      var pos = GetCenterPosition();

      g.FillRectangle(
        new SolidBrush(Color.White),
        pos.X - 10 * text.Length / 2 - ((10 * text.Length) / 100 * 8),
        pos.Y - 10,
        10 * text.Length, 
        10 * 2);

      Font drawFont = new Font("Arial", 10, FontStyle.Bold);
      SolidBrush drawBrush = new SolidBrush(Color.Black);
      StringFormat drawFormat = new StringFormat {
        Alignment = StringAlignment.Center,
        LineAlignment = StringAlignment.Center
      };

      g.DrawString(text, drawFont, drawBrush, pos, drawFormat);

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
