using Assets.Source.Core.Setups.Models.Enums;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Core.Setups.Models.Components
{
    public class Pc : Component
    {
        public override string Name => "Pc";

        protected override Dictionary<ComponentLevel, Vector3> _positions => new Dictionary<ComponentLevel, Vector3>
        {
            //{ ComponentLevel.Lvl2, new Vector3(-1.484f, 2.023f, -2.55f) }
        };

        public Pc(Setup setup, ComponentLevel level, Vector3 position = default, Quaternion rotation = default) : base(setup, level, position, rotation)
        {

        }
    }
}
