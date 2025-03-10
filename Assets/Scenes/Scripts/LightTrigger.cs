using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public Light dayLight;             
    public Light nightLight;
    [SerializeField] Material normalSkybox;
    [SerializeField] Material nightSkybox;

    public float transitionDuration = 2f;

    private bool transitioning = false;

    public AudioSource dayAudio;
    public AudioSource nightAudio;
    public float audioFadeDuration = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !transitioning)
        {
            StartCoroutine(SmoothTransition(dayLight, nightLight));

            if(nightSkybox != null) RenderSettings.skybox = nightSkybox;

            StartCoroutine(AudioCrossfade(dayAudio, nightAudio, audioFadeDuration));
        }
    }

    private System.Collections.IEnumerator SmoothTransition(Light fromLight, Light toLight)
    {
        transitioning = true;

        float timer = 0f;
        float fromInitial = fromLight.intensity;
        float toInitial = toLight.intensity;

        toLight.gameObject.SetActive(true); // Make sure it's active so we can see the transition

        while (timer < transitionDuration)
        {
            timer += Time.deltaTime;
            float t = timer / transitionDuration;

            fromLight.intensity = Mathf.Lerp(fromInitial, 0f, t);
            toLight.intensity = Mathf.Lerp(toInitial, 1f, t);

            yield return null;
        }

        fromLight.intensity = 0f;
        toLight.intensity = 1f;
        fromLight.gameObject.SetActive(false); // Optional: deactivate the day light

        transitioning = false;
    }

    private System.Collections.IEnumerator AudioCrossfade(AudioSource from, AudioSource to, float duration)
    {
        float timer = 0f;
        float fromStartVolume = from != null ? from.volume : 0f;
        float toStartVolume = to != null ? to.volume : 0f;

        if (to != null && !to.isPlaying) to.Play();

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;

            if (from != null) from.volume = Mathf.Lerp(fromStartVolume, 0f, t);
            if (to != null) to.volume = Mathf.Lerp(0f, toStartVolume, t);

            yield return null;
        }

        if (from != null)
        {
            from.Stop();
            from.volume = fromStartVolume; // Reset volume for next time
        }

        if (to != null) to.volume = toStartVolume;
    }

}
