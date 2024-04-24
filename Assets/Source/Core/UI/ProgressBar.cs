using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Core.UI
{
    public class ProgressBar : MonoBehaviour
    {
        public static Dictionary<string, ProgressBar> ProgressBars = new Dictionary<string, ProgressBar>();

        [SerializeField]
        private TextMeshProUGUI _textLabel;

        [SerializeField]
        private Slider _slider;

        [SerializeField]
        private float _needProgress = 100;

        public string Name;

        public float NeedProgress
        {
            get => _needProgress;
            set => _needProgress = value;
        }

        public int Progress { get; private set; } = 0;

        public float ProgressFill { get; private set; } = 0;

        public void Awake()
        {
            ProgressBars.Add(Name, this);
        }

        private void Update()
        {
            _setProgress();
            _updateProgressUI();
        }

        public void AddProgress(int amount)
        {
            if (amount <= 0 || amount > NeedProgress || amount + Progress > NeedProgress)
                return;

            Progress += amount;
            ProgressFill += Mathf.Floor(amount / NeedProgress * 100f);

            _updateProgressUI();
            _setProgress();
        }

        private void _setProgress()
        {
            _slider.value = ProgressFill;
        }

        private void _updateProgressUI()
        {
            _textLabel.text = $"{Progress}/{NeedProgress}";
        }
    }
}
