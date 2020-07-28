Set LogPath=.\UnregResult.log
if NOT "%1"=="" Set LogPath=%1

Regcom.exe zlPacsInterfaceC.dll -un >>%LogPath%