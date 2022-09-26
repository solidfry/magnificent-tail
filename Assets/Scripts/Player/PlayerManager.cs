using System;
using System.Collections.Generic;
using Events;
using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private float tailLength;
        [SerializeField] private float tailIncrement = 0.1f;
        [SerializeField] private List<TrailRenderer> trails;
        private InputManager inputManager;
        private Movement playerMovement;

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
            GameEvents.OnCollectablePickedUp += HandleTrailLength;
        }    
        
        private void OnDisable()
        {
            GameEvents.OnCollectablePickedUp -= HandleTrailLength;
        }
        
        private void HandleTrailLength()
        {
            tailLength += tailIncrement;
            foreach (TrailRenderer trail in trails)
            {
                trail.time += tailLength;
            }
        }
    }
}