using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public float moveSpeed;

    public bool IsMoving
    {
        get;
        set;
    }

    private void Awake()
    {
    }

    public IEnumerator Move(Vector2 moveVec, Action OnMoveOver = null)
    {
        var targetPos = transform.position;
        targetPos.x += moveVec.x;
        targetPos.y += moveVec.y;

        if (!IsWalkable(targetPos))
        {
            yield break;
        }

        IsMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        IsMoving = false;

        OnMoveOver.Invoke();
    }

    public void HandleUpdate()
    {
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.2f, GameLayers.i.SolidLayer) != null)
        {
            return false;
        }
        return true;

    }
}
