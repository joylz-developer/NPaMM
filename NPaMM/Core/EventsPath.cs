using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPaMM.Core {
  class EventsPath {
    public List<Bind> path { get; private set; }
    public float duration { get; private set; }
    public float dispersionPath { get; private set; }

    public EventsPath() {
      path = new List<Bind>();
      duration = 0;
      dispersionPath = 0;
    }

    public EventsPath(Bind bind) {
      path = new List<Bind>() { bind };
      duration = bind.timeExpected;
      dispersionPath = bind.dispersion;
    }

    public void AddBind(Bind bind) {
      path.Add(bind);
      duration += bind.timeExpected;
      dispersionPath += bind.dispersion;
    }

    public void AddPath(EventsPath path) {
      this.path.AddRange(path.path);
      duration += path.duration;
      dispersionPath += path.dispersionPath;
    }

    public float SqrDispersionPath() {
      return (float)Math.Sqrt(dispersionPath);
    }
  }
}
