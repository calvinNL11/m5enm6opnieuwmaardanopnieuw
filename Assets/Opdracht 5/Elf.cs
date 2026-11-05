using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Elf : EnemyParent
{
    private float timer = 0f;

    void Update()
    {
        Walk();

        timer += Time.deltaTime;

        if (timer >= 3f)
        {
            StartCoroutine(ToggleVisibility());
            timer = 0f;
        }
    }

    IEnumerator ToggleVisibility()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = false;

            yield return new WaitForSeconds(0.5f);

            renderer.enabled = true;

        }
    }
}