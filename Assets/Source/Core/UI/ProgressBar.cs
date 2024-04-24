using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Core.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _textLabel;

        [SerializeField]
        private Slider _slider;

        public byte Progress { get; private set; } = 0;

        public void AddProgress(int amount)
        {
            Progress += (byte)Mathf.Clamp(amount, 0, 100);
        }

        private void UpdateProgressUI()
        {
            if (_textLabel != null)
            {
                _textLabel.text = $"Progress: {Progress}%";
            }
        }
    }
}
