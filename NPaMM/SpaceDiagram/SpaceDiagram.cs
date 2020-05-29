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

    public ISpaceState state { get; private set; }

    public Model movingModel { get; set; }
    public Model hoverModel { get; set; }
    public List<Model> selectedModels { get; set; }

    public event Action OnChangedSelectedModels;

    public SpaceDiagram() {
      models = new List<Model>();
      movingModel = null;
      hoverModel = null;
      selectedModels = new List<Model>();

      state = new IdleSpaceState();
    }

    public void AddModel(string name = null) {
      var m = new Model(name);
      models.Add(m);
    }

    public void ResetSelectedModels() {
      foreach (var item in selectedModels) {
        item.select.Switch();
      }
      selectedModels.Clear();
    }

    public void Render(PaintEventArgs e) {
      foreach (var m in models) {
        m.Render(e);
      }
    }

    public void ChangeState(ISpaceState state) {
      this.state = state;
    }

    public void ChangedSelectedModels() {
      OnChangedSelectedModels?.Invoke();
    }

    public void ClickCursor(MouseEventArgs e) {
      state.Click(this, e);
    }

    public void MoveCursor(MouseEventArgs e) {
      state.Move(this, e);
    }

    public void DownCursor(MouseEventArgs e) {
      state.Down(this, e);
    }

    public void UpCursor(MouseEventArgs e) {
      state.Up(this, e);
    }

  }
}
