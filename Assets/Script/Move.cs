using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 //fait avec guillaume Secret, le 4.2 marche pour s'arreter mais nous ne parvenons pas à le faire tourner
public class Move : MonoBehaviour
{
    float speed = 4f;
    [SerializeField]
    Rigidbody2D body;
    [SerializeField]List<Vector3> points = new List<Vector3>();
    Vector3 target;
    Vector2 direction;
    Vector2 movement;
    int index = 0;
    float epsilon = 0.1f;
    float stopTimer = 0.0f;
    const float stopPeriod = 3.0f;
    bool movin = true;

	void Start ()
    {
        target = points[0];       
	}
	
	void Update ()
    {
        direction = (target - transform.position).normalized;
        movement = speed * direction;
        if (Vector3.Distance(transform.position, target) <= epsilon)
        {        
            if (index <= points.Count)
            {
                index++;
            }
            else
            {
                index = 0;
            }
            target = points[index];
            movin = false;
            StartCoroutine(stop());
         }

    }

    private void FixedUpdate()
    {
        if(movin)
        {
            body.velocity = movement;
        }
        if(!movin)
        {
            body.velocity = Vector3.zero;
        }     
    }
    IEnumerator stop()
    {
        yield return new WaitForSeconds(1);
        movin = true;
    }
}
