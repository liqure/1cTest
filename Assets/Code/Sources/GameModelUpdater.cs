using UnityEngine;

namespace Modules.Test1C.UI
{
    /// <summary>
    /// Updates GameModel status
    /// </summary>
    public class GameModelUpdater: MonoBehaviour
    {
        private void Update()
        {
            GameModel.Update();
        }
    }
}