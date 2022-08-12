using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    public GameObject[] Objects; 

    public Transform[] Points; 

    public float Ins_Time = 1;

void Start()

    {
        InvokeRepeating("Ins_Objs", Ins_Time, Ins_Time);
    }


    void Ins_Objs() 

    {

        int Random_Objects = Random.Range(0, Objects.Length);

        int Random_Points = Random.Range(0, Points.Length);

        Instantiate(Objects[Random_Objects], Points[Random_Points].transform.position, Points[Random_Points].transform.rotation);
    }
}
