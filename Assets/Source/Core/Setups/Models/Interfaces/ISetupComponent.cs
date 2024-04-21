using Assets.Source.Core.Setups.Models.Enums;
using UnityEngine;

namespace Assets.Source.Core.Setups.Models.Interfaces
{
    public interface ISetupComponent
    {
        public GameObject GameObject { get; set; }

        public ComponentLevel Level { get; set; }

        public void Change(ComponentLevel level);
    }
}
