msbuild particles-env\particles-env.sln
mkdir build\modules
msbuild micro4-1\micro4-1.sln
msbuild micro6\micro6.sln
del build\*.pdb
del build\modules\*.pdb
del build\modules\MDK.dll
del build\modules\ZedGraph.dll