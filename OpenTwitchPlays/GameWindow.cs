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
using System.Threading;
using System.Windows.Forms;

namespace OpenTwitchPlays
{
    /// <summary>
    /// A wrapper around a HWND IntPtr with various utility functions.
    /// </summary>
    class GameWindow
    {
        /// <summary>
        /// Internal HWND.
        /// </summary>
        protected IntPtr handle = IntPtr.Zero;

        public GameWindow(IntPtr handle)
        {
            this.handle = handle;
        }

        /// <summary>
        /// Brings the window on top.
        /// </summary>
        /// <returns>If the window was brought to the foreground, the return value is nonzero. 
        /// If the window was not brought to the foreground, the return value is zero.</returns>
        public int SetForeground()
        {
            return WinAPI.SetForegroundWindow(handle);
        }

        /// <summary>
        /// Simulates a keystroke within the window (even if it's minimized) by 
        /// using PostMessage. Only works on some applications.
        /// </summary>
        /// <param name="key">The desired key.</param>
        /// <param name="milliseconds">How long the key will be held down (in milliseconds).</param>
        /// <returns>true if the keystroke is successfully sent, false if the key is invalid.</returns>
        public bool SendMinimizedKeystroke(GameKey key, int milliseconds)
        {
            if (key == GameKey.Invalid)
                return false;

            WinAPI.PostMessage(handle, WinAPI.WM_KEYDOWN, key.VirtualKey, WinAPI.MapVirtualKey(key.VirtualKey, 0) << 16);
            Thread.Sleep(TimeSpan.FromMilliseconds(milliseconds));
            WinAPI.PostMessage(handle, WinAPI.WM_KEYUP, key.VirtualKey, WinAPI.MapVirtualKey(key.VirtualKey, 0) << 16);
            Thread.Sleep(100);

            return true;
        }

        
        /// <summary>
        /// Simulates a global keystroke in the system.
        /// </summary>
        /// <param name="key">The desired key.</param>
        /// <param name="delay">How long the key will be held down (in milliseconds).</param>
        /// <returns>true if the keystroke is successfully sent, false if the key is invalid.</param>
        public static bool SendGlobalKeystroke(GameKey key, int delay)
        {
            // move this to a different class maybe?

            try
            {
                DateTime beginspam = DateTime.Now;

                // this seems to work to make the game register it as holding down the key
                // TODO: find a more reliable way to do this?
                while (DateTime.Now - beginspam < TimeSpan.FromMilliseconds(delay))
                    SendKeys.SendWait(key.KeyString);

                SendKeys.Flush();
                Thread.Sleep(100);
            }
            catch (Exception)
            {
                // invalid keystroke string
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            return handle.ToString();
        }

        public string ToString(string fmt)
        {
            return handle.ToString(fmt);
        }
    }
}
