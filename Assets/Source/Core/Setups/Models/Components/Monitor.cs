using Assets.Source.Core.Setups.Models.Enums;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Core.Setups.Models.Components
{
    public class Monitor : Component
    {
        public override string Name => "Monitor";

        protected override Dictionary<ComponentLevel, Vector3> _positions => new Dictionary<ComponentLevel, Vector3>
        {
            { ComponentLevel.Lvl2, new Vector3(-3.311f, 2.023f, -2.049f) },
            { ComponentLevel.Lvl3, new Vector3(-3.311f, 2.008f, -1.743f) }
        };

        public Monitor(Setup setup, ComponentLevel level, Vector3 position = default, Quaternion rotation = default) : base(setup, level, position, rotation)
        {

        }
    }
}
