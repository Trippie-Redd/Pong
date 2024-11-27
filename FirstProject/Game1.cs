using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame;

namespace FirstProject;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Texture2D pixel;
    SpriteFont arial;
    Rectangle player1;
    Rectangle player2;
    Ball ball;

    // Speed vars
    int p1Speed = 4;
    int p2Speed = 4;

    // Viewport dimensions
    int vh = 480;
    int vw = 800;

    // Score vars
    int p1Score, p2Score = 0;

    Random rng = new Random();

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // Sets correct sizes for all objects
        player1 = new Rectangle(vw/40, 3*vh / 8, vw/40, vh/4);
        player2 = new Rectangle(vw - (vw/40 + vw/40), 3*vh / 8, vw/40, vh/4);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        pixel = Content.Load<Texture2D>("pixel");
        arial = Content.Load<SpriteFont>("font");

        ball = new Ball(pixel);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        ball.Update();
        UpdateInput();
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
        _spriteBatch.DrawString(arial, Convert.ToString(p1Score), new Vector2((vw/2) - (vw/40), vw/8), Color.White);
        _spriteBatch.DrawString(arial, Convert.ToString(p2Score), new Vector2((vw/2) + (vw/40), vw/8), Color.White);
        
        // Loads ball
        ball.Draw(_spriteBatch);
        
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

    // Updates score
    void UpdateScore()
    {
        if (ball.Rectangle.X <= 0)
        {
            p2Score++;
            ball.Reset();
        }
        else if (ball.Rectangle.X >= 780)
        {   
            Console.WriteLine(_graphics.PreferredBackBufferWidth);
            p1Score++;
            ball.Reset();
        }
    }
}