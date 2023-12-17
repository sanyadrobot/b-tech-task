using System;
using Core;
using UnityEngine;

namespace Gold.Spendable
{
    [Serializable]
    public class GoldFixedSpendable : ISpendable, IDisposable
    {
        [SerializeField] private int amount;
        public Action<bool> OnBeSpendableChange { get; set; }
        
        public GoldFixedSpendable()
        {
            GoldManager.Instance.OnGoldChange += OnGoldChange;
        }

        private void OnGoldChange(int obj)
        {
            OnBeSpendableChange?.Invoke(CanSpend());
        }

        public bool CanSpend()
        {
            return amount <= GoldManager.Instance.Amount;
        }

        public void Spend()
        {
            if(CanSpend())
                GoldManager.Instance.DecreaseGoldAmount(amount);
        }

        public void Dispose()
        {
            GoldManager.Instance.OnGoldChange -= OnGoldChange;
        }
    }
}