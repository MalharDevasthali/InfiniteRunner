using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerServices;

public class Coin : MonoBehaviour
{
    private int movementSpeed = 5;
    private Rigidbody2D rb2d;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        if (PlayerService.instance.GetPlayerController() == null)
        {
            rb2d.velocity = Vector2.zero;
            return;
        }

        if (PlayerService.instance.GetPlayerController().isFacingRight && PlayerService.instance.GetPlayerController().isMoving)
            rb2d.velocity = new Vector2(-movementSpeed, rb2d.velocity.y);
        else if (!PlayerService.instance.GetPlayerController().isFacingRight && PlayerService.instance.GetPlayerController().isMoving)
            rb2d.velocity = new Vector2(movementSpeed, rb2d.velocity.y);
        else if (!PlayerService.instance.GetPlayerController().isMoving)
            rb2d.velocity = Vector2.zero;

    }
}
