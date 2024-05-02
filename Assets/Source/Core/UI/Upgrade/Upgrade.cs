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
        private TextMeshProUGUI _componentName;

        [SerializeField]
        private TextMeshProUGUI _setupNumber;

        [SerializeField]
        private TextMeshProUGUI _componentDescription;

        [SerializeField]
        private TextMeshProUGUI _profitMoney;

        [SerializeField]
        private TextMeshProUGUI _profitTime;

        [SerializeField]
        private TextMeshProUGUI _componentLvl;

        [SerializeField]
        private GameObject _componentItems;

        private List<GridComponentItem> _components = new List<GridComponentItem>();
        private GridLayoutGroup _gridComponents;

        void Start()
        {
            _components = new List<GridComponentItem>();

            _gridComponents = _componentItems.GetComponent<GridLayoutGroup>();

            SetSetup(Setup.Setups[0]);
        }


        public void SetSetup(Setup setup)
        {
            foreach (var component in setup.Components)
            {
                GridComponentItem componentItem = GridComponentItem.Items[component.Name];

                GameObject componentItemObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Ui/Upgrade/Grid/ComponentItem"), new Vector3(), Quaternion.identity, _gridComponents.transform);

                _components.Add(componentItem);
            }
        }
    }
}