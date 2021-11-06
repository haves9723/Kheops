using UnityEngine;

public partial class Music : MonoBehaviour
{
    public static Music musique;

    private void Awake()
    {
        if (musique != null && musique != this )
        {
            Destroy(this.gameObject);
            return;
        }

        musique = this;
        DontDestroyOnLoad(this);
    }
}
