using System;
using Events;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private int collectionCount;
        [SerializeField] private TMP_Text collectionCountText;
        private void OnEnable()
        {
            GameEvents.OnCollectablePickedUp += HandlePickUp;
        }

        private void OnDisable()
        {
            GameEvents.OnCollectablePickedUp -= HandlePickUp;
        }
        
        private void HandlePickUp()
        {
            if (collectionCountText == null) return;
            
            collectionCount++;
            collectionCountText.text = collectionCount.ToString();
        }

    }
}