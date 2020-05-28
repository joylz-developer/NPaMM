using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPaMM {
  class SelectedSpaceState : ISpaceState {
    private bool _isDown = false;
    private Model _save = null;

    public SelectedSpaceState() {
      Console.WriteLine("Set SelectedSpaceState");
    }

    public void Click(SpaceDiagram d, MouseEventArgs e) {

    }

    public void Down(SpaceDiagram d, MouseEventArgs e) {
      foreach (var m in d.models) {
        if (m.Down(e.Location)) {
          _save = m;
          _isDown = true;
        }
      }
    }

    public void Move(SpaceDiagram d, MouseEventArgs e) {
      if (_isDown) {
        _save.Down(e.Location);
        d.movingModel = _save;
        d.ChangeState(new MovingSpaceState());
      }

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
