using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NPCFollow : NPCController {
    [SerializeField] private Vector2 []patrolArea;
    [SerializeField] private Transform moveNPC;

    [SerializeField] private float moveSpeed;
    private RaycastHit2D rcH;
    private bool isPatrolling = true;
    private bool isSearching = false;
    private bool doneSearchimg = false;
    private AStarManager asm;

    private Vector2Int start;
    private Vector2Int end;
    private int dummy;
    private Vector2 [] path;
    private List<Spot> spo;

    void Start()
    {
        talkText = new String[] {"Sorry","Can't Let you pass","You'll have to go around"};
        moveNPC.parent = null;
        asm = GetComponent<AStarManager>();
        // talkTextLength = talkText.Length;
        // gm = GameObject.FindGameObjectWithTag("GameController");
        bConstruc();
    }
    

    public Vector2 [] catchPlayer(Vector2 target)
    {
        start = asm.GridPositionOfNPC;
        end = asm.GridPositionofTarget(target);
        
        
        spo = asm.getPath(start, end);
        path = new Vector2[spo.Count];
        path[0] = asm.celltoWorldConvert(spo[0]);
        for (int i = 0; i < spo.Count; i++)
        {
            path[i] = asm.celltoWorldConvert(spo[i]);
        }
        
        return path;
        // Interact();
        // Push the Player back to allowed zone
        //:D
    }
}
