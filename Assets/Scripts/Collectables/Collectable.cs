using System;
using System.Collections;
using Events;
using ScriptableObjects;
using UnityEngine;

namespace Collectables
{
    public class Collectable : MonoBehaviour
    {
        [SerializeField] private GameObject pickUpParticlePrefab;
        [SerializeField] public GameObject initialParticlePrefab;
        [SerializeField] private Vector3 initialParticleTransform = new(6,6,6); 
        [SerializeField] public float smoothTime = 0.4f;
        [SerializeField] private float destroyTime = 1f;
        [SerializeField] private AudioList listOfClips;
        public Vector3 velocity = Vector3.zero;
        
        private void Awake()
        {
            pickUpParticlePrefab.SetActive(false);
        }

        private void OnEnable()
        {
            initialParticlePrefab.transform.localScale = initialParticleTransform;
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

                initialParticlePrefab.transform.localScale = Vector3.Lerp(transform.localScale, velocity, smoothTime);
                StartCoroutine(SetInactiveWithDelay(destroyTime));
            }
        }

        IEnumerator SetInactiveWithDelay(float delay = 1f)
        {
            yield return new WaitForSeconds(delay);
            gameObject.SetActive(false);
            pickUpParticlePrefab.SetActive(false);
        }
        
    }
}