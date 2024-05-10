using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Core
{
    public class GlobalUpdate : MonoBehaviour
    {
        private static List<Action> _updates = new List<Action>();

        public static void AddUpdate(Action action)
        {
            if (_updates.Contains(action))
                return;

            _updates.Add(action);
        }

        public static void RemoveUpdate(Action action)
        {
            _updates.Remove(action);
        }

        private void Update()
        {
            for (int i = 0; i < _updates.Count; i++)
            {
                _updates[i].Invoke();
            }
        }
    }
}
