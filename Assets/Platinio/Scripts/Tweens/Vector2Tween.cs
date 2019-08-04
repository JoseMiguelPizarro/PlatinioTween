﻿using UnityEngine;

namespace Platinio.TweenEngine
{

    public class Vector2Tween : BaseTween
    {
        #region PRIVATE
        private Vector2 from = Vector3.zero;
        private Vector2 to = Vector3.zero;
        #endregion

        #region PUBLIC
        public Vector2Tween(Vector2 from, Vector2 to, float t, int id)
        {
            this.from = from;
            this.to = to;
            this.duration = t;
            this.id = id;
        }

        /// <summary>
        /// called every frame
        /// </summary>
        public override void Update(float deltaTime)
        {
            
            //wait a delay
            if (delay > 0.0f)
            {
                delay -= deltaTime;
                return;
            }

            base.Update(deltaTime);

            //start counting time
            currentTime += deltaTime;

            //if time ends
            if (currentTime >= duration)
            {
               
                if (onUpdateVector2 != null)
                    onUpdateVector2(to);

                onComplete();
                return;
            }

            //get new value
            Vector2 change = to - from;
            Vector2 value = Equations.ChangeVector(currentTime, from, change, duration, ease);

            //Vector2 vector2Value = new Vector2(value.x , value.y);

            //call update if we have it
            if (onUpdateVector2 != null)
                onUpdateVector2(value);
        }
        #endregion
    }

}
