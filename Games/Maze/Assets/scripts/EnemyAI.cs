using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject player;
    public float mobDistanceRun = 4;
    public Transform[] patrolPoints;
    public int Index = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float Distance = Vector3.Distance(transform.position, player.transform.position);
        cheackDisOfPlayer(Distance);

        if (Vector3.Distance(transform.position, patrolPoints[Index].transform.position) < 1) {
            Index = (Index + 1) % patrolPoints.Length;
        }

        if (Distance < 1.5f) {
            SceneManager.LoadScene(2);
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    public void cheackDisOfPlayer(float Distance)
    {
        if (Distance < mobDistanceRun) {
            agent.SetDestination(player.transform.position);
        }

        else {
            agent.SetDestination(patrolPoints[Index].transform.position);
        }
    }
}