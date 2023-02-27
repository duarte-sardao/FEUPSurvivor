using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAnim : MonoBehaviour
{

    float scale = 0;
    bool peaked = false;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!peaked)
            scale += Time.deltaTime*2;
        else
            scale -= Time.deltaTime / 3;
        if (scale > 2)
            peaked = true;
        if (peaked && scale < 0)
            Destroy(this.gameObject);
        this.transform.localScale = new Vector3(scale, scale, 0);
        this.transform.rotation = Quaternion.AngleAxis(scale*90, new Vector3(0, 0, 1));
    }
}
