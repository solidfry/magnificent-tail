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
            GameEvents.OnTimerZeroEvent += ResetCollectionCount;
        }
        
        private void OnDisable()
        {
            GameEvents.OnCollectablePickedUp -= HandlePickUp;
            GameEvents.OnTimerZeroEvent -= ResetCollectionCount;
        }
        
        private void HandlePickUp()
        {
            if (collectionCountText == null) return;
            
            collectionCount++;
            SetCollectionText();
        }
        
        private void ResetCollectionCount()
        {
            collectionCount = 0;
            SetCollectionText();
        }

        private void SetCollectionText() => collectionCountText.text = collectionCount.ToString();
        

    }
}