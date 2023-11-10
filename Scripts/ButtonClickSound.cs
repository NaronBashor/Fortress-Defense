using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
        [SerializeField] private AudioSource buttonClick;

        public void OnButtonClick()
        {
                buttonClick.Play();
        }
}
