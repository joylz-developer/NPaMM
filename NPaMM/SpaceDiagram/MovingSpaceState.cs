using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPaMM {
  class MovingSpaceState : ISpaceState {
    private bool _isMoved = false;

    public void Click(SpaceDiagram d, MouseEventArgs e) {
      if (_isMoved == false) {
        d.selectedModels.Add(d.hoverModel);
        d.ChangeState(new SelectedSpaceState());
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
      d.movingModel.move.Stop();
      d.movingModel = null;
      d.ChangeState(new HoverSpaceState());
    }
  }
}
