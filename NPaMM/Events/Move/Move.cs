using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPaMM {
  class Move {
    public PointF? cling { get; set; }

    public enum EMove {
      ON,
      OFF
    }

    public EMove move { get; protected set; }

    protected DiagramEntity entity { get; set; }

    public event Pos OnStart;
    public event Pos OnMove;
    public event Pos OnStop;
    public delegate void Pos(DiagramEntity entity, Point location);

    public Move(DiagramEntity entity) {
      this.entity = entity;
      move = EMove.OFF;
    }

    public void Start(Point location) {
      if (move == EMove.OFF) {
        move = EMove.ON;
        cling = new PointF(entity.position.X - location.X, entity.position.Y - location.Y);
        OnStart?.Invoke(entity, location);
      }
    }

    public void Moving(Point location) {  
      entity.position = new PointF(location.X + cling.Value.X, location.Y + cling.Value.Y);
      OnMove?.Invoke(entity, location);
    }

    public void Stop(Point location) {
      cling = null;
      move = EMove.OFF;
      OnStop?.Invoke(entity, location);
    }
  }
}
