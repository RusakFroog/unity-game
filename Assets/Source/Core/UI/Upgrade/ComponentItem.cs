using System.Linq;
using Assets.Source.Core.Setups.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Core.UI.Upgrade 
{
    public class ComponentItem
    {
        public Setups.Models.Components.Component SelectedComponent;

        public readonly string Name;
        public readonly GridComponentItem GridComponentItem;
        public readonly Upgrade UpgradeUI;

        private readonly Setup _curentSetup;

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

        public ComponentItem(Setup curentSetup, GameObject prefabObject, Upgrade upgradeUI, string name, int level)
        {
            GridComponentItem = _getComponents(name, level, prefabObject);

            Name = name;
            Level = level;
            UpgradeUI = upgradeUI;
            _curentSetup = curentSetup;

            GridComponentItem.OnSelectComponent += OnSelectComponent;
        }

        private GridComponentItem _getComponents(string componentName, int componentLevel, GameObject gameObject)
        {
            Image backgroundImage = gameObject.GetComponent<Image>();
            Image componentImage = null;
            TextMeshProUGUI labelLevel = null;
            TextMeshProUGUI labelName = null;

            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                var child = gameObject.transform.GetChild(i);

                if (child.name == "ComponentLvl")
                    labelLevel = child.GetComponent<TextMeshProUGUI>();

                else if (child.name == "TextNameOfComponent")
                    labelName = child.GetComponent<TextMeshProUGUI>();

                else if (child.name == "ComponentImage")
                    componentImage = child.GetComponent<Image>();
            }

            return new GridComponentItem(gameObject.GetComponent<Button>(), labelLevel, labelName, componentImage, backgroundImage, componentLevel, componentName);
        }

        private void OnSelectComponent(string name)
        {
            var component = _curentSetup.Components.FirstOrDefault(x => x.Name == name);

            SelectedComponent = component;

            UpgradeUI.SetTextValue(_curentSetup, this);
        }
    }
}