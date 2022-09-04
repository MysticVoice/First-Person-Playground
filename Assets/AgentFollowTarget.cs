using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MysticVoice
{
    public class AgentFollowTarget : MonoBehaviour
    {
        NavMeshAgent agent;
        public Transform target;
        // Start is called before the first frame update
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void FixedUpdate()
        {
            agent.SetDestination(target.position);
        }
    }
}
