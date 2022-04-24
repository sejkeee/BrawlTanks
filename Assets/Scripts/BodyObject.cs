using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "TankParts/Body")]
    public class BodyObject : ScriptableObject, IItem
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