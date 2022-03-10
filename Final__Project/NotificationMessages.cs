using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final__Project
{
    public static class NotificationMessages
    {
        
        public static void ItemAdded()
        {
            string message = "A record has been added to the list!";
            string title = "Data Update Notification";
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void SceneryNotSelected(string scenery)
        {
            string message = $"Please select your {scenery} vacation destination!";
            string title = $"No Preference Selected - {scenery}" ;
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static DialogResult Deletion()
        {
            string message = "Are you sure you want to erase this data?";
            string title = "Unrecoverable Permanent Deletion";
            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return result;
        }
    }
}
