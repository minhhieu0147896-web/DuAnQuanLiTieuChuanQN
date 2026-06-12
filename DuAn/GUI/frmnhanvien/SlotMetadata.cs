using System;
using DuAn.DTO;

namespace DuAn.GUI.frmnhanvien
{
    public class SlotMetadata
    {
        public string Key { get; set; }
        public DateTime Date { get; set; }
        public BuoiAnModel BuoiAn { get; set; }
        public MealKind Meal { get; set; }
        public DishCategory Category { get; set; }
        public int CategoryIndex { get; set; }
    }
}
