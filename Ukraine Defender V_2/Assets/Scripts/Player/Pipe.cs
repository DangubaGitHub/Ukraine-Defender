using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{

    [SerializeField] Animator pipeAnim;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            pipeAnim.ResetTrigger("Hit");
            pipeAnim.SetTrigger("Hit");
        }
    }
}
