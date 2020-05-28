using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPaMM {
  abstract class Hover {
    public enum EHover {
      OUT,
      ENTER
    }

    public EHover state { get; protected set; }
    protected DiagramEntity entity { get; set; }

    public Hover(DiagramEntity entity) {
      this.entity = entity;
      state = EHover.OUT;
    }

    public event Action OnEnter;
    public event Action OnOut;

    protected bool Enter() {
      if (state == EHover.OUT) {
        state = EHover.ENTER;
        OnEnter?.Invoke();
      }
      return true;
    }
    protected bool Out() {
      if (state == EHover.ENTER) {
        state = EHover.OUT;
        OnOut?.Invoke();
      }
      return false;
    }
    public abstract bool Check(Point location);
  }
}
