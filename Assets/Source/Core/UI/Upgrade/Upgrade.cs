using System.Collections.Generic;
using Assets.Source.Core.Setups.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Core.UI.Upgrade
{
    public class Upgrade : InterationDialog
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
        private GameObject _gridComponentsObject;

        private List<ComponentItem> _components = new List<ComponentItem>();
        private GridLayoutGroup _gridComponents;

        private void Start()
        {
            _gridComponents = _gridComponentsObject.GetComponent<GridLayoutGroup>();

            SetSetup(Setup.Setups[0]);
        }

        public void SetSetup(Setup setup)
        {
            foreach (var component in setup.Components)
            {
                GameObject prefabGridItem = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Ui/Upgrade/Grid/ComponentItem"), Vector3.zero, Quaternion.identity, _gridComponents.transform);

                ComponentItem componentItem = new ComponentItem(prefabGridItem, component.Name, (int)component.Level);

                _components.Add(componentItem);
            }
        }
        public void SetTextValue(Setup setup, ComponentItem componentItem)
        {
            _setupNumber.text = "Computer " + setup.Id.ToString();
            _componentName.text = componentItem.Name;
            _componentLvl.text = componentItem.Level.ToString();
            _profitMoney.text = componentItem.SelectedComponent.ProfitMoney.ToString();
            _profitTime.text = componentItem.SelectedComponent.ProfitTime.ToString();
            _buyWithMoney.text = componentItem.SelectedComponent.Price.ToString();
        }
        public void SelectComponenet()
        {

        }
    }
}