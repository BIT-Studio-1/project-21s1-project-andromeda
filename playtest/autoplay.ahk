; Array with key inputs needed to win the game.
Keys := [1, Enter, N]

if WinActive(*project-andromeda.exe)
	{
		for Key in Keys
		{
			Send Key
			Sleep 1000
		}
	}
