using UnityEngine;

public interface IHoldable
    {
        void Hold(Vector2 cursorPosition, float deltaTime);
        void Release();
        
    }
