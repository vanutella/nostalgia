Exported using Ray1Map https://github.com/BinarySerializer/Ray1Map. Ray1Map exports .obj files with vertex colors; additionally, the normals in Ray1Map's exports are all inverted. As such, this zip provides different model format options: a .obj export with vertex colors, a .obj export without vertex colors, a .dae export, and the original .obj export from Ray1Map, with all exports except for the original one having corrected normals.

The sky backgrounds in this game are 2D backgrounds with parallax, going from 0, the farthest behind, to the most in front. Ray1Map rips these as .gif files.

Materials are split according to the special rendering and collision flags they have, structured as "texture_renderingflag_collisionflag" i.e. mtl_Tex6__Unlit__None is Tex6 with flat lighting and no special collision flags, mtl_Tex16__VertexColor__MoveSlow is Tex16 with vertex lighting and a collision flag that makes the player slow, mtl_Tex15__Hidden__Pit is Tex15 with an invisible rendering flag and a collision flag that makes the player respawn

Thus, if you're using the model for visual reference, you'll want to remove the geometry assigned to materials with "Hidden", and preserve the translucency and blending in materials with "Transparent", "TransparentCutout6", "TransparentCutout7", "Additive", and "AdditiveTransparent".

The full list of rendering flags is as follows:
Unlit (geometry has no lighting)
VertexColor (geometry has vertex lighting)
Mode_2 (unknown)
Transparent (geometry is semi-transparent)
Hidden (geometry is invisible)
Mode_5 (unknown)
TransparentCutout6 (texture has transparency, unknown)
TransparentCutout7 (texture has transparency, unknown)
Additive (texture uses additive blending)
AdditiveTransparent (texture uses additive blending, texture has transparency)
Mode_10 to Mode_15 (unknown)

The full list of collision flags is as follows:
Wall (wall)
TriggerArea (special collision area)
Flag_03 (unknown)
MoveSlow (makes player move slow)
HorizontalScroll (texture has a scrolling animation)
Flag_06 (unknown)
Water (water)
Pit (marks player as out of bounds, leads to respawn)
Jump (makes the player jump)
LongerJump (makes the player jump)
Teleporter (teleporter)
ElectricGate (obstacle)
Flag_14 (unknown)

Also, somewhat annoyingly enough the program extracts these models with the textures flipped upside down.