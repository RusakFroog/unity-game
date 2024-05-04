using UnityEngine;

namespace Assets.Source.Core.UI
{
    public class InteractionDialogue : MonoBehaviour
    {
        private void Awake()
        {
            Hide();
        }
    
        public virtual void Show() => this.gameObject.SetActive(true);

        public virtual void Hide() => this.gameObject.SetActive(false);
    }
}