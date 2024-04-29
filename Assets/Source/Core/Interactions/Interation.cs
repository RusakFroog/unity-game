using System.Linq;
using Assets.Source.Core.Setups.Models;

namespace Assets.Source.Core.Interactions
{
    public class Interation 
    {
        public void InterationWithPlayer(ushort setupId)
        {
           Setup interactedSetup = Setup.Setups.FirstOrDefault(x => x.Key == setupId).Value;
        
        }
    }
}