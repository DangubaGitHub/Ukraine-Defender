using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{

    [SerializeField] Animator knifeAnim;
    
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            knifeAnim.ResetTrigger("Slash");
            knifeAnim.SetTrigger("Slash");
        }
    }
}
