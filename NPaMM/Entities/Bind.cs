using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPaMM {
  class Bind : DiagramEntity {
    public int time { get; private set; }

    public Model left { get; private set; }
    public Model right { get; private set; }

    public override Render render { get; set; }

    public Bind(Model left, Model right, int time = 0) {
      this.time = time;
      this.left = left;
      this.right = right;

      render = new ArrowRender(this, time.ToString());
      var dist = CalculateDistance();
      ((ArrowRender)render).length = new SizeF((float)dist, (float)dist);
    }

    private double CalculateDistance() {
      var sizeL = left.render.GetSize();
      var sizeR = right.render.GetSize();
      var posL = left.position;
      var posR = right.position;
      var distance =
        Math.Sqrt(
          Math.Pow(posL.X - posR.X, 2) +
          Math.Pow(posL.Y - posR.Y, 2)
        );

      //distance -= sizeL.Width - sizeR.Width;

      return distance;
    }

    public void Render(PaintEventArgs e) {
      position = left.position;
      ((ArrowRender)render).length = new SizeF((float)CalculateDistance(), 0);
      ((ArrowRender)render).SetEntity(right.position);

      var startSize = left.render.GetSize().Width;
      ((ArrowRender)render).shift = 
        new SizeF(
          startSize * -(float)Math.Cos(render.angle), 
          startSize * -(float)Math.Sin(render.angle)
        );
      var endSize = right.render.GetSize().Width;
      var endPos = 
        new SizeF(
          endSize * (float)Math.Cos(render.angle), 
          endSize * (float)Math.Sin(render.angle)
        );
      ((ArrowRender)render).endShift = endPos;

      render.Draw(e);
    }
  }
}
