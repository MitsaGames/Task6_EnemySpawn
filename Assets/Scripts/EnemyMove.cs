using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float _speed = 2.0f;
    [SerializeField] private float _moveThreshold = 0.1f;
    
    private Transform _target;

    private void Start()
    {
        _target = FindObjectOfType<EnemiesTarget>().transform;

        if (_target != null)
        {
            GetComponent<Animator>().SetBool("Run Forward", true);

            var directionToTarget = _target.position - transform.position;
            transform.rotation = Quaternion.LookRotation(directionToTarget);
        }
    }

    private void Update()
    {
        if(_target == null)
        {
            return;
        }

        var distanceToTarget = Vector3.Distance(_target.position, transform.position);

        if(distanceToTarget > _moveThreshold)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
