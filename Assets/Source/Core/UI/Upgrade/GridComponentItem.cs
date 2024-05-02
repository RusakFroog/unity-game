using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Core.UI.Upgrade 
{
    public class GridComponentItem
    {
        public static Dictionary<string, GridComponentItem> Items = new Dictionary<string, GridComponentItem>()
        {
            { "Keyboard", new GridComponentItem("Keyboard", 1) },
            { "Pc", new GridComponentItem("Pc", 1) },
            { "Mouse", new GridComponentItem("Mouse", 1) },
            { "Table", new GridComponentItem("Table", 1) },
            { "Chair", new GridComponentItem("Chair", 1) },
            { "Monitor", new GridComponentItem("Monitor", 1) },
        };

        public readonly string Name;
        public readonly Sprite Sprite;
        public int Level;
        public readonly ComponentItem ComponentItem;

        private GridComponentItem(string name, int level)
        {
            Name = name;
            Level = level;
            Sprite = Resources.Load<Sprite>("Images/Upgrade/Components/" + name);
        }
    }
}