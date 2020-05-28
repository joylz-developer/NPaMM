using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPaMM.Render {
  abstract class Render {
    protected Paint onEntity;
    protected Paint onCenter;
    public delegate void Paint(PaintEventArgs e);


  }
}
