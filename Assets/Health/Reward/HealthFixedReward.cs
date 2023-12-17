using System;
using Core;
using UnityEngine;

namespace Health.Reward
{
    [Serializable]
    public class HealthFixedReward : IReward
    {
        [SerializeField] private int amount;

        public void GrantReward()
        {
            HealthManager.Instance.IncreaseHealthAmount(amount);
        }
    }
}