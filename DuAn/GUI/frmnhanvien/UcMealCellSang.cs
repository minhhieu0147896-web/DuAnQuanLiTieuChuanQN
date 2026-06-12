using System.Collections.Generic;
using System.Windows.Forms;

namespace DuAn.GUI.frmnhanvien
{
    public partial class UcMealCellSang : UserControl
    {
        public UcMealCellSang()
        {
            InitializeComponent();
        }

        public IEnumerable<Button> GetAllSlots()
        {
            yield return btnMan1;
            yield return btnCanh1;
            yield return btnSua1;
            yield return btnCom1;
        }

        public Button GetSlotButton(DishCategory category, int index)
        {
            if (category == DishCategory.Man) return btnMan1;
            if (category == DishCategory.Canh) return btnCanh1;
            if (category == DishCategory.SuaHop) return btnSua1;
            if (category == DishCategory.Com) return btnCom1;
            return null;
        }

        /// <summary>
        /// Ẩn/hiện một slot theo loại món.
        /// </summary>
        public void SetSlotVisible(DishCategory category, bool visible)
        {
            Button btn = GetSlotButton(category, 0);
            if (btn != null) btn.Visible = visible;
        }
    }
}
