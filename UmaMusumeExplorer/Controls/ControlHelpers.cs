using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UmaMusumeExplorer.Controls
{
    internal static class ControlHelpers
    {
        public static void ShowFormDialogCenter(Form form, Control target)
        {
            SetNewLocation(form, target);
            form.ShowDialog();
        }

        public static void ShowFormCenter(Form form, Control target)
        {
            SetNewLocation(form, target);
            form.Show();
        }

        private static void SetNewLocation(Form form, Control target)
        {
            Form parentForm = GetParentForm(target);

            int left = parentForm.Left;
            int top = parentForm.Top;

            left += (parentForm.Width / 2) - (form.Width / 2);
            top += (parentForm.Height / 2) - (form.Height / 2);

            form.Left = left;
            form.Top = top;
        }

        public static Form GetParentForm(Control control)
        {
            if (control is Form parentForm)
            {
                return parentForm;
            }
            else return GetParentForm(control.Parent);
        }
    }
}
