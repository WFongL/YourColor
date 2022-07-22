using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool firstBottle = true;
    private GameObject[] firstBottleOfPaint;
    private Transform firstPositionBottle;
    private GameObject[] secondBottleOfPaint;
    private Transform secondPositionBottle;

    private Color firstColorToMix;
    private Color secondColorToMix;
    private bool secondBottleNotFull = true;
    private bool secondBottleIsEmpty = false;
    private Material newPaint;
    private Material newPaint2;

    public void CheckThePressedBottle(GameObject[] paintInABottle, Transform positionBottle)
    {
        if (firstBottle)
        {
            firstBottleOfPaint = paintInABottle;
            firstPositionBottle = positionBottle;
            firstBottle = false;
        }
        else
        {
            secondBottleOfPaint = paintInABottle;
            secondPositionBottle = positionBottle;

            if (firstBottleOfPaint != secondBottleOfPaint)
                TransferAndMixPaint();

            firstPositionBottle.Translate(Vector3.down);
            secondPositionBottle.Translate(Vector3.down);
            firstBottle = true;
        }
    }

    private void TransferAndMixPaint()
    {
        secondBottleNotFull = true;
        secondBottleIsEmpty = false;

        PrepareTheFirstBottle();

        PrepareTheSecondBottle();

        if (secondBottleIsEmpty)
        {
            newPaint.color = firstColorToMix;
            return;
        }

        if (secondBottleNotFull)
        {
            newPaint.color = AverageColor(firstColorToMix, secondColorToMix);
            newPaint2.color = AverageColor(firstColorToMix, secondColorToMix);
        }
    }

    private void PrepareTheFirstBottle()
    {
        if (secondBottleOfPaint[secondBottleOfPaint.Length - 1].activeSelf)
            return;

        for (int i = firstBottleOfPaint.Length - 1; i >= 0; i--)
        {
            if (firstBottleOfPaint[i].activeSelf)
            {
                firstColorToMix = firstBottleOfPaint[i].GetComponent<Renderer>().material.color;
                firstBottleOfPaint[i].SetActive(false);
                return;
            }
        }
    }

    private void PrepareTheSecondBottle()
    {
        if (secondBottleOfPaint[secondBottleOfPaint.Length - 1].activeSelf) // the bottle is full
        {
            secondBottleNotFull = false;
            return;
        }

        if (!secondBottleOfPaint[0].activeSelf) // the bottle is empty
        {
            newPaint = secondBottleOfPaint[0].GetComponent<Renderer>().material;
            secondBottleOfPaint[0].SetActive(true);
            secondBottleIsEmpty = true;
            return;
        }

        for (int i = secondBottleOfPaint.Length - 2; i >= 0; i--)
        {
            if (secondBottleOfPaint[i].activeSelf)
            {
                secondColorToMix = secondBottleOfPaint[i].GetComponent<Renderer>().material.color;

                secondBottleOfPaint[i + 1].SetActive(true);

                newPaint = secondBottleOfPaint[i].GetComponent<Renderer>().material;
                newPaint2 = secondBottleOfPaint[i+1].GetComponent<Renderer>().material;
                return;
            }
        }
    }

    private Color AverageColor(Color firstColor, Color secondColor)
    {
        float h1, s1, v1, h2, s2, v2;
        Color.RGBToHSV(firstColor, out h1, out s1, out v1);
        Color.RGBToHSV(secondColor, out h2, out s2, out v2);
        return Color.HSVToRGB((h1 + h2) / 2, (s1 + s2) / 2, (v1 + v2) / 2);
    }
}