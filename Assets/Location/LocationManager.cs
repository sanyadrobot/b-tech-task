using System;
using Core;
using Location.Mono;
using UnityEngine;
using Object = System.Object;

namespace Location
{
    public class LocationManager : SingletonBase<LocationManager>
    {
        public string CurrentLocation => _currentLocation;
        
        private string _currentLocation = "Default";
        
        public event Action<string> OnLocationChange;

        public void ResetLocation()
        {
            ChangeLocation("Default");
        }
        
        public void ChangeLocation(string newLocation)
        {
            if(string.Equals(newLocation, _currentLocation, StringComparison.Ordinal)) return;
            _currentLocation = newLocation;
            OnLocationChange?.Invoke(_currentLocation);
        }
        
        [RuntimeInitializeOnLoadMethod]
        private static void Init()
        {
            var prefab = Resources.Load<LocationView>("LocationPanel");
            UnityEngine.Object.Instantiate(prefab);
        }
    }
}