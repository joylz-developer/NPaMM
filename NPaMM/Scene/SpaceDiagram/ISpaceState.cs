using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPaMM {
  interface ISpaceState {
    void Move(SpaceDiagram d, MouseEventArgs e);
    void Down(SpaceDiagram d, MouseEventArgs e);
    void Up(SpaceDiagram d, MouseEventArgs e);
    void Click(SpaceDiagram d, MouseEventArgs e);
  }
}
