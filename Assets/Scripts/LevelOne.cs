using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelOne : MonoBehaviour
{
    [SerializeField] private GameObject[] firstBottleOfPaint;
    [SerializeField] private GameObject[] secondBottleOfPaint;
    [SerializeField] private GameObject[] thirdBottleOfPaint;

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

        for (int i = 0; i < 2; i++)
        {
            firstCheckBottle &= firstBottleOfPaint[i].activeSelf &&
                firstBottleOfPaint[i].GetComponent<Renderer>().material.color == new Color(1, 1, 0);

            secondCheckBottle &= secondBottleOfPaint[i].activeSelf &&
                secondBottleOfPaint[i].GetComponent<Renderer>().material.color == new Color(1, 1, 0);

            thirdCheckBottle &= thirdBottleOfPaint[i].activeSelf &&
                thirdBottleOfPaint[i].GetComponent<Renderer>().material.color == new Color(1, 1, 0);
        }

        if(firstCheckBottle && secondCheckBottle || firstCheckBottle && thirdCheckBottle 
            || secondCheckBottle && thirdCheckBottle)
        {
            win.gameObject.SetActive(true);
        }
    }
}
