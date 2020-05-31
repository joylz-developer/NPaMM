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

    public NetworkCore(SpaceDiagram diagram) {
      space = diagram;

      modelsConnected = new List<Model>();
      usedBinds = new List<Bind>();
    }

    public bool CheckCorrectDiagram() {
      space.SortModels();

      var isResultCheck = 
        ConnectionCheck() ?? 
        DeadEndEventCheck() ?? 
        CollectUsedBinds() ??
        CorrectlyNumberedModelsCheck() ?? true;

      Console.WriteLine(isResultCheck);

      return true;
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

    private bool? CorrectlyNumberedModelsCheck() {
      foreach (var bind in usedBinds) {
        if (bind.right.number <= bind.left.number) {
          MessageBox.Show("The diagram has several ends or starts.");
          return false;
        }
      }

      return null;
    }
  }
}
