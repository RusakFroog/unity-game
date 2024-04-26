using Assets.Source.Core.Setups.Models.Components;
using Assets.Source.Core.Setups.Models.Enums;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Assets.Source.Core.Setups.Models
{
    public class Setup : MonoBehaviour
    {
        public static readonly Dictionary<ushort, Setup> Setups = new Dictionary<ushort, Setup>();

        private static ushort _lastId = 0;

        public Vector3 Position { get; private set; } =  new Vector3(0, 0, 0);
        public Pc Pc { get; private set; }
        public Table Table { get; private set; }
        public Monitor Monitor { get; private set; }
        public Mouse Mouse { get; private set; }
        public Keyboard Keyboard { get; private set; }
        public Chair Chair { get; private set; }

        private void Awake()
        {
            Position = transform.position;

            _initComponents();

            Monitor.Change(ComponentLevel.Lvl2);
            Pc.Change(ComponentLevel.Lvl3);
            Mouse.Change(ComponentLevel.Lvl3);
            Keyboard.Change(ComponentLevel.Lvl1);
            Table.Change(ComponentLevel.Lvl2);
            Chair.Change(ComponentLevel.Lvl3);

            Setups.Add(_lastId, this);

            _lastId++;
        }

        private void _initComponents()
        {
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
            }
        }

        private void _setProperty(string componentName, object instance)
        {
            PropertyInfo property = GetType().GetProperty(componentName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            if (property != null && property.PropertyType.IsAssignableFrom(instance.GetType()))
                property.SetValue(this, instance);
        }

        public void ChangeComponent(Components.Component component, ComponentLevel level)
        {
            component.Change(level);
        }
    }
}
