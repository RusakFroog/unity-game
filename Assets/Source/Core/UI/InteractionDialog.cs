using TMPro;
using UnityEngine;

namespace Assets.Source.Core.UI
{
    public class InterationDialog : MonoBehaviour
    {
        

        private void Awake()
        {
            //Hide();
        }
    
        public void Show() 
        {
            this.gameObject.SetActive(true);
        }

        public void Hide()
        {
            this.gameObject.SetActive(false);
        }
    }
}