using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BarthaSzabolcs.Tutorial_SpriteFlash
{
    public class SimpleFlash : MonoBehaviour
    {
        #region Datamembers

        #region Editor Settings

        [Tooltip("Duration of the flash.")]
        [SerializeField] private float duration = 0.2f;

        [Tooltip("Flash color to lerp toward in shader.")]
        [SerializeField] private Color flashColor = Color.white;

        [SerializeField] private Material flashMaterial;

        #endregion

        #region Private Fields

        // The SpriteRenderer that should flash.
        private SpriteRenderer spriteRenderer;

        // The original material
        private Material originalMaterial;

        // The currently running coroutine.
        private Coroutine flashRoutine;

        // Used to override shader properties without creating new materials.
        private MaterialPropertyBlock propertyBlock;

        // Shader property IDs
        private static readonly int FlashColorID = Shader.PropertyToID("_FlashColor");
        private static readonly int FlashIntensityID = Shader.PropertyToID("_FlashIntensity");

        #endregion

        #endregion


        #region Methods

        #region Unity Callbacks

        void Awake()
        {
            // Get the SpriteRenderer to be used,
            // alternatively you could set it from the inspector.
            spriteRenderer = GetComponent<SpriteRenderer>();

            // Set the original material
            originalMaterial = spriteRenderer.sharedMaterial;

            // Create a reusable property block
            propertyBlock = new MaterialPropertyBlock();
        }

        #endregion

        public void Flash(float intensity)
        {
            // If the flashRoutine is not null, then it is currently running.
            if (flashRoutine != null)
            {
                // In this case, we should stop it first.
                // Multiple FlashRoutines the same time would cause bugs.
                StopCoroutine(flashRoutine);
            }

            // Start the Coroutine, and store the reference for it.
            flashRoutine = StartCoroutine(FlashRoutine(intensity));
        }

        private IEnumerator FlashRoutine(float intensity)
        {
            // Swap to flash material
            spriteRenderer.material = flashMaterial;

            // Set the intensity and color on the property block
            spriteRenderer.GetPropertyBlock(propertyBlock);
            propertyBlock.SetColor(FlashColorID, flashColor);
            propertyBlock.SetFloat(FlashIntensityID, intensity);
            spriteRenderer.SetPropertyBlock(propertyBlock);

            Debug.Log($"{gameObject.name} - Flash Intensity: {intensity}");

            // Pause the execution of this function for "duration" seconds.
            yield return new WaitForSeconds(duration);

            // Reset the intensity after flashing
            spriteRenderer.material = originalMaterial;
            propertyBlock.SetFloat(FlashIntensityID, 0f);
            spriteRenderer.SetPropertyBlock(propertyBlock);

            // Set the routine to null, signaling that it's finished.
            flashRoutine = null;
        }

        #endregion
    }
}
