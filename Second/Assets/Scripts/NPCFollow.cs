using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollow : NPCController {
    [SerializeField] private Vector2 []patrolArea;
    [SerializeField] private Vector2 movePlayer;
    private RaycastHit2D rcH;
    private bool isPatrolling = true;
    private void Update()
    {
        if (!isPatrolling)
        {
            return;
        }
        foreach (Vector2 coords in patrolArea)
        {
            rcH = Physics2D.Raycast(pos + coords, pos + coords + new Vector2(0, 0.1f));
            if (rcH && rcH.transform.CompareTag("Player"))
            {
                Debug.Log("Caught");
            }
        }
    }

    private void catchPlayer()
    {
        // Move to Player
        Interact();
        // Push the Player back to allowed zone
        //:D
    }
}
