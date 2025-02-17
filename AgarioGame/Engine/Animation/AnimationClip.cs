using AgarioGame.Engine.Core.Time;
using SFML.Graphics;

namespace AgarioGame.Engine.Animation
{
    public class AnimationClip
    {
        public string AnimationName;

        private float _updateTrigger;
        private int _currentFrame;
        private Texture[] _frames;
        private Sprite _animableSprite;

        public AnimationClip(string animName,Sprite sprite)
        {
            _animableSprite = sprite;
            AnimationName = animName;

            _frames = LoadFrames();

            _currentFrame = 0;
            _animableSprite.Texture = _frames[_currentFrame];
            _updateTrigger = 1 / _frames.Length;
        }
        public void PlayLooped()
        {
            TimerManager.Instance.SetInterval(AnimationName,NextFrame,_updateTrigger);
        }
        public void PlayOnce()
        {
            TimerManager.Instance.SetRepeatedInterval(AnimationName, NextFrame, _updateTrigger, _frames.Length);
        }
        public void Stop()
        {
            TimerManager.Instance.StopInterval(AnimationName);
        }
        public void Reset()
        {
            _currentFrame = 0;
        }
        private void NextFrame()
        {
            _currentFrame++;

            if(_currentFrame > _frames.Length)
            {
                _currentFrame = 0;
            }

            _animableSprite.Texture = _frames[_currentFrame];
        }
        private Texture[] LoadFrames()
        {
            return new Texture[0];
        }
    }
}
