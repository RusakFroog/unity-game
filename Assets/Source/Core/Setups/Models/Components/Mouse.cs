using Assets.Source.Core.Setups.Models.Enums;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Core.Setups.Models.Components
{
    public class Mouse : Component
    {
        public override string Name => "Mouse";

        protected override Dictionary<ComponentLevel, Vector3> _offsets => new Dictionary<ComponentLevel, Vector3>
        {
            { ComponentLevel.Lvl2, new Vector3(0, 0.025f, 0) },
            { ComponentLevel.Lvl3, new Vector3(0, 0.033f, 0) }
        };

        public Mouse(Setup setup, ComponentLevel level, Vector3 position = default, Quaternion rotation = default) : base(setup, level, position, rotation)
        {

        }
    }
}
