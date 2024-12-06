using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.XAudio2;

namespace FirstProject
{
    public class Bullet
    {
        private Texture2D texture;
        private Color color = Color.Orange;
        private Rectangle rectangle;

        private bool dead = false;

        private Vector2 target, start, direction;

        public bool Dead
        {
            get{return dead;}
            set{dead = value;}
        }

        public Bullet(Vector2 t, Vector2 l, Texture2D te)
        {
            texture = te;
            
            rectangle = new Rectangle(Convert.ToInt32(l.X), Convert.ToInt32(l.Y), 20, 20);

            target = t;
            start = l;

            direction = Vector2.Normalize(target - start);
        }

        public void Update()
        {
            if (rectangle.X == target.X && rectangle.Y == target.Y)
                dead = true;
            else
                start += direction * 5;

            rectangle.Location = start.ToPoint();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, color);
        }
    }
}

/*

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Rectangle _rectangle;
        private Vector2 _startPoint;
        private Vector2 _endPoint;
        private Vector2 _currentPosition;
        private Vector2 _direction;
        private float _speed = 100f; // Pixels per second

        protected override void Initialize()
        {
            // Define the start and end points
            _startPoint = new Vector2(100, 100);
            _endPoint = new Vector2(500, 300);

            // Initialize the rectangle's position and size
            _rectangle = new Rectangle((int)_startPoint.X, (int)_startPoint.Y, 50, 50);
            _currentPosition = _startPoint;

            // Calculate the direction vector and normalize it
            _direction = Vector2.Normalize(_endPoint - _startPoint);

            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || 
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Update position based on the direction and speed
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _currentPosition += _direction * _speed * deltaTime;

            // Check if the rectangle has reached the end point and reverse direction if needed
            if (Vector2.Distance(_currentPosition, _endPoint) < 1f)
            {
                _direction = Vector2.Normalize(_startPoint - _endPoint);
                var temp = _startPoint;
                _startPoint = _endPoint;
                _endPoint = temp;
            }

            // Update the rectangle's position
            _rectangle.Location = _currentPosition.ToPoint();

            base.Update(gameTime);
        }

*/