using Assets.Source.Core.Setups.Models.Components;
using Assets.Source.Core.Setups.Models.Enums;
using Assets.Source.Core.Setups.Models.Interfaces;
using System;
using System.Reflection;
using UnityEngine;

namespace Assets.Source.Core.Setups.Models
{
    public class Setup : MonoBehaviour
    {
        public Pc Pc { get; private set; }
        public Table Table { get; private set; }
        public Monitor Monitor { get; private set; }
        public Mouse Mouse { get; private set; }
        public Keyboard Keyboard { get; private set; }
        public Chear Chear { get; private set; }

        private void Awake()
        {
            //Pc = new Pc(ComponentLevel.Lvl1);
            
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject gameOject = transform.GetChild(i).gameObject;
                string nameComponent = transform.GetChild(i).name;

                Type typeOfComponent = Type.GetType("Assets.Source.Core.Setups.Models.Components." + nameComponent);
                object instanceObject = Activator.CreateInstance(typeOfComponent, new object[] { this, ComponentLevel.Lvl1, gameOject.transform.position, gameOject.transform.rotation });
                
                Components.Component setupComponent = (Components.Component)instanceObject;
                setupComponent.GameObject = gameOject;

                if (typeOfComponent == typeof(Pc))
                    Pc = (Pc)setupComponent;
                else if (typeOfComponent == typeof(Table))
                    Table = (Table)setupComponent;
                else if (typeOfComponent == typeof(Monitor))
                    Monitor = (Monitor)setupComponent;
                else if (typeOfComponent == typeof(Mouse))
                    Mouse = (Mouse)setupComponent;
                else if (typeOfComponent == typeof(Keyboard))
                    Keyboard = (Keyboard)setupComponent;
                else if (typeOfComponent == typeof(Chear))
                    Chear = (Chear)setupComponent;
            }

            Pc.Change(ComponentLevel.Lvl2);
            //Pc.SetPosition(Pc.Position + new Vector3(0, 0.05f, 0));

            Mouse.Change(ComponentLevel.Lvl2);
            Keyboard.Change(ComponentLevel.Lvl2);
            Monitor.Change(ComponentLevel.Lvl2);
            Table.Change(ComponentLevel.Lvl2);
            Chear.Change(ComponentLevel.Lvl2);
        }

        public void ChangeComponent(ISetupComponent component)
        {

        }
    }
}
