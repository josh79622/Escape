using UnityEngine;
using System.Collections;

public class LightningFlash : MonoBehaviour
{
    public Light lightningLight;
    public int flashCount = 5;
    public float minDuration = 0.1f;
    public float maxDuration = 0.5f;
    public float minIntensity = 3f;
    public float maxIntensity = 4f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(FlashLightning());
        }
    }

    IEnumerator FlashLightning()
    {
        for (int i = 0; i < flashCount; i++)
        {
            float intensity = Random.Range(minIntensity, maxIntensity);
            float duration = Random.Range(minDuration, maxDuration);

            lightningLight.intensity = intensity;
            yield return new WaitForSeconds(duration);

            if (i < flashCount - 1)
            {
                lightningLight.intensity = 0f;
                yield return new WaitForSeconds(0.1f);
            }
        }

        // 最後一次閃電後，漸漸變暗
        float fadeDuration = 1f;
        float startIntensity = lightningLight.intensity;
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            lightningLight.intensity = Mathf.Lerp(startIntensity, 0f, elapsed / fadeDuration);
            yield return null;
        }

        lightningLight.intensity = 0f; // 保險設為 0
    }
}