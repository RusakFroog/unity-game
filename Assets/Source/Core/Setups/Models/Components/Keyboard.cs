using Assets.Source.Core.Setups.Models.Enums;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Core.Setups.Models.Components
{
    public class Keyboard : Component
    {
        public override string Name => "Keyboard";

        protected override Dictionary<ComponentLevel, Vector3> _offsets => new Dictionary<ComponentLevel, Vector3>
        {

        };

        public Keyboard(Setup setup, ComponentLevel level, Vector3 position = default, Quaternion rotation = default) : base(setup, level, position, rotation)
        {

        }
    }
}
