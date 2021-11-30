using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtGift : MonoBehaviour, IBox
{
    public Transform healgift;
    public float rotationSpeed = 180f;
    public int healt = 10;

    int IBox.getID()
    {
        return (int)BoxID.HEALT;
    }

    int IBox.OpenBox()
    {
        return healt;
    }

    // Update is called once per frame
    void Update()
    {
        healgift.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);   
    }
}
