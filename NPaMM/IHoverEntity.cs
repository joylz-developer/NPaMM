using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPaMM {
  interface IHoverEntity {
    enum EHover {
      ON,
      OFF
    }

    EHover hover { get; }

    void Render(IDiagramEntity d, PaintEventArgs e);
  }
}
