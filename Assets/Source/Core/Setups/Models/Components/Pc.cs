using Assets.Source.Core.Setups.Models.Enums;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Core.Setups.Models.Components
{
    public class Pc : Component
    {
        public override string Name => "Pc";

        protected override Dictionary<ComponentLevel, Vector3> _offsets => new Dictionary<ComponentLevel, Vector3>
        {

        };

        public Pc(Setup setup, ComponentLevel level, Vector3 position = default, Quaternion rotation = default) : base(setup, level, position, rotation)
        {

        }
    }
}
