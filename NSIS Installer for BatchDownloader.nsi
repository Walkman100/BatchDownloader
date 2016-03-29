; BatchDownloader Installer NSIS Script
; get NSIS at http://nsis.sourceforge.net/Download
; As a program that all Power PC users should have, Notepad++ is recommended to edit this file

;Icon "My Project\SerialPort.ico"
Caption "BatchDownloader Installer"
Name "BatchDownloader"
XPStyle on
AutoCloseWindow true
ShowInstDetails show

LicenseBkColor /windows
LicenseData "LICENSE.md"
LicenseForceSelection checkbox "I have read and understand this notice"
LicenseText "Please read the notice below before installing BatchDownloader. If you understand the notice, click the checkbox below and click Next."

InstallDir $PROGRAMFILES\WalkmanOSS

OutFile "bin\Release\BatchDownloader-Installer.exe"

; Pages

Page license
Page components
Page directory
Page instfiles
UninstPage uninstConfirm
UninstPage instfiles

; Sections

Section "Executable & Uninstaller"
  SectionIn RO
  SetOutPath $INSTDIR
  File "bin\Release\BatchDownloader.exe"
  WriteUninstaller "BatchDownloader-Uninst.exe"
SectionEnd

Section "Start Menu Shortcuts"
  CreateDirectory "$SMPROGRAMS\WalkmanOSS"
  CreateShortCut "$SMPROGRAMS\WalkmanOSS\BatchDownloader.lnk" "$INSTDIR\BatchDownloader.exe" "" "$INSTDIR\BatchDownloader.exe" "" "" "" "BatchDownloader"
  CreateShortCut "$SMPROGRAMS\WalkmanOSS\Uninstall BatchDownloader.lnk" "$INSTDIR\BatchDownloader-Uninst.exe" "" "" "" "" "" "Uninstall BatchDownloader"
  ;Syntax for CreateShortCut: link.lnk target.file [parameters [icon.file [icon_index_number [start_options [keyboard_shortcut [description]]]]]]
SectionEnd

Section "Desktop Shortcut"
  CreateShortCut "$DESKTOP\BatchDownloader.lnk" "$INSTDIR\BatchDownloader.exe" "" "$INSTDIR\BatchDownloader.exe" "" "" "" "BatchDownloader"
SectionEnd

Section "Quick Launch Shortcut"
  CreateShortCut "$QUICKLAUNCH\BatchDownloader.lnk" "$INSTDIR\BatchDownloader.exe" "" "$INSTDIR\BatchDownloader.exe" "" "" "" "BatchDownloader"
SectionEnd

; Functions

Function .onInit
  MessageBox MB_YESNO "This will install BatchDownloader. Do you wish to continue?" IDYES gogogo
    Abort
  gogogo:
  SetShellVarContext all
  SetAutoClose true
FunctionEnd

Function .onInstSuccess
    MessageBox MB_YESNO "Install Succeeded! Open ReadMe?" IDNO NoReadme
      ExecShell "open" "https://github.com/Walkman100/BatchDownloader/blob/master/README.md#batchdownloader-"
    NoReadme:
FunctionEnd

; Uninstaller

Section "Uninstall"
  Delete "$INSTDIR\BatchDownloader-Uninst.exe"   ; Remove Application Files
  Delete "$INSTDIR\BatchDownloader.exe"
  RMDir "$INSTDIR"
  
  Delete "$SMPROGRAMS\WalkmanOSS\BatchDownloader.lnk"   ; Remove Start Menu Shortcuts & Folder
  Delete "$SMPROGRAMS\WalkmanOSS\Uninstall BatchDownloader.lnk"
  RMDir "$SMPROGRAMS\WalkmanOSS"
  
  Delete "$DESKTOP\BatchDownloader.lnk"   ; Remove Desktop Shortcut
  Delete "$QUICKLAUNCH\BatchDownloader.lnk"   ; Remove Quick Launch Shortcut
SectionEnd

; Uninstaller Functions

Function un.onInit
    MessageBox MB_YESNO "This will uninstall BatchDownloader. Continue?" IDYES NoAbort
      Abort ; causes uninstaller to quit.
    NoAbort:
    SetShellVarContext all
    SetAutoClose true
FunctionEnd

Function un.onUninstFailed
    MessageBox MB_OK "Uninstall Cancelled"
FunctionEnd

Function un.onUninstSuccess
    MessageBox MB_OK "Uninstall Completed"
FunctionEnd
