using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace YJ
{
    public class VideoInteraction : Interactable
    {
        public VideoPlayer videoPlayer;
        public GameObject interactionTextUI;
        public int videoIndex;

        // Index of the tutorial video to play (set this based on the specific action)
        private bool isPlaying = false;

        private TutorialVideoManager videoManager;

        private void Start()
        {
            // Find the TutorialVideoManager in the scene
            videoManager = FindObjectOfType<TutorialVideoManager>();
        }

        public override void Interact(PlayerManager playerManager)
        {
            base.Interact(playerManager);

            if (!isPlaying)
            {
                PlayVideo(playerManager, videoIndex);
            }
            else
            {
                PauseVideo();
            }
        }

        private void PlayVideo(PlayerManager playerManager, int index)
        {
            PlayerLocomotion playerLocomotion;

            playerLocomotion = playerManager.GetComponent<PlayerLocomotion>();

            playerLocomotion.rigidbody.velocity = Vector3.zero; // Stops the player from moving whilst interacting
            playerManager.videoInteractableGameObject.SetActive(true); // Enable the video player GameObject
            videoPlayer.gameObject.SetActive(true);

            // Reset the VideoPlayer to its initial state
            videoPlayer.Stop();
            videoPlayer.targetTexture.Release();
            videoPlayer.clip = null;

            // Get the tutorial video clip from the TutorialVideoManager
            VideoClip tutorialClip = videoManager.GetTutorialVideo(index);

            if (tutorialClip != null)
            {
                // Set the tutorial video clip
                videoPlayer.clip = tutorialClip;

                // Play the video
                videoPlayer.Play();

                // Hide the interaction text UI (including its frame) when playing the video
                interactionTextUI.SetActive(false);

                isPlaying = true; // Set the video playing flag
            }
            else
            {
                Debug.LogWarning("Tutorial video not found.");
            }
        }


        // Function to manually close the video and show the interaction text UI
        private void PauseVideo()
        {
            videoPlayer.Pause(); // Pause the video
            videoPlayer.gameObject.SetActive(false); // Disable the video player GameObject
            isPlaying = false; // Reset the interaction state

            // Show the interaction text UI (including its frame) again when pausing the video
            interactionTextUI.SetActive(true);

        }
    }
}
