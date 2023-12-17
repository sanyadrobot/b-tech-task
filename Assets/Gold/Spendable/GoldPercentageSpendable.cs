using System;
using Core;
using UnityEngine;

namespace Gold.Spendable
{
    [Serializable]
    public class GoldPercentageSpendable : ISpendable, IDisposable
    {
        [Range(0, 100)]
        [SerializeField] private int percentage;
        public Action<bool> OnBeSpendableChange { get; set; }
        
        public GoldPercentageSpendable()
        {
            GoldManager.Instance.OnGoldChange += OnGoldChange;
        }
        
        private void OnGoldChange(int obj)
        {
            OnBeSpendableChange?.Invoke(CanSpend());
        }
        
        public bool CanSpend()
        {
            return GoldManager.Instance.GetPercentageGoldAmount(percentage) > 0;
        }

        public void Spend()
        {
            if(CanSpend())
                GoldManager.Instance.DecreaseGoldAmount(GoldManager.Instance.GetPercentageGoldAmount(percentage));
        }

        public void Dispose()
        {
            GoldManager.Instance.OnGoldChange -= OnGoldChange;
        }
    }
}