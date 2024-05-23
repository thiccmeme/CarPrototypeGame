using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guirao.UltimateTextDamage
{
    public class TextDamageClickerChaotic : MonoBehaviour
    {
        public UltimateTextDamageManager textManager;
        public Transform overrideTransformObstacle;
        public Transform overrideTransformCollectable;

        void Start( )
        {
            if( textManager == null )
                textManager = FindObjectOfType<UltimateTextDamageManager>( );
        }

        public void CollideObstacle()
        {
            textManager.Add( ( "-1 LIFE" ).ToString( ) , overrideTransformObstacle != null ? overrideTransformObstacle : transform, "critical" );
        }
        
        public void CollideCollectable()
        {
            textManager.Add( ( "+100 POINT" ).ToString( ) , overrideTransformCollectable != null ? overrideTransformCollectable : transform, "collectable" );
        }
    }
}
