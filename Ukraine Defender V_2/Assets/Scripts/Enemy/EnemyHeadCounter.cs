using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHeadCounter : MonoBehaviour
{
    [SerializeField] int currentHeadCount;
    [SerializeField] Text headCountText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHeadCount();
    }

    public void UpdateHeadCount()
    {
        headCountText.text = currentHeadCount.ToString();
    }

    public void AddToCounter()
    {
        currentHeadCount++;
        UpdateHeadCount();
    }
}
