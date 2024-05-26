using Assets.Source.Core.Setups.Models.Enums;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Core.Setups.Models.Components
{
    public class Chair : Component
    {
        public override string Name => "Chair";

        public GameObject SeatingPed { get; private set; }
        
        protected override Dictionary<ComponentLevel, Vector3> _positions => new Dictionary<ComponentLevel, Vector3>
        {

        };
        
        public Chair(Setup setup, ComponentLevel level, Vector3 position = default, Quaternion rotation = default) : base(setup, level, position, rotation)
        {

        }

        public void SetPed([CanBeNull] GameObject ped)
        {
            SeatingPed = ped;
        }

        protected override Action _onChange => () =>
        {
            if (Setup.SeatingPed == null)
                return;
            
            var transformChair = GameObject.transform;
            var offset = new Vector3(0, 0.1f, 0);
            
            if (Level == ComponentLevel.Lvl8)
            {
                offset = Vector3.zero;
                
                var armature = GameObject.transform.GetChild(0);

                // chair seat
                transformChair = armature.transform.GetChild(1);
            }
            
            GameObject pedObject = UnityEngine.Object.Instantiate(Setup.SeatingPed.GameObject, GameObject.transform.position + offset, new Quaternion(0, 0, 0, 0), transformChair);

            SetPed(pedObject);

            pedObject.transform.Rotate(Vector3.up, 90, Space.Self);
            pedObject.SetActive(true);
            pedObject.GetComponent<Animator>().SetBool("IsSeating", true);
        };
    }
}
