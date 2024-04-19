using UnityEngine;

namespace Assets.Source.Core
{
    public class FpsManager : MonoBehaviour
    {
        private void Awake()
        {
            Application.targetFrameRate = 120;
        }

        private void FixedUpdate()
        {
            //1f / Time.deltaTime;
        }
    }
}
