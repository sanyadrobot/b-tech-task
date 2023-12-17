using System;
using Core;
using Gold.Mono;
using UnityEngine;

namespace Gold
{
    public class GoldManager : SingletonBase<GoldManager>
    {
        public int Amount => _amount;
        public event Action<int> OnGoldChange;
        private int _amount = 100;
        
        public void IncreaseGoldAmount(int amountToAdd)
        {
            _amount += amountToAdd;
            OnGoldChange?.Invoke(_amount);
        }

        public int GetPercentageGoldAmount(float percentage)
        {
            percentage = percentage switch
            {
                > 100 => 100,
                < 0 => 0,
                _ => percentage
            };

            return Convert.ToInt32(Mathf.Round(percentage / 100f * _amount));
        }

        public void DecreaseGoldAmount(int amountToDecrease)
        {
            _amount -= amountToDecrease;
            OnGoldChange?.Invoke(_amount);
        }
        
        [RuntimeInitializeOnLoadMethod]
        private static void Init()
        {
            var prefab = Resources.Load<GoldView>("GoldPanel");
            UnityEngine.Object.Instantiate(prefab);
        }
    }
}