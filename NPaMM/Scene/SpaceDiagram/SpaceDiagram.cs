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

    public void AddImportModels(List<ImportModels> imports) {
      foreach (var import in imports) {
        if (import.work.Length != 2) {
          continue;
        }

        // create missing models
        var indexes = new int[2];

        for (int i = 0; i < 2; i++) {
          indexes[i] = models.FindIndex((m) => m.number == import.work[i]);

          if (indexes[i] == -1) {
            AddModel(import.work[i].ToString(), import.work[i]);
            indexes[i] = models.Count() - 1;
          }
        }

        models[indexes[0]].AddBind(
          models[indexes[1]], import.timeMin, import.timeMax
        );
      }
    }

    public void AddModel(string name = null) {
      var m = new Model(name);
      models.Add(m);
    }

    public void AddModel(string name, int number) {
      var m = new Model(name, number.ToString());
      models.Add(m);
    }

    public void SortModels() {
      models.Sort((m1, m2) => {
        return m1.number < m2.number ? -1 : 1;
      });
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
