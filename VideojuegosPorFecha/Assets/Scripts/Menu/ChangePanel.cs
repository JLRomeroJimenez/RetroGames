using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePanel : MonoBehaviour
{
    [SerializeField] private List<GameObject> panelList;

    private int previousPosition;
    private int position;

    public void ButtonChangeSelection(int newIndex)
    {
        //1 o -1 si es derecha o izq.
        panelList[previousPosition].SetActive(false);

        if (newIndex==1)
        {
            position++;

            if (position>=panelList.Count)
            {
                position = 0;

            }
            
        }
        else
        {
            position--;

            if (position<0)
            {
                position = panelList.Count - 1;

            }
        }

        panelList[previousPosition].SetActive(false);
        panelList[position].SetActive(true);
        previousPosition = position;
    }
}
