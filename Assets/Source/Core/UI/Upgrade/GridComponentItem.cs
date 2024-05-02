using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Core.UI.Upgrade
{
    public class GridComponentItem
    {
        public readonly TextMeshProUGUI LabelLevel;
        public readonly TextMeshProUGUI LabelName;
        public readonly Image Image;

        public GridComponentItem(TextMeshProUGUI level, TextMeshProUGUI name, Image image, int componentLevel, string componentName)
        {
            LabelLevel = level;
            LabelName = name;
            Image = image;

            _init(componentLevel, componentName);
        }

        private void _init(int lvl, string name)
        {
            LabelName.text = name;
            Image.sprite = Resources.Load<Sprite>("Images/Upgrade/Components/" + name);

            SetLvl((ushort)lvl);
        }

        public void SetLvl(ushort lvl)
        {
            LabelLevel.text = $"{lvl}";
        }
    }
}