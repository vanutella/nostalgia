//© 2023 Polysquat Studios LLC
Shader "MicroTexturesFree/StandardTile"
{
    Properties
    {
        _Color("", Color) = (1, 1, 1, 1)
        _MainTex("", 2D) = "white" {}
        _MainOffset ("Texture Offset", Vector) = (1,1,0,0) 
        _OcclusionStrength("Strength", Range(0.0, 1.0)) = 1.0
        _OcclusionStrengthBlend("Strength", Range(0.0, 1.0)) = 1.0

        _GridStrength("Grid Strength", Range(0.0, 1.0)) = 1.0
        _TextureNumber("Texture Number", Float) = 0

        _GridMult("Grid Multiplier", Float) = 1
        _GridSize("Grid Size", Float) = 2
        _GridStart("Grid Start", Vector) = (0,0,0,0)

        _TextureStartX("Start X", Float) = 0
        _TextureStartY("Start Y", Float) = 0
        _TextureStartLayer("Start Layer", Float) = 0

        _Color1("", Color) = (0, 0, 0, 1)
        _Color1Blend("", Color) = (0, 0, 0, 1)
        _NormalColor1T("", Range(0, 1)) = 0.5
        _NormalColor1B("", Range(0, 1)) = 0.5
        _NormalColor1N("", Range(0, 1)) = 0.5
        [Gamma] _MetalnessColor1("", Range(0, 1)) = 0
        _SmoothnessColor1("", Range(0, 1)) = 0.5
        _OcclusionColor1("", Range(0, 1)) = 1
        _EmissionColor1("", Color) = (0, 0, 0)
        _EmissionColor1Intensity("", Range(0, 1)) = 0
        _NormalColor1TBlend("", Range(0, 1)) = 0.5
        _NormalColor1BBlend("", Range(0, 1)) = 0.5
        _NormalColor1NBlend("", Range(0, 1)) = 0.5
        [Gamma] _MetalnessColor1Blend("", Range(0, 1)) = 0
        _SmoothnessColor1Blend("", Range(0, 1)) = 0.5
        _OcclusionColor1Blend("", Range(0, 1)) = 1
        _EmissionColor1Blend("", Color) = (0, 0, 0)
        _EmissionColor1IntensityBlend("", Range(0, 1)) = 0

        _Color2("", Color) = (0.333, 0.333, 0.333, 1)
        _Color2Blend("", Color) = (0.333, 0.333, 0.333, 1)
        _NormalColor2T("", Range(0, 1)) = 0.5
        _NormalColor2B("", Range(0, 1)) = 0.5
        _NormalColor2N("", Range(0, 1)) = 0.5
        [Gamma] _MetalnessColor2("", Range(0, 1)) = 0
        _SmoothnessColor2("", Range(0, 1)) = 0.5
        _OcclusionColor2("", Range(0, 1)) = 1
        _EmissionColor2("", Color) = (0, 0, 0)
        _EmissionColor2Intensity("", Range(0, 1)) = 0
        _NormalColor2TBlend("", Range(0, 1)) = 0.5
        _NormalColor2BBlend("", Range(0, 1)) = 0.5
        _NormalColor2NBlend("", Range(0, 1)) = 0.5
        [Gamma] _MetalnessColor2Blend("", Range(0, 1)) = 0
        _SmoothnessColor2Blend("", Range(0, 1)) = 0.5
        _OcclusionColor2Blend("", Range(0, 1)) = 1
        _EmissionColor2Blend("", Color) = (0, 0, 0)
        _EmissionColor2IntensityBlend("", Range(0, 1)) = 0

        _Color3("", Color) = (0.666, 0.666, 0.666, 1)
        _Color3Blend("", Color) = (0.666, 0.666, 0.666, 1)
        _NormalColor3T("", Range(0, 1)) = 0.5
        _NormalColor3B("", Range(0, 1)) = 0.5
        _NormalColor3N("", Range(0, 1)) = 0.5
        [Gamma] _MetalnessColor3("", Range(0, 1)) = 0
        _SmoothnessColor3("", Range(0, 1)) = 0.5
        _OcclusionColor3("", Range(0, 1)) = 1
        _EmissionColor3("", Color) = (0, 0, 0)
        _EmissionColor3Intensity("", Range(0, 1)) = 0
        _NormalColor3TBlend("", Range(0, 1)) = 0.5
        _NormalColor3BBlend("", Range(0, 1)) = 0.5
        _NormalColor3NBlend("", Range(0, 1)) = 0.5
        [Gamma] _MetalnessColor3Blend("", Range(0, 1)) = 0
        _SmoothnessColor3Blend("", Range(0, 1)) = 0.5
        _OcclusionColor3Blend("", Range(0, 1)) = 1
        _EmissionColor3Blend("", Color) = (0, 0, 0)
        _EmissionColor3IntensityBlend("", Range(0, 1)) = 0

        _Color4("", Color) = (1, 1, 1, 1)
        _Color4Blend("", Color) = (1, 1, 1, 1)
        _NormalColor4T("", Range(-1, 1)) = 0.5
        _NormalColor4B("", Range(-1, 1)) = 0.5
        _NormalColor4N("", Range(-1, 1)) = 0.5
        [Gamma] _MetalnessColor4("", Range(0, 1)) = 0
        _SmoothnessColor4("", Range(0, 1)) = 0.5
        _OcclusionColor4("", Range(0, 1)) = 1
        _EmissionColor4("", Color) = (0, 0, 0)
        _EmissionColor4Intensity("", Range(0, 1)) = 0
        _NormalColor4TBlend("", Range(-1, 1)) = 0.5
        _NormalColor4BBlend("", Range(-1, 1)) = 0.5
        _NormalColor4NBlend("", Range(-1, 1)) = 0.5
        [Gamma] _MetalnessColor4Blend("", Range(0, 1)) = 0
        _SmoothnessColor4Blend("", Range(0, 1)) = 0.5
        _OcclusionColor4Blend("", Range(0, 1)) = 1
        _EmissionColor4Blend("", Color) = (0, 0, 0)
        _EmissionColor4IntensityBlend("", Range(0, 1)) = 0

        _HasPBR("Enable PBR", Float) = 0
        _BlendOffset ("Blend Offset", Range(0, 0.5)) = 0.25
        _BlendExponent ("Blend Exponent", Range(1, 16)) = 2
        _Rotation("", Range(0,3)) = 0
        _HasRotation("Enable Rotation", Float) = 0
        _FlipHorizontal("Flip Horizontal", Float) = 0
        _FlipVertical("Flip Vertical", Float) = 0
        [Toggle] _UseStandard("UseStandard", Float) = 1
        [Toggle] _HasColorBlend ("HasColorBlend", Float) = 0.0
        _ColorBlendUV("Color Blend UV", Vector) = (0,0,0,0)
        _ColorBlendLerp("Color Blend Lerp", Range(0, 1)) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        CGPROGRAM
        #pragma surface surf Standard vertex:vert fullforwardshadows 
        #pragma target 3.0
        #include "UnityStandardUtils.cginc"
        #pragma shader_feature_local _ HASCOLORBLEND 
        #pragma multi_compile _ STANDARD
        //#pragma require integers
        //Add a shader feature for blur
        #if !STANDARD
            #define TRIPLANAR_CORRECT_PROJECTED_U
        #endif
        //0         1          2            3
        //00 Black 01 DarkGrey 10 LightGrey 11 White
        static const float _LayerBitFloaterPos[16] = {
            0,1,2,3,
            0,1,2,3,
            0,1,2,3,
            0,1,2,3
        };
        static const float _LayerChannelPos[16] = {
            0,0,0,0,
            1,1,1,1,
            2,2,2,2,
            3,3,3,3
        };
        static const float4 _BitFloater[256] = {
            float4(0,0,0,0), 
            float4(0,0,0,1), 
            float4(0,0,0,2), 
            float4(0,0,0,3), 
            float4(0,0,1,0), 
            float4(0,0,1,1), 
            float4(0,0,1,2), 
            float4(0,0,1,3), 
            float4(0,0,2,0), 
            float4(0,0,2,1), 
            float4(0,0,2,2), 
            float4(0,0,2,3), 
            float4(0,0,3,0), 
            float4(0,0,3,1),
            float4(0,0,3,2), 
            float4(0,0,3,3), 
            float4(0,1,0,0), 
            float4(0,1,0,1), 
            float4(0,1,0,2), 
            float4(0,1,0,3), 
            float4(0,1,1,0), 
            float4(0,1,1,1), 
            float4(0,1,1,2), 
            float4(0,1,1,3), 
            float4(0,1,2,0), 
            float4(0,1,2,1), 
            float4(0,1,2,2), 
            float4(0,1,2,3), 
            float4(0,1,3,0), 
            float4(0,1,3,1), 
            float4(0,1,3,2), 
            float4(0,1,3,3), 
            float4(0,2,0,0), 
            float4(0,2,0,1), 
            float4(0,2,0,2), 
            float4(0,2,0,3), 
            float4(0,2,1,0), 
            float4(0,2,1,1), 
            float4(0,2,1,2), 
            float4(0,2,1,3), 
            float4(0,2,2,0), 
            float4(0,2,2,1), 
            float4(0,2,2,2), 
            float4(0,2,2,3), 
            float4(0,2,3,0), 
            float4(0,2,3,1), 
            float4(0,2,3,2), 
            float4(0,2,3,3), 
            float4(0,3,0,0), 
            float4(0,3,0,1), 
            float4(0,3,0,2), 
            float4(0,3,0,3), 
            float4(0,3,1,0), 
            float4(0,3,1,1), 
            float4(0,3,1,2), 
            float4(0,3,1,3), 
            float4(0,3,2,0), 
            float4(0,3,2,1), 
            float4(0,3,2,2), 
            float4(0,3,2,3), 
            float4(0,3,3,0), 
            float4(0,3,3,1), 
            float4(0,3,3,2), 
            float4(0,3,3,3), 
            float4(1,0,0,0), 
            float4(1,0,0,1), 
            float4(1,0,0,2), 
            float4(1,0,0,3), 
            float4(1,0,1,0), 
            float4(1,0,1,1), 
            float4(1,0,1,2), 
            float4(1,0,1,3), 
            float4(1,0,2,0), 
            float4(1,0,2,1), 
            float4(1,0,2,2), 
            float4(1,0,2,3), 
            float4(1,0,3,0), 
            float4(1,0,3,1), 
            float4(1,0,3,2), 
            float4(1,0,3,3), 
            float4(1,1,0,0), 
            float4(1,1,0,1), 
            float4(1,1,0,2), 
            float4(1,1,0,3), 
            float4(1,1,1,0), 
            float4(1,1,1,1), 
            float4(1,1,1,2), 
            float4(1,1,1,3), 
            float4(1,1,2,0), 
            float4(1,1,2,1), 
            float4(1,1,2,2), 
            float4(1,1,2,3), 
            float4(1,1,3,0), 
            float4(1,1,3,1), 
            float4(1,1,3,2), 
            float4(1,1,3,3), 
            float4(1,2,0,0), 
            float4(1,2,0,1), 
            float4(1,2,0,2), 
            float4(1,2,0,3), 
            float4(1,2,1,0), 
            float4(1,2,1,1), 
            float4(1,2,1,2), 
            float4(1,2,1,3), 
            float4(1,2,2,0), 
            float4(1,2,2,1), 
            float4(1,2,2,2), 
            float4(1,2,2,3), 
            float4(1,2,3,0), 
            float4(1,2,3,1), 
            float4(1,2,3,2), 
            float4(1,2,3,3), 
            float4(1,3,0,0), 
            float4(1,3,0,1), 
            float4(1,3,0,2), 
            float4(1,3,0,3), 
            float4(1,3,1,0), 
            float4(1,3,1,1), 
            float4(1,3,1,2), 
            float4(1,3,1,3), 
            float4(1,3,2,0), 
            float4(1,3,2,1), 
            float4(1,3,2,2), 
            float4(1,3,2,3), 
            float4(1,3,3,0), 
            float4(1,3,3,1), 
            float4(1,3,3,2), 
            float4(1,3,3,3), 
            float4(2,0,0,0), 
            float4(2,0,0,1), 
            float4(2,0,0,2), 
            float4(2,0,0,3), 
            float4(2,0,1,0), 
            float4(2,0,1,1), 
            float4(2,0,1,2), 
            float4(2,0,1,3), 
            float4(2,0,2,0), 
            float4(2,0,2,1), 
            float4(2,0,2,2), 
            float4(2,0,2,3), 
            float4(2,0,3,0), 
            float4(2,0,3,1), 
            float4(2,0,3,2), 
            float4(2,0,3,3), 
            float4(2,1,0,0), 
            float4(2,1,0,1), 
            float4(2,1,0,2), 
            float4(2,1,0,3), 
            float4(2,1,1,0), 
            float4(2,1,1,1), 
            float4(2,1,1,2), 
            float4(2,1,1,3), 
            float4(2,1,2,0), 
            float4(2,1,2,1), 
            float4(2,1,2,2), 
            float4(2,1,2,3), 
            float4(2,1,3,0), 
            float4(2,1,3,1), 
            float4(2,1,3,2), 
            float4(2,1,3,3), 
            float4(2,2,0,0), 
            float4(2,2,0,1), 
            float4(2,2,0,2), 
            float4(2,2,0,3), 
            float4(2,2,1,0), 
            float4(2,2,1,1), 
            float4(2,2,1,2), 
            float4(2,2,1,3), 
            float4(2,2,2,0), 
            float4(2,2,2,1), 
            float4(2,2,2,2), 
            float4(2,2,2,3), 
            float4(2,2,3,0), 
            float4(2,2,3,1), 
            float4(2,2,3,2), 
            float4(2,2,3,3), 
            float4(2,3,0,0), 
            float4(2,3,0,1), 
            float4(2,3,0,2), 
            float4(2,3,0,3), 
            float4(2,3,1,0), 
            float4(2,3,1,1), 
            float4(2,3,1,2), 
            float4(2,3,1,3), 
            float4(2,3,2,0), 
            float4(2,3,2,1), 
            float4(2,3,2,2), 
            float4(2,3,2,3), 
            float4(2,3,3,0), 
            float4(2,3,3,1), 
            float4(2,3,3,2), 
            float4(2,3,3,3), 
            float4(3,0,0,0), 
            float4(3,0,0,1), 
            float4(3,0,0,2), 
            float4(3,0,0,3), 
            float4(3,0,1,0), 
            float4(3,0,1,1), 
            float4(3,0,1,2), 
            float4(3,0,1,3), 
            float4(3,0,2,0), 
            float4(3,0,2,1), 
            float4(3,0,2,2), 
            float4(3,0,2,3), 
            float4(3,0,3,0), 
            float4(3,0,3,1), 
            float4(3,0,3,2), 
            float4(3,0,3,3), 
            float4(3,1,0,0), 
            float4(3,1,0,1), 
            float4(3,1,0,2), 
            float4(3,1,0,3), 
            float4(3,1,1,0), 
            float4(3,1,1,1), 
            float4(3,1,1,2), 
            float4(3,1,1,3), 
            float4(3,1,2,0), 
            float4(3,1,2,1), 
            float4(3,1,2,2), 
            float4(3,1,2,3), 
            float4(3,1,3,0), 
            float4(3,1,3,1), 
            float4(3,1,3,2), 
            float4(3,1,3,3), 
            float4(3,2,0,0), 
            float4(3,2,0,1), 
            float4(3,2,0,2), 
            float4(3,2,0,3), 
            float4(3,2,1,0), 
            float4(3,2,1,1), 
            float4(3,2,1,2), 
            float4(3,2,1,3), 
            float4(3,2,2,0), 
            float4(3,2,2,1), 
            float4(3,2,2,2), 
            float4(3,2,2,3), 
            float4(3,2,3,0), 
            float4(3,2,3,1), 
            float4(3,2,3,2), 
            float4(3,2,3,3), 
            float4(3,3,0,0), 
            float4(3,3,0,1), 
            float4(3,3,0,2), 
            float4(3,3,0,3), 
            float4(3,3,1,0), 
            float4(3,3,1,1), 
            float4(3,3,1,2), 
            float4(3,3,1,3), 
            float4(3,3,2,0), 
            float4(3,3,2,1), 
            float4(3,3,2,2), 
            float4(3,3,2,3), 
            float4(3,3,3,0), 
            float4(3,3,3,1), 
            float4(3,3,3,2), 
            float4(3,3,3,3) 
        };

        float _StartX;
        float _StartY;

        half _GridMult;
        half _GridSize;
        float4 _GridStart;

        half _HasPBR;
        half _HasRotation;
        half _FlipHorizontal;
        half _FlipVertical;
        half _BlendOffset;
        half _BlendExponent;
        half _Rotation;

        float _TextureStartX;
        float _TextureStartY;
        float _TextureStartLayer;

        float4 _Color1;
        float4 _Color2;
        float4 _Color3;
        float4 _Color4;
        float4 _Color1Blend;
        float4 _Color2Blend;
        float4 _Color3Blend;
        float4 _Color4Blend;

        half _NormalColor1T;
        half _NormalColor1B;
        half _NormalColor1N;
        half _NormalColor2T;
        half _NormalColor2B;
        half _NormalColor2N;
        half _NormalColor3T;
        half _NormalColor3B;
        half _NormalColor3N;
        half _NormalColor4T;
        half _NormalColor4B;
        half _NormalColor4N;

        half _MetalnessColor1;
        half _MetalnessColor2;
        half _MetalnessColor3;
        half _MetalnessColor4;

        half _SmoothnessColor1;
        half _SmoothnessColor2;
        half _SmoothnessColor3;
        half _SmoothnessColor4;

        half _OcclusionColor1;
        half _OcclusionColor2;
        half _OcclusionColor3;
        half _OcclusionColor4;
        half _OcclusionStrength;

        fixed3 _EmissionColor1;
        fixed3 _EmissionColor2;
        fixed3 _EmissionColor3;
        fixed3 _EmissionColor4;

        half _EmissionColor1Intensity;
        half _EmissionColor2Intensity;
        half _EmissionColor3Intensity;
        half _EmissionColor4Intensity;

        half _NormalColor1TBlend;
        half _NormalColor1BBlend;
        half _NormalColor1NBlend;
        half _NormalColor2TBlend;
        half _NormalColor2BBlend;
        half _NormalColor2NBlend;
        half _NormalColor3TBlend;
        half _NormalColor3BBlend;
        half _NormalColor3NBlend;
        half _NormalColor4TBlend;
        half _NormalColor4BBlend;
        half _NormalColor4NBlend;

        half _MetalnessColor1Blend;
        half _MetalnessColor2Blend;
        half _MetalnessColor3Blend;
        half _MetalnessColor4Blend;

        half _SmoothnessColor1Blend;
        half _SmoothnessColor2Blend;
        half _SmoothnessColor3Blend;
        half _SmoothnessColor4Blend;

        half _OcclusionColor1Blend;
        half _OcclusionColor2Blend;
        half _OcclusionColor3Blend;
        half _OcclusionColor4Blend;
        half _OcclusionStrengthBlend;

        fixed3 _EmissionColor1Blend;
        fixed3 _EmissionColor2Blend;
        fixed3 _EmissionColor3Blend;
        fixed3 _EmissionColor4Blend;

        half _EmissionColor1IntensityBlend;
        half _EmissionColor2IntensityBlend;
        half _EmissionColor3IntensityBlend;
        half _EmissionColor4IntensityBlend;

        half3 blend_rnm(half3 n1, half3 n2)
        {
            n1.z += 1;
            n2.xy = -n2.xy;

            return n1 * dot(n1, n2) / n1.z - n2;
        }

        half4 _Color;
        sampler2D _MainTex;
        float4 _MainTex_TexelSize;
        float4 _MainOffset;
        float4 _ColorBlendUV;
        half _ColorBlendLerp;
        half _GridStrength;

        #if STANDARD
        struct Input{float2 uv_MainTex;};
        #else
        struct Input
        {
            float3 localCoord;
            float3 localNormal;
            float3 worldPos;
            float3 worldNormal;
            INTERNAL_DATA
        };
        #endif

        fixed3 ReturnNewNormalStandard(half TheColor){
            if(TheColor == 0){return float4(_NormalColor1T,_NormalColor1B,_NormalColor1N,1);}
            else if(TheColor == 1){return float4(_NormalColor2T,_NormalColor2B,_NormalColor2N,1);}
            else if(TheColor == 2){return float4(_NormalColor3T,_NormalColor3B,_NormalColor3N,1);}
            else{return float4(_NormalColor4T,_NormalColor4B,_NormalColor4N,1);}
        }

        fixed3 ReturnNewNormal(half TheColor){
            if(TheColor == 0){return fixed3(_NormalColor1T,_NormalColor1B,_NormalColor1N);}
            else if(TheColor == 1){return fixed3(_NormalColor2T,_NormalColor2B,_NormalColor2N);}
            else if(TheColor == 2){return fixed3(_NormalColor3T,_NormalColor3B,_NormalColor3N);}
            else{return fixed3(_NormalColor4T,_NormalColor4B,_NormalColor4N);}
        }

        float4 ReturnNewColor(half TheColor){
            if(TheColor == 0){return _Color1;}
            else if(TheColor == 1){return _Color2;}
            else if(TheColor == 2){return _Color3;}
            else{return _Color4;}
        }

        half ReturnNewMetallic(half TheColor){
            if(TheColor == 0){return _MetalnessColor1;}
            else if(TheColor == 1){return _MetalnessColor2;}
            else if(TheColor == 2){return _MetalnessColor3;}
            else{return _MetalnessColor4;}
        }

        half ReturnNewSmoothness(half TheColor){
            if(TheColor == 0){return _SmoothnessColor1;}
            else if(TheColor == 1){return _SmoothnessColor2;}
            else if(TheColor == 2){return _SmoothnessColor3;}
            else{return _SmoothnessColor4;}
        }

        half ReturnNewOcclusion(half TheColor){
            if(TheColor == 0){return _OcclusionColor1;}
            else if(TheColor == 1){return _OcclusionColor2;}
            else if(TheColor == 2){return _OcclusionColor3;}
            else{return _OcclusionColor4;}
        }

        fixed3 ReturnNewEmissionColor(half TheColor){
            if(TheColor == 0){return _EmissionColor1;}
            else if(TheColor == 1){return _EmissionColor2;}
            else if(TheColor == 2){return _EmissionColor3;}
            else{return _EmissionColor4;}
        }

        half ReturnNewEmissionIntensity(half TheColor){
            if(TheColor == 0){return _EmissionColor1Intensity;}
            else if(TheColor == 1){return _EmissionColor2Intensity;}
            else if(TheColor == 2){return _EmissionColor3Intensity;}
            else{return _EmissionColor4Intensity;}
        }

        //Blend
        fixed3 ReturnNewNormalStandardBlend(half TheColor){
            if(TheColor == 0){return float4(_NormalColor1TBlend,_NormalColor1BBlend,_NormalColor1NBlend,1);}
            else if(TheColor == 1){return float4(_NormalColor2TBlend,_NormalColor2BBlend,_NormalColor2NBlend,1);}
            else if(TheColor == 2){return float4(_NormalColor3TBlend,_NormalColor3BBlend,_NormalColor3NBlend,1);}
            else{return float4(_NormalColor4TBlend,_NormalColor4BBlend,_NormalColor4NBlend,1);}
        }

        fixed3 ReturnNewNormalBlend(half TheColor){
            if(TheColor == 0){return fixed3(_NormalColor1TBlend,_NormalColor1BBlend,_NormalColor1NBlend);}
            else if(TheColor == 1){return fixed3(_NormalColor2TBlend,_NormalColor2BBlend,_NormalColor2NBlend);}
            else if(TheColor == 2){return fixed3(_NormalColor3TBlend,_NormalColor3BBlend,_NormalColor3NBlend);}
            else{return fixed3(_NormalColor4TBlend,_NormalColor4BBlend,_NormalColor4NBlend);}
        }

        float4 ReturnNewColorBlend(half TheColor){
            if(TheColor == 0){return _Color1Blend;}
            else if(TheColor == 1){return _Color2Blend;}
            else if(TheColor == 2){return _Color3Blend;}
            else{return _Color4Blend;}
        }

        half ReturnNewMetallicBlend(half TheColor){
            if(TheColor == 0){return _MetalnessColor1Blend;}
            else if(TheColor == 1){return _MetalnessColor2Blend;}
            else if(TheColor == 2){return _MetalnessColor3Blend;}
            else{return _MetalnessColor4Blend;}
        }

        half ReturnNewSmoothnessBlend(half TheColor){
            if(TheColor == 0){return _SmoothnessColor1Blend;}
            else if(TheColor == 1){return _SmoothnessColor2Blend;}
            else if(TheColor == 2){return _SmoothnessColor3Blend;}
            else{return _SmoothnessColor4Blend;}
        }

        half ReturnNewOcclusionBlend(half TheColor){
            if(TheColor == 0){return _OcclusionColor1Blend;}
            else if(TheColor == 1){return _OcclusionColor2Blend;}
            else if(TheColor == 2){return _OcclusionColor3Blend;}
            else{return _OcclusionColor4Blend;}
        }

        fixed3 ReturnNewEmissionColorBlend(half TheColor){
            if(TheColor == 0){return _EmissionColor1Blend;}
            else if(TheColor == 1){return _EmissionColor2Blend;}
            else if(TheColor == 2){return _EmissionColor3Blend;}
            else{return _EmissionColor4Blend;}
        }

        half ReturnNewEmissionIntensityBlend(half TheColor){
            if(TheColor == 0){return _EmissionColor1IntensityBlend;}
            else if(TheColor == 1){return _EmissionColor2IntensityBlend;}
            else if(TheColor == 2){return _EmissionColor3IntensityBlend;}
            else{return _EmissionColor4IntensityBlend;}
        }


        #if STANDARD

        float2 ReturnNewRotation(float2 xy){
            if(_Rotation == 1){ //90 Clockwise
                return float2(-xy.y,xy.x);
            }
            else if(_Rotation == 2){ //180 Clockwise
                return float2(-xy.x,-xy.y);
            }
            else if(_Rotation == 3){ //270 Clockwise
                return float2(xy.y,-xy.x);
            }
            return xy;
        }

        #else

        float3 HeightToNormal(float height, float3 normal, float3 pos)
        {
            float3 worldDirivativeX = ddx(pos);
            float3 worldDirivativeY = ddy(pos);
            float3 crossX = cross(normal, worldDirivativeX);
            float3 crossY = cross(normal, worldDirivativeY);
            float3 d = abs(dot(crossY, worldDirivativeX));
            float3 inToNormal = ((((height + ddx(height)) - height) * crossY) + (((height + ddy(height)) - height) * crossX)) * sign(d);
            inToNormal.y *= -1.0;
            return normalize((d * normal) - inToNormal);
        }

        float3 WorldToTangentNormalVector(Input IN, float3 normal) {
            float3 t2w0 = WorldNormalVector(IN, float3(1,0,0));
            float3 t2w1 = WorldNormalVector(IN, float3(0,1,0));
            float3 t2w2 = WorldNormalVector(IN, float3(0,0,1));
            float3x3 t2w = float3x3(t2w0, t2w1, t2w2);
            return normalize(mul(t2w, normal));
        }

        struct TriplanarUV {
	        float2 x, y, z;
        };

        float2 ReturnNewRotationX(float2 zy){
            if(_Rotation == 1){ //90 Clockwise
                return float2(zy.y,-zy.x);
            }
            else if(_Rotation == 2){ //180 Clockwise
                return float2(-zy.x,-zy.y);
            }
            else if(_Rotation == 3){ //270 Clockwise
                return float2(-zy.y,zy.x);
            }
            return zy;
        }

        float2 ReturnNewRotationY(float2 xz){
            if(_Rotation == 1){ //90 Clockwise
                return float2(-xz.y,xz.x);
            }
            else if(_Rotation == 2){ //180 Clockwise
                return float2(-xz.x,-xz.y);
            }
            else if(_Rotation == 3){ //270 Clockwise
                return float2(xz.y,-xz.x);
            }
            return xz;
        }

        float2 ReturnNewRotationZ(float2 xy){
            if(_Rotation == 1){ //90 Clockwise
                return float2(-xy.y,xy.x);
            }
            else if(_Rotation == 2){ //180 Clockwise
                return float2(-xy.x,-xy.y);
            }
            else if(_Rotation == 3){ //270 Clockwise
                return float2(xy.y,-xy.x);
            }
            return xy;
        }

        #endif
        
        #if STANDARD
        void vert(inout appdata_full v){}
        #else
        void vert(inout appdata_full v, out Input data)
        {
            UNITY_INITIALIZE_OUTPUT(Input, data);
            data.localCoord = v.vertex.xyz;
            data.localNormal = v.normal.xyz;
        }
        #endif

        float2 returnFullTileUV(float2 MainUV){
            //64x64 tile stretched to 0 to 1 UV
            //Vector4(1 / width, 1 / height, width, height)
            //UV / Squaresize, if > 1 subtract SquareSize
            float UpdatedU = MainUV.x;
            float UpdatedV = MainUV.y;
            float SquareSize = _GridSize;
            float SquareMult = _GridMult;

            if(floor(UpdatedU / SquareSize) >= 1){UpdatedU = UpdatedU - (floor(UpdatedU / SquareSize)*SquareSize); }
            if(floor(UpdatedV / SquareSize) >= 1){UpdatedV = UpdatedV - (floor(UpdatedV / SquareSize)*SquareSize); }
            float HalfTexel = _MainTex_TexelSize * 0.5f;
            if(_FlipHorizontal){UpdatedU = (SquareSize - UpdatedU);}
            if(_FlipVertical){UpdatedV = SquareSize - UpdatedV;}
            float floatx = floor(64 * UpdatedU * SquareMult);
            float floaty = floor(64 * UpdatedV * SquareMult);
            if(_HasRotation){
                float fx = floatx; float fy = floaty; float sx = 63 * SquareSize * SquareMult;
                if(_Rotation == 1){ //90 Clockwise
                    UpdatedV = SquareSize - UpdatedV;
                    floatx = floor(64 * UpdatedV * SquareMult); floaty = floor(64 * UpdatedU * SquareMult); //and flipvertical
                }
                else if(_Rotation == 2){ //180 Clockwise
                    floatx = sx - fx; floaty = sx - fy;
                }
                else if(_Rotation == 3){ //270 Clockwise
                    UpdatedV = SquareSize - UpdatedV;
                floatx = sx - floor(64 * UpdatedV * SquareMult); floaty = sx - floor(64 * UpdatedU * SquareMult);;
                }
            }
            return float2(_GridStart.x*_MainTex_TexelSize.x + floatx *_MainTex_TexelSize.x + HalfTexel,_GridStart.y*_MainTex_TexelSize.y + floaty *_MainTex_TexelSize.y + HalfTexel);
        }

        float4 ReturnNewMultiColor(half TheColor){
            if(TheColor == 0){return _Color1;}
            else if(TheColor == 1){return _Color2;}
            else if(TheColor == 2){return _Color3;}
            else{return _Color4;}
        }

        float4 ReturnNewMultiColorBlend(half TheColor){
            if(TheColor == 0){return _Color1Blend;}
            else if(TheColor == 1){return _Color2Blend;}
            else if(TheColor == 2){return _Color3Blend;}
            else{return _Color4Blend;}
        }

        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            #if STANDARD

                #if HASCOLORBLEND
                    half4 cxa = tex2D (_MainTex, returnFullTileUV(IN.uv_MainTex * _GridStrength * _MainOffset.xy + _MainOffset.zw));
                    half cn = _BitFloater[cxa[_LayerChannelPos[_GridStart.z]] * 255][_LayerBitFloaterPos[_GridStart.z]];
                    half4 cx = ReturnNewMultiColor(cn);
                    half4 cxa2 = tex2D (_MainTex, returnFullTileUV(IN.uv_MainTex * _GridStrength * _ColorBlendUV.xy + _ColorBlendUV.zw));
                    half cn2 = _BitFloater[cxa2[_LayerChannelPos[_GridStart.z]] * 255][_LayerBitFloaterPos[_GridStart.z]];
                    half4 cx2 = ReturnNewMultiColorBlend(cn2);
                    o.Albedo = lerp(cx, cx2, _ColorBlendLerp);
                    o.Alpha = 1;
                   if(_HasPBR){
                        o.Metallic = lerp(ReturnNewMetallic(cn), ReturnNewMetallicBlend(cn2),_ColorBlendLerp);;
                        o.Smoothness = lerp(ReturnNewSmoothness(cn), ReturnNewSmoothnessBlend(cn2), _ColorBlendLerp);;
                        o.Occlusion = lerp(ReturnNewOcclusion(cn) * _OcclusionStrength,ReturnNewOcclusionBlend(cn2) * _OcclusionStrengthBlend,_ColorBlendLerp);
                        o.Emission = lerp(ReturnNewEmissionColor(cn) * ReturnNewEmissionIntensity(cn), ReturnNewEmissionColorBlend(cn2) * ReturnNewEmissionIntensityBlend(cn2), _ColorBlendLerp);;
                        o.Normal = lerp(ReturnNewNormal(cn),ReturnNewNormalBlend(cn2),_ColorBlendLerp);
                   }
                #else
                    half4 cxa = tex2D (_MainTex, returnFullTileUV(IN.uv_MainTex * _GridStrength * _MainOffset.xy + _MainOffset.zw));              
                    half cn = _BitFloater[cxa[_LayerChannelPos[_GridStart.z]] * 255][_LayerBitFloaterPos[_GridStart.z]];
                    half4 cx = ReturnNewMultiColor(cn);
                    o.Albedo = cx;
                    o.Alpha = 1;
                   if(_HasPBR){    
                        o.Metallic = ReturnNewMetallic(cn);
                        o.Smoothness = ReturnNewSmoothness(cn);
                        o.Occlusion = ReturnNewOcclusion(cn);
                        o.Emission = ReturnNewEmissionColor(cn) * ReturnNewEmissionIntensity(cn); 
                        o.Normal = ReturnNewNormal(cn);
                    }
                #endif
           #else //Triplanar
                #if HASCOLORBLEND
                    float3 BlendedNormal = abs(IN.localNormal);
                    BlendedNormal = saturate(BlendedNormal - _BlendOffset);
                    BlendedNormal = pow(BlendedNormal, _BlendExponent);
                    float3 bf = normalize(BlendedNormal);
                    bf /= dot(bf, (float3)1);

                    float2 dx = frac(IN.localCoord.zy * _GridStrength * _MainOffset.xy + _MainOffset.zw);
                    float2 dy = frac(IN.localCoord.xz * _GridStrength * _MainOffset.xy + _MainOffset.zw);
                    float2 dz = frac(IN.localCoord.xy * _GridStrength * _MainOffset.xy + _MainOffset.zw);
                    float2 dx2 = frac(IN.localCoord.zy * _GridStrength * _ColorBlendUV.xy + _ColorBlendUV.zw);
                    float2 dy2 = frac(IN.localCoord.xz * _GridStrength * _ColorBlendUV.xy + _ColorBlendUV.zw);
                    float2 dz2 = frac(IN.localCoord.xy * _GridStrength * _ColorBlendUV.xy + _ColorBlendUV.zw);

                    dy = float2(1-dy.x,1-dy.y);
                    dz = float2(1-dz.x,dz.y);
                    dy2 = float2(1-dy2.x,1-dy2.y);
                    dz2 = float2(1-dz2.x,dz2.y);

                    float4 dxa = tex2D (_MainTex, returnFullTileUV(dx));
                    float4 dya = tex2D (_MainTex, returnFullTileUV(dy));
                    float4 dza = tex2D (_MainTex, returnFullTileUV(dz));
                    float4 dxa2 = tex2D (_MainTex, returnFullTileUV(dx2));
                    float4 dya2 = tex2D (_MainTex, returnFullTileUV(dy2));
                    float4 dza2 = tex2D (_MainTex, returnFullTileUV(dz2));

                    half cnx = _BitFloater[dxa[_LayerChannelPos[_GridStart.z]] * 255][_LayerBitFloaterPos[_GridStart.z]];
                    half cny = _BitFloater[dya[_LayerChannelPos[_GridStart.z]] * 255][_LayerBitFloaterPos[_GridStart.z]];
                    half cnz = _BitFloater[dza[_LayerChannelPos[_GridStart.z]] * 255][_LayerBitFloaterPos[_GridStart.z]];
                    half cnx2 = _BitFloater[dxa2[_LayerChannelPos[_GridStart.z]] * 255][_LayerBitFloaterPos[_GridStart.z]];
                    half cny2 = _BitFloater[dya2[_LayerChannelPos[_GridStart.z]] * 255][_LayerBitFloaterPos[_GridStart.z]];
                    half cnz2 = _BitFloater[dza2[_LayerChannelPos[_GridStart.z]] * 255][_LayerBitFloaterPos[_GridStart.z]];

                    half4 cx = ReturnNewMultiColor(cnx) * bf.x;
                    half4 cy = ReturnNewMultiColor(cny) * bf.y;
                    half4 cz = ReturnNewMultiColor(cnz) * bf.z;
                    half4 cx2 = ReturnNewMultiColorBlend(cnx2) * bf.x;
                    half4 cy2 = ReturnNewMultiColorBlend(cny2) * bf.y;
                    half4 cz2 = ReturnNewMultiColorBlend(cnz2) * bf.z;

                    half4 color = lerp((cx + cy + cz) * _Color, (cx2 + cy2 + cz2) * _Color, _ColorBlendLerp);
                    o.Albedo = color.rgb;
                    o.Alpha = 1;
                    if(_HasPBR){
                        IN.worldNormal = WorldNormalVector(IN, float3(0,0,1));
                        half3 triblend = saturate(pow(IN.worldNormal, 4));
                        triblend /= max(dot(triblend, half3(1,1,1)), 0.0002);
                        half3 axisSign = IN.worldNormal < 0 ? -1 : 1;                                                          
                        half3 tnormalX = ReturnNewNormal(cnx);
                        half3 tnormalY = ReturnNewNormal(cny);
                        half3 tnormalZ = ReturnNewNormal(cnz);
                        half3 tnormalX2 = ReturnNewNormalBlend(cnx2);
                        half3 tnormalY2 = ReturnNewNormalBlend(cny2);
                        half3 tnormalZ2 = ReturnNewNormalBlend(cnz2);
                        #if defined(TRIPLANAR_CORRECT_PROJECTED_U)
                            tnormalX.x *= axisSign.x;
                            tnormalY.x *= axisSign.y;
                            tnormalZ.x *= -axisSign.z;
                            tnormalX2.x *= axisSign.x;
                            tnormalY2.x *= axisSign.y;
                            tnormalZ2.x *= -axisSign.z;
                        #endif
                        half3 absVertNormal = abs(IN.worldNormal);
                        tnormalX = blend_rnm(half3(IN.worldNormal.zy, absVertNormal.x), tnormalX);
                        tnormalY = blend_rnm(half3(IN.worldNormal.xz, absVertNormal.y), tnormalY);
                        tnormalZ = blend_rnm(half3(IN.worldNormal.xy, absVertNormal.z), tnormalZ);
                        tnormalX2 = blend_rnm(half3(IN.worldNormal.zy, absVertNormal.x), tnormalX2);
                        tnormalY2 = blend_rnm(half3(IN.worldNormal.xz, absVertNormal.y), tnormalY2);
                        tnormalZ2 = blend_rnm(half3(IN.worldNormal.xy, absVertNormal.z), tnormalZ2);
                        tnormalX.z *= axisSign.x;
                        tnormalY.z *= axisSign.y;
                        tnormalZ.z *= axisSign.z; 
                        tnormalX2.z *= axisSign.x;
                        tnormalY2.z *= axisSign.y;
                        tnormalZ2.z *= axisSign.z; 
                        half3 worldNormal = normalize(
                            tnormalX.zyx * triblend.x +
                            tnormalY.xzy * triblend.y +
                            tnormalZ.xyz * triblend.z
                            );
                        half3 worldNormal2 = normalize(
                            tnormalX2.zyx * triblend.x +
                            tnormalY2.xzy * triblend.y +
                            tnormalZ2.xyz * triblend.z
                            );
                        o.Metallic = lerp(
                            ReturnNewMetallic(cnx) * bf.x + ReturnNewMetallic(cny) * bf.y + ReturnNewMetallic(cnz) * bf.z,
                            ReturnNewMetallicBlend(cnx2) * bf.x + ReturnNewMetallicBlend(cny2) * bf.y + ReturnNewMetallicBlend(cnz2) * bf.z,
                            _ColorBlendLerp
                        );
                        o.Smoothness = lerp(
                            ReturnNewSmoothness(cnx) * bf.x + ReturnNewSmoothness(cny) * bf.y + ReturnNewSmoothness(cnz) * bf.z,
                            ReturnNewSmoothnessBlend(cnx2) * bf.x + ReturnNewSmoothnessBlend(cny2) * bf.y + ReturnNewSmoothnessBlend(cnz2) * bf.z,
                            _ColorBlendLerp
                            );
                        o.Occlusion = lerp(
                            LerpOneTo(ReturnNewOcclusion(cnx) * bf.x + ReturnNewOcclusion(cny) * bf.y + ReturnNewOcclusion(cnz) * bf.z, _OcclusionStrength),
                            LerpOneTo(ReturnNewOcclusionBlend(cnx2) * bf.x + ReturnNewOcclusionBlend(cny2) * bf.y + ReturnNewOcclusionBlend(cnz2) * bf.z, _OcclusionStrengthBlend),
                            _ColorBlendLerp
                            );
                        o.Emission = lerp(
                            ReturnNewEmissionColor(cnx) * bf.x * ReturnNewEmissionIntensity(cnx) 
                            + ReturnNewEmissionColor(cny) * bf.y * ReturnNewEmissionIntensity(cny)
                            + ReturnNewEmissionColor(cnz) * bf.z * ReturnNewEmissionIntensity(cnz),
                            ReturnNewEmissionColorBlend(cnx2) * bf.x * ReturnNewEmissionIntensityBlend(cnx2) 
                            + ReturnNewEmissionColorBlend(cny2) * bf.y * ReturnNewEmissionIntensityBlend(cny2)
                            + ReturnNewEmissionColorBlend(cnz2) * bf.z * ReturnNewEmissionIntensityBlend(cnz2),
                            _ColorBlendLerp
                            );
                        o.Normal = WorldToTangentNormalVector(IN, lerp(worldNormal,worldNormal2,_ColorBlendLerp));
                    }
                #else
                    float3 BlendedNormal = abs(IN.localNormal);
                    BlendedNormal = saturate(BlendedNormal - _BlendOffset);
                    BlendedNormal = pow(BlendedNormal, _BlendExponent);
                    float3 bf = normalize(BlendedNormal);
                    bf /= dot(bf, (float3)1);

                    float2 dx = frac(IN.localCoord.zy * _GridStrength * _MainOffset.xy + _MainOffset.zw);
                    float2 dy = frac(IN.localCoord.xz * _GridStrength * _MainOffset.xy + _MainOffset.zw);
                    float2 dz = frac(IN.localCoord.xy * _GridStrength * _MainOffset.xy + _MainOffset.zw);

                    dy = float2(1-dy.x,1-dy.y);
                    dz = float2(1-dz.x,dz.y);

                    float4 dxa = tex2D (_MainTex, returnFullTileUV(dx));
                    float4 dya = tex2D (_MainTex, returnFullTileUV(dy));
                    float4 dza = tex2D (_MainTex, returnFullTileUV(dz));

                    half cnx = _BitFloater[dxa[_LayerChannelPos[_GridStart.z]] * 255][_LayerBitFloaterPos[_GridStart.z]];
                    half cny = _BitFloater[dya[_LayerChannelPos[_GridStart.z]] * 255][_LayerBitFloaterPos[_GridStart.z]];
                    half cnz = _BitFloater[dza[_LayerChannelPos[_GridStart.z]] * 255][_LayerBitFloaterPos[_GridStart.z]];

                    half4 cx = ReturnNewMultiColor(cnx) * bf.x;
                    half4 cy = ReturnNewMultiColor(cny) * bf.y;
                    half4 cz = ReturnNewMultiColor(cnz) * bf.z;

                    half4 color = (cx + cy + cz) * _Color;
                    o.Albedo = color.rgb;
                    o.Alpha = color.a;
                   if(_HasPBR){
                        IN.worldNormal = WorldNormalVector(IN, float3(0,0,1));
                        half3 triblend = saturate(pow(IN.worldNormal, 4));
                        triblend /= max(dot(triblend, half3(1,1,1)), 0.0002);
                        half3 axisSign = IN.worldNormal < 0 ? -1 : 1;                                                      
                        half3 tnormalX = ReturnNewNormal(cnx);
                        half3 tnormalY = ReturnNewNormal(cny);
                        half3 tnormalZ = ReturnNewNormal(cnz);
                        #if defined(TRIPLANAR_CORRECT_PROJECTED_U)
                            tnormalX.x *= axisSign.x;
                            tnormalY.x *= axisSign.y;
                            tnormalZ.x *= -axisSign.z;
                        #endif
                        half3 absVertNormal = abs(IN.worldNormal);
                        tnormalX = blend_rnm(half3(IN.worldNormal.zy, absVertNormal.x), tnormalX);
                        tnormalY = blend_rnm(half3(IN.worldNormal.xz, absVertNormal.y), tnormalY);
                        tnormalZ = blend_rnm(half3(IN.worldNormal.xy, absVertNormal.z), tnormalZ);
                        tnormalX.z *= axisSign.x;
                        tnormalY.z *= axisSign.y;
                        tnormalZ.z *= axisSign.z; 
                        half3 worldNormal = normalize(
                            tnormalX.zyx * triblend.x +
                            tnormalY.xzy * triblend.y +
                            tnormalZ.xyz * triblend.z
                            );
                        o.Metallic = ReturnNewMetallic(cnx) * bf.x + ReturnNewMetallic(cny) * bf.y + ReturnNewMetallic(cnz) * bf.z;
                        o.Smoothness = ReturnNewSmoothness(cnx) * bf.x + ReturnNewSmoothness(cny) * bf.y + ReturnNewSmoothness(cnz) * bf.z;;
                        o.Occlusion = LerpOneTo(ReturnNewOcclusion(cnx) * bf.x + ReturnNewOcclusion(cny) * bf.y + ReturnNewOcclusion(cnz) * bf.z, _OcclusionStrength);;                   
                        o.Emission = ReturnNewEmissionColor(cnx) * bf.x * ReturnNewEmissionIntensity(cnx) 
                        + ReturnNewEmissionColor(cny) * bf.y * ReturnNewEmissionIntensity(cny)
                        + ReturnNewEmissionColor(cnz) * bf.z * ReturnNewEmissionIntensity(cnz);
                        o.Normal = WorldToTangentNormalVector(IN, worldNormal);
                   }
                #endif           
           #endif
        }
        ENDCG
    }
    CustomEditor "MicroTexturesStandardTileInspectorFree"
}
