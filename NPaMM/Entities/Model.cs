using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPaMM {
  class Model : DiagramEntity {
    static readonly Random _r = new Random();
    static int _id = 0;

    public int id { get; private set; }
    public string name { get; private set; }

    public List<Bind> bind { get; private set; }

    //public CircleRender render { get; set; }
    public CircleHover hover { get; private set; }
    public Move move { get; private set; }
    public Select select { get; private set; }
    public override Render render { get; set; }
    private CircleRender renderThis { get; set; }

    public Model(string name = null) {
      id = _id;
      _id += 1;
      position = new PointF(100, _r.Next(30, 300));
      this.name = name ?? id.ToString();

      bind = new List<Bind>();

      InitComp();
    }

    private void InitComp() {
      render = new CircleRender(this, name);
      renderThis = (CircleRender)render;

      hover = new CircleHover(this);
      move = new Move(this);
      select = new Select(this);

      hover.OnEnter += (DiagramEntity d, Point location) => {
        if (select.select == Select.ESelect.ENABLE) {
          renderThis.SetEntity(Color.Magenta).SetEntity(3);
        } else {
          renderThis.SetEntity(Color.Black).SetEntity(3);
        }
      };
      hover.OnOut += (DiagramEntity d, Point location) => {
        if (select.select == Select.ESelect.ENABLE) {
          renderThis.SetEntity(Color.Magenta).SetEntity(2);
        } else {
          renderThis.SetEntity(Color.Black).SetEntity(2);
        }
      };

      move.OnStart += (DiagramEntity entity, Point location) => {
        renderThis.SetEntity(Color.LightGray).SetEntity(2);
      };
      move.OnStop += (DiagramEntity entity, Point location) => {
        renderThis.SetEntity(Color.Black).SetEntity(3);
      };

      select.OnDisable += (DiagramEntity entity) => {
        renderThis.SetEntity(Color.Black).SetEntity(3);
      };
      select.OnEnable += (DiagramEntity entity) => {
        renderThis.SetEntity(Color.Magenta).SetEntity(2);
      };

      renderThis.SetEntity(Color.Black).SetEntity(2);
    }

    public void AddBind(Model m, int time) {
      RemoveDoubleBind(m);
      bind.Add(new Bind(this, m, time));
    }

    public void RemoveBind(Model m) {
      RemoveDoubleBind(m);
    }

    private void RemoveDoubleBind(Model m) {
      foreach (var item in bind) {
        if (item.right.id == m.id) {
          bind.Remove(item);
          return;
        }
      }
      foreach (var item in m.bind) {
        if (item.right.id == this.id) {
          m.bind.Remove(item);
          return;
        }
      }
    }

    public bool СhangeHover(Point location) {
      var isHover = hover.Check(location);
      return isHover;
    }

    public bool Down(Point location) {
      if (hover.state == Hover.EHover.ENTER) {
        move.Start(location);
        return true;
      }
      return false;
    }

    public void Render(PaintEventArgs e) {
      render.Draw(e);

      foreach (var item in bind) {
        item.Render(e);
      }
    }
  }
}
