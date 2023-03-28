; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "PinalMVC"
#define MyAppVersion "1.3.0"
#define MyAppPublisher "CPSystems, Inc."
#define MyAppURL "http://www.cpsystems.com.br/"
#define MyAppExeName "PinalMVC.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{BDB983BC-FE60-410F-A919-41E8AAE9FB5D}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
DisableProgramGroupPage=yes
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
OutputDir=C:\Users\USER\Desktop\Projects\Installs\PinalMVC
OutputBaseFilename=setup
SetupIconFile=C:\Users\USER\Desktop\Projects\PinalMVC\PinalMVC\favicon.ico
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "brazilianportuguese"; MessagesFile: "compiler:Languages\BrazilianPortuguese.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\USER\Desktop\Projects\PinalMVC\PinalMVC\bin\Debug\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\USER\Desktop\Projects\PinalMVC\PinalMVC\bin\Debug\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Users\USER\OneDrive\Projects\Dependencias\ndp472-kb4054530-x86-x64-allos-ptb.exe"; DestDir: "{tmp}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Users\USER\OneDrive\Projects\Dependencias\vcredist_x86.exe"; DestDir: "{tmp}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Users\USER\OneDrive\Projects\Dependencias\vcredist_x64.exe"; DestDir: "{tmp}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Users\USER\OneDrive\Projects\Dependencias\xampp-windows-x64-8.2.0-0-VS16-installer.exe"; DestDir: "{tmp}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
Filename: "{tmp}\ndp472-kb4054530-x86-x64-allos-ptb.exe"; WorkingDir:{tmp}; StatusMsg: Instalando .Net Framework 4.7.2
Filename: "{tmp}\vcredist_x86.exe"; Parameters: "/Q"; Flags: waituntilterminated skipifdoesntexist; StatusMsg: "Microsoft Visual C++ 2010 (x86) installation. Please Wait..."; Check: "not IsWin64";
Filename: "{tmp}\vcredist_x64.exe"; Parameters: "/Q"; Flags: waituntilterminated skipifdoesntexist; StatusMsg: "Microsoft Visual C++ 2010 (x64) installation. Please wait..."; Check: IsWin64
Filename: "{tmp}\xampp-windows-x64-8.2.0-0-VS16-installer.exe"; WorkingDir:{tmp}; StatusMsg: Instalando xampp 8.2.0

