using System.Collections;
using Events;
using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        private InputManager inputManager;
        private Movement playerMovement;
        [SerializeField] private GameObject birthParticle;
        [SerializeField] private float birthParticleDestroyDelay = 3f;
        [SerializeField] private TrailManager trails = new();
        
        private void Awake()
        {
            inputManager = GetComponent<InputManager>();
            playerMovement = GetComponent<Movement>();
        }
        
        private void FixedUpdate()
        {
            playerMovement.HandleAllMovement();
        }
        
        private void OnEnable()
        {
            GameEvents.OnCollectablePickedUp += trails.HandleTrailLength;
            GameEvents.OnTimerZeroEvent += trails.ResetTrails;
            GameEvents.OnTimerZeroEvent += Die;
        }
        
        private void OnDisable()
        {
            GameEvents.OnCollectablePickedUp -= trails.HandleTrailLength;
            GameEvents.OnTimerZeroEvent -= trails.ResetTrails;
            GameEvents.OnTimerZeroEvent -= Die;
        }
        
        private void Die()
        {
            playerMovement.IsDead = true;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            StartCoroutine(Rebirth());
        }

        IEnumerator Rebirth()
        {
            if (birthParticle == null) yield break;
            
            yield return new WaitForSeconds(2);
            var particle = Instantiate(birthParticle, transform);
            Destroy(particle, birthParticleDestroyDelay);
            yield return new WaitForSeconds(1);
            playerMovement.IsDead = false;
            GameEvents.OnResetTimerEvent?.Invoke();
        }
    }
}