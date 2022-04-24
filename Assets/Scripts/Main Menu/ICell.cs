using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main_Menu
{
    public interface ICell
    {
        Sprite Icon { get; }
        IItem Item { set; }
        
        bool Locked { get; set; }
        
        IItem GetItem();
        void SetIcon();

        void OnCellClick();
    }
}