using System;
using Core;
using UnityEngine;

namespace Location.Reward
{
    [Serializable]
    public class LocationChangeReward : IReward
    {
        [SerializeField] private string newLocation;
        
        public void GrantReward()
        {
            LocationManager.Instance.ChangeLocation(newLocation);
        }
    }
}