using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerServices;

public class Enemy : MonoBehaviour
{

    private int movementSpeed;
    private Rigidbody2D rb2d;
    private void Start()
    {
        movementSpeed = Random.Range(5, 10);
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (PlayerService.instance.GetPlayerController() == null) return;

        if (PlayerService.instance.GetPlayerController().isFacingRight && PlayerService.instance.GetPlayerController().isMoving)
            rb2d.velocity = new Vector2(-movementSpeed * 1.5f, rb2d.velocity.y); //if player and enemy are coming to each other , the speed of enemy should be lil bit more

        else if (!PlayerService.instance.GetPlayerController().isFacingRight && PlayerService.instance.GetPlayerController().isMoving)
            rb2d.velocity = new Vector2(-movementSpeed * 0.2f, rb2d.velocity.y); //lil bit gradual increase in the speed of enemy if player keeps on moving Left to avoid Always Safe Loop of the Game

        else if (!PlayerService.instance.GetPlayerController().isMoving)
            rb2d.velocity = new Vector2(-movementSpeed, rb2d.velocity.y); //if player is not moving enemy speed as it is 

    }
    public void SetRandomMovementSpeed()
    {
        movementSpeed = Random.Range(5, 10);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && PlayerService.instance.GetPlayerController() != null)
        {
            RuntimeOjectSpawnner.instance.SpawnEnemy();
            PlayerService.instance.GetPlayerController().TakeDamage();
        }
    }
}
