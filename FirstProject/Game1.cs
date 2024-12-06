using System;
using System.Collections.Generic;
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
    Player player;
    Enemy enemy;
    Gun gun;

    bool mouse_pressed = false;

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

        player = new Player(pixel);
        enemy = new Enemy(pixel);
        gun = new Gun();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        player.Update();

        if (player.IsDead(enemy)) {Exit();}

        MouseInput();
        gun.Update();

        enemy.Update(new Vector2(player.Rectangle.X, player.Rectangle.Y));

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin();

        player.Draw(_spriteBatch);
        enemy.Draw(_spriteBatch);
        gun.Draw(_spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }

    private void MouseInput()
    {
        MouseState mState = Mouse.GetState();
        if (mState.LeftButton == ButtonState.Pressed)
        {   
            if (!mouse_pressed)
                gun.Shoot(new Bullet(new Vector2(mState.X, mState.Y), new Vector2(player.Rectangle.X, player.Rectangle.Y), pixel));

            mouse_pressed = true;
        }

        if (mState.LeftButton == ButtonState.Released)
        {
            mouse_pressed = false;
        }
    }
}