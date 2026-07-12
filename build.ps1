Write-Host "开始构建 SteamAnalysis 发布版本..." -ForegroundColor Cyan

$baseDir = $PSScriptRoot
$releasesDir = Join-Path $baseDir "Releases"

# 如果 Releases 文件夹已存在，则清空
if (Test-Path $releasesDir) {
    Remove-Item -Path "$releasesDir\*" -Recurse -Force
} else {
    New-Item -ItemType Directory -Path $releasesDir | Out-Null
}

$singleFileDir = Join-Path $releasesDir "SingleFile"
$compatibleDir = Join-Path $releasesDir "Compatible"

Write-Host "`n[1/2] 正在构建 单文件极致版 (可能在部分机器上被杀毒拦截导致闪退)..." -ForegroundColor Yellow
dotnet publish "$baseDir\SteamAnalysisAvalonia.csproj" -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -o $singleFileDir

Write-Host "`n[2/2] 正在构建 兼容版 (包含外部dll，解决闪退问题)..." -ForegroundColor Yellow
dotnet publish "$baseDir\SteamAnalysisAvalonia.csproj" -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=false -o $compatibleDir

Write-Host "`n正在将兼容版打包为 ZIP..." -ForegroundColor Yellow
$zipPath = Join-Path $releasesDir "SteamAnalysis_Compatible.zip"
Compress-Archive -Path "$compatibleDir\*" -DestinationPath $zipPath -Force

Write-Host "`n构建完成！🎉" -ForegroundColor Green
Write-Host "发布文件位置："
Write-Host "1. 单文件版 (Single EXE): $singleFileDir\SteamAnalysisAvalonia.exe"
Write-Host "2. 兼容版压缩包 (ZIP with DLLs): $zipPath"
