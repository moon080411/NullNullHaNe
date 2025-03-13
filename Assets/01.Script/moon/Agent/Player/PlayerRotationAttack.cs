using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationAttack : MonoBehaviour
{
    [SerializeField]Player player;
    private bool isAttack = false;
    private float attackTimer = 0;
    [SerializeField] LayerMask attackLayer;
    private void Update()
    {
        if (isAttack)
        {
            attackTimer -= Time.deltaTime;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, player.DataCompo.RotationRadius, attackLayer);
            if (colliders != null)
            {
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject.TryGetComponent(out IHittable hit))
                    {
                        hit.GetHit(Mathf.RoundToInt(player.weaponCompo.damage * 0.5f), false, player.weaponCompo.elementType, player);
                    }
                    else
                    {
                        Destroy(colliders[i].gameObject);
                    }
                }
            }
        }
    }
    public void AttackStart()
    {
        attackTimer = player.DataCompo.RotationTime;
        isAttack = true;
    }
    public void AttackEnd()
    {
        isAttack = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, player.DataCompo.RotationRadius);
        Gizmos.color = Color.white;
    }
}
