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
    static int _id = 1;

    public int id { get; private set; }

    public int number { get; private set; }
    public string name { get; private set; }

    public List<Bind> binds { get; private set; }
    public List<Bind> investigators { get; private set; }

    public CircleHover hover { get; private set; }
    public Move move { get; private set; }
    public Select select { get; private set; }
    public override Render render { get; set; }
    public string displayText { get; private set; }
    private CircleRender renderThis { get; set; }

    public Model(string name = null, string number = null) {
      id = _id;
      _id += 1;
      position = new PointF(100, _r.Next(30, 300));
      this.name = name ?? id.ToString();

      if (int.TryParse(number, out int tmpNumber)) {
        this.number = tmpNumber;
      } else {
        this.number = id;
      }

      UpdateDisplayText();

      binds = new List<Bind>();
      investigators = new List<Bind>();

      InitComp();
    }

    public static int GetNextId() {
      return _id;
    }

    private void InitComp() {
      render = new CircleRender(this, displayText);
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

    public void AddBind(Model m, float timeMin, float timeMax) {
      RemoveDoubleBind(m);
      var newBind = new Bind(this, m, timeMin, timeMax);
      binds.Add(newBind);
      m.investigators.Add(newBind);
    }

    public void RemoveBind(Model m) {
      RemoveDoubleBind(m);
    }

    private void RemoveDoubleBind(Model m) {
      foreach (var item in binds) {
        if (item.right.id == m.id) {
          binds.Remove(item);
          m.investigators.Remove(item);
          return;
        }
      }
      foreach (var item in m.binds) {
        if (item.right.id == this.id) {
          m.binds.Remove(item);
          investigators.Remove(item);
          return;
        }
      }
    }

    public bool Edit(string name, string number) {
      this.name = name;

      if (int.TryParse(number, out int tmpNumber)) {
        this.number = tmpNumber;
      } else {
        MessageBox.Show("Error");
        return false;
      }

      UpdateDisplayText();
      render = new CircleRender(this, displayText);
      renderThis = (CircleRender)render;

      return true;
    }

    public void UpdateDisplayText() {
      displayText = this.name + "(" + this.number + ")";
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

      foreach (var item in binds) {
        item.Render(e);
      }
    }
  }
}
