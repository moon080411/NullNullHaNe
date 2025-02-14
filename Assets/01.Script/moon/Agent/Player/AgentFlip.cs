using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentFlip : MonoBehaviour
{
    public float FilpWay => transform.localScale.x;
    private void Awake()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
    public void Filp(float filpWay)
    {
        if(filpWay > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (filpWay < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
