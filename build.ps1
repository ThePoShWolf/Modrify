Get-ChildItem $PSScriptRoot -Directory | ?{$_.Name -like 'PSMutagen*'} | %{
    Set-Location $_.Fullname
    Invoke-build -Task ModuleBuild
}