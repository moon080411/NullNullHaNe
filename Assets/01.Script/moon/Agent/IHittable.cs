using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHittable
{
    void GetHit(int damage, bool ignoreInvincibility, ElementType element, Agent AttackPlayer);
}
