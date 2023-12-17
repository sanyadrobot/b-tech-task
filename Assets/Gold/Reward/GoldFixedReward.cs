using System;
using Core;
using UnityEngine;

namespace Gold.Reward
{
    [Serializable]
    public class GoldFixedReward: IReward
    {
        [SerializeField] private int amount;
        public void GrantReward()
        {
            GoldManager.Instance.IncreaseGoldAmount(amount);
        }
    }
}