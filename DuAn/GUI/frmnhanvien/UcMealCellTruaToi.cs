using System.Collections.Generic;
using System.Windows.Forms;

namespace DuAn.GUI.frmnhanvien
{
    public partial class UcMealCellTruaToi : UserControl
    {
        public UcMealCellTruaToi()
        {
            InitializeComponent();
        }

        public IEnumerable<Button> GetAllSlots()
        {
            yield return btnMan1;
            yield return btnMan2;
            yield return btnMan3;
            yield return btnMan4;
            yield return btnCanh1;
            yield return btnRau1;
            yield return btnTrangMieng1;
        }

        public Button GetSlotButton(DishCategory category, int index)
        {
            if (category == DishCategory.Man)
            {
                switch (index)
                {
                    case 0: return btnMan1;
                    case 1: return btnMan2;
                    case 2: return btnMan3;
                    case 3: return btnMan4;
                }
            }
            if (category == DishCategory.Canh) return btnCanh1;
            if (category == DishCategory.Rau) return btnRau1;
            if (category == DishCategory.TrangMieng) return btnTrangMieng1;
            return null;
        }

        /// <summary>
        /// Ẩn/hiện tất cả slot thuộc một loại món.
        /// </summary>
        public void SetSlotVisible(DishCategory category, bool visible)
        {
            foreach (Button btn in GetAllSlots())
            {
                // Kiểm tra tên button để xác định loại (vd: btnMan1, btnMan2...)
                if (category == DishCategory.Man && btn.Name.StartsWith("btnMan"))
                    btn.Visible = visible;
                else if (category == DishCategory.Canh && btn.Name.StartsWith("btnCanh"))
                    btn.Visible = visible;
                else if (category == DishCategory.Rau && btn.Name.StartsWith("btnRau"))
                    btn.Visible = visible;
                else if (category == DishCategory.TrangMieng && btn.Name.StartsWith("btnTrangMieng"))
                    btn.Visible = visible;
            }
        }
    }
}
