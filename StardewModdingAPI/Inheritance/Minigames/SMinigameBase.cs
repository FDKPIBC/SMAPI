﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StardewModdingAPI.Inheritance.Minigames
{
    abstract class SMinigameBase : StardewValley.Minigames.IMinigame
    {
        public abstract bool tick(GameTime time);

        public abstract void receiveLeftClick(int x, int y, bool playSound = true);

        public abstract void leftClickHeld(int x, int y);

        public abstract void receiveRightClick(int x, int y, bool playSound = true);

        public abstract void releaseLeftClick(int x, int y);

        public abstract void releaseRightClick(int x, int y);

        public abstract void receiveKeyPress(Keys k);

        public abstract void receiveKeyRelease(Keys k);

        public abstract void draw(SpriteBatch b);

        public abstract void changeScreenSize();

        public abstract void unload();

        public abstract void receiveEventPoke(int data);
    }
}
