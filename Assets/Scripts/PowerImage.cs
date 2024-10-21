using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PowerImage : MonoBehaviour
{
    public Paddle paddle;

    private Image image;
    private Color transparentColor = new Color(0, 0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.color = transparentColor;
        paddle.PowerUpEvent += ShowVignete;
    }

    public void ShowVignete()
    {
        StartCoroutine("VigneteRoutine");

    }

    private IEnumerator VigneteRoutine()
    {
        image.color = Color.white;
        yield return new WaitForSeconds(0.7f);
        image.color = transparentColor;
    }

}
