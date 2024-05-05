using Assets.Source.Core.Setups.Models;
using Assets.Source.Core.UI.Upgrade;
using UnityEngine;

namespace Assets.Source.Core.Interactions
{
    public class Interaction : MonoBehaviour
    {
        [SerializeField]
        private GameObject _canvas;

        [SerializeField]
        private Upgrade _upgradeUI;

        private Setup _setup;

        private void Awake()
        {
            _setup = GetComponent<Setup>();

            _canvas.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                _canvas.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                _canvas.SetActive(false);
            }
        }

        public void OnClickUpgrade()
        {
            _upgradeUI.SetSetup(_setup);

            _upgradeUI.Show();

            //_canvas.SetActive(false);
        }
    }
}