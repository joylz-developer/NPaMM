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
      _diagram.OnChangedSelectedModels += CheckDiagramSelectedModels;

      CheckDiagramSelectedModels();
      _diagram.AddModel("Start");
      _diagram.AddModel("End");
    }

    private void CheckDiagramSelectedModels() {
      var c = _diagram.selectedModels.Count();

      if (c == 2) {
        SetEnableAddingBind();
      } else {
        SetEnableAddingBind(false);
      }
    }

    private void SetEnableAddingBind(bool isEnabled = true) {
      //textBox2.Enabled = isEnabled;
      //button2.Enabled = isEnabled;
      //button3.Enabled = isEnabled;
      groupBox2.Enabled = isEnabled;
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

    private void button2_Click(object sender, EventArgs e) {
      var c = _diagram.selectedModels.Count();
      var time = textBox2.Text;

      if (c == 2 && int.TryParse(time, out int timeInt)) {
        _diagram.selectedModels[0].AddBind(_diagram.selectedModels[1], timeInt);
        _diagram.ResetSelectedModels();
        textBox2.Text = "";
        pictureBox1.Refresh();
        CheckDiagramSelectedModels();
      } else {
        MessageBox.Show("Error input");
      }
    }

    private void button3_Click(object sender, EventArgs e) {
      var c = _diagram.selectedModels.Count();

      if (c == 2) {
        _diagram.selectedModels[0].RemoveBind(_diagram.selectedModels[1]);
        _diagram.ResetSelectedModels();
        pictureBox1.Refresh();
        CheckDiagramSelectedModels();
      } else {
        MessageBox.Show("Error selected not 2");
      }
    }
  }
}
