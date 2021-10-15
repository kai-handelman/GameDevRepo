using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parachuteRayCast : MonoBehaviour
{
    float parachuteEffectiveness = 8; 
    float deploymentHeight = 3f;

    private bool deployed;
    private Rigidbody2D rb;
    private Transform t;

    ContactFilter2D cf;
    [SerializeField] private LayerMask lm;
    Collider2D [] overLapper =  new Collider2D[5];
    
    private void Start()
    {
        t = transform; 
        deployed = false;
        rb = GetComponent<Rigidbody2D>();
        cf.SetLayerMask(lm);
    }


    void Update()
    {
        if (!deployed)
        {
            if (Physics2D.OverlapCircle(t.position, deploymentHeight, cf, overLapper) > 0)
            {
                if (overLapper[0].gameObject.CompareTag("environment"))
                {
                    DeployParachute();
                }
            }
        }
    }

    void DeployParachute()
    {
        deployed = true;
        rb.drag = parachuteEffectiveness;
    }

    private void OnDrawGizmos()
    {
        // Gizmos.DrawSphere(transform.position,deploymentHeight);
        if (!deployed)
        {
            Gizmos.color = Color.cyan;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawWireSphere(transform.position,deploymentHeight);
    }
}
