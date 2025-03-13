using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hooking : MonoBehaviour
{
    GrapplingHook grappling;
    public DistanceJoint2D joint2D;
    [SerializeField] Transform player;
    private void Start()
    {
        grappling = GameObject.Find("Player").GetComponent<GrapplingHook>();
        joint2D = GetComponent<DistanceJoint2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ring"))
        {

            joint2D.distance = Vector2.Distance(player.position, transform.position);
            joint2D.enabled = true;
            grappling.isAttach = true;
        }
        else if(!collision.CompareTag("Player"))
        {
            grappling.LineMax();
        }
    }
}
