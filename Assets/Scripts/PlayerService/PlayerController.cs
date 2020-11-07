
using UnityEngine;
namespace PlayerServices
{
    //Entire Business Logic Written in Controller as per standard MVC practice..
    public class PlayerController
    {
        private PlayerView playerView;
        private PlayerModel playerModel;
        public bool isFacingRight = true;
        public bool isMoving;
        private int heartLeft = 3;
        public PlayerController(PlayerView playerView, PlayerModel playerModel)
        {
            this.playerModel = playerModel;
            this.playerView = GameObject.Instantiate(playerView.gameObject).GetComponent<PlayerView>();
            this.playerView.SetController(this);
            this.playerModel.SetController(this);
        }
        public void Move(float movemnet)
        {
            if (movemnet < 0)
            {
                if (isFacingRight) flip();

                isMoving = true;
                BGScroller.instance.MoveBGForward();
                if (playerView.isGrounded)
                    playerView.GetAnimator().SetBool("isRunning", true);
            }
            else if (movemnet > 0)
            {

                if (!isFacingRight) flip();
                BGScroller.instance.MoveBGBackword();

                isMoving = true;
                if (playerView.isGrounded)
                    playerView.GetAnimator().SetBool("isRunning", true);
            }
            else
            {
                isMoving = false;
                playerView.GetRigidbody().velocity = new Vector2(0, playerView.GetRigidbody().velocity.y);
                playerView.GetAnimator().SetBool("isRunning", false);
            }
        }
        public bool IsPlayerStopped()
        {
            if (playerView.GetRigidbody().velocity.magnitude == 0)
                return true;
            return false;
        }
        public void flip()
        {
            float scaleX = playerView.transform.localScale.x;
            isFacingRight = !isFacingRight;
            scaleX *= -1;
            playerView.transform.localScale = new Vector2(scaleX, playerView.transform.localScale.y);
        }
        public void Jump(float jump)
        {

            if (jump > 0 && playerView.isGrounded)
            {
                playerView.isGrounded = false;
                playerView.GetRigidbody().velocity = new Vector2(playerView.GetRigidbody().velocity.x, playerModel.jumpForce);
                playerView.GetAnimator().SetTrigger("Jump");
            }
            else
                return;
        }
        public void TakeDamage()
        {
            if (heartLeft <= 1)
            {
                Dead();
                GamePlayUI.instance.RecudeHeart(0);
                return;
            }
            heartLeft--;
            GamePlayUI.instance.RecudeHeart(heartLeft);
        }
        private void Dead()
        {

            if (playerView.currentScore > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", playerView.currentScore);
            }
            //this Completes the Total Memory Allocation and Dealocation Cycle
            playerModel.DestroyModel();
            playerView.DestroView();
            PlayerService.instance.DestroyPlayer();
            playerModel = null;
            playerView = null;
        }

        public PlayerModel GetPlayerModel()
        {
            return playerModel;
        }
    }
}