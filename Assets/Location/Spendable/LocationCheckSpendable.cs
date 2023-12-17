using System;
using Core;
using UnityEngine;

namespace Location.Spendable
{
    [Serializable]
    public class LocationCheckSpendable : ISpendable, IDisposable
    {
        [SerializeField] private string currentLocation;
        public Action<bool> OnBeSpendableChange { get; set; }

        public LocationCheckSpendable()
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
            
        }

        public void Dispose()
        {
            LocationManager.Instance.OnLocationChange -= OnLocationChange;
        }
    }
}