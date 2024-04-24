using Assets.Source.Core.Setups.Models.Enums;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Core.Setups.Models.Components
{
    public class Chear : Component
    {
        public override string Name => "Chear";

        protected override Dictionary<ComponentLevel, Vector3> _positions => new Dictionary<ComponentLevel, Vector3>
        {

        };

        public Chear(Setup setup, ComponentLevel level, Vector3 position = default, Quaternion rotation = default) : base(setup, level, position, rotation)
        {


        }
    }
}
