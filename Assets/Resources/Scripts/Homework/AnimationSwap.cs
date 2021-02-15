using UnityEngine;

public class AnimationSwap : MonoBehaviour
{
    [SerializeField] private AnimationClip[] _animations = null;// Array of accessible animations

    private Animator _animator = null;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Swaps to random animation clip in the animations array
    /// </summary>
    public void SwapAnimation()
    {
        if (_animations != null)
        {
            int result = Random.Range(0, _animations.Length);

            switch (result)
            {
                case 0:
                    _animator.Play(_animations[result].name);
                    break;
                case 1:
                    _animator.Play(_animations[result].name);
                    break;
                case 2:
                    _animator.Play(_animations[result].name);
                    break;
            }
        }
        else
        {
            Debug.Log($"Animations array is empty!");
        }
    }    
}
