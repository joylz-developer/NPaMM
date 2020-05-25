using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPaMM {
  class HoverEntity : IHoverEntity {
    public IHoverEntity.EHover hover => IHoverEntity.EHover.ON;

    public void Render(IDiagramEntity d, PaintEventArgs e) {
      d.RenderHover(e);
      d.RenderCenterHover(e);
    }
  }
}
