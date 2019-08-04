﻿using UnityEngine;

namespace Platinio.TweenEngine
{
    
    public class Vector3Tween : BaseTween
    {
        #region PRIVATE
        private Vector3 from  = Vector3.zero;
        private Vector3 to    = Vector3.zero;
        #endregion

        #region PUBLIC
        public Vector3Tween(Vector3 from, Vector3 to, float t , int id)
        {
            this.from      = from;
            this.to        = to;
            this.duration  = t;
            this.id        = id;
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
                
                if(onUpdateVector3 != null)
                    onUpdateVector3(to);

                onComplete();
                return;
            }

            //get new value
            Vector3 change  = to - from;
            Vector3 value   = Equations.ChangeVector(currentTime, from, change, duration, ease);

            //call update if we have it
            if (onUpdateVector3 != null)
                onUpdateVector3(value);
        }
        #endregion
    }

}
