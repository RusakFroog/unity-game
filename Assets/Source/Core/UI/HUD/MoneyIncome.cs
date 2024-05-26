using System;
using TMPro;
using UnityEngine;

namespace Assets.Source.Core.UI.HUD
{
    public class MoneyIncome : MonoBehaviour
    {
        public static MoneyIncome Instance { get; private set; }
        
        [SerializeField]
        private TextMeshProUGUI _amount;
        
        private void Awake()
        {
            Instance = this;
        }

        public void SetAmount(int amount)
        {
            _amount.text = _getFormattedAmount(amount);
        }

        private string _getFormattedAmount(int amount)
        {
            // TODO: make forrmating like: 1,34 K | 22,3 KK
            return $"{amount}";
        }
    }
}
