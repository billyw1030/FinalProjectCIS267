using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerMan : MonoBehaviour
{ 
        public float walkSpeed = 2.0f;
        public float wallLeft = 0.0f;
        public float wallRight = 5.0f;
        float walkingDirection = 1.0f;
        Vector3 walkAmount;

        // Update is called once per frame
        void Update()
        {
            //walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;

            //if (walkingDirection > 0.0f && transform.position.x >= wallRight)
            //{
            //    walkingDirection = -1.0f;
            //}
            //else if (walkingDirection < 0.0f && transform.position.x <= wallLeft)
            //{
            //    walkingDirection = 1.0f;
            //    transform.Translate(walkAmount);
            //}

        }
}
