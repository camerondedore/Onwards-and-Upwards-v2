using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField]
    float projectileSpeed = 150;

    [SerializeField]
    GameObject target;
    Rigidbody targetRigid;



    void Start()
    {
        // get target
        targetRigid = target.GetComponent<Rigidbody>();
    }



    void Update()
    {
        // get Pt
        var targetDir = target.transform.position - transform.position;

        // get a, b, c
        var a = Mathf.Pow(targetDir.magnitude, 2) * Mathf.Pow(projectileSpeed, -2);
        var b = Mathf.Pow(targetRigid.velocity.magnitude, 2) * Mathf.Pow(projectileSpeed, -2);
        var c = 2 * targetDir.magnitude * targetRigid.velocity.magnitude * Vector3.Dot(targetDir.normalized, targetRigid.velocity.normalized) * Mathf.Pow(projectileSpeed, -2);

        // calc aimDir
        var aimDir = targetDir + targetRigid.velocity * (-c - Mathf.Sqrt(Mathf.Pow(c, 2) - 4 * (b - 1) * a)) / (2 * (b - 1));

        transform.forward = aimDir;

    }
}
