using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.auxScene)
        {
            GameManager.instance.auxScene = false;
            Destroy(this.gameObject);
        }
    }
}
