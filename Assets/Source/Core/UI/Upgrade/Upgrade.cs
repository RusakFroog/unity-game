using System.Collections.Generic;
using Assets.Source.Core.Setups.Models;
using TMPro;
using Unity.VisualScripting;
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
        private Image _selectedComponent;

        [SerializeField]
        private GameObject _gridComponentsObject;

        private List<ComponentItem> _components = new List<ComponentItem>();
        private GridLayoutGroup _gridComponents;

        private void Awake()
        {
            _gridComponents = _gridComponentsObject.GetComponent<GridLayoutGroup>();

            Hide();
        }

        public void SetSetup(Setup setup)
        {
            foreach (var component in setup.Components)
            {
                GameObject prefabGridItem = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Ui/Upgrade/Grid/ComponentItem"), Vector3.zero, Quaternion.identity, _gridComponents.transform);

                ComponentItem componentItem = new ComponentItem(setup, prefabGridItem, this, component.Name, (int)component.Level);

                _components.Add(componentItem);
            }
            SetTextValue(setup, _components[0]);
        }

        public void SetTextValue(Setup setup, ComponentItem componentItem)
        {
            _setupNumber.text = $"Computer #{setup.Id}";
            _componentName.text = componentItem.Name;
            _componentLvl.text = $"LVL {componentItem.Level}";
            _profitMoney.text = componentItem.SelectedComponent.ProfitMoney.ToString();
            _profitTime.text = componentItem.SelectedComponent.ProfitTime.ToString();
            _buyWithMoney.text = componentItem.SelectedComponent.Price.ToString();
            _selectedComponent.sprite = Resources.Load<Sprite>("Images/Upgrade/Components/" + componentItem.Name);
        }
        
        public void OnCloseBootonClick()
        {
            Hide();
    
            for(int i = 0; i < _gridComponentsObject.transform.childCount; i++)
            {
                Object.Destroy(_gridComponentsObject.transform.GetChild(i).gameObject);
            }

            foreach (var component in _components)
            {
                component.Clear();
            }
        }
    }
}