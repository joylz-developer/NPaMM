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
using NPaMM.Utils;

namespace NPaMM {
  public partial class Form1 : Form {
    private SpaceDiagram _diagram;
    private NetworkCore _netCore;
    private ListViewCore _dataView;
    private ListViewCore _infoView;

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

      AddImportsDataDiagram(FakeImportsData());

      CheckDiagramSelectedModels();

      var namesColumns = new List<ColumnHeader> {
        new ColumnHeader() { Text = "Work", Width = 50 },
        new ColumnHeader() { Text = "Time (min)", Width = 65 },
        new ColumnHeader() { Text = "Time (max)", Width = 65 },
        new ColumnHeader() { Text = "Time (expected)", Width = 95 },
        new ColumnHeader() { Text = "Dispersion", Width = 65 }
      };

      _dataView = new ListViewCore(listView1, namesColumns);

      _infoView = new ListViewCore(listView2, null, false);
      _infoView.HideHeaders(ColumnHeaderStyle.None);
    }

    private List<ImportModels> FakeImportsData() {
      return new List<ImportModels>() {
        new ImportModels(new int[] { 1, 2 }, 5, 7.5f),
        new ImportModels(new int[] { 2, 3 }, 4, 6.5f),
        new ImportModels(new int[] { 2, 4 }, 3, 6),
        new ImportModels(new int[] { 2, 5 }, 1, 5.5f),
        new ImportModels(new int[] { 3, 7 }, 0.5f, 3.5f),
        new ImportModels(new int[] { 4, 5 }, 5, 7.5f),
        new ImportModels(new int[] { 4, 6 }, 3, 5.5f),
        new ImportModels(new int[] { 4, 9 }, 5, 10),
        new ImportModels(new int[] { 5, 8 }, 2, 4.5f),
        new ImportModels(new int[] { 5, 10 }, 7, 12),
        new ImportModels(new int[] { 6, 9 }, 0, 0),
        new ImportModels(new int[] { 6, 11 }, 3, 8),
        new ImportModels(new int[] { 7, 10 }, 4, 9),
        new ImportModels(new int[] { 8, 10 }, 2, 7),
        new ImportModels(new int[] { 9, 10 }, 1, 6),
        new ImportModels(new int[] { 10, 11 }, 8, 10.5f)
      };
    }

    private void AddImportsDataDiagram(List<ImportModels> imports) {
      _diagram.AddImportModels(imports);

      _diagram.ResetSelectedModels();
      textBox2.Text = "";
      textBox3.Text = "";
      pictureBox1.Refresh();
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

      if (c == 2 && float.TryParse(timeMin, out float timeMinInt)) {
        if (timeMax == "" || float.TryParse(timeMax, out float timeMaxInt) == false) {
          timeMaxInt = -1;
        }
        _diagram.selectedModels[0].AddBind(
          _diagram.selectedModels[1], timeMinInt, timeMaxInt
        );
        _diagram.ResetSelectedModels();
        textBox2.Text = "";
        textBox3.Text = "";
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

    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {
      var select = ((TabControl)sender).SelectedIndex;

      if (select == 1) {
        if (_netCore.CheckCorrectDiagram()) {
          _dataView.Clear();
          _dataView.AddLines(_netCore.BildTable());
          _netCore.GetCriticalPath();

          foreach (var item in _netCore.eventsPaths) {
            var str = $@"[L={item.duration} S={item.dispersionPath}] => (";
            item.path.ForEach((ev) => str += ev.left.number + "..");
            str += item.path.Last().right.number + ")";

            _infoView.AddLine(new List<string>() { str });
          }
          var maxCrPath = _netCore.CalcMaxDurationPath();
        }
      }

      //Console.WriteLine(SND.Get(0.1f));
    }
  }
}
