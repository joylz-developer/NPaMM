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

    public event Pos OnEnter;
    public event Pos OnOut;
    public delegate void Pos(DiagramEntity entity, Point location);


    protected bool Enter(Point location) {
      if (state == EHover.OUT) {
        state = EHover.ENTER;
        OnEnter?.Invoke(entity, location);
      }
      return true;
    }
    protected bool Out(Point location) {
      if (state == EHover.ENTER) {
        state = EHover.OUT;
        OnOut?.Invoke(entity, location);
      }
      return false;
    }
    public abstract bool Check(Point location);
  }
}
