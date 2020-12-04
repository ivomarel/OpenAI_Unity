using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextBubble : MonoBehaviour
{
    public float delayToFade = 1;
    public float speed = 1;
    public float timeToFade = 1;

    public Vector3 offset = new Vector3(0, 3, 0);

    private float timer;

    private TextMeshPro textMesh;

    public void Init(GameObject owner, string text)
    {
        this.transform.position = owner.transform.position + offset;
        
        //Rotate to cam
        if (Camera.main)
        {
            Vector3 lookAtPos = Camera.main.transform.position;
            lookAtPos.y = this.transform.position.y;
            this.transform.LookAt(lookAtPos);
            this.transform.Rotate(0, 180, 0);
        }

        textMesh = GetComponent<TextMeshPro>();
        textMesh.text = text;
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        while (true)
        {
            this.transform.Translate(0, Time.deltaTime * speed, 0);
            timer += Time.deltaTime;
            if (timer >= delayToFade)
            {
                textMesh.alpha = (timeToFade - (timer - delayToFade)) / timeToFade;
                if (textMesh.alpha <= 0)
                {
                    Destroy(this.gameObject);
                }
            }

            yield return null;
        }

    }
}
