using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "TankParts/Tower")]
    public class TowerObject : ScriptableObject, IItem
    {
        [SerializeField] private GameObject _main;
        [SerializeField] private Sprite _icon;
        
        public GameObject Main 
        {
            get
            {
                return _main;
            }
            set
            {
                Main = value;
            }
        }

        public Sprite Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                Icon = value;
            }
        }
    }
}