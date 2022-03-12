using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    [SerializeField] Animator grenadeAnim;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            grenadeAnim.ResetTrigger("Throw");
            grenadeAnim.SetTrigger("Throw");
        }
    }
}
