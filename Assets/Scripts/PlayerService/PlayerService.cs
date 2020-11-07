
using System;
using UnityEngine;
namespace PlayerServices
{
    public class PlayerService : MonoBehaviour
    {
        [SerializeField] private PlayerView playerView;
        [SerializeField] private float movementSpeed;
        [SerializeField] private float jumpForce;
        public static PlayerService instance;
        private PlayerController playerController;
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(this.gameObject);
            }
            else
            {
                instance = this;
            }
        }
        private PlayerModel playerModel;
        private void Start()
        {
            CreatePlayer();
        }
        public PlayerController GetPlayerController()
        {
            return playerController;
        }
        public void DestroyPlayer()
        {
            playerController = null;
            playerView = null;
        }

        private void CreatePlayer()
        {
            PlayerModel playerModel = new PlayerModel(movementSpeed, jumpForce);
            playerController = new PlayerController(playerView, playerModel);
        }
    }
}
