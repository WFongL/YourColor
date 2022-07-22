using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool firstBottle = true;
    private GameObject[] firstBottleOfPaint;
    private Transform firstPositionBottle;
    [SerializeField] private Text victory;


    public void CheckPassBottle(GameObject[] paintInABottle, Transform positionBottle)
    {
        if (firstBottle)
        {
            firstBottleOfPaint = paintInABottle;
            firstPositionBottle = positionBottle;
            firstBottle = false;
            return;
        }

        if (firstBottleOfPaint != paintInABottle)
            PassToMixColors(firstBottleOfPaint, paintInABottle);

        firstPositionBottle.Translate(Vector3.down);
        positionBottle.Translate(Vector3.down);
        firstBottle = true;
    }

    private void PassToMixColors(GameObject[] passBottleOfPaint, GameObject[] acceptBottleOfPaint)
    {
        for (int i = passBottleOfPaint.Length - 1; i >= 0; i--)
        {
            if (passBottleOfPaint[i].activeSelf)
            {
                Color firstPaint = passBottleOfPaint[i].GetComponent<Renderer>().material.color;

                for (int k = acceptBottleOfPaint.Length - 2; k >= 0; k--)
                {
                    if (acceptBottleOfPaint[k].activeSelf && !acceptBottleOfPaint[acceptBottleOfPaint.Length - 1].activeSelf || !acceptBottleOfPaint[0].activeSelf)
                    {
                        if (!acceptBottleOfPaint[0].activeSelf)
                        {
                            acceptBottleOfPaint[0].GetComponent<Renderer>().material.color = firstPaint;
                            passBottleOfPaint[i].SetActive(false);
                            acceptBottleOfPaint[0].SetActive(true);
                            return;
                        }
                        Material secondPaint = acceptBottleOfPaint[k].GetComponent<Renderer>().material;
                        Material newPaint = acceptBottleOfPaint[k+1].GetComponent<Renderer>().material;


                        newPaint.color = AverageColor(firstPaint, secondPaint.color);
                        secondPaint.color = newPaint.color;
                        passBottleOfPaint[i].SetActive(false);
                        acceptBottleOfPaint[k+1].SetActive(true);
                        return;
                    }
                }
            }
        }
    }

    private Color AverageColor(Color firstColor, Color secondColor)
    {
        float h1, s1, v1, h2, s2, v2;
        Color.RGBToHSV(firstColor, out h1, out s1, out v1);
        Color.RGBToHSV(secondColor, out h2, out s2, out v2);
        if (s1 < 0.01f) h1 = h2;
        if (Mathf.Abs(h1 - h2) > .5) h1 += 1.0f;
        return Color.HSVToRGB((h1 + h2) / 2, (s1 + s2) / 2, (v1 + v2) / 2);
    }
}