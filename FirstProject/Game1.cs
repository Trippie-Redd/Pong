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
    Paddle player1;
    Paddle player2;
    Scoreboard p1Scoreboard;
    Scoreboard p2Scoreboard;
    Ball ball;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        pixel = Content.Load<Texture2D>("pixel");
        arial = Content.Load<SpriteFont>("font");

        ball = new Ball(pixel);
        player1 = new Paddle(pixel, Keys.W, Keys.S, new Rectangle(30, 190, 20, 100));
        p1Scoreboard = new Scoreboard(new Vector2(10, 20), arial, Color.White, "Player 1");

        player2 = new Paddle(pixel, Keys.Up, Keys.Down, new Rectangle(750, 190, 20, 100));
        p2Scoreboard = new Scoreboard(new Vector2(780, 20), arial, Color.White, "Player 2");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        
        ball.Update();
        player1.Update();
        player2.Update();

        checkCollison();

        UpdateScore();

        player2.AI = true;
        
        if (player2.Rectangle.Y > ball.Rectangle.X)
        {
            player2.Down = false;
            player2.Up = true;
        }
        else
        {
            player2.Up = false;
            player2.Down = true;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin();

        // Draws score
        p1Scoreboard.Draw(_spriteBatch);
        p2Scoreboard.Draw(_spriteBatch);

        // Draws ball
        ball.Draw(_spriteBatch);
        
        // Draws players
        player1.Draw(_spriteBatch);
        player2.Draw(_spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }

    // Checks for collison
    void checkCollison()
    {
        if (player1.Rectangle.Intersects(ball.Rectangle) || player2.Rectangle.Intersects(ball.Rectangle))
        {
            ball.Bounce();
        }
    }

    // Updates score
    void UpdateScore()
    {
        if (ball.Rectangle.X <= 0)
        {
            p2Scoreboard.UpdateScore(1);
            ball.Reset();
        }
        else if (ball.Rectangle.X >= 780)
        {   
            p1Scoreboard.UpdateScore(1);
            ball.Reset();
        }
    }
}