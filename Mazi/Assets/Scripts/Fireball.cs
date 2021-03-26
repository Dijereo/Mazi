using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
	public Animator animator;
	public Vector3 target;
	public float speed;

    void Update()
    {
        Vector3 direction = target - transform.position;

        if (direction.magnitude < Time.deltaTime)
        {
        	transform.position = target;
        	animator.SetBool("HitTarget", true);
            Destroy(this.gameObject, 1f);
        }
        else 
        {
        	transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
    }
}
