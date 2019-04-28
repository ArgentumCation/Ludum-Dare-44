using UnityEngine;

public class HandMB : MonoBehaviour
{
    private const float CardWidth = 2.2f;
    
    private void Update()
    {
        for (int i = 0; i < Deck.Hand.Count; i++)
        {
            Deck.Hand[i].SetTargetPos(new Vector2(CalculatePos(i), 1.5f));
        }
    }

    public static float CalculatePos(int index)
    {
        float centerIndex = (Deck.Hand.Count - 1) / 2f;
        float relIndexPos = index - centerIndex;
        return relIndexPos * CardWidth + 8;
    }
}