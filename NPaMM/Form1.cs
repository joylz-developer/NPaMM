using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPaMM {
  public partial class Form1 : Form {
    private SpaceDiagram _diagram;

    public Form1() {
      InitializeComponent();

      pictureBox1.Paint += this.PictureBox1_Paint;
      pictureBox1.MouseMove += this.PictureBox1_MouseMove;
      pictureBox1.MouseDown += this.PictureBox1_MouseDown;
      pictureBox1.MouseUp += this.PictureBox1_MouseUp;
      pictureBox1.MouseClick += this.PictureBox1_MouseClick;
      ;

      _diagram = new SpaceDiagram();
      _diagram.AddModel();
      _diagram.AddModel();
    }

    private void PictureBox1_MouseClick(object sender, MouseEventArgs e) {
      _diagram.ClickCursor(e);
      pictureBox1.Refresh();
    }

    private void PictureBox1_MouseUp(object sender, MouseEventArgs e) {
      _diagram.UpCursor(e);
      pictureBox1.Refresh();
    }

    private void PictureBox1_MouseDown(object sender, MouseEventArgs e) {
      _diagram.DownCursor(e);
      pictureBox1.Refresh();
    }

    private void PictureBox1_MouseMove(object sender, MouseEventArgs e) {
      _diagram.MoveCursor(e);
      pictureBox1.Refresh();
    }

    private void PictureBox1_Paint(object sender, PaintEventArgs e) {
      _diagram.Render(e);
    }

    private void button1_Click(object sender, EventArgs e) {
      var name = textBox1.Text;

      if (name == "") {
        _diagram.AddModel();
      } else {
        _diagram.AddModel(name);
      }

      textBox1.Text = "";
      pictureBox1.Refresh();
    }
  }
}
