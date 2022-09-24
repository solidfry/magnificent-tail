using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        private InputManager _inputManager;
        private Movement _playerMovement;

        private void Awake()
        {
            _inputManager = GetComponent<InputManager>();
            _playerMovement = GetComponent<Movement>();
        }
        private void FixedUpdate()
        {
            _playerMovement.HandleAllMovement();
        }
    }
}