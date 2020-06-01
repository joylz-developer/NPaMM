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
    private readonly bool _isFirstColumn;

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

      _columnHeaders = columnHeaders;

      Init();

      _listViewItem = new List<ListViewItem>();
    }

    public void Init() {
      _listView.Columns.AddRange(_columnHeaders.ToArray());
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

    public void AddLine(params string[] s) {
      var v = new ListViewItem();

      if (_isFirstColumn) {
        v.Text = (_lastId++).ToString();
      } else {
        v.Text = s[0];
      }

      for (int i = 0; i < _columnHeaders.Count(); i++) {
        if (i == 0 && _isFirstColumn == false) {
          continue;
        }

        if (s.Length <= i) {
          v.SubItems.Add("");
        } else {
          v.SubItems.Add(s[i]);
        }

      }

      _listViewItem.Add(v);
      _listView.Items.Add(v);
    }

    public void AddLines(List<string[]> lines) {
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
  }

}
