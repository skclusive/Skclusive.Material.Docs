using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Skclusive.Material.Docs.Pages
{
    public class CountAction
    {
        public string Type { set; get; }

        public string Path { set; get; }

        public List<object> Arguments { set; get; }
    }

    public partial class ListTest : ComponentBase
    {
        private bool Open { set; get; } = false;

        private int SelectedIndex { set; get; } = 0;

        private Dictionary<int, bool> checkedMapping = new Dictionary<int, bool>()
        {
           { 1, false },
           { 2, false }
        };

        private bool IsChecked(int id)
        {
            bool xchecked = checkedMapping[id];

            return xchecked;
        }

        private void ToggleChecked(int id)
        {
            checkedMapping[id] = !checkedMapping[id];
        }

        private void OnSelect(int selectedIndex)
        {
            SelectedIndex = selectedIndex;

            if (SelectedIndex == 3)
            {
                Open = !Open;
            }
        }
    }
}