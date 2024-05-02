using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Core.UI.Upgrade
{
    public delegate void OnSelectComponent(string componentName);
    
    public class GridComponentItem
    {
        private static List<GridComponentItem> _allItems = new List<GridComponentItem>();

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

            _allItems.Add(this);
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

                GridComponentItem previousItem = _allItems.FirstOrDefault(x => x.IsSelected);

                if (previousItem != null)
                {
                    previousItem.IsSelected = false;
                    previousItem.BackgroundImage.sprite = Resources.Load<Sprite>("Images/Upgrade/GridItems/gridItemBack");
                }
                
                BackgroundImage.sprite = Resources.Load<Sprite>("Images/Upgrade/GridItems/gridItemBackSelected");

                IsSelected = true;
                
                OnSelectComponent?.Invoke(name);
            });

            LabelName.text = name;
            ComponentImage.sprite = Resources.Load<Sprite>("Images/Upgrade/Components/" + name);

            SetLvl((ushort)lvl);
        }
    }
}