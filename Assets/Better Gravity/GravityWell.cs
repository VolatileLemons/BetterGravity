using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BetterGravity
{
    public class GravityWell : MonoBehaviour
    {
        public Planet planet;
        public Transform zero;
        public Vector3 vectorZero;
        public float attractorRadius;
        public Collider[] attractedObjects;
        public int spherecastLayerMask;
        public float gravityConst;

        // Start is called before the first frame update
        void Start()
        {
            zero = gameObject.transform;
            vectorZero = zero.position;
            planet = gameObject.GetComponentInParent<Planet>();
            attractorRadius = planet.gravityRadius;
            spherecastLayerMask = Physics.DefaultRaycastLayers;
            gravityConst = planet.gravityScale;
        }

        // Update is called once per frame
        void Update()
        {

        }

        void FixedUpdate()
        {
            vectorZero = zero.position;
            attractedObjects = Physics.OverlapSphere(vectorZero, attractorRadius, spherecastLayerMask, QueryTriggerInteraction.UseGlobal);
            foreach (var item in attractedObjects)
            {
                try
                {
                    item.attachedRigidbody.AddForce(((vectorZero) - item.gameObject.transform.position) * gravityConst, ForceMode.Force);
                }
                catch (System.Exception)
                {

                }
            }
        }
    }
}
