using UnityEngine;
using EchoesOfTheDeep.Narrative;

namespace EchoesOfTheDeep.Visual
{
    public class DemoDirector : MonoBehaviour
    {
        [SerializeField] private ChamberManager chamberManager;
        [SerializeField] private float demoDelay = 8f;
        private float timer;

        private void Update()
        {
            if (chamberManager == null) return;
            timer += Time.deltaTime;

            // Optional unattended demo flow for judges.
            if (timer >= demoDelay)
            {
                timer = 0f;
                if (chamberManager.Current != ChamberManager.Chamber.EchoChamber)
                    chamberManager.Next();
            }
        }
    }
}
