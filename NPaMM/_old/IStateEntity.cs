using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPaMM {
  interface IStateEntity {
    enum EState {
      IDLE,
      SELECTED,
      HOVER
    }

    EState state { get; }

    void Enter(DiagramEntity d, Point location);
    void Out(DiagramEntity d, Point location);
  }
}
