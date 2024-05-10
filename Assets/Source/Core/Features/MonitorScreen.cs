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
            "Textures/Gameplays/gameplay1",
            "Textures/Gameplays/gameplay2",
            "Textures/Gameplays/gameplay3",
            "Textures/Gameplays/gameplay4",
            "Textures/Gameplays/gameplay5",
            "Textures/Gameplays/gameplay6",
        };

        [SerializeField]
        private GameObject _screen = null;

        public void Awake()
        {
            if (_screen == null)
            {
                _screen = transform.Find("Screen").gameObject;
            }

            StartCoroutine(_startGamePlay());
        }

        private IEnumerator _startGamePlay()
        {
            for (int i = 0; i < _textures.Count; i++)
            {
                _changeTexture(_textures[i]);

                if (i == _textures.Count - 1)
                    i = 0;

                yield return new WaitForSeconds(5f);
            }
        }

        private void _changeTexture(string texturePath)
        {
            if (_screen == null)
            {
                Debug.LogError("_screen not found");

                throw new NullReferenceException("_screen not found");
            }

            _screen.GetComponent<MeshRenderer>().material.mainTexture = Resources.Load<Texture>(texturePath);
        }
    }
}
