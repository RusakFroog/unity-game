using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Core.UI.Upgrade
{
    public delegate void SelectComponent(string componentName);
    
    public class GridComponentItem
    {
        public readonly TextMeshProUGUI LabelLevel;
        public readonly TextMeshProUGUI LabelName;
        public readonly Button ComponentButton;
        public readonly Image ComponentImage;
        public readonly Image BackgroundImage;

        public bool IsSelected = false;

        public SelectComponent SelectComponentDelegate;
        
        public GridComponentItem(Button button, TextMeshProUGUI level, TextMeshProUGUI name, Image componentImage, Image backgroundImage, int componentLevel, string componentName)
        {
            ComponentButton = button;
            LabelLevel = level;
            LabelName = name;
            ComponentImage = componentImage;
            BackgroundImage = backgroundImage;

            _init(componentLevel, componentName);
        }

        public void SetLvl(ushort lvl)
        {
            LabelLevel.text = $"{lvl}";
        }

        private void _init(int lvl, string name)
        {
            ComponentButton.onClick.AddListener(() => 
            {
                if (IsSelected)
                    return;

                SelectComponentDelegate?.Invoke(name);

                string imageBack = IsSelected ? "Images/Upgrade/GridItems/gridItemBack" : "Images/Upgrade/GridItems/gridItemBackSelected";

                BackgroundImage.sprite = Resources.Load<Sprite>(imageBack);

                IsSelected = !IsSelected;
            });

            LabelName.text = name;
            ComponentImage.sprite = Resources.Load<Sprite>("Images/Upgrade/Components/" + name);

            SetLvl((ushort)lvl);
        }
    }
}