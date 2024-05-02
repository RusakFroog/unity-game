using System.Collections.Generic;
using Assets.Source.Core.Setups.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Core.UI.Upgrade 
{
    public class ComponentItem
    {
        public readonly string Name;
        public readonly GridComponentItem GridComponentItem;
        public Setups.Models.Components.Component SelectedComponent;

        private Setup _curentSetup;

        private int _level;

        public int Level
        {
            get => _level;
            set
            {
                _level = value;

                GridComponentItem.SetLvl((ushort)value);
            }
        }

        public ComponentItem(Setup curentSetup, GameObject prefabObject, string name, int level)
        {
            GridComponentItem = _getComponents(name, level, prefabObject);

            GridComponentItem.SelectComponentDelegate += SelectComponentDelegate;

            Name = name;
            Level = level;
            _curentSetup = curentSetup;
        }

        private GridComponentItem _getComponents(string componentName, int componentLevel, GameObject gameObject)
        {
            TextMeshProUGUI labelLevel = null;
            TextMeshProUGUI labelName = null;
            Image image = null;

            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                var child = gameObject.transform.GetChild(i);

                if (child.name == "ComponentLvl")
                    labelLevel = child.GetComponent<TextMeshProUGUI>();

                else if (child.name == "TextNameOfComponent")
                    labelName = child.GetComponent<TextMeshProUGUI>();

                else if (child.name == "ComponentImage")
                    image = child.GetComponent<Image>();
            }

            return new GridComponentItem(gameObject.GetComponent<Button>(), labelLevel, labelName, image, componentLevel, componentName);
        }

        private void SelectComponentDelegate(string name)
        {
            foreach (var component in Setup.Setups[0].Components)
            {
                if (component.Name == name)
                {
                    SelectedComponent = component;
                    break;
                }
            }
        }
    }
}