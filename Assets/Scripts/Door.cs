using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] float closeDistance;
    [SerializeField] float timeToClose;
    [SerializeField] AnimationCurve curve;
    bool closed;
    Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!closed)
            StartCoroutine(closeDoor());
    }

    void resetDoor()
    {
        transform.position = startPos;
        closed = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (!closed)
            {
                StartCoroutine(closeDoor());
            }
            else { resetDoor(); }
        }
    }
    IEnumerator closeDoor()
    {
        closed = true;

        Debug.Log("aa");
        float t = 0;
        while (t < 1)
        {
            transform.position = Vector3.Lerp(startPos, startPos - new Vector3(0, closeDistance, 0), curve.Evaluate(t));
            t += Time.deltaTime / timeToClose;

            yield return null;
        }
    }
}
