using Assets.Source.Core.Features;
using Assets.Source.Core.Interactions;
using Assets.Source.Core.MoneySystem;
using Assets.Source.Core.Peds;
using Assets.Source.Core.Setups.Models.Components;
using Assets.Source.Core.Setups.Models.Enums;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Monitor = Assets.Source.Core.Setups.Models.Components.Monitor;

namespace Assets.Source.Core.Setups.Models
{
    public class Setup : MonoBehaviour
    {
        private static ushort _lastId = 0;

        public static readonly Dictionary<ushort, Setup> Setups = new Dictionary<ushort, Setup>();

        public readonly List<Components.Component> Components = new List<Components.Component>();
        
        public ushort Id { get; private set; }
        public Vector3 Position { get; private set; } = new Vector3(0, 0, 0);

        public Pc Pc { get; private set; }
        public Table Table { get; private set; }
        public Monitor Monitor { get; private set; }
        public Mouse Mouse { get; private set; }
        public Keyboard Keyboard { get; private set; }
        public Chair Chair { get; private set; }
        public Ped SeatingPed { get; private set; }
        public Interaction Interaction { get; set; }

        private void Awake()
        {
            _initComponents();

            Monitor.Change(ComponentLevel.Lvl8);
            Table.Change(ComponentLevel.Lvl2);
            Table.Change(ComponentLevel.Lvl8);
            Pc.Change(ComponentLevel.Lvl1);
            Mouse.Change(ComponentLevel.Lvl1);
            Keyboard.Change(ComponentLevel.Lvl1);
            Chair.Change(ComponentLevel.Lvl1);

            Setups.Add(_lastId, this);
            
            _lastId++;
        }

        private void _initComponents()
        {
            Position = transform.position;
            Id = _lastId;
            
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject gameObject = transform.GetChild(i).gameObject;
                string componentName = gameObject.name;

                Type componentType = Type.GetType("Assets.Source.Core.Setups.Models.Components." + componentName);

                if (componentType == null)
                    continue;

                object instance = Activator.CreateInstance(componentType, new object[] { this, ComponentLevel.Lvl1, gameObject.transform.localPosition, gameObject.transform.localRotation });

                Components.Component setupComponent = (Components.Component)instance;
                setupComponent.GameObject = gameObject;

                setupComponent.Change(ComponentLevel.Lvl1);

                _setProperty(componentName, instance);

                Components.Add(setupComponent);
            }
        }

        private void _setProperty(string componentName, object instance)
        {
            PropertyInfo property = GetType().GetProperty(componentName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            if (property != null && property.PropertyType.IsAssignableFrom(instance.GetType()))
                property.SetValue(this, instance);
        }

        public void TakeSeat(Ped ped)
        {
            if (SeatingPed != null)
                return;

            Monitor.GameObject.GetComponent<MonitorScreen>().StartChanging();

            SeatingPed = ped;

            ped.GameObject.SetActive(false);

            var transformChair = Chair.GameObject.transform;
            var offset = new Vector3(0, 0.1f, 0);
            
            if (Chair.Level == ComponentLevel.Lvl8)
            {
                offset = Vector3.zero;
                
                var armature = Chair.GameObject.transform.GetChild(0);

                // chair seat
                transformChair = armature.transform.GetChild(1);
            }
            
            GameObject pedObject = UnityEngine.Object.Instantiate(ped.GameObject, Chair.GameObject.transform.position + offset, new Quaternion(0, 0, 0, 0), transformChair);

            Chair.SetPed(pedObject);
            
            pedObject.transform.Rotate(Vector3.up, 90, Space.Self);
            pedObject.SetActive(true);
            pedObject.GetComponent<Animator>().SetBool("IsSeating", true);
        }

        public void TakeOffSeat()
        {
            if (SeatingPed == null)
                return;
            
            SeatingPed.GameObject.SetActive(true);
            SeatingPed = null;

            Destroy(Chair.SeatingPed);
            
            Chair.SetPed(null);
            
            Monitor.GameObject.GetComponent<MonitorScreen>().StopChanging();
        }
        
        public void ChangeComponent(Components.Component component, ComponentLevel level)
        {
            if (!MoneySystem.Wallet.Change(-component.UpgradePrice))
                return;
            
            component.Change(level);
        }
    }
}
