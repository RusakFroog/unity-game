using Assets.Source.Core.Setups.Models.Enums;
using UnityEngine;
using System.Collections.Generic;

namespace Assets.Source.Core.Setups.Models.Components
{
    public abstract class Component
    {
        public readonly Setup Setup;

        public abstract string Name { get; }

        protected abstract Dictionary<ComponentLevel, Vector3> _positions { get; }
        protected Dictionary<ComponentLevel, int> _profitMoneyPerLevel = new Dictionary<ComponentLevel, int>()
        {
            {ComponentLevel.Lvl1, 0},
            {ComponentLevel.Lvl2, 10},
            {ComponentLevel.Lvl3, 20},
            {ComponentLevel.Lvl4, 30},
            {ComponentLevel.Lvl5, 40},
            {ComponentLevel.Lvl6, 50},
            {ComponentLevel.Lvl7, 60},
            {ComponentLevel.Lvl8, 70},
        };

        protected Dictionary<ComponentLevel, float> _profitTimePerLevel = new Dictionary<ComponentLevel, float>()
        {
            {ComponentLevel.Lvl1, 0.0f},
            {ComponentLevel.Lvl2, 1.0f},
            {ComponentLevel.Lvl3, 2.0f},
            {ComponentLevel.Lvl4, 3.0f},
            {ComponentLevel.Lvl5, 4.0f},
            {ComponentLevel.Lvl6, 5.0f},
            {ComponentLevel.Lvl7, 6.0f},
            {ComponentLevel.Lvl8, 7.0f},
        };
        protected Dictionary<ComponentLevel, int> _pricePerLevel = new Dictionary<ComponentLevel, int>()
        {
            {ComponentLevel.Lvl1, 0},
            {ComponentLevel.Lvl2, 10},
            {ComponentLevel.Lvl3, 20},
            {ComponentLevel.Lvl4, 30},
            {ComponentLevel.Lvl5, 40},
            {ComponentLevel.Lvl6, 50},
            {ComponentLevel.Lvl7, 60},
            {ComponentLevel.Lvl8, 70},
        };
        

        public GameObject GameObject { get; set; } = null;
        public ComponentLevel Level { get; set; } = ComponentLevel.Lvl1;
        public Vector3 Position { get; private set; } = new Vector3(0, 0, 0);
        public Quaternion Rotation { get; private set; } = new Quaternion(0, 0, 0, 0);
        public int ProfitMoney = 0;
        public float ProfitTime = 0.0f;
        public int Price = 0;

        public Component(Setup setup, ComponentLevel level, Vector3 position = default, Quaternion rotation = default)
        {
            Setup = setup;
            Level = level;
            Position = position;
            Rotation = rotation;
        }
        
        public void SetLocalPosition(Vector3 position)
        {
            Position = position;

            GameObject.transform.SetLocalPositionAndRotation(Position, Rotation);
        }

        public void SetPosition(Vector3 position)
        {
            Position = position;

            GameObject.transform.SetPositionAndRotation(Position, Rotation);
        }
        
        public void SetRotation(Quaternion rotation)
        {
            Rotation = rotation;

            Rotation.Normalize();

            GameObject.transform.rotation = Rotation;
        }

        public void Change(ComponentLevel level)
        {
            Level = level;

            Object.Destroy(GameObject);

            string pathPrefab = $"Prefabs/Props/Setups/{Level}/{Name}";
            
            ProfitMoney = _profitMoneyPerLevel.GetValueOrDefault(Level, 0);
            ProfitTime = _profitTimePerLevel.GetValueOrDefault(Level, 0.0f);
            Price = _pricePerLevel.GetValueOrDefault(Level, 0);

            Position = _positions.GetValueOrDefault(Level, Position);
            GameObject = Object.Instantiate(Resources.Load<GameObject>(pathPrefab), Position, Rotation, Setup.transform);

            SetLocalPosition(Position);
        }
    }
}
