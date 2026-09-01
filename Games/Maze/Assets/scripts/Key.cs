using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Transform[] Positions;
    public Timer timer;
    public GameObject HiddenWall;

    void Start()
    {
        transform.position = Positions[Random.Range(0, Positions.Length - 1)].position + Vector3.up;
        timer.showMsg("Try to Find key to open Hidden Wall", 10);
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            timer.showMsg("Hidden Wall is open you can escape", 5);
            Destroy(gameObject);
            Destroy(HiddenWall);
        }
    }
}
