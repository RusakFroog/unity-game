using Assets.Source.Core.Setups.Models.Components;
using Assets.Source.Core.Setups.Models.Enums;
using Assets.Source.Core.Setups.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Assets.Source.Core.Setups.Models
{
    public class Setup : MonoBehaviour
    {
        public static readonly List<Setup> Setups = new List<Setup>();

        public Pc Pc { get; private set; }
        public Table Table { get; private set; }
        public Monitor Monitor { get; private set; }
        public Mouse Mouse { get; private set; }
        public Keyboard Keyboard { get; private set; }
        public Chear Chear { get; private set; }

        private void Awake()
        {
            _initComponents();

            Monitor.Change(ComponentLevel.Lvl3);
            Pc.Change(ComponentLevel.Lvl2);
            Mouse.Change(ComponentLevel.Lvl3);
            Keyboard.Change(ComponentLevel.Lvl2);
            Table.Change(ComponentLevel.Lvl2);
            Chear.Change(ComponentLevel.Lvl3);

            Setups.Add(this);
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

                object instance = Activator.CreateInstance(componentType, new object[] { this, ComponentLevel.Lvl1, gameObject.transform.position, gameObject.transform.rotation });

                Components.Component setupComponent = (Components.Component)instance;
                setupComponent.GameObject = gameObject;

                _setProperty(componentName, instance);
            }
        }

        private void _setProperty(string componentName, object instance)
        {
            PropertyInfo property = GetType().GetProperty(componentName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            if (property != null && property.PropertyType.IsAssignableFrom(instance.GetType()))
                property.SetValue(this, instance);
        }

        public void ChangeComponent(ISetupComponent component)
        {

        }
    }
}
