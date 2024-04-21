using Assets.Source.Core.Setups.Models.Enums;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Core.Setups.Models.Components
{
    public class Chear : Component
    {
        public override string Name => "Chear";

        public override Dictionary<ComponentLevel, Vector3> PositionOffsets => new Dictionary<ComponentLevel, Vector3>
        {
            { ComponentLevel.Lvl1, new Vector3(0, 0, 0) },
            { ComponentLevel.Lvl2, new Vector3(0, 0, 0) },
        };

        public override Dictionary<ComponentLevel, Quaternion> Rotations => new Dictionary<ComponentLevel, Quaternion>
        {
            { ComponentLevel.Lvl1, new Quaternion(0, 0, 0, 0) },
            { ComponentLevel.Lvl2, new Quaternion(0, 180, 0, 0) },
        };

        public Chear(Setup setup, ComponentLevel level, Vector3 position = default, Quaternion rotation = default) : base(setup, level, position, rotation)
        {


        }
    }
}
