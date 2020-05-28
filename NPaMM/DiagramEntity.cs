using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPaMM {
  abstract class DiagramEntity {
    public PointF position { get; set; }
    public SizeF collision { get; private set; }

    public DiagramEntity(SizeF size) {
      collision = size + new SizeF(5, 5);
    }

    public Paint onEntity;
    public Paint onCenter;
    public delegate void Paint(PaintEventArgs e);

    public abstract void RenderHover(PaintEventArgs e);
    public abstract void RenderCenterHover(PaintEventArgs e);
    public abstract void RenderEntity(PaintEventArgs e);
    public abstract void RenderCenterEntity(PaintEventArgs e);
  }
}
