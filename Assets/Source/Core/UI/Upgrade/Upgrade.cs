using System.Collections.Generic;
using System.Linq;
using Assets.Source.Core.Setups.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Core.UI.Upgrade
{
    public class Upgrade : InteractionDialogue
    {
        [SerializeField]
        private TextMeshProUGUI _setupNumber;

        [SerializeField] 
        private TextMeshProUGUI _componentName;

        [SerializeField]
        private TextMeshProUGUI _componentLvl;

        [SerializeField]
        private TextMeshProUGUI _profitMoney;

        [SerializeField]
        private TextMeshProUGUI _profitTime;

        [SerializeField]
        private TextMeshProUGUI _buyWithMoney;

        [SerializeField]
        private Image _componentImage;

        [SerializeField]
        private GameObject _gridComponentsObject;

        private List<ComponentItem> _components = new List<ComponentItem>();
        private GridLayoutGroup _gridComponents;

        private ComponentItem _selectedComponent;

        private void Awake()
        {
            _gridComponents = _gridComponentsObject.GetComponent<GridLayoutGroup>();

            Hide();
        }

        public void SetSetup(Setup setup)
        {
            if (_components.Count > 0 && setup == _components.First().CurrentSetup)
                return;

            _components.Clear();

            foreach (var component in setup.Components)
            {
                GameObject prefabGridItem = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Ui/Upgrade/Grid/ComponentItem"), Vector3.zero, Quaternion.identity, _gridComponents.transform);

                ComponentItem componentItem = new ComponentItem(setup, prefabGridItem, this, component);

                _components.Add(componentItem);
            }

            SelectComponent(_components.First());
        }

        public void SelectComponent(ComponentItem componentItem)
        {
            _setupNumber.text = $"Computer #{componentItem.CurrentSetup.Id + 1}";
            _componentName.text = componentItem.Name;
            _componentLvl.text = $"LVL {componentItem.Level}";
            _profitMoney.text = componentItem.SetupComponent.ProfitMoney.ToString();
            _profitTime.text = componentItem.SetupComponent.ProfitTime.ToString();
            _buyWithMoney.text = componentItem.SetupComponent.Price.ToString();
            _componentImage.sprite = Resources.Load<Sprite>("Images/Upgrade/Components/" + componentItem.Name);

            componentItem.GridComponentItem.BackgroundImage.sprite = Resources.Load<Sprite>("Images/Upgrade/GridItems/gridItemBackSelected");
            componentItem.GridComponentItem.IsSelected = true;

            _selectedComponent = componentItem;
        }

        public void OnClickClose()
        {
            Hide();
        }

        public void OnClickBuyWithMoney()
        {
            // Money.Change(-price);

            _upgradeComponent();
        }

        public void OnClickBuyWithAd()
        {
            // Ad.Show();

            _upgradeComponent();
        }

        private void _upgradeComponent()
        {
            if (_selectedComponent == null)
                return;

            _selectedComponent.Upgrade();
        }
    }
}