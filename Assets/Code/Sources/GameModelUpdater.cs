using UnityEngine;

namespace Modules.Test1C.UI
{
    public class GameModelUpdater: MonoBehaviour
    {
        private void Update()
        {
            GameModel.Update();
        }
    }
}