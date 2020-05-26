﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPaMM {
  class HoverEntity : IStateEntity {
    public IStateEntity.EState state => IStateEntity.EState.HOVER;

    public void Enter(DiagramEntity d, Point location) {
    }

    public void Out(DiagramEntity d, Point location) {
      d.ChangeState(new IdleEntity());
      d.onEntity = d.RenderEntity;
      d.onCenter = d.RenderCenterEntity;
    }
  }
}
