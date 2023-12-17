using System;
using Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace Location.Spendable
{
    [Serializable]
    public class LocationMoveSpendable : ISpendable, IDisposable
    {
        [SerializeField] private string currentLocation;
        [SerializeField] private string newLocation;
        public Action<bool> OnBeSpendableChange { get; set; }
        
        public LocationMoveSpendable()
        {
            LocationManager.Instance.OnLocationChange += OnLocationChange;
        }

        private void OnLocationChange(string obj)
        {
            OnBeSpendableChange?.Invoke(CanSpend());
        }


        public bool CanSpend()
        {
            return LocationManager.Instance.CurrentLocation == currentLocation;
        }

        public void Spend()
        {
            if (CanSpend())
                LocationManager.Instance.ChangeLocation(newLocation);
        }

        public void Dispose()
        {
            LocationManager.Instance.OnLocationChange -= OnLocationChange;
        }
    }
}