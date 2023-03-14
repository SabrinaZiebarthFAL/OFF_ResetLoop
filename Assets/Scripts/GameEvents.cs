using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameEvents : MonoBehaviour
    {
        public Action<int> OnTimeChanged;
        public static GameEvents Instance;
        public Action<ItemInteraction.Interaction> OnMouseOverItem;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
    }
}