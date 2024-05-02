using UnityEngine;

namespace Assets.Source.Core.UI.Upgrade
{
    
    public class ComponentItem
    {
        public string Name;
        public int Level;
        public Sprite Sprite;

        public ComponentItem(string name, int level)
        {
            Name = name;
            Level = level;
            Sprite = Resources.Load<Sprite>("Images/Upgrade/Components/" + name);
        }
    }
}