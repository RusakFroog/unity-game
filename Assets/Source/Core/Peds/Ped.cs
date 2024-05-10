using System.Threading;
using UnityEngine;

namespace Assets.Source.Core.Peds
{
    public class Ped
    {
        public Vector3 Position 
        { 
            get => Position;
            private set
            {
                _gameObject.transform.position = value;
            } 
        }

        public readonly CapsuleCollider Collider;
        public readonly Rigidbody Rigidbody;

        private readonly GameObject _gameObject;
        private readonly Animator _animator;

        public Ped(Vector3 position)
        {
            _gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Peds/Ped"));

            if (position.y != -0.34f)
                position = new Vector3(position.x, -0.34f, position.z);

            Position = position;

            Collider = _gameObject.GetComponent<CapsuleCollider>();
            Rigidbody = _gameObject.GetComponent<Rigidbody>();

            _animator = _gameObject.GetComponent<Animator>();
        }

        public void GoToPosition(Vector3 position)
        {
            position.y = _gameObject.transform.position.y;

            _animator.SetBool("IsWalking", true);

            System.Action move = null;

            move = new System.Action(() =>
            {
                if (Vector3.Distance(_gameObject.transform.position, position) < 2f)
                {
                    _animator.SetBool("IsWalking", false);

                    GlobalUpdate.RemoveUpdate(move);

                    return;
                }

                Position = Vector3.MoveTowards(_gameObject.transform.position, position, Time.deltaTime * 2f);

                Rigidbody.rotation = Quaternion.Slerp(_gameObject.transform.rotation, Quaternion.LookRotation(position - _gameObject.transform.position), Time.deltaTime * 5f);
            });

            GlobalUpdate.AddUpdate(move);
        }
    }
}
