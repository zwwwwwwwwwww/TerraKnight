using UnityEngine;
using UnityEngine.Video;

namespace YJ
{
    public class TutorialVideoManager : MonoBehaviour
    {
        public VideoClip[] tutorialVideos;

        // This function can be used to get a tutorial video clip by index
        public VideoClip GetTutorialVideo(int videoIndex)
        {
            if (videoIndex >= 0 && videoIndex < tutorialVideos.Length)
            {
                return tutorialVideos[videoIndex];
            }
            else
            {
                Debug.LogWarning("Invalid video index.");
                return null;
            }
        }
    }
}