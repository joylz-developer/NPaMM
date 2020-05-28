using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPaMM {
  class Select {
    public enum ESelect {
      ENABLE,
      DISABLE
    }

    public ESelect select { get; protected set; }

    protected DiagramEntity entity { get; set; }

    public event Entity OnEnable;
    public event Entity OnDisable;
    public delegate void Entity(DiagramEntity entity);

    public Select(DiagramEntity entity) {
      this.entity = entity;
      select = ESelect.DISABLE;
    }

    public void Switch() {
      if (select == ESelect.DISABLE) {
        select = ESelect.ENABLE;
        OnEnable?.Invoke(entity);
      } else {
        select = ESelect.DISABLE;
        OnDisable?.Invoke(entity);
      }
    }
  }
}
