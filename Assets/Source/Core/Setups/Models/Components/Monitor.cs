using Assets.Source.Core.Setups.Models.Enums;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Core.Setups.Models.Components
{
    public class Monitor : Component
    {
        public override string Name => "Monitor";

        protected override Dictionary<ComponentLevel, Vector3> _offsets => new Dictionary<ComponentLevel, Vector3>
        {
            { ComponentLevel.Lvl2, new Vector3(0, 0.048f, -0.492f) },
            { ComponentLevel.Lvl3, new Vector3(0, 0.043f, -0.29f) },
        };

        public Monitor(Setup setup, ComponentLevel level, Vector3 position = default, Quaternion rotation = default) : base(setup, level, position, rotation)
        {

        }
    }
}
