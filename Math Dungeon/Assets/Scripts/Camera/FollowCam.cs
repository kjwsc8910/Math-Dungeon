using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{

    public float transitionDuration = 2.5f;

    public IEnumerator Transition(Vector3 _target)
    {
        float t = 0.0f;
        Vector3 startingPos = transform.position;
        while (t < 1.0f)
        {
            t += Time.deltaTime * (Time.timeScale / transitionDuration);


            transform.position = Vector3.Lerp(startingPos, _target, t);
            yield return 0;
        }

    }

    public void Move(Vector3 _target)
	{
        StartCoroutine(Transition(_target));
	}

}
