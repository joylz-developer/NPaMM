using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPaMM {
  class CircleHover : Hover {
    public CircleHover(DiagramEntity entity) : base(entity) {
    }
    public override bool Check(Point location) {
      var distance =
        Math.Sqrt(
          Math.Pow(location.X - entity.position.X, 2) +
          Math.Pow(location.Y - entity.position.Y, 2)
        );

      if (distance <= entity.render.collision.Width) {
        return Enter(location);
      } else {
        return Out(location);
      }
    }
  }
}
