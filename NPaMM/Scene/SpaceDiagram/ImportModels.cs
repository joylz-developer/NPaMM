using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPaMM {
  class ImportModels {
    public int[] work { get; private set; }
    public float timeMin { get; private set; }
    public float timeMax { get; private set; }

    public ImportModels(int[] work, float timeMin, float timeMax) {
      this.work = work;
      this.timeMin = timeMin;
      this.timeMax = timeMax;
    }
  }
}
