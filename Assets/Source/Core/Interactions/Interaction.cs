using System.Linq;
using Assets.Source.Core.Setups.Models;
using UnityEngine;

namespace Assets.Source.Core.Interactions
{
    public class Interaction : MonoBehaviour
    {
        [SerializeField]
        private GameObject _canvas;

        private void Awake()
        {
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
            _canvas.SetActive(false);
        }

        public void InterationWithPlayer(ushort setupId)
        {
            Setup interactedSetup = Setup.Setups.FirstOrDefault(x => x.Key == setupId).Value;
        }
    }
}