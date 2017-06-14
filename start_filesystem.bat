@echo off

echo start master server
start "Cluster Master Server" "D:\Documents\visual studio 2015\Projects\Cluster\Debug\Cluster.exe"

pause

echo start file server
start "FileServer 1" "D:\Documents\visual studio 2015\Projects\Cluster\Debug\FileSystem.exe" 6011 127.0.0.1
start "FileServer 2" "D:\Documents\visual studio 2015\Projects\Cluster\Debug\FileSystem.exe" 6012 127.0.0.1