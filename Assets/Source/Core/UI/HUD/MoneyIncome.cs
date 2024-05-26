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
            string suffix;
            double dividedNum;

            if (Math.Abs(amount) >= 1_000_000_000)
            {
                dividedNum = amount / 1_000_000_000;
                suffix = "B";
            }
            else if (Math.Abs(amount) >= 1_000_000)
            {
                dividedNum = amount / 1_000_000;
                suffix = "M";
            }
            else if (Math.Abs(amount) >= 1_000)
            {
                dividedNum = amount / 1_000;
                suffix = "K";
            }
            else
            {
                return amount.ToString();
            }

            string formattedNum = dividedNum.ToString("0.##");

            return $"{formattedNum}{suffix}";
        }
    }
}
