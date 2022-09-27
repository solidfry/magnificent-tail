using Events;
using ScriptableObjects;
using UnityEngine;

namespace Collectables
{
    public class Collectable : MonoBehaviour
    {
        [SerializeField] private GameObject pickUpParticlePrefab;
        [SerializeField] private GameObject initialParticlePrefab;
        [SerializeField] private float smoothTime = 0.4f;
        [SerializeField] private float destroyTime = 1f;
        [SerializeField] private AudioList listOfClips;
        
        Vector3 velocity = Vector3.zero;
        private void Awake()
        {
            pickUpParticlePrefab.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                pickUpParticlePrefab.SetActive(true);
                GameEvents.OnCollectablePickedUp?.Invoke();
                GameEvents.OnResetTimerEvent?.Invoke();
                
                if (listOfClips)
                {
                    var clipToPlay = listOfClips.GetRandomClip();
                    GameEvents.OnAudioCollisionEvent?.Invoke(clipToPlay);
                }

                initialParticlePrefab.transform.localScale = Vector3.SmoothDamp(transform.localScale, velocity, ref velocity, smoothTime);
                Destroy(this.gameObject, destroyTime);
            }
        }
    }
}