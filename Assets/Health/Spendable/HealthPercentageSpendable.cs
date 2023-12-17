using System;
using Core;
using UnityEngine;

namespace Health.Spendable
{
    [Serializable]
    public class HealthPercentageSpendable : ISpendable, IDisposable
    {
        [Range(0, 100)]
        [SerializeField] private int percentage;
        public Action<bool> OnBeSpendableChange { get; set; }

        public HealthPercentageSpendable()
        {
            HealthManager.Instance.OnHealthChange += OnHealthChange;
        }

        private void OnHealthChange(int obj)
        {
            OnBeSpendableChange?.Invoke(CanSpend());
        }

        public bool CanSpend()
        {
            return HealthManager.Instance.GetPercentageHealthAmount(percentage) > 0;
        }

        public void Spend()
        {
            if(CanSpend())
                HealthManager.Instance.DecreaseHealthAmount(HealthManager.Instance.GetPercentageHealthAmount(percentage));
        }

        public void Dispose()
        {
            HealthManager.Instance.OnHealthChange -= OnHealthChange;
        }
    }
}