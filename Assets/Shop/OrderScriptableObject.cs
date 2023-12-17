using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(fileName = "Order", menuName = "ScriptableObjects/OrderScriptableObject", order = 1)]
    public class OrderScriptableObject : ScriptableObject
    {
        [SerializeReference, SelectImplementation(typeof(ISpendable))]
        public ISpendable [] ArraySpendable;
        [SerializeReference, SelectImplementation(typeof(IReward))]
        public IReward [] ArrayReward;
    }
}