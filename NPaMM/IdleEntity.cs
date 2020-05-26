using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPaMM {
  class IdleEntity : IStateEntity {
    public IStateEntity.EState state => IStateEntity.EState.IDLE;

    public void Enter(DiagramEntity d, Point location) {
      d.ChangeState(new HoverEntity());
      d.onEntity = d.RenderHover;
      d.onCenter = d.RenderCenterHover;
    }

    public void Out(DiagramEntity d, Point location) {

    }
  }
}
