using System.Collections.Generic;
using Events;
using UnityEngine;

namespace Collectables
{
    public class CollectablesManager : MonoBehaviour
    {
        [SerializeField] private List<Collectable> allCollectables;
        private void OnEnable()
        {
            GameEvents.OnResetTimerEvent += SetCollectablesActive;
        }

        private void OnDisable()
        {
            GameEvents.OnResetTimerEvent -= SetCollectablesActive;
        }

        private void SetCollectablesActive()
        {
            foreach (var collectable in allCollectables)
            {
                collectable.gameObject.SetActive(true);
//                collectable.initialParticlePrefab.transform.localScale = Vector3.SmoothDamp(transform.localScale, new Vector3(3,3,3), ref collectable.velocity, collectable.smoothTime);
            }   
        }
    }
}