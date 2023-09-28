namespace UmaMusumeExplorer.Controls
{
    static class ControlHelpers
    {
        private static List<Form> OpenedForms { get; } = new();

        public static void CloseAllForms()
        {
            OpenedForms.ForEach(form =>
            {
                form.FormClosed -= FormClosed;
                form.Close();
            });

            OpenedForms.Clear();
        }

        public static void ShowFormDialogCenter(Form form, Control source)
        {
            SetNewLocation(form, source);
            Form parentForm = GetParentForm(source);
            form.Icon = parentForm.Icon;
            form.ShowDialog(parentForm);
        }

        public static void ShowFormCenter(Form form, Control source)
        {
            SetNewLocation(form, source);
            form.Icon = GetParentForm(source).Icon;
            form.FormClosed += FormClosed;
            form.Show();
            OpenedForms.Add(form);
        }

        private static void SetNewLocation(Form form, Control source)
        {
            Form parentForm = GetParentForm(source);

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

        private static void FormClosed(object sender, FormClosedEventArgs e) => OpenedForms.Remove(sender as Form);
    }
}
