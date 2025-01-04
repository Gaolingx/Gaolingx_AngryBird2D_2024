using System;
using UnityEngine;

namespace Core.GameLogic
{
    public class BlackBird : Bird
    {
        public float boomRadius = 2.5f;

        protected override void FullTimeSkill()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, boomRadius);
            foreach (Collider2D collider in colliders)
            {
                Destructiable des = collider.GetComponent<Destructiable>();
                if (des != null)
                {
                    des.TakeDamage(Int32.MaxValue);
                }
            }

            state = BirdState.WaitToDie;
            LoadNextBird();
        }
    }
}
