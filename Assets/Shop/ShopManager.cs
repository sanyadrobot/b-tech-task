using System.Collections.Generic;
using System.Linq;
using Core;
using Shop.Mono;
using UnityEditor;
using UnityEngine;

namespace Shop
{
    public class ShopManager : SingletonBase<ShopManager>
    {
        private const string OrdersPath = "Data";
        private const string OrderPrefabPath = "Prefabs/OrderItem";
        private const string OrderListPrefabPath = "Prefabs/OrderList";

        public void BuyOrder(OrderScriptableObject orderScriptableObject)
        {
            if (orderScriptableObject.ArraySpendable.Any(spendable => !spendable.CanSpend()))
            {
                return;
            }
            
            foreach (var spendable in orderScriptableObject.ArraySpendable)
            {
                spendable.Spend();
            }

            foreach (var reward in orderScriptableObject.ArrayReward)
            {
                reward.GrantReward();
            }
        }
        
        [RuntimeInitializeOnLoadMethod]
        private static void Init()
        {
            var listPrefab = Resources.Load<OrderItemView>(OrderListPrefabPath);
            var orderListView = Object.Instantiate(listPrefab);
            
            var orderPrefab = Resources.Load<OrderItem>(OrderPrefabPath);
            
            foreach (var order in Resources.LoadAll<OrderScriptableObject>(OrdersPath))
            {
                var orderView = Object.Instantiate(orderPrefab, orderListView.content);
                orderView.Init(order);
            }
        }
    }
}