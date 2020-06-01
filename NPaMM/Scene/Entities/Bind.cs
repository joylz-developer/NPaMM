using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPaMM {
  class Bind : DiagramEntity {
    public float timeMin { get; private set; }
    public float timeMax { get; private set; }
    public float timeExpected { get; private set; }
    public float dispersion { get; private set; }

    public Model left { get; private set; }
    public Model right { get; private set; }

    public string displayText { get; private set; }

    public override Render render { get; set; }

    public Bind(Model left, Model right, float timeMin = 0, float timeMax = -1) {
      this.timeMin = timeMin;
      this.timeMax = timeMax == -1 ? timeMin : timeMax;
      this.left = left;
      this.right = right;
      this.timeExpected = TimeExpectedCalc();
      this.dispersion = DispersionCalc();

      DisplayText();

      render = new ArrowRender(this, displayText);
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

    public string DisplayText() {
      var times = (this.timeMin + "-" + this.timeMax).ToString();
      var expected  = (this.timeExpected).ToString();

      displayText = expected;
      return displayText;
    }

    public float TimeExpectedCalc() {
      return (3 * timeMin + 2 * timeMax) / 5;
    }

    public float DispersionCalc() {
      return (float)Math.Pow((timeMax - timeMin), 2) / 25;
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
