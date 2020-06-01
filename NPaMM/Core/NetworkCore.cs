using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPaMM.Core {
  class NetworkCore {
    public SpaceDiagram space { get; private set; }

    public List<Model> modelsConnected { get; private set; }
    public List<Bind> usedBinds { get; private set; }

    public bool IsCorrectData { get; private set; }
    public List<EventsPath> eventsPaths { get; private set; }
    public List<EventsPath> maxDurationPath { get; private set; }

    public NetworkCore(SpaceDiagram diagram) {
      space = diagram;
      IsCorrectData = false;

      modelsConnected = new List<Model>();
      usedBinds = new List<Bind>();

      eventsPaths = new List<EventsPath>();
      maxDurationPath = new List<EventsPath>();
    }

    public bool CheckCorrectDiagram() {
      space.SortModels();

      var isResultCheck = 
        ConnectionCheck() ?? 
        DeadEndEventCheck() ?? 
        CollectUsedBinds() ??
        SortUsedBinds() ??
        CorrectlyNumberedModelsCheck() ?? true;

      IsCorrectData = isResultCheck;

      return IsCorrectData;
    }

    private bool? ConnectionCheck() {
      modelsConnected.Clear();
      foreach (var model in space.models) {
        if (model.binds.Count > 0 || model.investigators.Count > 0) {
          modelsConnected.Add(model);
        }
      }

      if (modelsConnected.Count == 0) {
        MessageBox.Show("The diagram has no connections.");
        return false;
      }

      return null;
    }

    private bool? DeadEndEventCheck() {
      var countEnds = 0;
      var countStarts = 0;
      foreach (var model in modelsConnected) {
        if (model.binds.Count == 0) {
          countEnds += 1;
        }
        if (model.investigators.Count == 0) {
          countStarts += 1;
        }
      }

      if (countEnds != 1 || countStarts != 1) {
        MessageBox.Show("The diagram has several ends or starts.");
        return false;
      }

      return null;
    }

    private bool? CollectUsedBinds() {
      usedBinds.Clear();
      foreach (var model in modelsConnected) {
        usedBinds.AddRange(model.binds);
      }

      if (usedBinds.Count == 0) {
        return false;
      }

      return null;
    }

    private bool? SortUsedBinds() {
      usedBinds.Sort((bind1, bind2) => {
        if (bind1.left.number == bind2.left.number) {
          return bind1.right.number > bind2.right.number ? 1 : -1;
        } else {
          return bind1.left.number > bind2.left.number ? 1 : -1;
        }
      });

      return null;
    }

    private bool? CorrectlyNumberedModelsCheck() {
      foreach (var bind in usedBinds) {
        if (bind.right.number <= bind.left.number) {
          MessageBox.Show("The diagram has several ends or starts.");
          return false;
        }
      }

      return null;
    }

    public List<string[]> BildTable() {
      if (IsCorrectData == false) {
        return null;
      }

      var table = new List<string[]>();
      var line = new string[5];

      usedBinds.ForEach((bind) => {
        line.Select((item) => "");
        line[0] = $@"({bind.left.number},{bind.right.number})";
        line[1] = $@"{bind.timeMin}";
        line[2] = $@"{bind.timeMax}";
        line[3] = $@"{bind.timeExpected}";
        line[4] = $@"{bind.dispersion}";
        table.Add((string[])line.Clone());
      });

      return table;
    }

    public List<EventsPath> GetCriticalPath() {
      if (IsCorrectData == false) {
        return null;
      }

      eventsPaths = new List<EventsPath>();

      modelsConnected[0].binds.ForEach((bind) => {
        eventsPaths.Add(new EventsPath(bind));
        EachBinds(eventsPaths, bind.right);
      });

      return eventsPaths;
    }

    private void EachBinds(List<EventsPath> paths, Model model) {
      var i = 0;
      model.binds.ForEach((bind) => {
        if (i == 0) {
          paths.Last().AddBind(bind);
        } else {
          paths.Add(new EventsPath(bind));
        }
        EachBinds(paths, bind.right);
        i += 1;
      });
    }

    public List<EventsPath> CalcMaxDurationPath() {
      if (IsCorrectData == false) {
        return null;
      }

      var currentMax = -float.MinValue;
      maxDurationPath = new List<EventsPath>();

      eventsPaths.ForEach((path) => {
        if (currentMax > path.duration) {
          currentMax = path.duration;
          maxDurationPath.Clear();
          maxDurationPath.Add(path);
        } else if (currentMax == path.duration) {
          maxDurationPath.Add(path);
        }
      });

      return maxDurationPath;
    }
  }
}
