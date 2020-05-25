using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPaMM {
  class UnHoverEntity : IHoverEntity {
    public IHoverEntity.EHover hover => IHoverEntity.EHover.OFF;

    public void Render(IDiagramEntity d, PaintEventArgs e) {
      d.RenderUnHover(e);
    }
  }
}
