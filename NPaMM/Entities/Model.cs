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

    //public CircleRender render { get; set; }
    public CircleHover hover { get; private set; }
    public Move move { get; private set; }
    public Select select { get; private set; }
    public override Render render { get; set; }

    public Model(string name = null) {
      id = _id;
      _id += 1;
      position = new PointF(100, _r.Next(30, 300));
      this.name = name ?? id.ToString();

      InitComp();
    }

    private void InitComp() {
      render = new CircleRender(this, name);

      hover = new CircleHover(this);
      move = new Move(this);
      select = new Select(this);

      hover.OnEnter += (DiagramEntity d, Point location) => {
        if (select.select == Select.ESelect.ENABLE) {
          ((CircleRender)render).SetEntity(Color.Magenta).SetEntity(3);
        } else {
          ((CircleRender)render).SetEntity(Color.Black).SetEntity(3);
        }
      };
      hover.OnOut += (DiagramEntity d, Point location) => {
        if (select.select == Select.ESelect.ENABLE) {
          ((CircleRender)render).SetEntity(Color.Magenta).SetEntity(2);
        } else {
          ((CircleRender)render).SetEntity(Color.Black).SetEntity(2);
        }
      };

      move.OnStart += (DiagramEntity entity, Point location) => {
        ((CircleRender)render).SetEntity(Color.LightGray).SetEntity(2);
      };
      move.OnStop += (DiagramEntity entity, Point location) => {
        ((CircleRender)render).SetEntity(Color.Black).SetEntity(3);
      };

      select.OnDisable += (DiagramEntity entity) => {
        ((CircleRender)render).SetEntity(Color.Black).SetEntity(3);
      };
      select.OnEnable += (DiagramEntity entity) => {
        ((CircleRender)render).SetEntity(Color.Magenta).SetEntity(2);
      };

      ((CircleRender)render).SetEntity(Color.Black).SetEntity(2);
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
    }
  }
}
