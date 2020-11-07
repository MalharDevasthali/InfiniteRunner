using UnityEngine;

namespace PlayerServices
{
    //Entire Data is Written in Model as per standard MVC practice..
    public class PlayerModel
    {
        public float movementSpeed { private set; get; }
        public float jumpForce { private set; get; }
        private PlayerController playerController;

        public PlayerModel(float movementSpeed, float jumpForce)
        {
            this.movementSpeed = movementSpeed;
            this.jumpForce = jumpForce;
        }
        public void SetController(PlayerController playerController)
        {
            this.playerController = playerController;
        }
        public void DestroyModel()
        {
            playerController = null;
        }
    }
}