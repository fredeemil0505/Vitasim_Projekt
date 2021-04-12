public enum FingerType
{
    None,
    Thumb,
    Index,
    Middle,
    Ring,
    Pinky
}

public class Finger
{
    /*
     * This class focuses on smoothing out finger animations, by tracking target position and current position of fingers
     */

    public FingerType type = FingerType.None;
    public float current = 0.0f;
    public float target = 0.0f;

    public Finger(FingerType type)
    {
        this.type = type;
    }
}
