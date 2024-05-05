using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Core.UI.Upgrade
{
    public delegate void OnSelectComponent();
    
    public class GridComponentItem
    {
        private static List<GridComponentItem> _gridItems = new List<GridComponentItem>();

        public readonly TextMeshProUGUI LabelLevel;
        public readonly TextMeshProUGUI LabelName;
        public readonly Button ComponentButton;
        public readonly Image ComponentImage;
        public readonly Image BackgroundImage;

        public bool IsSelected = false;

        public OnSelectComponent OnSelectComponent;
        
        public GridComponentItem(Button button, TextMeshProUGUI level, TextMeshProUGUI name, Image componentImage, Image backgroundImage, int componentLevel, string componentName)
        {
            ComponentButton = button;
            LabelLevel = level;
            LabelName = name;
            ComponentImage = componentImage;
            BackgroundImage = backgroundImage;

            _init(componentLevel, componentName);

            _gridItems.Add(this);
        }

        public void SetLvl(ushort lvl, bool isMaxLvl = false)
        {
            LabelLevel.text = isMaxLvl ? "M" : $"{lvl}";
        }

        public static void ClearItems() => _gridItems.Clear();

        private void _init(int lvl, string name)
        {
            ComponentButton.onClick.AddListener(() => 
            {
                if (IsSelected)
                    return;
                
                GridComponentItem previousItem = _gridItems.FirstOrDefault(x => x.IsSelected);

                if (previousItem != null)
                {
                    previousItem.IsSelected = false;
                    previousItem.BackgroundImage.sprite = Resources.Load<Sprite>("Images/Upgrade/GridItems/gridItemBack");
                }
                
                BackgroundImage.sprite = Resources.Load<Sprite>("Images/Upgrade/GridItems/gridItemBackSelected");

                IsSelected = true;
                
                OnSelectComponent?.Invoke();
            });

            LabelName.text = name;
            ComponentImage.sprite = Resources.Load<Sprite>("Images/Upgrade/Components/" + name);

            SetLvl((ushort)lvl);
        }
    }
}