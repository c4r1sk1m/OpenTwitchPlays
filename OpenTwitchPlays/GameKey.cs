/*
	Copyright 2014 Francesco "Franc[e]sco" Noferi (francesco149@gmail.com)

	This file is part of OpenTwitchPlays.

	OpenTwitchPlays is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	OpenTwitchPlays is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with OpenTwitchPlays.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OpenTwitchPlays
{
    /// <summary>
    /// Represents a virtual key for simulated keystrokes with its virtual 
    /// key code and its SendKeys string as well as an identifying name.
    /// </summary>
    public struct GameKey
    {
        /// <summary>
        /// A list of all of the keys that work for PostMessage and SendKeys.
        /// </summary>
        public static readonly IList<GameKey> List = 
            new ReadOnlyCollection<GameKey>(new[] {
                // fuck it, I dunno if there's a way to convert between SendKeys strings and Virtual Keys but
                // as long as it works, I'll take the risk of having spent 30 mins mapping this crap for nothing
                // basically, these are keys that are guaranteed to work for both PostMessage and SendKeys
                new GameKey("backspace",    (ushort)WinAPI.VirtualKeys.Back,        "{BACKSPACE}"), 
                new GameKey("pause",        (ushort)WinAPI.VirtualKeys.Pause,       "{BREAK}"), 
                new GameKey("capslock",     (ushort)WinAPI.VirtualKeys.CapsLock,    "{CAPSLOCK}"), 
                new GameKey("delete",       (ushort)WinAPI.VirtualKeys.Delete,      "{DELETE}"), 
                new GameKey("down",         (ushort)WinAPI.VirtualKeys.Down,        "{DOWN}"), 
                new GameKey("end",          (ushort)WinAPI.VirtualKeys.End,         "{END}"), 
                new GameKey("enter",        (ushort)WinAPI.VirtualKeys.Return,      "{ENTER}"), 
                new GameKey("esc",          (ushort)WinAPI.VirtualKeys.Escape,      "{ESC}"), 
                new GameKey("help",         (ushort)WinAPI.VirtualKeys.Help,        "{HELP}"), 
                new GameKey("home",         (ushort)WinAPI.VirtualKeys.Home,        "{HOME}"), 
                new GameKey("insert",       (ushort)WinAPI.VirtualKeys.Insert,      "{INSERT}"), 
                new GameKey("left",         (ushort)WinAPI.VirtualKeys.Left,        "{LEFT}"), 
                new GameKey("numlock",      (ushort)WinAPI.VirtualKeys.NumLock,     "{NUMLOCK}"), 
                new GameKey("pagedown",     (ushort)WinAPI.VirtualKeys.Next,        "{PGDN}"), 
                new GameKey("pageup",       (ushort)WinAPI.VirtualKeys.Prior,       "{PGUP}"), 
                new GameKey("printscreen",  (ushort)WinAPI.VirtualKeys.Snapshot,    "{PRTSCR}"), 
                new GameKey("right",        (ushort)WinAPI.VirtualKeys.Right,       "{RIGHT}"), 
                new GameKey("scrollock",    (ushort)WinAPI.VirtualKeys.ScrollLock,  "{SCROLLOCK}"), 
                new GameKey("tab",          (ushort)WinAPI.VirtualKeys.Tab,         "{TAB}"), 
                new GameKey("up",           (ushort)WinAPI.VirtualKeys.Up,          "{UP}"), 
                new GameKey("f1",           (ushort)WinAPI.VirtualKeys.F1,          "{F1}"), 
                new GameKey("f2",           (ushort)WinAPI.VirtualKeys.F2,          "{F2}"),
                new GameKey("f3",           (ushort)WinAPI.VirtualKeys.F3,          "{F3}"),
                new GameKey("f4",           (ushort)WinAPI.VirtualKeys.F4,          "{F4}"),
                new GameKey("f5",           (ushort)WinAPI.VirtualKeys.F5,          "{F5}"),
                new GameKey("f6",           (ushort)WinAPI.VirtualKeys.F6,          "{F6}"),
                new GameKey("f7",           (ushort)WinAPI.VirtualKeys.F7,          "{F7}"),
                new GameKey("f8",           (ushort)WinAPI.VirtualKeys.F8,          "{F8}"),
                new GameKey("f9",           (ushort)WinAPI.VirtualKeys.F9,          "{F9}"),
                new GameKey("f10",          (ushort)WinAPI.VirtualKeys.F10,         "{F10}"),
                new GameKey("f11",          (ushort)WinAPI.VirtualKeys.F11,         "{F11}"),
                new GameKey("f12",          (ushort)WinAPI.VirtualKeys.F12,         "{F12}"),
                new GameKey("f13",          (ushort)WinAPI.VirtualKeys.F13,         "{F13}"), // wut, are F13-24 even used?
                new GameKey("f14",          (ushort)WinAPI.VirtualKeys.F14,         "{F14}"),
                new GameKey("f15",          (ushort)WinAPI.VirtualKeys.F15,         "{F15}"),
                new GameKey("f16",          (ushort)WinAPI.VirtualKeys.F16,         "{F16}"),
                new GameKey("f17",          (ushort)WinAPI.VirtualKeys.F17,         "{F17}"),
                new GameKey("f18",          (ushort)WinAPI.VirtualKeys.F18,         "{F18}"),
                new GameKey("f19",          (ushort)WinAPI.VirtualKeys.F19,         "{F19}"),
                new GameKey("f20",          (ushort)WinAPI.VirtualKeys.F20,         "{F20}"),
                new GameKey("f21",          (ushort)WinAPI.VirtualKeys.F21,         "{F21}"),
                new GameKey("f22",          (ushort)WinAPI.VirtualKeys.F22,         "{F22}"),
                new GameKey("f23",          (ushort)WinAPI.VirtualKeys.F23,         "{F23}"),
                new GameKey("f24",          (ushort)WinAPI.VirtualKeys.F24,         "{F24}"),
                new GameKey("add",          (ushort)WinAPI.VirtualKeys.Add,         "{ADD}"), 
                new GameKey("subtract",     (ushort)WinAPI.VirtualKeys.Subtract,    "{SUBTRACT}"), 
                new GameKey("multiply",     (ushort)WinAPI.VirtualKeys.Multiply,    "{MULTIPLY}"), 
                new GameKey("divide",       (ushort)WinAPI.VirtualKeys.Divide,      "{DIVIDE}"), 
                new GameKey("shift",        (ushort)WinAPI.VirtualKeys.LeftShift,   "+"), 
                new GameKey("ctrl",         (ushort)WinAPI.VirtualKeys.LeftControl, "^"), 
                new GameKey("alt",          (ushort)WinAPI.VirtualKeys.Menu,        "%"), 
                new GameKey("a",            (ushort)WinAPI.VirtualKeys.A,           "a"),
                new GameKey("b",            (ushort)WinAPI.VirtualKeys.B,           "b"),
                new GameKey("c",            (ushort)WinAPI.VirtualKeys.C,           "c"),
                new GameKey("d",            (ushort)WinAPI.VirtualKeys.D,           "d"),
                new GameKey("e",            (ushort)WinAPI.VirtualKeys.E,           "e"),
                new GameKey("f",            (ushort)WinAPI.VirtualKeys.F,           "f"),
                new GameKey("g",            (ushort)WinAPI.VirtualKeys.G,           "g"),
                new GameKey("h",            (ushort)WinAPI.VirtualKeys.H,           "h"),
                new GameKey("i",            (ushort)WinAPI.VirtualKeys.I,           "i"),
                new GameKey("j",            (ushort)WinAPI.VirtualKeys.J,           "j"),
                new GameKey("k",            (ushort)WinAPI.VirtualKeys.K,           "k"),
                new GameKey("l",            (ushort)WinAPI.VirtualKeys.L,           "l"),
                new GameKey("m",            (ushort)WinAPI.VirtualKeys.M,           "m"),
                new GameKey("n",            (ushort)WinAPI.VirtualKeys.N,           "n"),
                new GameKey("o",            (ushort)WinAPI.VirtualKeys.O,           "o"),
                new GameKey("p",            (ushort)WinAPI.VirtualKeys.P,           "p"),
                new GameKey("q",            (ushort)WinAPI.VirtualKeys.Q,           "q"),
                new GameKey("r",            (ushort)WinAPI.VirtualKeys.R,           "r"),
                new GameKey("s",            (ushort)WinAPI.VirtualKeys.S,           "s"),
                new GameKey("t",            (ushort)WinAPI.VirtualKeys.T,           "t"),
                new GameKey("u",            (ushort)WinAPI.VirtualKeys.U,           "u"),
                new GameKey("v",            (ushort)WinAPI.VirtualKeys.V,           "v"),
                new GameKey("w",            (ushort)WinAPI.VirtualKeys.W,           "w"),
                new GameKey("x",            (ushort)WinAPI.VirtualKeys.X,           "x"),
                new GameKey("y",            (ushort)WinAPI.VirtualKeys.Y,           "y"),
                new GameKey("z",            (ushort)WinAPI.VirtualKeys.Z,           "z"),
                new GameKey("0",            (ushort)WinAPI.VirtualKeys.N0,          "0"),
                new GameKey("1",            (ushort)WinAPI.VirtualKeys.N1,          "1"),
                new GameKey("2",            (ushort)WinAPI.VirtualKeys.N2,          "2"),
                new GameKey("3",            (ushort)WinAPI.VirtualKeys.N3,          "3"),
                new GameKey("4",            (ushort)WinAPI.VirtualKeys.N4,          "4"),
                new GameKey("5",            (ushort)WinAPI.VirtualKeys.N5,          "5"),
                new GameKey("6",            (ushort)WinAPI.VirtualKeys.N6,          "6"),
                new GameKey("7",            (ushort)WinAPI.VirtualKeys.N7,          "7"),
                new GameKey("8",            (ushort)WinAPI.VirtualKeys.N8,          "8"),
                new GameKey("9",            (ushort)WinAPI.VirtualKeys.N9,          "9")
            });

        /// <summary>
        /// A null GameKey, usually returned in case of errors.
        /// </summary>
        public static GameKey Invalid = new GameKey("invalid", 0xFF, "invalid");

        /// <summary>
        /// Finds a key by name in the GameKey list.
        /// </summary>
        /// <param name="name">The name of the key.</param>
        /// <returns>Returns the desired key if it's found. Otherwise, GameKey.Invalid is returned.</returns>
        public static GameKey ByName(string name)
        {
            foreach (GameKey key in List)
            {
                if (key.Name == name)
                    return key;
            }

            return Invalid;
        }

        /// <summary>
        /// Finds a key by virtual key code in the GameKey list.
        /// </summary>
        /// <param name="vkey">The virtual key code of the key.</param>
        /// <returns>Returns the desired key if it's found. Otherwise, GameKey.Invalid is returned.</returns>
        public static GameKey ByVKey(ushort vkey)
        {
            foreach (GameKey key in List)
            {
                if (key.vkey == vkey)
                    return key;
            }

            return Invalid;
        }

        /// <summary>
        /// Finds a key by SendKeys string in the GameKey list.
        /// </summary>
        /// <param name="keys">The SendKeys string of the key.</param>
        /// <returns>Returns the desired key if it's found. Otherwise, GameKey.Invalid is returned.</returns>
        public static GameKey ByKeyString(string keys)
        {
            foreach (GameKey key in List)
            {
                if (key.key == keys)
                    return key;
            }

            return Invalid;
        }

        /// <summary>
        /// Gets the unique name identifier of the key.
        /// </summary>
        public string Name { get { return name; } }

        /// <summary>
        /// Gets the virtual key code of the key.
        /// </summary>
        public ushort VirtualKey { get { return vkey; } }

        /// <summary>
        /// Gets the SendKeys string code of the key.
        /// </summary>
        public string KeyString { get { return key; } }

        private readonly string name;
        private readonly ushort vkey;
        private readonly string key;

        public GameKey(string Name, ushort VirtualKey, string KeyString)
        {
            this.name = Name;
            this.vkey = VirtualKey;
            this.key = KeyString;
        }

        public static bool operator ==(GameKey a, GameKey b)
        {
            // if both are null, or both are same instance, return true.
            if (Object.ReferenceEquals(a, b))
                return true;

            // if one is null, but not both, return false.
            // should never happen with structs
            if (((object)a == null) || ((object)b == null))
                return false;

            return a.vkey == b.vkey;
        }

        public static bool operator !=(GameKey a, GameKey b)
        {
            return !(a == b);
        }

        public override bool Equals(Object obj)
        {
            // if parameter is null return false
            if (obj == null)
                return false;

            // if parameter cannot be cast to GameKey return false
            if (!(obj is GameKey))
                return false;

            GameKey gk = (GameKey)obj;

            // return true if the fields match:
            return vkey == gk.vkey;
        }

        public bool Equals(GameKey gk)
        {
            // if parameter is null return false
            if ((object)gk == null)
                return false;

            // return true if the fields match
            return vkey == gk.vkey;
        }

        public override int GetHashCode()
        {
            // this crap needs to be overridden to overload the equals operator
            return vkey;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
