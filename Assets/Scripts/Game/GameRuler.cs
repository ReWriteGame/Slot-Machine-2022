using UnityEngine;
using UnityEngine.Events;

public class GameRuler : MonoBehaviour
{
    [SerializeField] private Arrow arrow1;
    [SerializeField] private Arrow arrow2;
    [SerializeField] private Roulette roulette1;
    [SerializeField] private Roulette roulette2;
    [SerializeField] private ScoreCounter scoreCounter;
    private int endSlots = 0;


    public UnityEvent endSpinSlotsEvent;

    private void EndSlot()
    {
        endSlots++;
        if (endSlots == 2)
        {
            endSpinSlotsEvent?.Invoke();
            endSlots = 0;
        }
    }

    private void OnEnable()
    {
        roulette1.endRotateEvent?.AddListener(EndSlot);
        roulette2.endRotateEvent?.AddListener(EndSlot);
    }

    private void OnDisable()
    {
        roulette1.endRotateEvent.RemoveListener(EndSlot);
        roulette2.endRotateEvent.RemoveListener(EndSlot);
    }

    public void GetResults()
    {
        if(arrow1.collidedObject.Value > 0)
            scoreCounter.Add(arrow1.collidedObject.Value);
        else  scoreCounter.TakeAway(Mathf.Abs(arrow1.collidedObject.Value));
        
        if(arrow2.collidedObject.Value > 0)
            scoreCounter.Add(arrow2.collidedObject.Value);
        else  scoreCounter.TakeAway(Mathf.Abs(arrow2.collidedObject.Value));

    }

}
