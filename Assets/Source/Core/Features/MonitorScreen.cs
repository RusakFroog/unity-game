using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Core.Features
{
    /// <summary>
    /// Put this component on the Monitor prefabs
    /// _screen - isn't required
    /// </summary>
    public class MonitorScreen : MonoBehaviour
    {
        private static List<string> _textures = new List<string>()
        {
            "Textures/Gameplay/Materials/gameplay1",
            "Textures/Gameplay/Materials/gameplay2",
            "Textures/Gameplay/Materials/gameplay3",
        };

        [SerializeField]
        private GameObject _screen = null;

        public void Awake()
        {
            if (_screen == null)
            {
                _screen = transform.Find("Screen").gameObject;
            }
        }

        public void StartChanging()
        {
            StartCoroutine(_startGamePlay());
        }

        public void StopChanging()
        {
            StopCoroutine(_startGamePlay());

            _changeTexture("Textures/Gameplay/Materials/defaultScreen");
        }

        private IEnumerator _startGamePlay()
        {
            for (int i = 0; i < _textures.Count; i++)
            {
                _changeTexture(_textures[i]);

                if (i == _textures.Count - 1)
                    i = -1;

                yield return new WaitForSeconds(5f);
            }
        }

        private void _changeTexture(string texturePath)
        {
            if (_screen == null)
                throw new NullReferenceException("_screen not found");

            _screen.GetComponent<MeshRenderer>().material = Resources.Load<Material>(texturePath);
        }
    }
}
