using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortingVisualizer.Validate
{
    public static class Validator
    {
        public static bool TxfHasContent(TextBox txfBox)
        {
            bool hasValue = false;

            if(txfBox.Text != "" || txfBox.TextLength != 0)
            {
                hasValue = true;
            }

            return hasValue;
        }

        public static bool TxfHasInteger(TextBox txfBox)
        {
            bool hasInteger = false;
            int parsedValue;

            if(int.TryParse(txfBox.Text, out parsedValue))
            {
                hasInteger = true;
            }

            return hasInteger;
        }

        public static bool CheckBoxListHasValue(CheckedListBox list)
        {
            bool hasCheckedItems = false;

            for (int i = 0; i < list.Items.Count; i++)
            {
                if (list.GetItemChecked(i))
                {
                    hasCheckedItems = true;
                }
            }

            return hasCheckedItems;
        }
    }
}
