using System.Collections.Generic;
using UnityEngine;
using static ItemInteraction;

namespace DefaultNamespace
{
    public class WorldState : MonoBehaviour
    {
        private int _time = 0;
        
        private List<Item> _inventory = new List<Item>();

        private void Start()
        {
            GameEvents.Instance.OnItemFound += OnItemFound;
            GameEvents.Instance.OnDialogueOpened += StopTime;
            GameEvents.Instance.OnDialogueClosed += StartTime;
        }

        private void StartTime()
        {
            InvokeRepeating(nameof(Tick), 0f, 1f);
        }
        
        private void StopTime()
        {
            CancelInvoke(nameof(Tick));
        }

        private void OnItemFound(Item item)
        {
            _inventory.Add(item);
        }
        
        public void Tick()
        {
            _time++;
            if (_time == 60)
            {
                GameEvents.Instance.OnWorldReset();
                _time = 0;
            }
            GameEvents.Instance.OnTimeChanged(_time);
        }
    }
}