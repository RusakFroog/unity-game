using Assets.Source.Core.Setups.Models.Interfaces;
using Assets.Source.Core.Setups.Models.Enums;
using Assets.Source.Core.Utils;
using UnityEngine;
using System.Collections.Generic;

namespace Assets.Source.Core.Setups.Models.Components
{
    public abstract class Component : ISetupComponent
    {
        public readonly Setup Setup;

        public abstract Dictionary<ComponentLevel, Quaternion> Rotations { get; }
        public abstract Dictionary<ComponentLevel, Vector3> PositionOffsets { get; }
        public abstract string Name { get; }

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
        
        public void SetPosition(Vector3 position)
        {
            Position = position;

            Position.Normalize();

            GameObject.transform.position = Position;
        }
        
        public void SetRotation(Quaternion rotation)
        {
            Rotation = rotation;

            Rotation.Normalize();

            GameObject.transform.rotation = Rotation;
        }

        public virtual void Change(ComponentLevel level)
        {
            Level = level;

            Object.Destroy(GameObject);

            GameObject = PrefabManager.Generate(Name, $"Props/Setups/{Level}", Position + PositionOffsets[level], Rotations[level], Setup.transform);
        }
    }
}
