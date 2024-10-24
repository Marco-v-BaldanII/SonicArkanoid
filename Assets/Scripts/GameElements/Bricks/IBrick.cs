using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBrick 
{

    public void SetHealth();

    public void SetPosition(float width, float height, Vector2 position);

    public void Load(Vector2 tranformPosition, int hp);

}
