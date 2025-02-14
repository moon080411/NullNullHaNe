using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrapplingHook : MonoBehaviour
{
    [SerializeField] private LineRenderer line;
    [SerializeField] private Transform hook;
    [SerializeField] private float speed;
    [SerializeField] private float maxDistance;
    Vector2 mouseDir;

    private bool isHookActive = false;
    private bool isLineMax;
    public bool isAttach;
    private void Start()
    {
        line.positionCount = 2;
        line.endWidth = line.startWidth = 0.05f;
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hook.position);
        line.useWorldSpace = true;
        isAttach = false;
        hook.gameObject.SetActive(false);
    }
    private void Update()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hook.position);
        if(isHookActive && !isLineMax && !isAttach)
        {
            hook.Translate(mouseDir.normalized * Time.deltaTime * speed);
            if(Vector2.Distance(transform.position, hook.position) > maxDistance)
            {
                isLineMax = true;
            }
        }
        else if(isHookActive && isLineMax && !isAttach)
        {
            hook.position = Vector2.MoveTowards(hook.position, transform.position, Time.deltaTime * speed * 1.5f);
            if(Vector2.Distance(transform.position,hook.position) < 0.1f)
            {
                isHookActive = false;
                isLineMax = false;
                hook.gameObject.SetActive(false);
            }
        }
    }
    public void Hook()
    {
        if (!isHookActive)
        {
            Vector3 mousePosition = Mouse.current.position.ReadValue();
            mousePosition.z = Camera.main.nearClipPlane;
            hook.position = transform.position;
            mouseDir = Camera.main.ScreenToWorldPoint(mousePosition) - transform.position;
            isHookActive = true;
            hook.gameObject.SetActive(true);
        }
        else if (isAttach)
        {
            isAttach = false;
            isHookActive = false;
            isLineMax = false;
            hook.GetComponent<Hooking>().joint2D.enabled = false;
            hook.gameObject.SetActive(false);
        }
    }
}
