using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementAttack : MonoBehaviour
{
	public Animator AttackAnimator;
	public Vector3 AttackTarget;
	public float AttackSpeed;

	public void InitializeAttack(Vector3 origin, Vector3 target)
	{
		transform.position = origin + (new Vector3(0, 0, -1));
		AttackTarget = target + (new Vector3(0, 0, -1));
	}

    void Update()
    {
        Vector3 direction = AttackTarget - transform.position;

        if (direction.magnitude < AttackSpeed * Time.deltaTime)
        {
        	transform.position = AttackTarget;
        	AttackAnimator.SetBool("HitTarget", true);
            Destroy(this.gameObject, 1f);
        }
        else 
        {
        	transform.Translate(direction.normalized * AttackSpeed * Time.deltaTime, Space.World);
        }
    }
}
