using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPaMM {
  class IdleSpaceState : ISpaceState {
    public IdleSpaceState() {
      //Console.WriteLine("Set IdleSpaceState");
    }

    public void Click(SpaceDiagram d, MouseEventArgs e) {

    }

    public void Down(SpaceDiagram d, MouseEventArgs e) {

    }

    public void Move(SpaceDiagram d, MouseEventArgs e) {
      foreach (var m in d.models) {
        if (m.СhangeHover(e.Location)) {
          d.hoverModel = m;
          d.ChangeState(new HoverSpaceState());
          return;
        }
      }
    }

    public void Up(SpaceDiagram d, MouseEventArgs e) {

    }
  }
}
