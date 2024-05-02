using Assets.Source.Core.Setups.Models.Enums;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Core.Setups.Models.Components
{
    public class Chair : Component
    {
        public override string Name => "Chair";

        protected override Dictionary<ComponentLevel, Vector3> _positions => new Dictionary<ComponentLevel, Vector3>
        {

        };
        
        public Chair(Setup setup, ComponentLevel level, Vector3 position = default, Quaternion rotation = default) : base(setup, level, position, rotation)
        {


        }
    }
}
