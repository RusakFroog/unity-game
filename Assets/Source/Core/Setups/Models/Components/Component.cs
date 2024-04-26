using Assets.Source.Core.Setups.Models.Enums;
using UnityEngine;
using System.Collections.Generic;

namespace Assets.Source.Core.Setups.Models.Components
{
    public abstract class Component
    {
        public readonly Setup Setup;

        public abstract string Name { get; }

        protected abstract Dictionary<ComponentLevel, Vector3> _positions { get; }

        public GameObject GameObject { get; set; } = null;
        public ComponentLevel Level { get; set; } = ComponentLevel.Lvl1;
        public Vector3 Position { get; private set; } = new Vector3(0, 0, 0);
        public Quaternion Rotation { get; private set; } = new Quaternion(0, 0, 0, 0);

        public Component(Setup setup, ComponentLevel level, Vector3 position = default, Quaternion rotation = default)
        {
            Setup = setup;
            Level = level;
            Position = position;
            Rotation = rotation;
        }
        
        public void SetLocalPosition(Vector3 position)
        {
            Position = position;

            GameObject.transform.SetLocalPositionAndRotation(Position, Rotation);
        }

        public void SetPosition(Vector3 position)
        {
            Position = position;

            GameObject.transform.SetPositionAndRotation(Position, Rotation);
        }
        
        public void SetRotation(Quaternion rotation)
        {
            Rotation = rotation;

            Rotation.Normalize();

            GameObject.transform.rotation = Rotation;
        }

        public void Change(ComponentLevel level)
        {
            Level = level;

            Object.Destroy(GameObject);

            string pathPrefab = $"Prefabs/Props/Setups/{Level}/{Name}";

            Position = _positions.GetValueOrDefault(Level, Position);
            GameObject = Object.Instantiate(Resources.Load<GameObject>(pathPrefab), Position, Rotation, Setup.transform);

            SetLocalPosition(Position);
        }
    }
}
