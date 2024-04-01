﻿using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.PlayerComponents
{
    internal class PlayerMovement : MonoBehaviour
    {
        private PlayerAnimator _animator;
        private NavMeshAgent _navMeshAgent;

        private float _attackMoveSpeed;
        private float _rotationSpeed = 2;
        private bool _isAttacking;
        private float _moveSpeed = 6;

        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<PlayerAnimator>();
        }

        public void Move(Vector2 direction)
        {
            Vector3 movementDIrection = new Vector3(direction.x, 0, direction.y);
            Vector3 movePosition = transform.position + movementDIrection;

            _navMeshAgent.speed = _isAttacking ? _attackMoveSpeed : _moveSpeed;
            _navMeshAgent.SetDestination(movePosition);

            _animator.SetAnimatorSpeed(movementDIrection, _moveSpeed);
        }

        public void StopMove()
        {
            _isAttacking = true;
        }

        public void StartMove()
        {
            _isAttacking = false;
        }

        public void RotateTowards(Transform target, Vector3 offset)
        {
            Vector3 directionToTarget = target.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget, Vector3.up);
            offset = new Vector3(transform.rotation.x, offset.y, transform.rotation.z);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation * Quaternion.Euler(offset), Time.fixedDeltaTime / _rotationSpeed);
        }
    }
}