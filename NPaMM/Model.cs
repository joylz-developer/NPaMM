using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPaMM.Select;

namespace NPaMM {
  class Model : DiagramEntity {
    public SizeF radius { get; private set; }
    static readonly Random _r = new Random();

    public SizeF radiusCenter { get; private set; }
    public PointF? cling { get; set; }

    public CircleHover hover { get; private set; }
    public Move move { get; private set; }

    public Model() : base(new SizeF(50, 50)) {
      radius = new SizeF(50, 50);
      radiusCenter = new SizeF(3, 3);
      position = new PointF(100, _r.Next(70, 140));
      cling = null;

      hover = new CircleHover(this);
      hover.OnEnter += this.EnterHover;
      hover.OnOut += this.OutHover;

      OutHover();

      move = new Move(this);
    }

    public bool СhangeHover(Point location) {
      return hover.Check(location);
    }

    public bool Down(Point location) {
      if (hover.state == Hover.EHover.ENTER) {
        move.Start(location);
        return true;
      }
      return false;
    }

    public void Render(PaintEventArgs e) {
      onEntity(e);
      onCenter(e);
    }

    public void EnterHover() {
      onEntity = this.RenderHover;
      onCenter = this.RenderCenterHover;
    }

    public void OutHover() {
      onEntity = this.RenderEntity;
      onCenter = this.RenderCenterEntity;
    }

    public override void RenderHover(PaintEventArgs e) {
      Graphics g = e.Graphics;
      Pen pen = new Pen(Color.Red);
      RectangleF rect = new RectangleF(
        this.position - this.radius,
        new SizeF(this.radius.Width * 2, this.radius.Height * 2));

      g.DrawEllipse(pen, rect);
    }

    public override void RenderCenterHover(PaintEventArgs e) {
      Graphics g = e.Graphics;
      Pen pen = new Pen(Color.Black);
      RectangleF rect = new RectangleF(
        this.position - this.radiusCenter,
        new SizeF(this.radiusCenter.Width * 2, this.radiusCenter.Height * 2));

      g.DrawEllipse(pen, rect);
      //g.FillRectangle(new SolidBrush(Color.Black), rect);
    }

    public override void RenderEntity(PaintEventArgs e) {
      Graphics g = e.Graphics;
      Pen pen = new Pen(Color.Blue);
      RectangleF rect = new RectangleF(
        this.position - this.radius,
        new SizeF(this.radius.Width * 2, this.radius.Height * 2));

      g.DrawEllipse(pen, rect);
    }

    public override void RenderCenterEntity(PaintEventArgs e) {
      //Graphics g = e.Graphics;
      //Pen pen = new Pen(Color.Red);
      //RectangleF rect = new RectangleF(
      //  this.position - this.radiusCenter,
      //  new SizeF(this.radiusCenter.Width * 2, this.radiusCenter.Height * 2));

      //g.DrawEllipse(pen, rect);
      //g.FillRectangle(new SolidBrush(Color.Black), rect);
    }
  }
}
