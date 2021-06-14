; Panic button if it fails. Escape will kill the script
Hotkey, Escape, EarlyTerm

; Start the game
Run, project-andromeda.exe

; Set game to active window
SetTitleMatchMode, 2 ; This makes the WinWait find the window without giving it the exact title
WinWait, project-andromeda.exe ; Wait for the game to open
WinActivate ; Set the game window to active

; Sequentially insert the keys needed to finish the game
Send, 1
Sleep, 1000
Send, {Enter}
Sleep, 1000
Send, N
Send, {Enter}
Sleep, 1000
Send,E
Send, {Enter}
Sleep, 1000
Send, N
Send, {Enter}
Sleep, 1000
Send, N
Send, {Enter}
Sleep, 1000
Send, W
Send, {Enter}
Sleep, 1000
Send, S
Send, {Enter}
Sleep, 1000
Send, W
Send, {Enter}
Sleep, 1000
Send, W
Send, {Enter}
Sleep, 1000
Send, N
Send, {Enter}
Sleep, 1000
Send, E
Send, {Enter}
Sleep, 1000
Send, N
Send, {Enter}
Sleep, 1000
Send, N
Send, {Enter}
Sleep, 1000
Send, N
Send, {Enter}
Sleep, 1000
Send, E
Send, {Enter}
Sleep, 1000
Send, S
Send, {Enter}
Sleep, 1000
Send, S
Send, {Enter}
Sleep, 1000
Send, E
Send, {Enter}
Sleep, 1000
Send, N
Send, {Enter}
Sleep, 1000
Send, N
Send, {Enter}
Sleep, 1000
Send, E
Send, {Enter}
Sleep, 1000
Send, N
Send, {Enter}

ExitApp, 0

EarlyTerm:  
ExitApp 