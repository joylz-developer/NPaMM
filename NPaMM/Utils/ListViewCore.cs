using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPaMM {
  public class ListViewCore {
    private ListView _listView;
    private List<ColumnHeader> _columnHeaders;
    private List<ListViewItem> _listViewItem;
    private int _lastId;
    public ListViewItem curentSelected { get; set; }
    public int curentSelectedId { get; set; }
    private bool _isFirstColumn { get; set; }

    public delegate void ESelectionChanged(bool isSelected, ListViewItem item);
    public event ESelectionChanged OnSelectionChanged;

    public ListViewCore(ListView listView, List<ColumnHeader> columnHeaders, bool isFirstColumn = true) {
      _listView = listView;
      _isFirstColumn = isFirstColumn;
      curentSelected = null;
      curentSelectedId = -1;
      _lastId = 1;

      if (_isFirstColumn) {
        _listView.Columns.Add(
          new ColumnHeader() {
            Text = "#",
            Width = 30
          }
        );
      }

      _columnHeaders = columnHeaders ?? new List<ColumnHeader>();

      Init();

      _listViewItem = new List<ListViewItem>();
    }

    public void Init() {
      if (_columnHeaders.Count > 0) {
        _listView.Columns.AddRange(_columnHeaders.ToArray());
      } else {
        _listView.Columns.Add("Log", _listView.Width);
      }
      _listView.FullRowSelect = true;
      _listView.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(SelectionChanged);
    }

    private void SelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
      if (e.IsSelected) {
        curentSelected = e.Item;
        curentSelectedId = e.ItemIndex;
      } else {
        curentSelected = null;
        curentSelectedId = -1;
      }

      OnSelectionChanged?.Invoke(e.IsSelected, e.Item);
    }

    public bool SelectLine(int index) {
      if (_listView.Items.Count > index && index >= 0) {
        _listView.Items[index].Selected = true;
        return true;
      }

      return false;
    }

    public void AddLine(List<string> s, ListViewItem style = null) {
      var v = style ?? new ListViewItem();

      if (_isFirstColumn) {
        v.Text = (_lastId++).ToString();
      } else {
        v.Text = s.First();
      }

      for (int i = 0; i < _columnHeaders.Count(); i++) {
        if (i == 0 && _isFirstColumn == false) {
          continue;
        }

        if (s.Count <= i) {
          v.SubItems.Add("");
        } else {
          v.SubItems.Add(s[i]);
        }
      }

      _listViewItem.Add(v);
      _listView.Items.Add(v);
    }

    public void AddLine(string s, ListViewItem style = null) {
      var v = style ?? new ListViewItem();

      if (_isFirstColumn) {
        v.Text = (_lastId++).ToString();
      } else {
        v.Text = s;
      }

      for (int i = 0; i < _columnHeaders.Count(); i++) {
        if (i == 0 && _isFirstColumn == false) {
          continue;
        }

        if (1 <= i) {
          v.SubItems.Add("");
        } else {
          v.SubItems.Add(s);
        }
      }

      _listViewItem.Add(v);
      _listView.Items.Add(v);
    }

    public void AddLines(List<List<string>> lines) {
      lines.ForEach(line => this.AddLine(line));
    }

    public void RemoveLine(ListViewItem item) {
      _listView.Items.Remove(item);
      _listViewItem.Remove(item);
    }

    public void Clear() {
      _listViewItem.Clear();
      _listView.Items.Clear();
      _lastId = 1;

      curentSelected = null;
      curentSelectedId = -1;
    }

    public void HideHeaders(ColumnHeaderStyle style) {
      _listView.HeaderStyle = style;
    }
  }
}
