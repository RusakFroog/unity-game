using Assets.Source.Core.Features;
using Assets.Source.Core.Setups.Models.Enums;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Core.Setups.Models.Components
{
    public class Monitor : Component
    {
        public override string Name => "Monitor";

        protected override Dictionary<ComponentLevel, Vector3> _positions => new Dictionary<ComponentLevel, Vector3>
        {

        };

        public Monitor(Setup setup, ComponentLevel level, Vector3 position = default, Quaternion rotation = default) : base(setup, level, position, rotation)
        {

        }

        protected override Action _onChange => () =>
        {
            GameObject.GetComponent<MonitorScreen>().StartChanging();

            if (Setup.SeatingPed == null)
                GameObject.GetComponent<MonitorScreen>().StopChanging();
        };
    }
}
