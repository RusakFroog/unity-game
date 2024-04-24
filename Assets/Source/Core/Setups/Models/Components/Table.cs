using Assets.Source.Core.Setups.Models.Enums;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Core.Setups.Models.Components
{
    public class Table : Component
    {
        public override string Name => "Table";

        protected override Dictionary<ComponentLevel, Vector3> _position => new Dictionary<ComponentLevel, Vector3>
        {

        };

        public Table(Setup setup, ComponentLevel level, Vector3 position = default, Quaternion rotation = default) : base(setup, level, position, rotation)
        {

        }
    }
}
