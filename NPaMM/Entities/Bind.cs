using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPaMM {
  class Bind : DiagramEntity {
    public int timeMin { get; private set; }
    public int timeMax { get; private set; }

    public Model left { get; private set; }
    public Model right { get; private set; }

    public override Render render { get; set; }

    public Bind(Model left, Model right, int timeMin = 0, int timeMax = -1) {
      this.timeMin = timeMin;
      this.timeMax = timeMax == -1 ? timeMin : timeMax;
      this.left = left;
      this.right = right;

      render = new ArrowRender(this, (this.timeMin + "-" + this.timeMax).ToString());
      var dist = CalculateDistance();
      ((ArrowRender)render).length = new SizeF((float)dist, (float)dist);
    }

    private double CalculateDistance() {
      var posL = left.position;
      var posR = right.position;
      var distance =
        Math.Sqrt(
          Math.Pow(posL.X - posR.X, 2) +
          Math.Pow(posL.Y - posR.Y, 2)
        );

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
