using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop.Mono
{
    public class OrderItem : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private TMP_Text text;

        private OrderScriptableObject _orderScriptableObject; // Bad, better to add mvc

        public void Init(OrderScriptableObject order)
        {
            _orderScriptableObject = order;
            text.text = _orderScriptableObject.name;
            foreach (var spendable in _orderScriptableObject.ArraySpendable)
            {
                spendable.OnBeSpendableChange += OnBeSpendableChange;
            }
            button.onClick.AddListener(BuyItem);
            OnBeSpendableChange(false);
        }

        private void OnBeSpendableChange(bool obj)
        {
            if (_orderScriptableObject.ArraySpendable.Any(spendable => !spendable.CanSpend()))
            {
                button.interactable = false;
                return;
            }

            button.interactable = true;
        }

        private void OnDisable()
        {
            foreach (var spendable in _orderScriptableObject.ArraySpendable)
            {
                spendable.OnBeSpendableChange -= OnBeSpendableChange;
            }
            button.onClick.RemoveAllListeners();
        }

        private void BuyItem()
        {
            ShopManager.Instance.BuyOrder(_orderScriptableObject);
        }
    }
}