using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTimer : MonoBehaviour
{
    public float MaxTime;
    private Image img;
    private float currenntTime;
    public bool Tick;

    void Start()
    {
        img = GetComponent<Image>();
        currenntTime = MaxTime;
    }

    void Update()
    {
        Tick = false;
        currenntTime -= Time.deltaTime;
        if (currenntTime <= 0)
        {
            Tick = true;
            currenntTime = MaxTime;
            
        }
        img.fillAmount = currenntTime / MaxTime;
    }
}
