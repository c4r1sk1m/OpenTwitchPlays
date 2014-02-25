![OpenTwitchPlays GUI](http://i.imgur.com/qJpNsMa.png)
![OpenTwitchPlays - Example livestream](http://i.imgur.com/Jd99nFi.jpg)

Introduction:
=============
OpenTwitchPlays is an utility to create interactive livestreams where users can type chat commands to control the game or the application such as TwitchPlaysPokemon.

Features:
=============
* Quickly bind chat commands to key strokes and save your settings
* Fire up your favorite IRC client, connect to your twitch chat and select your chat log on OpenTwitchPlays and you're ready to stream.
* Set up an autosave hotkey that will fire periodically for emulator savestates
* Send keystrokes to minimized windows that support them by activating the PostMessage mode.
* Outputs keystroke stats, uptime and command log on three separate text files that you can display on-screen on your live stream using your favorite broadcasting software (OpenBroadcaster is recommended).
* Runs great even on a virtual machine.
* Open Source and licensed under the GNU GPL license. Download the Source Code and make and redistribute your own modifications!

Getting started:
=============
* Download the binaries ([x64]() or [x86]()) and make sure you have the .NET Framework version 4.0 or higher.
* Get [HexChat](http://hexchat.github.io/) and set it up to connect to your twitch channel's chat by following [this guide](http://teamfortress.tv/forum/thread/719-tutorial-connecting-to-twitch-tv-via-xchat-mirc/1).
* Go to Settings -> Preferences on HexChat and click on the Logging tab on the left and set it up like this: ![HexChat logging settings](http://i.imgur.com/poyNNf1.png)
* Restart HexChat and join your channel's chat.
* Unzip and start OpenTwitchPlays and click File -> Open source...
* Navigate to C:\Users\your windows username\AppData\Roaming\HexChat\logs and select lastsession.log
* Open your game and click File -> Attach on OpenTwitchPlays and select your game window from the list and confirm by clicking OK.
* Change your autosave key combination and delay (default is shift + F2 every 60 seconds) or disable it by unticking settings -> Autosave. For more info on the format of the autosave key combination for special or multiple keys, see [this](http://msdn.microsoft.com/en-us/library/system.windows.forms.sendkeys.aspx) (scroll down to Remarks).
* Bind chat commands to keys in the Key bindings section. The delay is how long the key will be held down for.
* Save your settings by clicking File -> Save config.
* You're ready to go! Set up your livestream on your favorite broadcasting software and click Tools -> Start on OpenTwitchPlays to start processing chat commands.
* OpenTwitchPlays will also output information about the stream to three separate text files in the program's folder: stats.txt (keystroke statistics), commands.txt (command log), uptime.txt (current uptime). You can set these as text sources on your broadcasting software to display the information on-screen in your livestream.

Known issues:
=============
* "My autosave key combination is not working! / OpenTwitchPlays says that my autosave combination is invalid!" - Make Sure that your autosave setting is checked from the settings menu. If you're in PostMessage mode, keep in mind that you can only use a single key for autosave. If you're not using PostMessage, make sure that your key combination is in a correct format. For more info on the format of the autosave key combination for special or multiple keys, see [this](http://msdn.microsoft.com/en-us/library/system.windows.forms.sendkeys.aspx) (scroll down to Remarks).
* "How do I reset my uptime / keystrokes?" - Tools -> Reset
* "How do I send keystrokes even if the game is minimized?" - Settings -> Use PostMessage. Keep in mind that this will only work with some games.
* "How do I backup my uptime or settings?" - Uptime & Keystrokes: status.bin, Settings: settings.bin
* "OpenTwitchPlays crashes on startup! / I'm getting some weird exception error" - Your settings might be corrupt. Try deleting settings.bin. If the problem continues, try deleting status.bin.
* "My game is not registering the key presses!" - Make sure that the delay of your key bindings is high enough. Make sure that you selected the correct keys. Try disabling "Use PostMessage" in Settings. Make sure that your HexChat client is connected to the correct channel and that the commands are logging in the Command log. Some games might have protection against keystroke emulation and will therefore not work with OpenTwitchPlays.
* "Adding identical commands causes errors" - This will be prevented in the next revision.