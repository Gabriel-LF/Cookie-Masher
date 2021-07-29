using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public int xRotate;
    public int yRotate;
    public int zRotate;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(xRotate * Time.deltaTime, yRotate * Time.deltaTime, zRotate * Time.deltaTime));
    }
}
