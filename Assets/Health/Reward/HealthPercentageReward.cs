using System;
using Core;
using UnityEngine;

namespace Health.Reward
{
    [Serializable]
    public class HealthPercentageReward: IReward
    {
        [Range(0, 100)]
        [SerializeField] private int percentage;

        public void GrantReward()
        {
            HealthManager.Instance.IncreaseHealthAmount(HealthManager.Instance.GetPercentageHealthAmount(percentage));
        }
    }
}