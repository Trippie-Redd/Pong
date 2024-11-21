using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FirstProject;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Texture2D pixel;
    SpriteFont arial;
    Rectangle player1;
    Rectangle player2;
    Rectangle ball;

    Vector2 ballPosition;
    Vector2 ballVelocity;

    // Speed vars
    int p1Speed = 4;
    int p2Speed = 4;

    // Viewport dimensions
    int vh;
    int vw;

    // Score vars
    int p1Score, p2Score = 0;

    Random rng = new Random();

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _graphics.PreferredBackBufferWidth = 1200;
        _graphics.PreferredBackBufferHeight = 720;
    }

    protected override void Initialize()
    {
        // sets viewport height and width
        vw = _graphics.PreferredBackBufferWidth;
        vh = _graphics.PreferredBackBufferHeight;
        
        // Sets correct sizes for all objects
        player1 = new Rectangle(vw/40, 3*vh / 8, vw/40, vh/4);
        player2 = new Rectangle(vw - (vw/40 + vw/40), 3*vh / 8, vw/40, vh/4);
        ball = new Rectangle((vh/2) - (ball.Height / 2), (vh/2) - (ball.Height / 2), vw/40, vh/24);

        // Corrects speed
        p1Speed *= vw/800;
        p2Speed *= vw/800;

        NewBall();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        pixel = Content.Load<Texture2D>("pixel");
        arial = Content.Load<SpriteFont>("font");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        // Moves the ball
        ballPosition += ballVelocity;

        UpdateInput();
        CheckCollisions();
        UpdateScore();
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin();
        
        // TODO: Add your drawing code here
        _spriteBatch.Draw(pixel, player1, Color.White);
        _spriteBatch.Draw(pixel, player2, Color.White);
        _spriteBatch.Draw(pixel, ball, Color.White);
        _spriteBatch.DrawString(arial, Convert.ToString(p1Score), new Vector2((vw/2) - (vw/40), vw/8), Color.White);
        _spriteBatch.DrawString(arial, Convert.ToString(p2Score), new Vector2((vw/2) + (vw/40), vw/8), Color.White);
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }

    // All input logic
    public void UpdateInput()
    {
        KeyboardState kState = Keyboard.GetState();

        // Player 1 up
        if (kState.IsKeyDown(Keys.W))
        {
            if (player1.Y <= 0)
            {
                player1.Y = 0;
            }
            else
                player1.Y -= p1Speed;
        }

        // Player 1 down
        if (kState.IsKeyDown(Keys.S))
        {
            if (player1.Y >= (vh - player1.Height))
            {
                player1.Y = vh - player1.Height;
            }
            player1.Y += p1Speed;
        }

        // Player 2 up
        if (kState.IsKeyDown(Keys.Up))
        {
            if (player2.Y <= 0)
            {
                player2.Y = 0;
            }
            else
                player2.Y -= p2Speed;
        }

        // Player 2 down
        if (kState.IsKeyDown(Keys.Down))
        {
            if (player2.Y >= (vh - player2.Height))
            {
                player2.Y = vh - player2.Height;
            }
            else
                player2.Y += p2Speed;
        }
    }

    // Collision logic
    void CheckCollisions()
    {
        ball.X = (int)ballPosition.X;
        ball.Y = (int)ballPosition.Y;

        // Checks for player collisions
        if (ball.Intersects(player1) || ball.Intersects(player2))
        {
            ballVelocity.X *= -1;
        }

        // Checks for floor/roof collisions
        if (ballPosition.Y < 0 || ballPosition.Y + ball.Height > vh)
        {
            ballVelocity.Y *= -1;
        }
    }

    // Updates score
    void UpdateScore()
    {
        if (ballPosition.X <= 0)
        {
            p2Score++;
            NewBall();
        }
        else if (ballPosition.X >= (vw - ball.Width))
        {
            p1Score++;
            NewBall();
        }
    }

    // Spawns a new ball
    void NewBall()
    {
        ballPosition.X = (vw/2) - (ball.Width / 2);
        ballPosition.Y = (vh/2) - (ball.Height / 2);
        ballVelocity.X = rng.Next(3, 6) * (vw/800);
        ballVelocity.Y = rng.Next(3, 6) * (vw/800);
        Console.WriteLine(ballVelocity.Y);
    }
}