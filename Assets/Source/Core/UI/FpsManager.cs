using TMPro;
using UnityEngine;

namespace Assets.Source.Core.UI
{
    public class FpsManager : MonoBehaviour
    {
        public float UpdateTimer = 0.2f;

        private TextMeshProUGUI _fpsCounter;
        private float _updateTime;

        private void Awake()
        {
            Application.targetFrameRate = 120;

            _fpsCounter = GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            _updateTime -= Time.deltaTime;

            if (_updateTime < 0)
            {
                _fpsCounter.text = "FPS: " + ((int)(1f / Time.smoothDeltaTime)).ToString();
                _updateTime = UpdateTimer;
            }
        }
    }
}
