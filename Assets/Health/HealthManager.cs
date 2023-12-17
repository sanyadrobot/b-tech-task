using System;
using Core;
using Health.Mono;
using UnityEngine;

namespace Health
{
    public class HealthManager : SingletonBase<HealthManager>
    {
        public int Amount => _amount;
        
        private int _amount = 100;
        
        public event Action<int> OnHealthChange;

        public void IncreaseHealthAmount(int amountToAdd)
        {
            _amount += amountToAdd;
            OnHealthChange?.Invoke(_amount);
        }

        public int GetPercentageHealthAmount(float percentage)
        {
            percentage = percentage switch
            {
                > 100 => 100,
                < 0 => 0,
                _ => percentage
            };

            return Convert.ToInt32(Mathf.Round(percentage / 100f * _amount));
        }

        public void DecreaseHealthAmount(int amountToDecrease)
        {
            _amount -= amountToDecrease;
            OnHealthChange?.Invoke(_amount);
        }
        
        [RuntimeInitializeOnLoadMethod]
        private static void Init()
        {
            var prefab = Resources.Load<HealthView>("HealthPanel");
            UnityEngine.Object.Instantiate(prefab);
        }
    }
}