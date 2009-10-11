msbuild /l:FileLogger,Microsoft.Build.Engine;logfile=build.log particles-env\particles-env.sln

mkdir build\modules
mkdir build\modules\icons

msbuild micro4-1\micro4-1.sln
copy micro4-1\*.bmp build\modules\icons

msbuild micro6\micro6.sln
copy micro6\*.bmp build\modules\icons


del build\*.pdb
del build\modules\*.pdb
del build\modules\MDK.dll
del build\modules\ZedGraph.dll


