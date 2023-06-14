using UnityEngine;
using UnityEngine.AI;

namespace _Scripts
{
    public class EnemyAI : MonoBehaviour
    {

        [SerializeField] private Transform target;
        [SerializeField] private float chaseRange = 5f;
    

        private NavMeshAgent _navMeshAgent;

        private float _distanceToTarget = Mathf.Infinity;

        private bool _isProvoked = false;
    

        void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }


        void Update()
        {
            _distanceToTarget = Vector3.Distance(target.position, transform.position);

            if (_isProvoked)
            {
                EngageTarget();
            }
        
        
            else if (_distanceToTarget <= chaseRange)
            {
                _isProvoked = true;
            }
      
        }

        private void EngageTarget()
        {
            if (_distanceToTarget > _navMeshAgent.stoppingDistance)
            {
                
                ChaseTarget();
            }

            if (_distanceToTarget <= _navMeshAgent.stoppingDistance)
            {
                GetComponent<Animator>().SetBool("attack", true);
                AttackTarget();
            }
        }
    
        private void ChaseTarget()
        {
            GetComponent<Animator>().SetBool("attack", false);
            GetComponent<Animator>().SetTrigger("Move");
            _navMeshAgent.SetDestination(target.position);
        }

        private void AttackTarget()
        {
           
            Debug.Log("Attacking");
        }
    
        void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(1, 1, 0, 0.75F);
            Gizmos.DrawWireSphere(transform.position,chaseRange);
        }
    }
}
