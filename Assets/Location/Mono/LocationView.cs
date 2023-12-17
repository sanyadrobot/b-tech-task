using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Location.Mono
{
    public class LocationView : MonoBehaviour
    {
        [SerializeField] private Button resetButton;
        [SerializeField] private TMP_Text locationText;

        public void OnEnable()
        {
            resetButton.onClick.AddListener(() => LocationManager.Instance.ResetLocation());
            LocationManager.Instance.OnLocationChange += SetLocationText;
            SetLocationText(LocationManager.Instance.CurrentLocation);
        }
        
        public void OnDisable()
        {
            LocationManager.Instance.OnLocationChange -= SetLocationText;
            resetButton.onClick.RemoveAllListeners();
        }

        private void SetLocationText(string location)
        {
            locationText.text = $"Location: {location}";
        }
    }
}