using System;
using Core;
using UnityEngine;

namespace Health.Spendable
{
    [Serializable]
    public class HealthFixedSpendable : ISpendable, IDisposable
    {
        [SerializeField] private int amount;
        public Action<bool> OnBeSpendableChange { get; set; }
        
        public HealthFixedSpendable()
        {
            HealthManager.Instance.OnHealthChange += OnHealthChange;
        }

        private void OnHealthChange(int obj)
        {
            OnBeSpendableChange?.Invoke(CanSpend());
        }

        public bool CanSpend()
        {
            return amount <= HealthManager.Instance.Amount;
        }

        public void Spend()
        {
            if(CanSpend())
                HealthManager.Instance.DecreaseHealthAmount(amount);
        }

        public void Dispose()
        {
            HealthManager.Instance.OnHealthChange -= OnHealthChange;
        }
    }
}