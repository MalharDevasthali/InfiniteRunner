using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerServices
{
    //Unity Dependadnt and Visual things will be written in PlayerView and only View will be inherited from Mono, Keeping other Classes Lightweight
    public class PlayerView : MonoBehaviour
    {
        private Rigidbody2D rb2D;
        private PlayerController playerController;
        private Animator animator;
        public bool isGrounded;
        public int currentScore = 0;


        private void Start()
        {
            rb2D = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }
        private void Update()
        {
            playerController.Move(Input.GetAxis("Horizontal"));

            if (isGrounded)
                playerController.Jump(Input.GetAxis("Vertical"));

        }
        public void SetController(PlayerController playerController)
        {
            this.playerController = playerController;
        }
        public Rigidbody2D GetRigidbody()
        {
            return rb2D;
        }
        public Animator GetAnimator()
        {
            return animator;
        }
        public void DestroView()
        {
            rb2D = null;
            animator = null;
            playerController = null;
            Destroy(this.gameObject);
        }
        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Road"))
            {
                isGrounded = false;
                if (animator)
                    animator.SetBool("isGrounded", isGrounded);
            }
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Road"))
            {
                isGrounded = true;
                animator.SetBool("isGrounded", isGrounded);
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Coin"))
            {
                RuntimeOjectSpawnner.instance.SpawnCoin();
                currentScore++;
                GamePlayUI.instance.UpdateScore(currentScore);
            }
        }
    }
}