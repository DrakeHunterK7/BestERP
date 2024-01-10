using Avalonia.Controls;
using DynamicData;

namespace ERP.Views
{
    public partial class AddNewUserView : UserControl
    {
        public AddNewUserView()
        {
            InitializeComponent();
            LoadComboBox();
        }

        public void LoadComboBox()
        {
            DepartmentDropdown.SelectedItem = DepartmentDropdown.Items[0];
        }
    }
}
