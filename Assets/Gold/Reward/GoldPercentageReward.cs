using System;
using Core;
using UnityEngine;

namespace Gold.Reward
{
    [Serializable]
    public class GoldPercentageReward: IReward
    {
        [Range(0, 100)]
        [SerializeField] private int percentage;

        public void GrantReward()
        {
            GoldManager.Instance.IncreaseGoldAmount(GoldManager.Instance.GetPercentageGoldAmount(percentage));
        }
    }
}