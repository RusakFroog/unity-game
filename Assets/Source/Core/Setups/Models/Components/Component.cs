using Assets.Source.Core.Setups.Models.Enums;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace Assets.Source.Core.Setups.Models.Components
{
    public abstract class Component
    {
        public readonly Setup Setup;

        public abstract string Name { get; }
        
        protected virtual System.Action _onChange { get; }

        protected abstract Dictionary<ComponentLevel, Vector3> _positions { get; }

        private Dictionary<ComponentLevel, int> _incomeMoney = new Dictionary<ComponentLevel, int>()
        {
            { ComponentLevel.Lvl1, 10 },
            { ComponentLevel.Lvl2, 20 },
            { ComponentLevel.Lvl3, 30 },
            { ComponentLevel.Lvl4, 40 },
            { ComponentLevel.Lvl5, 50 },
            { ComponentLevel.Lvl6, 60 },
            { ComponentLevel.Lvl7, 70 },
            { ComponentLevel.Lvl8, 80 },
        };

        private Dictionary<ComponentLevel, float> _needTime = new Dictionary<ComponentLevel, float>()
        {
            { ComponentLevel.Lvl1, 7.0f },
            { ComponentLevel.Lvl2, 6.0f },
            { ComponentLevel.Lvl3, 5.0f },
            { ComponentLevel.Lvl4, 4.0f },
            { ComponentLevel.Lvl5, 3.0f },
            { ComponentLevel.Lvl6, 2.0f },
            { ComponentLevel.Lvl7, 1.0f },
            { ComponentLevel.Lvl8, 0.0f },
        };

        private Dictionary<ComponentLevel, int> _upgradePrices = new Dictionary<ComponentLevel, int>()
        {
            { ComponentLevel.Lvl1, 10 },
            { ComponentLevel.Lvl2, 20 },
            { ComponentLevel.Lvl3, 30 },
            { ComponentLevel.Lvl4, 40 },
            { ComponentLevel.Lvl5, 50 },
            { ComponentLevel.Lvl6, 60 },
            { ComponentLevel.Lvl7, 70 },
            { ComponentLevel.Lvl8, 80 },
        };
        
        public GameObject GameObject { get; set; } = null;
        public ComponentLevel Level { get; private set; } = ComponentLevel.Lvl1;
        public Vector3 Position { get; private set; } = new Vector3(0, 0, 0);
        public Quaternion Rotation { get; private set; } = new Quaternion(0, 0, 0, 0);
        public int ProfitMoney { get; private set; } = 0;
        public float ProfitTime { get; private set; } = 0f;
        public int UpgradePrice { get; private set; } = 0;

        public Component(Setup setup, ComponentLevel level, Vector3 position = default, Quaternion rotation = default)
        {
            Setup = setup;
            Level = level;
            Position = position;
            Rotation = rotation;

            ProfitMoney = _incomeMoney.GetValueOrDefault(Level, 0);
            ProfitTime = _needTime.GetValueOrDefault(Level, 0f);
            UpgradePrice = _upgradePrices.GetValueOrDefault(Level, 0);
        }
        
        public void SetLocalPosition(Vector3 position)
        {
            GameObject.transform.SetLocalPositionAndRotation(position, Rotation);
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

        public bool IsMaxLevel()
        {
            var values = (ComponentLevel[])System.Enum.GetValues(typeof(ComponentLevel));

            return Level >= values.Last();
        }

        public void Change(ComponentLevel level)
        {
            Level = level;

            Object.Destroy(GameObject);

            string pathPrefab = $"Prefabs/Props/Setups/{Level}/{Name}";
            
            ProfitMoney = _incomeMoney.GetValueOrDefault(Level, 0);
            ProfitTime = _needTime.GetValueOrDefault(Level, 0f);
            UpgradePrice = _upgradePrices.GetValueOrDefault(Level, 0);

            Position = _positions.GetValueOrDefault(Level, Position);
            GameObject = Object.Instantiate(Resources.Load<GameObject>(pathPrefab), Position, Rotation, Setup.transform);

            _onChange?.Invoke();

            SetLocalPosition(Position);
        }
    }
}
