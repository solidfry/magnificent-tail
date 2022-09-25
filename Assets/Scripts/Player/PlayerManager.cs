using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
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
    }
}