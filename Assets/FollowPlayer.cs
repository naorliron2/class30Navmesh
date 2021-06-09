using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float speed;

    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = player.transform.InverseTransformPoint(transform.position);
        Debug.Log(offset);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position , player.transform.position + offset, speed * Time.deltaTime) ;
    }
}
