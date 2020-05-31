using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPaMM.Core;

namespace NPaMM {
  public partial class Form1 : Form {
    private SpaceDiagram _diagram;
    private NetworkCore _netCore;

    public Form1() {
      InitializeComponent();

      pictureBox1.Paint += this.PictureBox1_Paint;
      pictureBox1.MouseMove += this.PictureBox1_MouseMove;
      pictureBox1.MouseDown += this.PictureBox1_MouseDown;
      pictureBox1.MouseUp += this.PictureBox1_MouseUp;
      pictureBox1.MouseClick += this.PictureBox1_MouseClick;
      ;

      _diagram = new SpaceDiagram();
      _netCore = new NetworkCore(_diagram);

      listView1.FullRowSelect = true;

      _diagram.OnChangedSelectedModels += CheckDiagramSelectedModels;

      _diagram.AddModel("Start");
      _diagram.AddModel("End");

      CheckDiagramSelectedModels();
    }

    private void CheckDiagramSelectedModels() {
      var c = _diagram.selectedModels.Count();

      if (c == 2) {
        SetEnableAddingBind();
      } else {
        SetEnableAddingBind(false);
      }

      if (c == 1) {
        SetEnableEditModel();
      } else {
        SetEnableEditModel(false);
      }
    }

    private void SetEnableAddingBind(bool isEnabled = true) {
      groupBox2.Enabled = isEnabled;
    }

    private void SetEnableEditModel(bool isEnabled = true) {
      button4.Enabled = isEnabled;
      button1.Enabled = !isEnabled;

      if (isEnabled) {
        textBox1.Text = _diagram.selectedModels[0]?.name;
        textBox4.Text = _diagram.selectedModels[0]?.number.ToString();
      } else {
        ResetModelBlock();
      }
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

      ResetModelBlock();
      pictureBox1.Refresh();
    }

    private void button2_Click(object sender, EventArgs e) {
      var c = _diagram.selectedModels.Count();
      var timeMin = textBox2.Text;
      var timeMax = textBox3.Text;

      if (c == 2 && int.TryParse(timeMin, out int timeMinInt)) {
        if (timeMax == "" || int.TryParse(timeMax, out int timeMaxInt) == false) {
          timeMaxInt = -1;
        }
        _diagram.selectedModels[0].AddBind(
          _diagram.selectedModels[1], timeMinInt, timeMaxInt
        );
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
        _diagram.selectedModels[0]?.RemoveBind(_diagram.selectedModels[1]);
        _diagram.ResetSelectedModels();
        pictureBox1.Refresh();
        CheckDiagramSelectedModels();
      } else {
        MessageBox.Show("Error selected not 2");
      }
    }

    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {
      var select = ((TabControl)sender).SelectedIndex;

      if (select == 1) {
        _netCore.CheckCorrectDiagram();
        Console.WriteLine(sender);
      }

    }

    private void button4_Click(object sender, EventArgs e) {
      var name = textBox1.Text;
      var number = textBox4.Text;

      if (_diagram.selectedModels[0]?.Edit(name, number) == true) {
        CheckDiagramSelectedModels();
      }

      pictureBox1.Refresh();
    }

    public void ResetModelBlock() {
      textBox1.Text = "";
      textBox4.Text = Model.GetNextId().ToString();
    }
  }
}
