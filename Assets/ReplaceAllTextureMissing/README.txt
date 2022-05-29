© 2016 - 2022 Furrany Studio


Thank you for downloading this "firmware" for Unity.

This script allows to change all the missing material in the scene to missing masterials of better quality.


List of error :

RATMError001 -> The resource file containing the folder 'RATM' which contains the material 'MissingTexture.mat' does not exist.

Loads the asset of the requested type stored at path in a Resources folder.
--> https://docs.unity3d.com/ScriptReference/Resources.Load.html


RATMError002 -> The content of your scene is empty.

This is to say that there is no MeshRenderer containing no Missing Materials in your scene.


RATMError003 -> The selected objects do not exist, or have not been instantiated, or even worse Unity cannot modify the materials found.

Unity may have problems finding MeshRenderers.
Your MeshRenderer may not exist.
Or delete at processing time.

OR just Unity doing nothing, it happens from time to time we don't know why, no internal and external errors.


RATMError004 -> Window for RATM can't open.

Maybe you have wrongly import the package.
Or there is an internal problem in Unity that prevents you from using RATM.


© 2016 - 2022 Furrany Studio