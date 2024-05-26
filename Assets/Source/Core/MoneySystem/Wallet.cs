using Assets.Source.Core.UI.HUD;

namespace Assets.Source.Core.MoneySystem
{
    public static class Wallet
    {
        public static int Amount { get; private set; } = 0;
        
        public static bool Change(int amount)
        {
            if (amount < 0 && Amount < amount)
                return false;
            
            Amount += amount;
            
            MoneyIncome.Instance.SetAmount(Amount);

            return true;
        }
    }
}
