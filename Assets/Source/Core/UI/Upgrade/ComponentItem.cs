using Assets.Source.Core.Setups.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Core.UI.Upgrade 
{
    public class ComponentItem
    {
        public readonly Setups.Models.Components.Component SetupComponent;
        public readonly string Name;
        public readonly GridComponentItem GridComponentItem;
        public readonly Upgrade UpgradeUI;
        public readonly Setup CurrentSetup;

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

        public ComponentItem(Setup curentSetup, GameObject prefabObject, Upgrade upgradeUI, Setups.Models.Components.Component component)
        {
            GridComponentItem = _getComponents(component.Name, (int)component.Level, prefabObject);

            Name = component.Name;
            Level = (int)component.Level;
            UpgradeUI = upgradeUI;
            CurrentSetup = curentSetup;
            SetupComponent = component;

            GridComponentItem.OnSelectComponent += () => UpgradeUI.SelectComponent(this);
        }

        public void Upgrade()
        {
            CurrentSetup.ChangeComponent(SetupComponent, SetupComponent.Level + 1);

            Level = (int)SetupComponent.Level;

            UpgradeUI.SelectComponent(this);
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
    }
}