using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Core.UI.Upgrade
{
    public class GridComponentItem
    {
        public readonly TextMeshProUGUI LabelLevel;
        public readonly TextMeshProUGUI LabelName;
        public readonly Button ComponentButton;
        public readonly Image Image;

        public GridComponentItem(Button button, TextMeshProUGUI level, TextMeshProUGUI name, Image image, int componentLevel, string componentName)
        {
            ComponentButton = button;
            LabelLevel = level;
            LabelName = name;
            Image = image;

            _init(componentLevel, componentName);
        }

        private void _init(int lvl, string name)
        {
            ComponentButton.onClick.AddListener(SelectComponenet);

            LabelName.text = name;
            Image.sprite = Resources.Load<Sprite>("Images/Upgrade/Components/" + name);

            SetLvl((ushort)lvl);
        }

        public void SetLvl(ushort lvl)
        {
            LabelLevel.text = $"{lvl}";
        }

        private void SelectComponenet()
        {

        }
    }
}