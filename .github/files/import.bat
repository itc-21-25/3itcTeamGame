@echo off

rem set colors
setlocal
call :setESC
echo %ESC%[91m 3ITC %ESC%[0m
echo %ESC%[93m UNITY PROJECT %ESC%[0m
echo %ESC%[92m IMPORTER %ESC%[0m
timeout 5 /nobreak


rem Finding version...
echo %ESC%[93m Finding version.... %ESC%[0m
rem Go to the Unity installation directory
echo %ESC%[93m Try to open unity path.... %ESC%[0m
cd "C:\Program Files\Unity\Hub\Editor\"
rem Check if the 2022.3.11f1 folder exists
if exist "2022.3.11f1\Editor" (
    rem Open the folder
    cd "2022.3.11f1\Editor"
    echo echo %ESC%[92m Version:2022.3.11f1 found. %ESC%[0m

    rem Create a new folder on the Documents
    echo %ESC%[93m Creating folder 3itcTeamGame on Documents %ESC%[0m
    mkdir "%USERPROFILE%\Documents\3itcTeamGame"
    echo %ESC%[92m Folder created %ESC%[0m

    rem Clone the repository to the new folder
    cd "%USERPROFILE%\Documents\3itcTeamGame"
    echo %ESC%[93m Cloning repo. %ESC%[0m
    git clone https://github.com/dolezalll/3itcTeamGame.git
    echo %ESC%[92m Repo cloned %ESC%[0m
    

    rem Import the game into Unity
        echo %ESC%[93m Starting importing project to unity. %ESC%[0m
    "C:\Program Files\Unity\Hub\Editor\2022.3.11f1\Editor\Unity.exe" -projectPath "%USERPROFILE%\Documents\3itcTeamGame\3itcTeamGame" -logFile "%USERPROFILE%\Documents\3itcTeamGame\log"
    echo %ESC%[92m DONE %ESC%[0m
    echo %ESC%[93m Output of log %ESC%[0m
    timeout 3 /nobreak
    type "%USERPROFILE%\Documents\3itcTeamGame\log"
    echo %ESC%[91m Closing .... T %ESC%[0m
    timeout 10 /nobreak
    

) else (
    rem Print an error message
    echo  echo %ESC%[91m Error: Please download Unity version 2022.3.11f1 %ESC%[0m 
    echo %ESC%[91m Closing .... T %ESC%[0m
    timeout 5 /nobreak
)
:setESC
for /F "tokens=1,2 delims=#" %%a in ('"prompt #$H#$E# & echo on & for %%b in (1) do rem"') do (
  set ESC=%%b
  exit /B 0
)
exit /B 0