using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gold.Mono
{
    public class GoldView : MonoBehaviour
    {
        [SerializeField] private Button addButton;
        [SerializeField] private TMP_Text amountText;

        public void OnEnable()
        {
            GoldManager.Instance.OnGoldChange += SetGoldText;
            SetGoldText(GoldManager.Instance.Amount);
            addButton.onClick.AddListener((() => GoldManager.Instance.IncreaseGoldAmount(10)));
        }
        
        private void OnDisable()
        {
            GoldManager.Instance.OnGoldChange -= SetGoldText;
            addButton.onClick.RemoveAllListeners();
        }

        private void SetGoldText(int goldAmount)
        {
            amountText.text = $"Gold: {goldAmount}";
        }
    }
}
