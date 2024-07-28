using UnityEngine;

public class Slot : MonoBehaviour
{
    public enum SlotState { Empty, Full }
    public SlotState currentState = SlotState.Empty;
}
