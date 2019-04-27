using UnityEngine;

public class HandMB : MonoBehaviour
{
    private const float CardWidth = 1.8f;
    
    private void Update()
    {
        for (int i = 0; i < Deck.Hand.Count; i++)
        {
            Deck.Hand[i].SetTargetPos(CalculatePos(i));
        }
    }

    private Vector2 CalculatePos(int index)
    {
        Vector2 result = new Vector2(0, 1.5f);
        float centerIndex = Deck.Hand.Count / 2f;
        float relIndexPos = index - centerIndex;
        result.x = relIndexPos * CardWidth + 8;
        return result;
    }
}