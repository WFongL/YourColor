using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelTwo : MonoBehaviour
{
    [SerializeField] private GameObject[] firstBottleOfPaint;
    [SerializeField] private GameObject[] secondBottleOfPaint;
    [SerializeField] private GameObject[] thirdBottleOfPaint;
    [SerializeField] private GameObject[] fourthBottleOfPaint;
    [SerializeField] private GameObject[] fifthBottleOfPaint;

    [SerializeField] private Button win;
    [SerializeField] private Button task;

    public void ExcludeTask()
    {
        task.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        bool firstCheckBottle = true;
        bool secondCheckBottle = true;
        bool thirdCheckBottle = true;
        bool fourthCheckBottle = true;
        bool fifthCheckBottle = true;

        for (int i = 0; i < 2; i++)
        {
            firstCheckBottle &= firstBottleOfPaint[i].activeSelf &&
                firstBottleOfPaint[i].GetComponent<Renderer>().material.color == new Color(0, 1, 0);

            secondCheckBottle &= secondBottleOfPaint[i].activeSelf &&
                secondBottleOfPaint[i].GetComponent<Renderer>().material.color == new Color(0, 1, 0);

            thirdCheckBottle &= thirdBottleOfPaint[i].activeSelf &&
                thirdBottleOfPaint[i].GetComponent<Renderer>().material.color == new Color(0, 1, 0);

            fourthCheckBottle &= fourthBottleOfPaint[i].activeSelf &&
                fourthBottleOfPaint[i].GetComponent<Renderer>().material.color == new Color(0, 1, 0);

            fifthCheckBottle &= fifthBottleOfPaint[i].activeSelf &&
                fifthBottleOfPaint[i].GetComponent<Renderer>().material.color == new Color(0, 1, 0);
        }

        if (firstCheckBottle && secondCheckBottle || firstCheckBottle && thirdCheckBottle
            || secondCheckBottle && thirdCheckBottle || firstCheckBottle && fifthCheckBottle)
        {
            win.gameObject.SetActive(true);
        }
    }
}
