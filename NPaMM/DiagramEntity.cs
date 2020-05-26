using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPaMM {
  abstract class DiagramEntity {
    public IStateEntity state { get; protected set; }

    public Paint onEntity;
    public Paint onCenter;
    public delegate void Paint(PaintEventArgs e);

    public void ChangeState(IStateEntity s) {
      state = s;
    }

    public abstract void RenderHover(PaintEventArgs e);
    public abstract void RenderCenterHover(PaintEventArgs e);
    public abstract void RenderEntity(PaintEventArgs e);
    public abstract void RenderCenterEntity(PaintEventArgs e);
  }
}
