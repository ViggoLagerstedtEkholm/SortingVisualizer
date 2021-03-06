﻿using System.Collections.Generic;
using System.Windows.Forms;

namespace SortingVisualizer.Validate
{
    public static class Validator
    {
        public static bool TxfHasInteger(TextBox txfBox)
        {
            bool hasInteger = false;
            if (int.TryParse(txfBox.Text, out _))
            {
                hasInteger = true;
            }

            return hasInteger;
        }

        public static bool CheckRadioBtnHasSelected(List<RadioButton> buttons)
        {
            bool res = false;

            for (int i = 0; i < buttons.Count; i++)
            {
                if (buttons[i].Checked)
                {
                    res = true;
                }
            }
            return res;
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
