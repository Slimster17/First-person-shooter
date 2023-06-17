using UnityEngine;
using UnityEngine.AI;

namespace _Scripts
{
    public class EnemyAI : MonoBehaviour
    {

      
        [SerializeField] private float chaseRange = 5f;
        
        [SerializeField] private float turnSpeed = 5f;

        [SerializeField] private AudioClip chaseSound;
    

        private NavMeshAgent _navMeshAgent;

        private float _distanceToTarget = Mathf.Infinity;

        private bool _isProvoked = false;
        
        Transform target;
        
        private EnemyHealth health;
        private CapsuleCollider capsuleCollider;

        private AudioSource audioSource;

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = chaseSound;
            _navMeshAgent = GetComponent<NavMeshAgent>();
            health = GetComponent<EnemyHealth>();
            capsuleCollider = GetComponent<CapsuleCollider>();
            target = FindObjectOfType<PlayerHealth>().transform;
        }


        void Update()
        {
            if (health.IsDead())
            {
                this.enabled = false;
                _navMeshAgent.enabled = false;
                capsuleCollider.enabled = false;
            }
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

        public void OnDamageTaken()
        {
            _isProvoked = true;
        }

        private void EngageTarget()
        {
            FaceTarget();
            if (_distanceToTarget > _navMeshAgent.stoppingDistance)
            {
                audioSource.Play();
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
            if (enabled)
            {
              
                GetComponent<Animator>().SetBool("attack", false);
                GetComponent<Animator>().SetTrigger("Move");
                _navMeshAgent.SetDestination(target.position);
            }
           
        }

        private void AttackTarget()
        {
           
            Debug.Log("Attacking");
        }

        private void FaceTarget()
        {
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
        }
    
        void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(1, 1, 0, 0.75F);
            Gizmos.DrawWireSphere(transform.position,chaseRange);
        }
    }
}
