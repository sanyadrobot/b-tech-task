using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Health.Mono
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Button addButton;
        [SerializeField] private TMP_Text amountText;

        public void OnEnable()
        {
            HealthManager.Instance.OnHealthChange += SetHealthText;
            SetHealthText(HealthManager.Instance.Amount);
            addButton.onClick.AddListener((() => HealthManager.Instance.IncreaseHealthAmount(10)));
        }

        private void OnDisable()
        {
            HealthManager.Instance.OnHealthChange -= SetHealthText;
            addButton.onClick.RemoveAllListeners();
        }
        
        private void SetHealthText(int healthAmount)
        {
            amountText.text = $"Health: {healthAmount}";
        }
    }
}