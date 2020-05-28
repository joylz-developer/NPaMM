using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPaMM {
  class MovingSpaceState : ISpaceState {
    public MovingSpaceState() {
      Console.WriteLine("Set MovingSpaceState");
    }
    private bool _isMoved = false;

    public void Click(SpaceDiagram d, MouseEventArgs e) {
      if (_isMoved == false) {
        if (d.selectedModels.Contains(d.hoverModel)) {
          d.selectedModels.Remove(d.hoverModel);
          d.hoverModel.select.Switch();
        } else {
          d.selectedModels.Add(d.hoverModel);
          d.hoverModel.select.Switch();
        }

        if (d.selectedModels.Count > 2) {
          d.selectedModels[0].select.Switch();
          d.selectedModels.RemoveAt(0);
        }
        d.ChangeState(new HoverSpaceState());
      }
    }

    public void Down(SpaceDiagram d, MouseEventArgs e) {

    }

    public void Move(SpaceDiagram d, MouseEventArgs e) {
      _isMoved = true;
      d.movingModel.move.Moving(e.Location);
    }

    public void Up(SpaceDiagram d, MouseEventArgs e) {
      if (_isMoved == false) {
        return;
      }
      d.movingModel.move.Stop(e.Location);
      d.movingModel = null;

      if (d.selectedModels.Count == 0) {
        d.ChangeState(new HoverSpaceState());
      } else {
        d.ChangeState(new SelectedSpaceState());
      }
    }
  }
}
