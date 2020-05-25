using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPaMM {
  class SpaceDiagram {
    public List<Model> models { get; private set; }
    public Model movingModel { get; private set; }
    public Model hoverModel { get; private set; }

    public SpaceDiagram() {
      models = new List<Model>();
      movingModel = null;
      hoverModel = null;
    }

    public void AddModel() {
      var m = new Model();
      models.Add(m);
    }

    public void MoveCursor(MouseEventArgs e) {
      if (movingModel != null && movingModel.cling != null) {
        movingModel.position = new PointF(e.Location.X + movingModel.cling.Value.X, e.Location.Y + movingModel.cling.Value.Y);
      } else {
        СhangeHover(e);
      }
    }

    public void DownCursor(MouseEventArgs e) {
      foreach (var m in models) {
        if (m.hover.hover == IHoverEntity.EHover.ON) {
          movingModel = m;
          m.cling = new PointF(m.position.X - e.Location.X, m.position.Y - e.Location.Y);
        }
      }
    }

    public void UpCursor(MouseEventArgs e) {
      if (movingModel != null) {
        movingModel.cling = null;
        movingModel = null;
      }
    }

    private void СhangeHover(MouseEventArgs e) {
      foreach (var m in models) {
        if (m.СhangeHover(e.Location)) {
          if (hoverModel != null && hoverModel != m) {
            hoverModel.hover = new UnHoverEntity();
          }
          hoverModel = m;
          break;
        }
      }
    }

    public void Render(PaintEventArgs e) {
      foreach (var m in models) {
        m.Render(e);
      }
    }
  }
}
