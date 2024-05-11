using System.Threading;
using UnityEngine;

namespace Assets.Source.Core.Peds
{
    public class Ped
    {
        public Vector3 Position 
        { 
            get => Position;
            set => GameObject.transform.position = value;
        }

        public readonly GameObject GameObject;
        public readonly CapsuleCollider Collider;
        public readonly Rigidbody Rigidbody;
        public readonly Animator Animator;

        public Ped(Vector3 position)
        {
            GameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Peds/Ped"));

            if (position.y != -0.34f)
                position = new Vector3(position.x, -0.34f, position.z);

            Position = position;

            Collider = GameObject.GetComponent<CapsuleCollider>();
            Rigidbody = GameObject.GetComponent<Rigidbody>();
            Animator = GameObject.GetComponent<Animator>();
        }

        public void GoToPosition(Vector3 position)
        {
            position.y = GameObject.transform.position.y;

            Animator.SetBool("IsWalking", true);

            System.Action move = null;

            move = new System.Action(() =>
            {
                if (Vector3.Distance(GameObject.transform.position, position) < 1f)
                {
                    Animator.SetBool("IsWalking", false);

                    GlobalUpdate.RemoveUpdate(move);

                    return;
                }

                Position = Vector3.MoveTowards(GameObject.transform.position, position, Time.deltaTime * 2f);

                Rigidbody.rotation = Quaternion.Slerp(GameObject.transform.rotation, Quaternion.LookRotation(position - GameObject.transform.position), Time.deltaTime * 5f);
            });

            GlobalUpdate.AddUpdate(move);
        }
    }
}
