using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour
{
    bool runOnce = false;
    float scaleTime = 0.0f;
    void Update()
    {
        scaleTime += Time.deltaTime;

        Light KonoYagami = GetComponent<Light>();
    
            KonoYagami.color = Color.Lerp(new Color(1, 1, 1, 1), new Color(1, 0, 0, 1), scaleTime * 0.5f);
      
    }
}
