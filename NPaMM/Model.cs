using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPaMM {
  class Model : IDiagramEntity {
    public SizeF radius { get; private set; }

    public PointF position { get; set; }
    public SizeF radiusCenter { get; private set; }
    public SizeF collision { get; private set; }
    public PointF? cling { get; set; }

    public IHoverEntity hover { get; set; }

    public Model() {
      radius = new SizeF(50, 50);
      collision = radius + new SizeF(0, 0);
      radiusCenter = new SizeF(3, 3);
      position = new PointF(100, 100);
      cling = null;

      hover = new HoverEntity();
    }

    public bool СhangeHover(Point location) {
      var distance = 
        Math.Sqrt(
          Math.Pow(location.X - this.position.X, 2) + 
          Math.Pow(location.Y - this.position.Y, 2)
        );

      if (distance <= collision.Width) {
        hover = new HoverEntity();
        return true;
      } else {
        hover = new UnHoverEntity();
        return false;
      }
    }

    public void Render(PaintEventArgs e) {
      hover.Render(this, e);
    }

    void IDiagramEntity.RenderHover(PaintEventArgs e) {
      Graphics g = e.Graphics;
      Pen pen = new Pen(Color.Red);
      RectangleF rect = new RectangleF(
        this.position - this.radius,
        new SizeF(this.radius.Width * 2, this.radius.Height * 2));

      g.DrawEllipse(pen, rect);
    }

    void IDiagramEntity.RenderCenterHover(PaintEventArgs e) {
      Graphics g = e.Graphics;
      Pen pen = new Pen(Color.Black);
      RectangleF rect = new RectangleF(
        this.position - this.radiusCenter,
        new SizeF(this.radiusCenter.Width * 2, this.radiusCenter.Height * 2));

      g.DrawEllipse(pen, rect);
      //g.FillRectangle(new SolidBrush(Color.Black), rect);
    }

    void IDiagramEntity.RenderUnHover(PaintEventArgs e) {
      Graphics g = e.Graphics;
      Pen pen = new Pen(Color.Blue);
      RectangleF rect = new RectangleF(
        this.position - this.radius,
        new SizeF(this.radius.Width * 2, this.radius.Height * 2));

      g.DrawEllipse(pen, rect);
    }

    void IDiagramEntity.RenderCenterUnHover(PaintEventArgs e) {
      Graphics g = e.Graphics;
      Pen pen = new Pen(Color.Red);
      RectangleF rect = new RectangleF(
        this.position - this.radiusCenter,
        new SizeF(this.radiusCenter.Width * 2, this.radiusCenter.Height * 2));

      g.DrawEllipse(pen, rect);
      //g.FillRectangle(new SolidBrush(Color.Black), rect);
    }
  }
}
