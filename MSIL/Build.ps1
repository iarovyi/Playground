
function PrintHeader([string]$Header){
    Write-Host "----------------------"  -ForegroundColor Green
    Write-Host "------- $Header"         -ForegroundColor Green
    Write-Host "----------------------"  -ForegroundColor Green
}

function EnsureToolAvailable([string]$Tool){
    if ((Get-Command $Tool -ErrorAction SilentlyContinue) -eq $null) 
    { 
        throw "Unable to find $Tool in your PATH"
    }
}

Clear-Host
EnsureToolAvailable "ilasm"
EnsureToolAvailable "ildasm"
EnsureToolAvailable "peverify"

Remove-Item "output" -Recurse -ErrorAction Ignore
New-Item -ItemType Directory -Force -Path "output"

PrintHeader "1. Assembling"
ilasm ConsoleApp.il /output:.\output\ConsoleApp.exe

PrintHeader "2. Disassembling"
ildasm output\ConsoleApp.exe /output:output\ConsoleApp_Disassembled.il 

PrintHeader "3. Verifying portable executable"
peverify output\ConsoleApp.exe /verbose /md /il

PrintHeader "4. Run"
output\ConsoleApp.exe

