using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPaMM {
  interface IDiagramEntity {
    void RenderHover(PaintEventArgs e);
    void RenderCenterHover(PaintEventArgs e);
    void RenderUnHover(PaintEventArgs e);
    void RenderCenterUnHover(PaintEventArgs e);
  }
}
