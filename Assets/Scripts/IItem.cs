using UnityEngine;

namespace Assets.Scripts
{
    public interface IItem
    {
        GameObject Main { get; set; }
        Sprite Icon { get; set; }
    }
}