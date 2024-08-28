using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum State { Idle, Running}

    [Header("Settings")]
    [SerializeField] float searchRadius;
    [SerializeField] float moveSpeed;
    State state;
    Transform targetRunner;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    public void ManageState()
    {
        switch(state)
        {
            case State.Idle:
                SearchForTarget();
                break;

            case State.Running:
                RunTowardsTarget();
                break;
        }
    }

    private void RunTowardsTarget()
    {
        if (targetRunner == null)
            return;

        Debug.Log("RunTowardsTarget çalıştı");

        transform.position = Vector3.MoveTowards(transform.position, targetRunner.position, 
            moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, targetRunner.position) < 0.1f)
        {
            Destroy(targetRunner.gameObject);
            Destroy(this.gameObject);
        }
    }

    private void SearchForTarget()
    {
        Collider[] detectedColliders = Physics.OverlapSphere(transform.position, searchRadius);

        for (int i = 0; i < detectedColliders.Length; i++)
        {
            if (detectedColliders[i].TryGetComponent(out Runner runner))
            {
                if (runner.IsTarget())
                    continue;

                runner.SetTarget();

                targetRunner = runner.transform;

                StartRunningTowardsTarget();
            }
        }
    }

    private void StartRunningTowardsTarget()
    {
        Debug.Log("StartRunningTowardsTarget çalıştı");
        state = State.Running;
        GetComponent<Animator>().SetBool("Run", true);
    }
}
