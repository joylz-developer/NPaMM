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

    public EventsPath AddBind(Bind bind) {
      path.Add(bind);
      duration += bind.timeExpected;
      dispersionPath += bind.dispersion;
      return this;
    }

    public EventsPath AddPath(EventsPath path) {
      this.path.AddRange(path.path);
      duration += path.duration;
      dispersionPath += path.dispersionPath;
      return this;
    }

    public float SqrDispersionPath() {
      return (float)Math.Sqrt(dispersionPath);
    }

    public override string ToString() {
      var str = $@"[L={duration} S={dispersionPath}] => (";
      path.ForEach((ev) => str += ev.left.number + "..");
      str += path.Last().right.number + ")";
      return str.ToString();
    }
  }
}
