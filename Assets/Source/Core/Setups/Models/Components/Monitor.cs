using Assets.Source.Core.Setups.Models.Enums;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Core.Setups.Models.Components
{
    public class Monitor : Component
    {
        public override string Name => "Monitor";

        protected override Dictionary<ComponentLevel, Vector3> _position => new Dictionary<ComponentLevel, Vector3>
        {
        };

        public Monitor(Setup setup, ComponentLevel level, Vector3 position = default, Quaternion rotation = default) : base(setup, level, position, rotation)
        {

        }
    }
}
