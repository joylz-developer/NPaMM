using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPaMM {
  class HoverSpaceState : ISpaceState {
    public void Click(SpaceDiagram d, MouseEventArgs e) {

    }

    public void Down(SpaceDiagram d, MouseEventArgs e) {
      foreach (var m in d.models) {
        if (m.Down(e.Location)) {
          d.movingModel = m;
          d.ChangeState(new MovingSpaceState());
        }
      }
    }

    public void Move(SpaceDiagram d, MouseEventArgs e) {
      if (d.hoverModel.СhangeHover(e.Location)) {
        return;
      }

      d.hoverModel = null;
      d.ChangeState(new IdleSpaceState());
    }

    public void Up(SpaceDiagram d, MouseEventArgs e) {

    }
  }
}
