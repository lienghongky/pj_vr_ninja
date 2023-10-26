using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class SliceObject : MonoBehaviour
{


    public Transform startSlicePoint;
    public Transform endSlicePoint;
    public GameObject target;
    public LayerMask sliceableLayer;
    public VelocityEstimator velocityEstimator;
    public float cutForce = 2000;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void FixedUpdate() {
        bool hasHit = Physics.Linecast(startSlicePoint.position,endSlicePoint.position,out RaycastHit hit);
        if (hasHit && hit.transform.gameObject.GetComponent<Sliceable>()){
            GameObject target = hit.transform.gameObject;
            slice(target);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void slice(GameObject target){
        Material material = target.GetComponent<Material>();
        Sliceable sliceable = target.GetComponent<Sliceable>();
        if (sliceable != null)
        {
            material = sliceable.material;
            sliceable.splash();
        }
        Vector3 velocity = velocityEstimator.GetVelocityEstimate();
        Vector3 planeNormal = Vector3.Cross(endSlicePoint.position - startSlicePoint.position,velocity);
        planeNormal.Normalize();

        SlicedHull hull = target.Slice(endSlicePoint.position,planeNormal,material);

        if(hull != null){
            GameObject upperHull = hull.CreateUpperHull(target);
            GameObject lowerHull = hull.CreateLowerHull(target); 
            upperHull.transform.position = target.transform.position;
            lowerHull.transform.position = target.transform.position;

            Destroy(target);
            SetupSlicedComponent(upperHull);
            SetupSlicedComponent(lowerHull);
        }
    }

    public void SetupSlicedComponent(GameObject slicedObject){
        Rigidbody rb = slicedObject.AddComponent<Rigidbody>();
        MeshCollider collider = slicedObject.AddComponent<MeshCollider>();
        Sliceable sliceable = slicedObject.AddComponent<Sliceable>();
        collider.convex = true;
        int layer = LayerMask.NameToLayer("OBJ");
        slicedObject.layer = layer;
        //rb.AddExplosionForce(cutForce,slicedObject.transform.position,1);
        //rb.useGravity = true;
    }
}
