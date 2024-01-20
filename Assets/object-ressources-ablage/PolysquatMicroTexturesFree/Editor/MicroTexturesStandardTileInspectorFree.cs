//© 2023 Polysquat Studios LLC
using UnityEngine;
using UnityEditor;

public class MicroTexturesStandardTileInspectorFree : ShaderGUI
{
    bool _initialized;
    Color Color1Label = new Color(0, 0, 0, 1);
    Color Color2Label = new Color(0.31373f, 0.31373f, 0.31373f, 1);
    Color Color3Label = new Color(0.62745f, 0.62745f, 0.62745f, 1);
    Color Color4Label = new Color(1, 1, 1, 1);

    private string EnablePBRStr = "Enable PBR";
    private bool togglePBR;

    //Cached Values
    private MaterialProperty[] CachedProps;
    private Vector4 MainOffset;
    private Color ColorC1;
    private Color ColorC2;
    private Color ColorC3;
    private Color ColorC4;
    private Color ColorC1Blend;
    private Color ColorC2Blend;
    private Color ColorC3Blend;
    private Color ColorC4Blend;
    //private float HeightScale;
    private Vector3 NormalC1V3;
    private Vector3 NormalC2V3;
    private Vector3 NormalC3V3;
    private Vector3 NormalC4V3;
    private float MetalnessC1;
    private float MetalnessC2;
    private float MetalnessC3;
    private float MetalnessC4;
    private float SmoothnessC1;
    private float SmoothnessC2;
    private float SmoothnessC3;
    private float SmoothnessC4;
    private float OcclusionC1;
    private float OcclusionC2;
    private float OcclusionC3;
    private float OcclusionC4;
    private float OcclusionStrength;
    private Color EmissionC1;
    private Color EmissionC2;
    private Color EmissionC3;
    private Color EmissionC4;
    private float EmissionC1Intensity;
    private float EmissionC2Intensity;
    private float EmissionC3Intensity;
    private float EmissionC4Intensity;
    private Vector3 NormalC1V3Blend;
    private Vector3 NormalC2V3Blend;
    private Vector3 NormalC3V3Blend;
    private Vector3 NormalC4V3Blend;
    private float MetalnessC1Blend;
    private float MetalnessC2Blend;
    private float MetalnessC3Blend;
    private float MetalnessC4Blend;
    private float SmoothnessC1Blend;
    private float SmoothnessC2Blend;
    private float SmoothnessC3Blend;
    private float SmoothnessC4Blend;
    private float OcclusionC1Blend;
    private float OcclusionC2Blend;
    private float OcclusionC3Blend;
    private float OcclusionC4Blend;
    private float OcclusionStrengthBlend;
    private Color EmissionC1Blend;
    private Color EmissionC2Blend;
    private Color EmissionC3Blend;
    private Color EmissionC4Blend;
    private float EmissionC1IntensityBlend;
    private float EmissionC2IntensityBlend;
    private float EmissionC3IntensityBlend;
    private float EmissionC4IntensityBlend;
    private bool showPBRNormal;
    private string PBRNormalFoldStr = "Normal";
    private bool showPBRMetalness;
    private string PBRMetalnessFoldStr = "Metalness";
    private bool showPBRSmoothness;
    private string PBRSmoothnessFoldStr = "Smoothness";
    private bool showPBROcclusion;
    private string PBROcclusionFoldStr = "Occlusion";
    private bool showPBREmission;
    private string PBREmissionFoldStr = "Emission";
    private bool showPBRNormalBlend;
    private string PBRNormalFoldStrBlend = "Normal Blend";
    private bool showPBRMetalnessBlend;
    private string PBRMetalnessFoldStrBlend = "Metalness Blend";
    private bool showPBRSmoothnessBlend;
    private string PBRSmoothnessFoldStrBlend = "Smoothness Blend";
    private bool showPBROcclusionBlend;
    private string PBROcclusionFoldStrBlend = "Occlusion Blend";
    private bool showPBREmissionBlend;
    private string PBREmissionFoldStrBlend = "Emission Blend";
    private float BlendOffset;
    private float BlendExponent;
    private bool showColorTools = false;
    private bool showColorToolsBlend = false;
    private string ColorToolsFoldStr = "Color Tools";
    private Color LerpC1 = Color.black;
    private Color LerpC2 = Color.white;
    private Color LerpC1Blend = Color.black;
    private Color LerpC2Blend = Color.white;
    private float Rotation;
    private bool FlipHorizontal;
    private bool FlipVertical;
    private int SelectedShaderType = 0; //0 Standard 1 Triplanar
    private string[] SelectedShaderType_str = new string[] { "Standard", "Triplanar" };
    private int[] SelectedShaderType_int = { 0, 1 };
    private int SelectedShaderEffect = 0; //0 None 1 UV Color Blend
    private string[] SelectedShaderEffect_str = new string[] { "None", "UV Color Blend" };
    private int[] SelectedShaderEffect_int = { 0, 1 };
    private Vector4 ColorBlendUV = new Vector4(1,1,0,0);
    private float ColorBlendLerp;
    private float GridStrength;
    private int GridSize;
    private string[] GridSize_str = new string[] {"1", "2", "4", "8", "16" };
    private int[] GridSize_int = { 1, 2, 4, 8, 16 };
    private int TextureNumber = 1;
    //0 to 31, 0 to 31, Layer 0 to 15
    private int TextureStartX;
    private int TextureStartY;
    private int TextureStartLayer;
    private string[] TextureStart_str = new string[] {"0","1"};
    private int[] TextureStart_int = {0,1};
    private int[] TextureFind = {0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31 };
    private string[] TextureStartLayer_str = new string[] {"0","1","2","3","4","5","6","7","8","9","10","11","12","13","14","15"};
    private int[] TextureStartLayer_int = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15};

    //GUISpacing Values
    private int ArrowWidth = 25;
    private int ColorLabelWidth = 50;
    private int ColorFieldWidth = 50;
    private int ColorLabelWidthBlend = 75;
    private string EmptyLabel = "";
    private int EmptyLabelSize = 15;

    //Rotation
    int RotationInt = 0;
    string[] RotationInt_str = new string[] { "0°", "90°", "180°", "270°"};
    int[] RotationInt_int = {0,1,2,3};

    public override void OnGUI(MaterialEditor editor, MaterialProperty[] props)
    {
        if (!_initialized) { InitShader(props); _initialized = true; }

        EditorGUI.BeginChangeCheck();
        SelectedShaderType = EditorGUILayout.IntPopup("ShaderType: ", SelectedShaderType, SelectedShaderType_str, SelectedShaderType_int);
        if (EditorGUI.EndChangeCheck()) { UpdateSelectedShaderType((Material)editor.target); }

        EditorGUI.BeginChangeCheck();
        GridSize = EditorGUILayout.IntPopup("Grid Size: ", GridSize, GridSize_str, GridSize_int);
        if (EditorGUI.EndChangeCheck()) { UpdateGridSize(); }

        EditorGUI.BeginChangeCheck();
        GridStrength = EditorGUILayout.FloatField("Grid Strength", GridStrength);
        if (EditorGUI.EndChangeCheck()) { UpdateGridStrength(); }

        EditorGUILayout.BeginHorizontal();
        EditorGUI.BeginChangeCheck();
        TextureNumber = EditorGUILayout.IntField("TextureNumber: ", TextureNumber, GUILayout.Width(180));
        if (EditorGUI.EndChangeCheck()) { UpdateTextureNumber(); }
        if (GUILayout.Button("Random", GUILayout.Width(60))) { RandomTextureNumber(); }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Start X:", GUILayout.Width(50));
        EditorGUI.BeginChangeCheck();
        TextureStartX = EditorGUILayout.IntPopup(TextureStartX, TextureStart_str, TextureStart_int, GUILayout.Width(40));
        if (EditorGUI.EndChangeCheck()) { UpdateTextureStart(); }
        EditorGUILayout.LabelField("Start Y:", GUILayout.Width(50));
        EditorGUI.BeginChangeCheck();
        TextureStartY = EditorGUILayout.IntPopup(TextureStartY, TextureStart_str, TextureStart_int, GUILayout.Width(40));
        if (EditorGUI.EndChangeCheck()) { UpdateTextureStart(); }
        EditorGUILayout.LabelField("Layer:", GUILayout.Width(45));
        EditorGUI.BeginChangeCheck();
        TextureStartLayer = EditorGUILayout.IntPopup(TextureStartLayer, TextureStartLayer_str, TextureStartLayer_int, GUILayout.Width(40));
        if (EditorGUI.EndChangeCheck()) { UpdateTextureStart(); }
        EditorGUILayout.EndHorizontal();

        EditorGUI.BeginChangeCheck();
        MainOffset = EditorGUILayout.Vector4Field("Texture Offset", MainOffset);
        if (EditorGUI.EndChangeCheck()) { UpdateMainOffset(); }

        EditorGUI.BeginChangeCheck();
        RotationInt = EditorGUILayout.IntPopup("Rotation: ", RotationInt, RotationInt_str, RotationInt_int);
        if (EditorGUI.EndChangeCheck()) { UpdateRotation(); }

        EditorGUILayout.BeginHorizontal();
        EditorGUI.BeginChangeCheck();
        FlipHorizontal = EditorGUILayout.Toggle("Flip Horizontal", FlipHorizontal);
        FlipVertical = EditorGUILayout.Toggle("Flip Vertical", FlipVertical);
        if (EditorGUI.EndChangeCheck()) { UpdateFlip(); }
        EditorGUILayout.EndHorizontal();

        if (SelectedShaderType == 1)
        {
            EditorGUI.BeginChangeCheck();
            BlendOffset = EditorGUILayout.FloatField("Blend Offset", BlendOffset);
            if (EditorGUI.EndChangeCheck()) { UpdateBlendOffset(); }

            EditorGUI.BeginChangeCheck();
            BlendExponent = EditorGUILayout.FloatField("Blend Exponent", BlendExponent);
            if (EditorGUI.EndChangeCheck()) { UpdateBlendExponent(); }
        }

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Color1", GUILayout.Width(ColorLabelWidth));
        EditorGUI.BeginDisabledGroup(true);
        Color1Label = EditorGUILayout.ColorField(Color1Label, GUILayout.Width(ColorFieldWidth));
        EditorGUI.EndDisabledGroup();
        EditorGUILayout.LabelField("->", GUILayout.Width(ArrowWidth));
        EditorGUI.BeginChangeCheck();
        ColorC1 = EditorGUILayout.ColorField(ColorC1, GUILayout.Width(ColorFieldWidth));
        if (EditorGUI.EndChangeCheck()) { UpdateColor1(); }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Color2", GUILayout.Width(ColorLabelWidth));
        EditorGUI.BeginDisabledGroup(true);
        Color2Label = EditorGUILayout.ColorField(Color2Label, GUILayout.Width(ColorFieldWidth));
        EditorGUI.EndDisabledGroup();
        EditorGUILayout.LabelField("->", GUILayout.Width(ArrowWidth));
        EditorGUI.BeginChangeCheck();
        ColorC2 = EditorGUILayout.ColorField(ColorC2, GUILayout.Width(ColorFieldWidth));
        if (EditorGUI.EndChangeCheck()) { UpdateColor2(); }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Color3", GUILayout.Width(ColorLabelWidth));
        EditorGUI.BeginDisabledGroup(true);
        Color3Label = EditorGUILayout.ColorField(Color3Label, GUILayout.Width(ColorFieldWidth));
        EditorGUI.EndDisabledGroup();
        EditorGUILayout.LabelField("->", GUILayout.Width(ArrowWidth));
        EditorGUI.BeginChangeCheck();
        ColorC3 = EditorGUILayout.ColorField(ColorC3, GUILayout.Width(ColorFieldWidth));
        if (EditorGUI.EndChangeCheck()) { UpdateColor3(); }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Color4", GUILayout.Width(ColorLabelWidth));
        EditorGUI.BeginDisabledGroup(true);
        Color4Label = EditorGUILayout.ColorField(Color4Label, GUILayout.Width(ColorFieldWidth));
        EditorGUI.EndDisabledGroup();
        EditorGUILayout.LabelField("->", GUILayout.Width(ArrowWidth));
        EditorGUI.BeginChangeCheck();
        ColorC4 = EditorGUILayout.ColorField(ColorC4, GUILayout.Width(ColorFieldWidth));
        if (EditorGUI.EndChangeCheck()) { UpdateColor4(); }
        EditorGUILayout.EndHorizontal();

        showColorTools = EditorGUILayout.BeginFoldoutHeaderGroup(showColorTools, ColorToolsFoldStr);
        if (showColorTools)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
            LerpC1 = EditorGUILayout.ColorField(LerpC1, GUILayout.Width(ColorFieldWidth));
            EditorGUILayout.LabelField("-Lerp->", GUILayout.Width(48));
            LerpC2 = EditorGUILayout.ColorField(LerpC2, GUILayout.Width(ColorFieldWidth));
            if (GUILayout.Button("()", GUILayout.Width(20)))
            {
                ReverseLerpColors();
            }
            if (GUILayout.Button("Apply", GUILayout.Width(50)))
            {
                ApplyLerpColors();
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
            if (GUILayout.Button("Move Up", GUILayout.Width(90)))
            {
                MoveColorsUp();
            }
            if (GUILayout.Button("Move Down", GUILayout.Width(90)))
            {
                MoveColorsDown();
            }
            if (GUILayout.Button("Random", GUILayout.Width(60)))
            {
                MoveColorsRandom();
            }
            if (GUILayout.Button("Default", GUILayout.Width(60)))
            {
                MoveColorsDefault();
            }
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        //editor.ColorProperty(FindProperty("_TestColor", props), "");
        //editor.ShaderProperty(FindProperty("_TestColor", props), "");

        //togglePBR = (FindProperty("_HasPBR", props).floatValue != 0.0f);

        EditorGUI.BeginChangeCheck();
        SelectedShaderEffect = EditorGUILayout.IntPopup("Shader Effects: ", SelectedShaderEffect, SelectedShaderEffect_str, SelectedShaderEffect_int);
        if (EditorGUI.EndChangeCheck()) { UpdateSelectedShaderEffect((Material)editor.target); }

        if(SelectedShaderEffect == 1)
        {
            EditorGUI.BeginChangeCheck();
            ColorBlendUV = EditorGUILayout.Vector4Field("Color Blend UV:", ColorBlendUV);
            if (EditorGUI.EndChangeCheck()) { UpdateColorBlendUV(); }

            EditorGUI.BeginChangeCheck();
            ColorBlendLerp = EditorGUILayout.FloatField("Lerp:", ColorBlendLerp);
            if (EditorGUI.EndChangeCheck()) { UpdateColorBlendLerp(); }

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Color1Blend", GUILayout.Width(ColorLabelWidthBlend));
            EditorGUI.BeginDisabledGroup(true);
            Color1Label = EditorGUILayout.ColorField(Color1Label, GUILayout.Width(ColorFieldWidth));
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.LabelField("->", GUILayout.Width(ArrowWidth));
            EditorGUI.BeginChangeCheck();
            ColorC1Blend = EditorGUILayout.ColorField(ColorC1Blend, GUILayout.Width(ColorFieldWidth));
            if (EditorGUI.EndChangeCheck()) { UpdateColor1Blend(); }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Color2Blend", GUILayout.Width(ColorLabelWidthBlend));
            EditorGUI.BeginDisabledGroup(true);
            Color2Label = EditorGUILayout.ColorField(Color2Label, GUILayout.Width(ColorFieldWidth));
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.LabelField("->", GUILayout.Width(ArrowWidth));
            EditorGUI.BeginChangeCheck();
            ColorC2Blend = EditorGUILayout.ColorField(ColorC2Blend, GUILayout.Width(ColorFieldWidth));
            if (EditorGUI.EndChangeCheck()) { UpdateColor2Blend(); }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Color3Blend", GUILayout.Width(ColorLabelWidthBlend));
            EditorGUI.BeginDisabledGroup(true);
            Color3Label = EditorGUILayout.ColorField(Color3Label, GUILayout.Width(ColorFieldWidth));
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.LabelField("->", GUILayout.Width(ArrowWidth));
            EditorGUI.BeginChangeCheck();
            ColorC3Blend = EditorGUILayout.ColorField(ColorC3Blend, GUILayout.Width(ColorFieldWidth));
            if (EditorGUI.EndChangeCheck()) { UpdateColor3Blend(); }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Color4Blend", GUILayout.Width(ColorLabelWidthBlend));
            EditorGUI.BeginDisabledGroup(true);
            Color4Label = EditorGUILayout.ColorField(Color4Label, GUILayout.Width(ColorFieldWidth));
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.LabelField("->", GUILayout.Width(ArrowWidth));
            EditorGUI.BeginChangeCheck();
            ColorC4Blend = EditorGUILayout.ColorField(ColorC4Blend, GUILayout.Width(ColorFieldWidth));
            if (EditorGUI.EndChangeCheck()) { UpdateColor4Blend(); }
            EditorGUILayout.EndHorizontal();

            showColorToolsBlend = EditorGUILayout.BeginFoldoutHeaderGroup(showColorToolsBlend, "Color Tools Blend");
            if (showColorToolsBlend)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                LerpC1Blend = EditorGUILayout.ColorField(LerpC1Blend, GUILayout.Width(ColorFieldWidth));
                EditorGUILayout.LabelField("-Lerp->", GUILayout.Width(48));
                LerpC2Blend = EditorGUILayout.ColorField(LerpC2Blend, GUILayout.Width(ColorFieldWidth));
                if (GUILayout.Button("()", GUILayout.Width(20)))
                {
                    ReverseLerpColorsBlend();
                }
                if (GUILayout.Button("Apply", GUILayout.Width(50)))
                {
                    ApplyLerpColorsBlend();
                }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                if (GUILayout.Button("Move Up", GUILayout.Width(90)))
                {
                    MoveColorsUpBlend();
                }
                if (GUILayout.Button("Move Down", GUILayout.Width(90)))
                {
                    MoveColorsDownBlend();
                }
                if (GUILayout.Button("Random", GUILayout.Width(60)))
                {
                    MoveColorsRandomBlend();
                }
                if (GUILayout.Button("Default", GUILayout.Width(60)))
                {
                    MoveColorsDefaultBlend();
                }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndFoldoutHeaderGroup();
        }

        if (GUILayout.Button(EnablePBRStr))
        {
            if (togglePBR) { FindProperty("_HasPBR", props).floatValue = 0.0f; togglePBR = false; EnablePBRStr = "Enable PBR"; }
            else { FindProperty("_HasPBR", props).floatValue = 1f; togglePBR = true; EnablePBRStr = "Disable PBR"; }
        }
        //EditorGUI.BeginChangeCheck();
        //togglePBR = EditorGUILayout.Toggle("Enable PBR", togglePBR);
        //if (EditorGUI.EndChangeCheck())
        if (togglePBR)
        {
            showPBRNormal = EditorGUILayout.BeginFoldoutHeaderGroup(showPBRNormal, PBRNormalFoldStr);
            if (showPBRNormal)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                EditorGUI.BeginChangeCheck();
                NormalC1V3 = EditorGUILayout.Vector3Field("Color 1:", NormalC1V3);
                if (EditorGUI.EndChangeCheck()) { UpdateNormalColor1(); }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                EditorGUI.BeginChangeCheck();
                NormalC2V3 = EditorGUILayout.Vector3Field("Color 2:", NormalC2V3);
                if (EditorGUI.EndChangeCheck()) { UpdateNormalColor2(); }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                EditorGUI.BeginChangeCheck();
                NormalC3V3 = EditorGUILayout.Vector3Field("Color 3:", NormalC3V3);
                if (EditorGUI.EndChangeCheck()) { UpdateNormalColor3(); }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                EditorGUI.BeginChangeCheck();
                NormalC4V3 = EditorGUILayout.Vector3Field("Color 4:", NormalC4V3);
                if (EditorGUI.EndChangeCheck()) { UpdateNormalColor4(); }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                if (GUILayout.Button("Reset Normal", GUILayout.Width(125))){ResetNormal();}
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndFoldoutHeaderGroup();

            showPBRMetalness = EditorGUILayout.BeginFoldoutHeaderGroup(showPBRMetalness, PBRMetalnessFoldStr);
            if (showPBRMetalness)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                EditorGUI.BeginChangeCheck();
                MetalnessC1 = EditorGUILayout.FloatField("Color 1:", MetalnessC1);
                if (EditorGUI.EndChangeCheck()) { UpdateMetalnessColor1(); }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                EditorGUI.BeginChangeCheck();
                MetalnessC2 = EditorGUILayout.FloatField("Color 2:", MetalnessC2);
                if (EditorGUI.EndChangeCheck()) { UpdateMetalnessColor2(); }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                EditorGUI.BeginChangeCheck();
                MetalnessC3 = EditorGUILayout.FloatField("Color 3:", MetalnessC3);
                if (EditorGUI.EndChangeCheck()) { UpdateMetalnessColor3(); }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                EditorGUI.BeginChangeCheck();
                MetalnessC4 = EditorGUILayout.FloatField("Color 4:", MetalnessC4);
                if (EditorGUI.EndChangeCheck()) { UpdateMetalnessColor4(); }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                if (GUILayout.Button("No Metal", GUILayout.Width(125))) { NoMetal(); }
                if (GUILayout.Button("Full Metal", GUILayout.Width(125))) { FullMetal(); }
                EditorGUILayout.EndHorizontal();

            }
            EditorGUILayout.EndFoldoutHeaderGroup();

            showPBRSmoothness = EditorGUILayout.BeginFoldoutHeaderGroup(showPBRSmoothness, PBRSmoothnessFoldStr);
            if (showPBRSmoothness)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                EditorGUI.BeginChangeCheck();
                SmoothnessC1 = EditorGUILayout.FloatField("Color 1:", SmoothnessC1);
                if (EditorGUI.EndChangeCheck()) { UpdateSmoothnessColor1(); }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                EditorGUI.BeginChangeCheck();
                SmoothnessC2 = EditorGUILayout.FloatField("Color 2:", SmoothnessC2);
                if (EditorGUI.EndChangeCheck()) { UpdateSmoothnessColor2(); }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                EditorGUI.BeginChangeCheck();
                SmoothnessC3 = EditorGUILayout.FloatField("Color 3:", SmoothnessC3);
                if (EditorGUI.EndChangeCheck()) { UpdateSmoothnessColor3(); }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                EditorGUI.BeginChangeCheck();
                SmoothnessC4 = EditorGUILayout.FloatField("Color 4:", SmoothnessC4);
                if (EditorGUI.EndChangeCheck()) { UpdateSmoothnessColor4(); }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                if (GUILayout.Button("No Smooth", GUILayout.Width(125))) { NoSmooth(); }
                if (GUILayout.Button("Default", GUILayout.Width(125))) { DefaultSmooth(); }
                if (GUILayout.Button("Full Smooth", GUILayout.Width(125))) { FullSmooth(); }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndFoldoutHeaderGroup();

            showPBROcclusion = EditorGUILayout.BeginFoldoutHeaderGroup(showPBROcclusion, PBROcclusionFoldStr);
            if (showPBROcclusion)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                EditorGUI.BeginChangeCheck();
                OcclusionC1 = EditorGUILayout.FloatField("Color 1:", OcclusionC1);
                if (EditorGUI.EndChangeCheck()) { UpdateOcclusionColor1(); }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                EditorGUI.BeginChangeCheck();
                OcclusionC2 = EditorGUILayout.FloatField("Color 2:", OcclusionC2);
                if (EditorGUI.EndChangeCheck()) { UpdateOcclusionColor2(); }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                EditorGUI.BeginChangeCheck();
                OcclusionC3 = EditorGUILayout.FloatField("Color 3:", OcclusionC3);
                if (EditorGUI.EndChangeCheck()) { UpdateOcclusionColor3(); }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                EditorGUI.BeginChangeCheck();
                OcclusionC4 = EditorGUILayout.FloatField("Color 4:", OcclusionC4);
                if (EditorGUI.EndChangeCheck()) { UpdateOcclusionColor4(); }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                EditorGUI.BeginChangeCheck();
                OcclusionStrength = EditorGUILayout.FloatField("Occlusion Strength:", OcclusionStrength);
                if (EditorGUI.EndChangeCheck()) { UpdateOcclusionStrength(); }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                if (GUILayout.Button("No Occlude", GUILayout.Width(125))) { NoOcclude(); }
                if (GUILayout.Button("Full Occlude", GUILayout.Width(125))) { FullOcclude(); }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndFoldoutHeaderGroup();

            showPBREmission = EditorGUILayout.BeginFoldoutHeaderGroup(showPBREmission, PBREmissionFoldStr);
            if (showPBREmission)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                EditorGUI.BeginChangeCheck();
                EmissionC1 = EditorGUILayout.ColorField("Color 1:", EmissionC1);
                if (EditorGUI.EndChangeCheck()) { UpdateEmissionColor1(); }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                EditorGUI.BeginChangeCheck();
                EmissionC1Intensity = EditorGUILayout.FloatField("Intensity:", EmissionC1Intensity);
                if (EditorGUI.EndChangeCheck()) { UpdateEmissionColor1Intensity(); }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                EditorGUI.BeginChangeCheck();
                EmissionC2 = EditorGUILayout.ColorField("Color 2:", EmissionC2);
                if (EditorGUI.EndChangeCheck()) { UpdateEmissionColor2(); }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                EditorGUI.BeginChangeCheck();
                EmissionC2Intensity = EditorGUILayout.FloatField("Intensity:", EmissionC2Intensity);
                if (EditorGUI.EndChangeCheck()) { UpdateEmissionColor2Intensity(); }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                EditorGUI.BeginChangeCheck();
                EmissionC3 = EditorGUILayout.ColorField("Color 3:", EmissionC3);
                if (EditorGUI.EndChangeCheck()) { UpdateEmissionColor3(); }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                EditorGUI.BeginChangeCheck();
                EmissionC3Intensity = EditorGUILayout.FloatField("Intensity:", EmissionC3Intensity);
                if (EditorGUI.EndChangeCheck()) { UpdateEmissionColor3Intensity(); }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                EditorGUI.BeginChangeCheck();
                EmissionC4 = EditorGUILayout.ColorField("Color 4:", EmissionC4);
                if (EditorGUI.EndChangeCheck()) { UpdateEmissionColor4(); }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                EditorGUI.BeginChangeCheck();
                EmissionC4Intensity = EditorGUILayout.FloatField("Intensity:", EmissionC4Intensity);
                if (EditorGUI.EndChangeCheck()) { UpdateEmissionColor4Intensity(); }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                if (GUILayout.Button("No Emission", GUILayout.Width(125))) { NoEmission(); }
                if (GUILayout.Button("Half", GUILayout.Width(125))) { HalfEmission(); }
                if (GUILayout.Button("Full Emission", GUILayout.Width(125))) { FullEmission(); }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                if (GUILayout.Button("Black", GUILayout.Width(125))) { EBlack(); }
                if (GUILayout.Button("Blue", GUILayout.Width(125))) { EBlue(); }
                if (GUILayout.Button("Cyan", GUILayout.Width(125))) { ECyan(); }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                if (GUILayout.Button("Gray", GUILayout.Width(125))) { EGray(); }
                if (GUILayout.Button("Green", GUILayout.Width(125))) { EGreen(); }
                if (GUILayout.Button("Magenta", GUILayout.Width(125))) { EMagenta(); }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                if (GUILayout.Button("Red", GUILayout.Width(125))) { ERed(); }
                if (GUILayout.Button("White", GUILayout.Width(125))) { EWhite(); }
                if (GUILayout.Button("Yellow", GUILayout.Width(125))) { EYellow(); }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndFoldoutHeaderGroup();

            EditorGUILayout.Space();
            
            //BLEND
            if (SelectedShaderEffect == 1)
            {
                showPBRNormalBlend = EditorGUILayout.BeginFoldoutHeaderGroup(showPBRNormalBlend, PBRNormalFoldStrBlend);
                if (showPBRNormalBlend)
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    EditorGUI.BeginChangeCheck();
                    NormalC1V3Blend = EditorGUILayout.Vector3Field("Color 1:", NormalC1V3Blend);
                    if (EditorGUI.EndChangeCheck()) { UpdateNormalColor1Blend(); }
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    EditorGUI.BeginChangeCheck();
                    NormalC2V3Blend = EditorGUILayout.Vector3Field("Color 2:", NormalC2V3Blend);
                    if (EditorGUI.EndChangeCheck()) { UpdateNormalColor2Blend(); }
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    EditorGUI.BeginChangeCheck();
                    NormalC3V3Blend = EditorGUILayout.Vector3Field("Color 3:", NormalC3V3Blend);
                    if (EditorGUI.EndChangeCheck()) { UpdateNormalColor3Blend(); }
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    EditorGUI.BeginChangeCheck();
                    NormalC4V3Blend = EditorGUILayout.Vector3Field("Color 4:", NormalC4V3Blend);
                    if (EditorGUI.EndChangeCheck()) { UpdateNormalColor4Blend(); }
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    if (GUILayout.Button("Reset Normal", GUILayout.Width(125))) { ResetNormal(); }
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUILayout.EndFoldoutHeaderGroup();

                showPBRMetalnessBlend = EditorGUILayout.BeginFoldoutHeaderGroup(showPBRMetalnessBlend, PBRMetalnessFoldStrBlend);
                if (showPBRMetalnessBlend)
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    EditorGUI.BeginChangeCheck();
                    MetalnessC1Blend = EditorGUILayout.FloatField("Color 1:", MetalnessC1Blend);
                    if (EditorGUI.EndChangeCheck()) { UpdateMetalnessColor1Blend(); }
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    EditorGUI.BeginChangeCheck();
                    MetalnessC2Blend = EditorGUILayout.FloatField("Color 2:", MetalnessC2Blend);
                    if (EditorGUI.EndChangeCheck()) { UpdateMetalnessColor2Blend(); }
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    EditorGUI.BeginChangeCheck();
                    MetalnessC3Blend = EditorGUILayout.FloatField("Color 3:", MetalnessC3Blend);
                    if (EditorGUI.EndChangeCheck()) { UpdateMetalnessColor3Blend(); }
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    EditorGUI.BeginChangeCheck();
                    MetalnessC4Blend = EditorGUILayout.FloatField("Color 4:", MetalnessC4Blend);
                    if (EditorGUI.EndChangeCheck()) { UpdateMetalnessColor4Blend(); }
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    if (GUILayout.Button("No Metal", GUILayout.Width(125))) { NoMetalBlend(); }
                    if (GUILayout.Button("Full Metal", GUILayout.Width(125))) { FullMetalBlend(); }
                    EditorGUILayout.EndHorizontal();

                }
                EditorGUILayout.EndFoldoutHeaderGroup();

                showPBRSmoothnessBlend = EditorGUILayout.BeginFoldoutHeaderGroup(showPBRSmoothnessBlend, PBRSmoothnessFoldStrBlend);
                if (showPBRSmoothnessBlend)
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    EditorGUI.BeginChangeCheck();
                    SmoothnessC1Blend = EditorGUILayout.FloatField("Color 1:", SmoothnessC1Blend);
                    if (EditorGUI.EndChangeCheck()) { UpdateSmoothnessColor1Blend(); }
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    EditorGUI.BeginChangeCheck();
                    SmoothnessC2Blend = EditorGUILayout.FloatField("Color 2:", SmoothnessC2Blend);
                    if (EditorGUI.EndChangeCheck()) { UpdateSmoothnessColor2Blend(); }
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    EditorGUI.BeginChangeCheck();
                    SmoothnessC3Blend = EditorGUILayout.FloatField("Color 3:", SmoothnessC3Blend);
                    if (EditorGUI.EndChangeCheck()) { UpdateSmoothnessColor3Blend(); }
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    EditorGUI.BeginChangeCheck();
                    SmoothnessC4Blend = EditorGUILayout.FloatField("Color 4:", SmoothnessC4Blend);
                    if (EditorGUI.EndChangeCheck()) { UpdateSmoothnessColor4Blend(); }
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    if (GUILayout.Button("No Smooth", GUILayout.Width(125))) { NoSmoothBlend(); }
                    if (GUILayout.Button("Default", GUILayout.Width(125))) { DefaultSmoothBlend(); }
                    if (GUILayout.Button("Full Smooth", GUILayout.Width(125))) { FullSmoothBlend(); }
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUILayout.EndFoldoutHeaderGroup();

                showPBROcclusionBlend = EditorGUILayout.BeginFoldoutHeaderGroup(showPBROcclusionBlend, PBROcclusionFoldStrBlend);
                if (showPBROcclusionBlend)
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    EditorGUI.BeginChangeCheck();
                    OcclusionC1Blend = EditorGUILayout.FloatField("Color 1:", OcclusionC1Blend);
                    if (EditorGUI.EndChangeCheck()) { UpdateOcclusionColor1Blend(); }
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    EditorGUI.BeginChangeCheck();
                    OcclusionC2Blend = EditorGUILayout.FloatField("Color 2:", OcclusionC2Blend);
                    if (EditorGUI.EndChangeCheck()) { UpdateOcclusionColor2Blend(); }
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    EditorGUI.BeginChangeCheck();
                    OcclusionC3Blend = EditorGUILayout.FloatField("Color 3:", OcclusionC3Blend);
                    if (EditorGUI.EndChangeCheck()) { UpdateOcclusionColor3Blend(); }
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    EditorGUI.BeginChangeCheck();
                    OcclusionC4Blend = EditorGUILayout.FloatField("Color 4:", OcclusionC4Blend);
                    if (EditorGUI.EndChangeCheck()) { UpdateOcclusionColor4Blend(); }
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    EditorGUI.BeginChangeCheck();
                    OcclusionStrengthBlend = EditorGUILayout.FloatField("Occlusion Strength:", OcclusionStrengthBlend);
                    if (EditorGUI.EndChangeCheck()) { UpdateOcclusionStrengthBlend(); }
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    if (GUILayout.Button("No Occlude", GUILayout.Width(125))) { NoOccludeBlend(); }
                    if (GUILayout.Button("Full Occlude", GUILayout.Width(125))) { FullOccludeBlend(); }
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUILayout.EndFoldoutHeaderGroup();

                showPBREmissionBlend = EditorGUILayout.BeginFoldoutHeaderGroup(showPBREmissionBlend, PBREmissionFoldStrBlend);
                if (showPBREmissionBlend)
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    EditorGUI.BeginChangeCheck();
                    EmissionC1Blend = EditorGUILayout.ColorField("Color 1:", EmissionC1Blend);
                    if (EditorGUI.EndChangeCheck()) { UpdateEmissionColor1Blend(); }
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    EditorGUI.BeginChangeCheck();
                    EmissionC1IntensityBlend = EditorGUILayout.FloatField("Intensity:", EmissionC1IntensityBlend);
                    if (EditorGUI.EndChangeCheck()) { UpdateEmissionColor1IntensityBlend(); }
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    EditorGUI.BeginChangeCheck();
                    EmissionC2Blend = EditorGUILayout.ColorField("Color 2:", EmissionC2Blend);
                    if (EditorGUI.EndChangeCheck()) { UpdateEmissionColor2Blend(); }
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    EditorGUI.BeginChangeCheck();
                    EmissionC2IntensityBlend = EditorGUILayout.FloatField("Intensity:", EmissionC2IntensityBlend);
                    if (EditorGUI.EndChangeCheck()) { UpdateEmissionColor2IntensityBlend(); }
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    EditorGUI.BeginChangeCheck();
                    EmissionC3Blend = EditorGUILayout.ColorField("Color 3:", EmissionC3Blend);
                    if (EditorGUI.EndChangeCheck()) { UpdateEmissionColor3Blend(); }
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    EditorGUI.BeginChangeCheck();
                    EmissionC3IntensityBlend = EditorGUILayout.FloatField("Intensity:", EmissionC3IntensityBlend);
                    if (EditorGUI.EndChangeCheck()) { UpdateEmissionColor3IntensityBlend(); }
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    EditorGUI.BeginChangeCheck();
                    EmissionC4Blend = EditorGUILayout.ColorField("Color 4:", EmissionC4Blend);
                    if (EditorGUI.EndChangeCheck()) { UpdateEmissionColor4Blend(); }
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    EditorGUI.BeginChangeCheck();
                    EmissionC4IntensityBlend = EditorGUILayout.FloatField("Intensity:", EmissionC4IntensityBlend);
                    if (EditorGUI.EndChangeCheck()) { UpdateEmissionColor4IntensityBlend(); }
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    if (GUILayout.Button("No Emission", GUILayout.Width(125))) { NoEmissionBlend(); }
                    if (GUILayout.Button("Half", GUILayout.Width(125))) { HalfEmissionBlend(); }
                    if (GUILayout.Button("Full Emission", GUILayout.Width(125))) { FullEmissionBlend(); }
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    if (GUILayout.Button("Black", GUILayout.Width(125))) { EBlackBlend(); }
                    if (GUILayout.Button("Blue", GUILayout.Width(125))) { EBlueBlend(); }
                    if (GUILayout.Button("Cyan", GUILayout.Width(125))) { ECyanBlend(); }
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    if (GUILayout.Button("Gray", GUILayout.Width(125))) { EGrayBlend(); }
                    if (GUILayout.Button("Green", GUILayout.Width(125))) { EGreenBlend(); }
                    if (GUILayout.Button("Magenta", GUILayout.Width(125))) { EMagentaBlend(); }
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(EmptyLabel, GUILayout.Width(EmptyLabelSize));
                    if (GUILayout.Button("Red", GUILayout.Width(125))) { ERedBlend(); }
                    if (GUILayout.Button("White", GUILayout.Width(125))) { EWhiteBlend(); }
                    if (GUILayout.Button("Yellow", GUILayout.Width(125))) { EYellowBlend(); }
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUILayout.EndFoldoutHeaderGroup();

                EditorGUILayout.Space();
            }
        }
    }

    //black Solid black.RGBA is (0, 0, 0, 1).
    //blue Solid blue.RGBA is (0, 0, 1, 1).
    //cyan Cyan.RGBA is (0, 1, 1, 1).
    //gray Gray.RGBA is (0.5, 0.5, 0.5, 1).
    //green Solid green.RGBA is (0, 1, 0, 1).
    //grey English spelling for gray.RGBA is the same(0.5, 0.5, 0.5, 1).
    //magenta Magenta.RGBA is (1, 0, 1, 1).
    //red Solid red.RGBA is (1, 0, 0, 1).
    //white Solid white.RGBA is (1, 1, 1, 1).
    //yellow

    private void EBlack() { EmissionC1 = Color.black; EmissionC2 = Color.black; EmissionC3 = Color.black; EmissionC4 = Color.black; UpdateEmissionColor1(); UpdateEmissionColor2(); UpdateEmissionColor3(); UpdateEmissionColor4(); }
    private void EBlue() { EmissionC1 = Color.blue; EmissionC2 = Color.blue; EmissionC3 = Color.blue; EmissionC4 = Color.blue; UpdateEmissionColor1(); UpdateEmissionColor2(); UpdateEmissionColor3(); UpdateEmissionColor4(); }
    private void ECyan() { EmissionC1 = Color.cyan; EmissionC2 = Color.cyan; EmissionC3 = Color.cyan; EmissionC4 = Color.cyan; UpdateEmissionColor1(); UpdateEmissionColor2(); UpdateEmissionColor3(); UpdateEmissionColor4(); }
    private void EGray() { EmissionC1 = Color.gray; EmissionC2 = Color.gray; EmissionC3 = Color.gray; EmissionC4 = Color.gray; UpdateEmissionColor1(); UpdateEmissionColor2(); UpdateEmissionColor3(); UpdateEmissionColor4(); }
    private void EGreen() { EmissionC1 = Color.green; EmissionC2 = Color.green; EmissionC3 = Color.green; EmissionC4 = Color.green; UpdateEmissionColor1(); UpdateEmissionColor2(); UpdateEmissionColor3(); UpdateEmissionColor4(); }
    private void EMagenta() { EmissionC1 = Color.magenta; EmissionC2 = Color.magenta; EmissionC3 = Color.magenta; EmissionC4 = Color.magenta; UpdateEmissionColor1(); UpdateEmissionColor2(); UpdateEmissionColor3(); UpdateEmissionColor4(); }
    private void ERed() { EmissionC1 = Color.red; EmissionC2 = Color.red; EmissionC3 = Color.red; EmissionC4 = Color.red; UpdateEmissionColor1(); UpdateEmissionColor2(); UpdateEmissionColor3(); UpdateEmissionColor4(); }
    private void EWhite() { EmissionC1 = Color.white; EmissionC2 = Color.white; EmissionC3 = Color.white; EmissionC4 = Color.white; UpdateEmissionColor1(); UpdateEmissionColor2(); UpdateEmissionColor3(); UpdateEmissionColor4(); }
    private void EYellow() { EmissionC1 = Color.yellow; EmissionC2 = Color.yellow; EmissionC3 = Color.yellow; EmissionC4 = Color.yellow; UpdateEmissionColor1(); UpdateEmissionColor2(); UpdateEmissionColor3(); UpdateEmissionColor4(); }
   
    private void NoEmission() { EmissionC1Intensity = 0; EmissionC2Intensity = 0; EmissionC3Intensity = 0; EmissionC4Intensity = 0; UpdateEmissionColor1Intensity(); UpdateEmissionColor2Intensity(); UpdateEmissionColor3Intensity(); UpdateEmissionColor4Intensity(); }
    private void HalfEmission() { EmissionC1Intensity = 0.5f; EmissionC2Intensity = 0.5f; EmissionC3Intensity = 0.5f; EmissionC4Intensity = 0.5f; UpdateEmissionColor1Intensity(); UpdateEmissionColor2Intensity(); UpdateEmissionColor3Intensity(); UpdateEmissionColor4Intensity(); }
    private void FullEmission() { EmissionC1Intensity = 1; EmissionC2Intensity = 1; EmissionC3Intensity = 1; EmissionC4Intensity = 1; UpdateEmissionColor1Intensity(); UpdateEmissionColor2Intensity(); UpdateEmissionColor3Intensity(); UpdateEmissionColor4Intensity(); }

    private void NoOcclude() { OcclusionC1 = 0; OcclusionC2 = 0; OcclusionC3 = 0; OcclusionC4 = 0; UpdateOcclusionColor1(); UpdateOcclusionColor2(); UpdateOcclusionColor3(); UpdateOcclusionColor4(); }
    private void FullOcclude() { OcclusionC1 = 1; OcclusionC2 = 1; OcclusionC3 = 1; OcclusionC4 = 1; UpdateOcclusionColor1(); UpdateOcclusionColor2(); UpdateOcclusionColor3(); UpdateOcclusionColor4(); }

    private void NoSmooth() { SmoothnessC1 = 0; SmoothnessC2 = 0; SmoothnessC3 = 0; SmoothnessC4 = 0; UpdateSmoothnessColor1(); UpdateSmoothnessColor2(); UpdateSmoothnessColor3(); UpdateSmoothnessColor4(); }
    private void DefaultSmooth() { SmoothnessC1 = 0.5f; SmoothnessC2 = 0.5f; SmoothnessC3 = 0.5f; SmoothnessC4 = 0.5f; UpdateSmoothnessColor1(); UpdateSmoothnessColor2(); UpdateSmoothnessColor3(); UpdateSmoothnessColor4(); }
    private void FullSmooth() { SmoothnessC1 = 1; SmoothnessC2 = 1; SmoothnessC3 = 1; SmoothnessC4 = 1; UpdateSmoothnessColor1(); UpdateSmoothnessColor2(); UpdateSmoothnessColor3(); UpdateSmoothnessColor4(); }

    private void NoMetal() { MetalnessC1 = 0; MetalnessC2 = 0; MetalnessC3 = 0; MetalnessC4 = 0; UpdateMetalnessColor1(); UpdateMetalnessColor2(); UpdateMetalnessColor3(); UpdateMetalnessColor4(); }
    private void FullMetal() { MetalnessC1 = 1; MetalnessC2 = 1; MetalnessC3 = 1; MetalnessC4 = 1; UpdateMetalnessColor1(); UpdateMetalnessColor2(); UpdateMetalnessColor3(); UpdateMetalnessColor4(); }

    private void ResetNormal() {
        NormalC1V3 = new Vector3(0, 0, 1);
        NormalC2V3 = new Vector3(0, 0, 1);
        NormalC3V3 = new Vector3(0, 0, 1);
        NormalC4V3 = new Vector3(0, 0, 1);
        UpdateNormalColor1(); UpdateNormalColor2(); UpdateNormalColor3(); UpdateNormalColor4();
    }

    private void EBlackBlend() { EmissionC1Blend = Color.black; EmissionC2Blend = Color.black; EmissionC3Blend = Color.black; EmissionC4Blend = Color.black; UpdateEmissionColor1Blend(); UpdateEmissionColor2Blend(); UpdateEmissionColor3Blend(); UpdateEmissionColor4Blend(); }
    private void EBlueBlend() { EmissionC1Blend = Color.blue; EmissionC2Blend = Color.blue; EmissionC3Blend = Color.blue; EmissionC4Blend = Color.blue; UpdateEmissionColor1Blend(); UpdateEmissionColor2Blend(); UpdateEmissionColor3Blend(); UpdateEmissionColor4Blend(); }
    private void ECyanBlend() { EmissionC1Blend = Color.cyan; EmissionC2Blend = Color.cyan; EmissionC3Blend = Color.cyan; EmissionC4Blend = Color.cyan; UpdateEmissionColor1Blend(); UpdateEmissionColor2Blend(); UpdateEmissionColor3Blend(); UpdateEmissionColor4Blend(); }
    private void EGrayBlend() { EmissionC1Blend = Color.gray; EmissionC2Blend = Color.gray; EmissionC3Blend = Color.gray; EmissionC4Blend = Color.gray; UpdateEmissionColor1Blend(); UpdateEmissionColor2Blend(); UpdateEmissionColor3Blend(); UpdateEmissionColor4Blend(); }
    private void EGreenBlend() { EmissionC1Blend = Color.green; EmissionC2Blend = Color.green; EmissionC3Blend = Color.green; EmissionC4Blend = Color.green; UpdateEmissionColor1Blend(); UpdateEmissionColor2Blend(); UpdateEmissionColor3Blend(); UpdateEmissionColor4Blend(); }
    private void EMagentaBlend() { EmissionC1Blend = Color.magenta; EmissionC2Blend = Color.magenta; EmissionC3Blend = Color.magenta; EmissionC4Blend = Color.magenta; UpdateEmissionColor1Blend(); UpdateEmissionColor2Blend(); UpdateEmissionColor3Blend(); UpdateEmissionColor4Blend(); }
    private void ERedBlend() { EmissionC1Blend = Color.red; EmissionC2Blend = Color.red; EmissionC3Blend = Color.red; EmissionC4Blend = Color.red; UpdateEmissionColor1Blend(); UpdateEmissionColor2Blend(); UpdateEmissionColor3Blend(); UpdateEmissionColor4Blend(); }
    private void EWhiteBlend() { EmissionC1Blend = Color.white; EmissionC2Blend = Color.white; EmissionC3Blend = Color.white; EmissionC4Blend = Color.white; UpdateEmissionColor1Blend(); UpdateEmissionColor2Blend(); UpdateEmissionColor3Blend(); UpdateEmissionColor4Blend(); }
    private void EYellowBlend() { EmissionC1Blend = Color.yellow; EmissionC2Blend = Color.yellow; EmissionC3Blend = Color.yellow; EmissionC4Blend = Color.yellow; UpdateEmissionColor1Blend(); UpdateEmissionColor2Blend(); UpdateEmissionColor3Blend(); UpdateEmissionColor4Blend(); }

    private void NoEmissionBlend() { EmissionC1IntensityBlend = 0; EmissionC2IntensityBlend = 0; EmissionC3IntensityBlend = 0; EmissionC4IntensityBlend = 0; UpdateEmissionColor1IntensityBlend(); UpdateEmissionColor2IntensityBlend(); UpdateEmissionColor3IntensityBlend(); UpdateEmissionColor4IntensityBlend(); }
    private void HalfEmissionBlend() { EmissionC1IntensityBlend = 0.5f; EmissionC2IntensityBlend = 0.5f; EmissionC3IntensityBlend = 0.5f; EmissionC4IntensityBlend = 0.5f; UpdateEmissionColor1IntensityBlend(); UpdateEmissionColor2IntensityBlend(); UpdateEmissionColor3IntensityBlend(); UpdateEmissionColor4IntensityBlend(); }
    private void FullEmissionBlend() { EmissionC1IntensityBlend = 1; EmissionC2IntensityBlend = 1; EmissionC3IntensityBlend = 1; EmissionC4IntensityBlend = 1; UpdateEmissionColor1IntensityBlend(); UpdateEmissionColor2IntensityBlend(); UpdateEmissionColor3IntensityBlend(); UpdateEmissionColor4IntensityBlend(); }

    private void NoOccludeBlend() { OcclusionC1Blend = 0; OcclusionC2Blend = 0; OcclusionC3Blend = 0; OcclusionC4Blend = 0; UpdateOcclusionColor1Blend(); UpdateOcclusionColor2Blend(); UpdateOcclusionColor3Blend(); UpdateOcclusionColor4Blend(); }
    private void FullOccludeBlend() { OcclusionC1Blend = 1; OcclusionC2Blend = 1; OcclusionC3Blend = 1; OcclusionC4Blend = 1; UpdateOcclusionColor1Blend(); UpdateOcclusionColor2Blend(); UpdateOcclusionColor3Blend(); UpdateOcclusionColor4Blend(); }

    private void NoSmoothBlend() { SmoothnessC1Blend = 0; SmoothnessC2Blend = 0; SmoothnessC3Blend = 0; SmoothnessC4Blend = 0; UpdateSmoothnessColor1Blend(); UpdateSmoothnessColor2Blend(); UpdateSmoothnessColor3Blend(); UpdateSmoothnessColor4Blend(); }
    private void DefaultSmoothBlend() { SmoothnessC1Blend = 0.5f; SmoothnessC2Blend = 0.5f; SmoothnessC3Blend = 0.5f; SmoothnessC4Blend = 0.5f; UpdateSmoothnessColor1Blend(); UpdateSmoothnessColor2Blend(); UpdateSmoothnessColor3Blend(); UpdateSmoothnessColor4Blend(); }
    private void FullSmoothBlend() { SmoothnessC1Blend = 1; SmoothnessC2Blend = 1; SmoothnessC3Blend = 1; SmoothnessC4Blend = 1; UpdateSmoothnessColor1Blend(); UpdateSmoothnessColor2Blend(); UpdateSmoothnessColor3Blend(); UpdateSmoothnessColor4Blend(); }

    private void NoMetalBlend() { MetalnessC1Blend = 0; MetalnessC2Blend = 0; MetalnessC3Blend = 0; MetalnessC4Blend = 0; UpdateMetalnessColor1Blend(); UpdateMetalnessColor2Blend(); UpdateMetalnessColor3Blend(); UpdateMetalnessColor4Blend(); }
    private void FullMetalBlend() { MetalnessC1Blend = 1; MetalnessC2Blend = 1; MetalnessC3Blend = 1; MetalnessC4Blend = 1; UpdateMetalnessColor1Blend(); UpdateMetalnessColor2Blend(); UpdateMetalnessColor3Blend(); UpdateMetalnessColor4Blend(); }

    private void ResetNormalBlend()
    {
        NormalC1V3Blend = new Vector3(0, 0, 1);
        NormalC2V3Blend = new Vector3(0, 0, 1);
        NormalC3V3Blend = new Vector3(0, 0, 1);
        NormalC4V3Blend = new Vector3(0, 0, 1);
        UpdateNormalColor1Blend(); UpdateNormalColor2Blend(); UpdateNormalColor3Blend(); UpdateNormalColor4Blend();
    }

    private void MoveColorsUp()
    {
        Color TC1 = ColorC1; Color TC2 = ColorC2; Color TC3 = ColorC3; Color TC4 = ColorC4;
        ColorC1 = TC2; ColorC2 = TC3; ColorC3 = TC4; ColorC4 = TC1;
        UpdateColor1(); UpdateColor2(); UpdateColor3(); UpdateColor4();
    }
    private void MoveColorsDown()
    {
        Color TC1 = ColorC1; Color TC2 = ColorC2; Color TC3 = ColorC3; Color TC4 = ColorC4;
        ColorC1 = TC4; ColorC2 = TC1; ColorC3 = TC2; ColorC4 = TC3;
        UpdateColor1(); UpdateColor2(); UpdateColor3(); UpdateColor4();
    }
    private void MoveColorsRandom()
    {
        Color[] ColArr = new Color[4] { ColorC1, ColorC2, ColorC3, ColorC4 };
        System.Random random = new System.Random();
        for (int i = 0; i < ColArr.Length - 1; ++i)
        {
            int r = random.Next(i, ColArr.Length);
            (ColArr[r], ColArr[i]) = (ColArr[i], ColArr[r]);
        }
        ColorC1 = ColArr[0]; ColorC2 = ColArr[1]; ColorC3 = ColArr[2]; ColorC4 = ColArr[3];
        UpdateColor1(); UpdateColor2(); UpdateColor3(); UpdateColor4();
    }
    private void MoveColorsDefault()
    {
        LerpC1 = Color.black; LerpC2 = Color.white;
        ApplyLerpColors();
    }

    private void ReverseLerpColors()
    {
        Color TC1 = LerpC1;
        Color TC2 = LerpC2;
        LerpC1 = TC2;
        LerpC2 = TC1;
    }
    private void ApplyLerpColors()
    {
        ColorC1 = LerpC1;
        ColorC2 = Color.Lerp(LerpC1, LerpC2, 0.333f);
        ColorC3 = Color.Lerp(LerpC1, LerpC2, 0.666f);
        ColorC4 = LerpC2;
        UpdateColor1(); UpdateColor2(); UpdateColor3(); UpdateColor4();
    }

    private void MoveColorsUpBlend()
    {
        Color TC1 = ColorC1Blend; Color TC2 = ColorC2Blend; Color TC3 = ColorC3Blend; Color TC4 = ColorC4Blend;
        ColorC1Blend = TC2; ColorC2Blend = TC3; ColorC3Blend = TC4; ColorC4Blend = TC1;
        UpdateColor1Blend(); UpdateColor2Blend(); UpdateColor3Blend(); UpdateColor4Blend();
    }
    private void MoveColorsDownBlend()
    {
        Color TC1 = ColorC1Blend; Color TC2 = ColorC2Blend; Color TC3 = ColorC3Blend; Color TC4 = ColorC4Blend;
        ColorC1Blend = TC4; ColorC2Blend = TC1; ColorC3Blend = TC2; ColorC4Blend = TC3;
        UpdateColor1Blend(); UpdateColor2Blend(); UpdateColor3Blend(); UpdateColor4Blend();
    }
    private void MoveColorsRandomBlend()
    {
        Color[] ColArr = new Color[4] { ColorC1Blend, ColorC2Blend, ColorC3Blend, ColorC4Blend };
        System.Random random = new System.Random();
        for (int i = 0; i < ColArr.Length - 1; ++i)
        {
            int r = random.Next(i, ColArr.Length);
            (ColArr[r], ColArr[i]) = (ColArr[i], ColArr[r]);
        }
        ColorC1Blend = ColArr[0]; ColorC2Blend = ColArr[1]; ColorC3Blend = ColArr[2]; ColorC4Blend = ColArr[3];
        UpdateColor1Blend(); UpdateColor2Blend(); UpdateColor3Blend(); UpdateColor4Blend();
    }
    private void MoveColorsDefaultBlend()
    {
        LerpC1Blend = Color.black; LerpC2Blend = Color.white;
        ApplyLerpColorsBlend();
    }

    private void ReverseLerpColorsBlend()
    {
        Color TC1 = LerpC1Blend;
        Color TC2 = LerpC2Blend;
        LerpC1Blend = TC2;
        LerpC2Blend = TC1;
    }
    private void ApplyLerpColorsBlend()
    {
        ColorC1Blend = LerpC1Blend;
        ColorC2Blend = Color.Lerp(LerpC1Blend, LerpC2Blend, 0.333f);
        ColorC3Blend = Color.Lerp(LerpC1Blend, LerpC2Blend, 0.666f);
        ColorC4Blend = LerpC2Blend;
        UpdateColor1Blend(); UpdateColor2Blend(); UpdateColor3Blend(); UpdateColor4Blend();
    }


    private void InitShader(MaterialProperty[] TheProps)
    {
        CachedProps = TheProps;
        //Read All vals from material
        MainOffset = FindProperty("_MainOffset", CachedProps).vectorValue;
        ColorC1 = FindProperty("_Color1", CachedProps).colorValue;
        ColorC2 = FindProperty("_Color2", CachedProps).colorValue;
        ColorC3 = FindProperty("_Color3", CachedProps).colorValue;
        ColorC4 = FindProperty("_Color4", CachedProps).colorValue;
        ColorC1Blend = FindProperty("_Color1Blend", CachedProps).colorValue;
        ColorC2Blend = FindProperty("_Color2Blend", CachedProps).colorValue;
        ColorC3Blend = FindProperty("_Color3Blend", CachedProps).colorValue;
        ColorC4Blend = FindProperty("_Color4Blend", CachedProps).colorValue;
        NormalC1V3 = new Vector3(FindProperty("_NormalColor1T", CachedProps).floatValue, FindProperty("_NormalColor1B", CachedProps).floatValue, FindProperty("_NormalColor1N", CachedProps).floatValue);
        NormalC2V3 = new Vector3(FindProperty("_NormalColor2T", CachedProps).floatValue, FindProperty("_NormalColor2B", CachedProps).floatValue, FindProperty("_NormalColor2N", CachedProps).floatValue);
        NormalC3V3 = new Vector3(FindProperty("_NormalColor3T", CachedProps).floatValue, FindProperty("_NormalColor3B", CachedProps).floatValue, FindProperty("_NormalColor3N", CachedProps).floatValue);
        NormalC4V3 = new Vector3(FindProperty("_NormalColor4T", CachedProps).floatValue, FindProperty("_NormalColor4B", CachedProps).floatValue, FindProperty("_NormalColor4N", CachedProps).floatValue);
        MetalnessC1 = FindProperty("_MetalnessColor1", CachedProps).floatValue;
        MetalnessC2 = FindProperty("_MetalnessColor2", CachedProps).floatValue;
        MetalnessC3 = FindProperty("_MetalnessColor3", CachedProps).floatValue;
        MetalnessC4 = FindProperty("_MetalnessColor4", CachedProps).floatValue;
        SmoothnessC1 = FindProperty("_SmoothnessColor1", CachedProps).floatValue;
        SmoothnessC2 = FindProperty("_SmoothnessColor2", CachedProps).floatValue;
        SmoothnessC3 = FindProperty("_SmoothnessColor3", CachedProps).floatValue;
        SmoothnessC4 = FindProperty("_SmoothnessColor4", CachedProps).floatValue;
        OcclusionC1 = FindProperty("_OcclusionColor1", CachedProps).floatValue;
        OcclusionC2 = FindProperty("_OcclusionColor1", CachedProps).floatValue;
        OcclusionC3 = FindProperty("_OcclusionColor1", CachedProps).floatValue;
        OcclusionC4 = FindProperty("_OcclusionColor1", CachedProps).floatValue;
        OcclusionStrength = FindProperty("_OcclusionStrength", CachedProps).floatValue;
        EmissionC1 = FindProperty("_EmissionColor1", CachedProps).colorValue;
        EmissionC2 = FindProperty("_EmissionColor2", CachedProps).colorValue;
        EmissionC3 = FindProperty("_EmissionColor3", CachedProps).colorValue;
        EmissionC4 = FindProperty("_EmissionColor4", CachedProps).colorValue;
        NormalC1V3Blend = new Vector3(FindProperty("_NormalColor1TBlend", CachedProps).floatValue, FindProperty("_NormalColor1BBlend", CachedProps).floatValue, FindProperty("_NormalColor1NBlend", CachedProps).floatValue);
        NormalC2V3Blend = new Vector3(FindProperty("_NormalColor2TBlend", CachedProps).floatValue, FindProperty("_NormalColor2BBlend", CachedProps).floatValue, FindProperty("_NormalColor2NBlend", CachedProps).floatValue);
        NormalC3V3Blend = new Vector3(FindProperty("_NormalColor3TBlend", CachedProps).floatValue, FindProperty("_NormalColor3BBlend", CachedProps).floatValue, FindProperty("_NormalColor3NBlend", CachedProps).floatValue);
        NormalC4V3Blend = new Vector3(FindProperty("_NormalColor4TBlend", CachedProps).floatValue, FindProperty("_NormalColor4BBlend", CachedProps).floatValue, FindProperty("_NormalColor4NBlend", CachedProps).floatValue);
        MetalnessC1Blend = FindProperty("_MetalnessColor1Blend", CachedProps).floatValue;
        MetalnessC2Blend = FindProperty("_MetalnessColor2Blend", CachedProps).floatValue;
        MetalnessC3Blend = FindProperty("_MetalnessColor3Blend", CachedProps).floatValue;
        MetalnessC4Blend = FindProperty("_MetalnessColor4Blend", CachedProps).floatValue;
        SmoothnessC1Blend = FindProperty("_SmoothnessColor1Blend", CachedProps).floatValue;
        SmoothnessC2Blend = FindProperty("_SmoothnessColor2Blend", CachedProps).floatValue;
        SmoothnessC3Blend = FindProperty("_SmoothnessColor3Blend", CachedProps).floatValue;
        SmoothnessC4Blend = FindProperty("_SmoothnessColor4Blend", CachedProps).floatValue;
        OcclusionC1Blend = FindProperty("_OcclusionColor1Blend", CachedProps).floatValue;
        OcclusionC2Blend = FindProperty("_OcclusionColor1Blend", CachedProps).floatValue;
        OcclusionC3Blend = FindProperty("_OcclusionColor1Blend", CachedProps).floatValue;
        OcclusionC4Blend = FindProperty("_OcclusionColor1Blend", CachedProps).floatValue;
        OcclusionStrengthBlend = FindProperty("_OcclusionStrengthBlend", CachedProps).floatValue;
        EmissionC1Blend = FindProperty("_EmissionColor1Blend", CachedProps).colorValue;
        EmissionC2Blend = FindProperty("_EmissionColor2Blend", CachedProps).colorValue;
        EmissionC3Blend = FindProperty("_EmissionColor3Blend", CachedProps).colorValue;
        EmissionC4Blend = FindProperty("_EmissionColor4Blend", CachedProps).colorValue;

        BlendOffset = FindProperty("_BlendOffset", CachedProps).floatValue;
        BlendExponent = FindProperty("_BlendExponent", CachedProps).floatValue;
        togglePBR = (FindProperty("_HasPBR", CachedProps).floatValue != 0.0f);
        if (togglePBR) { EnablePBRStr = "Disable PBR"; }
        else { EnablePBRStr = "Enable PBR"; }
        RotationInt = (int)FindProperty("_Rotation", CachedProps).floatValue;
        FlipHorizontal = (FindProperty("_FlipHorizontal", CachedProps).floatValue != 0.0f);
        FlipVertical = (FindProperty("_FlipVertical", CachedProps).floatValue != 0.0f);
        SelectedShaderType = (int)FindProperty("_UseStandard", CachedProps).floatValue;
        if ((int)FindProperty("_HasColorBlend", CachedProps).floatValue == 1) { SelectedShaderEffect = 1; }
        else { SelectedShaderEffect = 0;}

        ColorBlendUV = FindProperty("_ColorBlendUV", CachedProps).vectorValue;
        ColorBlendLerp = FindProperty("_ColorBlendLerp", CachedProps).floatValue;
        GridSize = (int)FindProperty("_GridMult", CachedProps).floatValue;
        GridStrength = FindProperty("_GridStrength", CachedProps).floatValue;
        TextureNumber = (int)FindProperty("_TextureNumber", CachedProps).floatValue;

        TextureStartX = (int)FindProperty("_TextureStartX", CachedProps).floatValue;
        TextureStartY = (int)FindProperty("_TextureStartY", CachedProps).floatValue;
        TextureStartLayer = (int)FindProperty("_TextureStartLayer", CachedProps).floatValue;
    }

    private void UpdateGridStrength() {
        GridStrength = Mathf.Clamp01(GridStrength); FindProperty("_GridStrength", CachedProps).floatValue = GridStrength;
    }

    private void UpdateTextureStart() {
        FindProperty("_GridStart", CachedProps).vectorValue = new Vector4(TextureStartX * 64, TextureStartY * 64, TextureStartLayer, 0);
        FindProperty("_TextureStartX", CachedProps).floatValue = TextureStartX;
        FindProperty("_TextureStartY", CachedProps).floatValue = TextureStartY;
        FindProperty("_TextureStartLayer", CachedProps).floatValue = TextureStartLayer;
    }
    private void RandomTextureNumber() {
        //TextureNumber = UnityEngine.Random.Range(0, 16383);
        TextureNumber = UnityEngine.Random.Range(0, 63);
        UpdateTextureNumber();
        //Layer 1 to 4 R, 5 to 8 G, 9 to 12 B, 13 to 16 A
        //Create 16 by 16 Texture 0 to 255, Bit lookup table, Then layer onto an rgba texture, r layer 1, g, layer 2, b layer 3, a layer 4;
        //Upscale to 64 to 64 to create slight buffer, then use for lookup in each channel for fast lookup.
    }
    private void UpdateTextureNumber() {
        int X = 0;
        int Y = 0;
        int L = 0;
        for (int i = 0; i < 64; i++)
        {
            if(TextureNumber == i) { TextureStartX = X; TextureStartY = Y; TextureStartLayer = L; break; }
            if (X == 1)
            {
                if (Y == 1)
                {
                    X = 0; Y = 0;
                    L++;
                }
                else
                {
                    X = 0;
                    Y++;
                }
            }
            else
            {
                X++;
            }
        }
        UpdateTextureStart();
        FindProperty("_TextureNumber", CachedProps).floatValue = TextureNumber;
    }

    private void UpdateGridSize() {
        FindProperty("_GridMult", CachedProps).floatValue = GridSize;
        FindProperty("_GridSize", CachedProps).floatValue = 1/(float)GridSize;
    }

    private void UpdateColorBlendUV() {
        float fx = ColorBlendUV.x; float fy = ColorBlendUV.y; float fz = ColorBlendUV.z; float fw = ColorBlendUV.w;
        if (fx < 0) { fx = 0; }
        if (fy < 0) { fy = 0; }
        if (fz < 0) { fz = 0; }
        if (fw < 0) { fw = 0; }
        ColorBlendUV = new Vector4(fx, fy, fz, fw);
        FindProperty("_ColorBlendUV", CachedProps).vectorValue = ColorBlendUV; }
    private void UpdateColorBlendLerp() { ColorBlendLerp = Mathf.Clamp01(ColorBlendLerp); FindProperty("_ColorBlendLerp", CachedProps).floatValue = ColorBlendLerp; }

    private void UpdateSelectedShaderType(Material TheMaterial) {
        if (SelectedShaderType == 0) { TheMaterial.EnableKeyword("STANDARD");}
        else { TheMaterial.DisableKeyword("STANDARD"); }
        FindProperty("_UseStandard", CachedProps).floatValue = (float)SelectedShaderType; }

    private void UpdateSelectedShaderEffect(Material TheMaterial) {
        if (SelectedShaderEffect == 0) { FindProperty("_HasColorBlend", CachedProps).floatValue = 0; TheMaterial.DisableKeyword("HASCOLORBLEND"); }
        else { FindProperty("_HasColorBlend", CachedProps).floatValue = 1; TheMaterial.EnableKeyword("HASCOLORBLEND"); }
    }
    private void UpdateMainOffset() {
        float fx = MainOffset.x; float fy = MainOffset.y; float fz = MainOffset.z; float fw = MainOffset.w;
        if (fx < 0) { fx = 0; }
        if (fy < 0) { fy = 0; }
        if (fz < 0) { fz = 0; }
        if (fw < 0) { fw = 0; }
        MainOffset = new Vector4(fx, fy, fz, fw);
        FindProperty("_MainOffset", CachedProps).vectorValue = MainOffset; }

    private void UpdateColor1() { FindProperty("_Color1", CachedProps).colorValue = ColorC1; }
    private void UpdateColor2() { FindProperty("_Color2", CachedProps).colorValue = ColorC2; }
    private void UpdateColor3() { FindProperty("_Color3", CachedProps).colorValue = ColorC3; }
    private void UpdateColor4() { FindProperty("_Color4", CachedProps).colorValue = ColorC4; }

    private void UpdateColor1Blend() { FindProperty("_Color1Blend", CachedProps).colorValue = ColorC1Blend; }
    private void UpdateColor2Blend() { FindProperty("_Color2Blend", CachedProps).colorValue = ColorC2Blend; }
    private void UpdateColor3Blend() { FindProperty("_Color3Blend", CachedProps).colorValue = ColorC3Blend; }
    private void UpdateColor4Blend() { FindProperty("_Color4Blend", CachedProps).colorValue = ColorC4Blend; }

    private void UpdateNormalColor1()
    {
        NormalC1V3 = new Vector3(Mathf.Clamp01(NormalC1V3.x), Mathf.Clamp01(NormalC1V3.y), Mathf.Clamp01(NormalC1V3.z));
        FindProperty("_NormalColor1T", CachedProps).floatValue = NormalC1V3.x;
        FindProperty("_NormalColor1B", CachedProps).floatValue = NormalC1V3.y;
        FindProperty("_NormalColor1N", CachedProps).floatValue = NormalC1V3.z;
    }
    private void UpdateNormalColor2()
    {
        NormalC2V3 = new Vector3(Mathf.Clamp01(NormalC2V3.x), Mathf.Clamp01(NormalC2V3.y), Mathf.Clamp01(NormalC2V3.z));
        FindProperty("_NormalColor2T", CachedProps).floatValue = NormalC2V3.x;
        FindProperty("_NormalColor2B", CachedProps).floatValue = NormalC2V3.y;
        FindProperty("_NormalColor2N", CachedProps).floatValue = NormalC2V3.z;
    }
    private void UpdateNormalColor3()
    {
        NormalC3V3 = new Vector3(Mathf.Clamp01(NormalC3V3.x), Mathf.Clamp01(NormalC3V3.y), Mathf.Clamp01(NormalC3V3.z));
        FindProperty("_NormalColor3T", CachedProps).floatValue = NormalC3V3.x;
        FindProperty("_NormalColor3B", CachedProps).floatValue = NormalC3V3.y;
        FindProperty("_NormalColor3N", CachedProps).floatValue = NormalC3V3.z;
    }
    private void UpdateNormalColor4()
    {
        NormalC4V3 = new Vector3(Mathf.Clamp01(NormalC4V3.x), Mathf.Clamp01(NormalC4V3.y), Mathf.Clamp01(NormalC4V3.z));
        FindProperty("_NormalColor4T", CachedProps).floatValue = NormalC4V3.x;
        FindProperty("_NormalColor4B", CachedProps).floatValue = NormalC4V3.y;
        FindProperty("_NormalColor4N", CachedProps).floatValue = NormalC4V3.z;
    }

    private void UpdateMetalnessColor1() { MetalnessC1 = Mathf.Clamp01(MetalnessC1); FindProperty("_MetalnessColor1", CachedProps).floatValue = MetalnessC1; }
    private void UpdateMetalnessColor2() { MetalnessC2 = Mathf.Clamp01(MetalnessC2); FindProperty("_MetalnessColor2", CachedProps).floatValue = MetalnessC2; }
    private void UpdateMetalnessColor3() { MetalnessC3 = Mathf.Clamp01(MetalnessC3); FindProperty("_MetalnessColor3", CachedProps).floatValue = MetalnessC3; }
    private void UpdateMetalnessColor4() { MetalnessC4 = Mathf.Clamp01(MetalnessC4); FindProperty("_MetalnessColor4", CachedProps).floatValue = MetalnessC4; }
    private void UpdateSmoothnessColor1() { SmoothnessC1 = Mathf.Clamp01(SmoothnessC1); FindProperty("_SmoothnessColor1", CachedProps).floatValue = SmoothnessC1; }
    private void UpdateSmoothnessColor2() { SmoothnessC2 = Mathf.Clamp01(SmoothnessC2); FindProperty("_SmoothnessColor2", CachedProps).floatValue = SmoothnessC2; }
    private void UpdateSmoothnessColor3() { SmoothnessC3 = Mathf.Clamp01(SmoothnessC3); FindProperty("_SmoothnessColor3", CachedProps).floatValue = SmoothnessC3; }
    private void UpdateSmoothnessColor4() { SmoothnessC4 = Mathf.Clamp01(SmoothnessC4); FindProperty("_SmoothnessColor4", CachedProps).floatValue = SmoothnessC4; }
    private void UpdateOcclusionColor1() { OcclusionC1 = Mathf.Clamp01(OcclusionC1); FindProperty("_OcclusionColor1", CachedProps).floatValue = OcclusionC1; }
    private void UpdateOcclusionColor2() { OcclusionC2 = Mathf.Clamp01(OcclusionC2); FindProperty("_OcclusionColor2", CachedProps).floatValue = OcclusionC2; }
    private void UpdateOcclusionColor3() { OcclusionC3 = Mathf.Clamp01(OcclusionC3); FindProperty("_OcclusionColor3", CachedProps).floatValue = OcclusionC3; }
    private void UpdateOcclusionColor4() { OcclusionC4 = Mathf.Clamp01(OcclusionC4); FindProperty("_OcclusionColor4", CachedProps).floatValue = OcclusionC4; }
    private void UpdateOcclusionStrength() { OcclusionStrength = Mathf.Clamp01(OcclusionStrength); FindProperty("_OcclusionStrength", CachedProps).floatValue = OcclusionStrength; }
    private void UpdateEmissionColor1() { FindProperty("_EmissionColor1", CachedProps).colorValue = EmissionC1; }
    private void UpdateEmissionColor2() { FindProperty("_EmissionColor2", CachedProps).colorValue = EmissionC2; }
    private void UpdateEmissionColor3() { FindProperty("_EmissionColor3", CachedProps).colorValue = EmissionC3; }
    private void UpdateEmissionColor4() { FindProperty("_EmissionColor4", CachedProps).colorValue = EmissionC4; }
    private void UpdateEmissionColor1Intensity() { EmissionC1Intensity = Mathf.Clamp01(EmissionC1Intensity); FindProperty("_EmissionColor1Intensity", CachedProps).floatValue = EmissionC1Intensity; }
    private void UpdateEmissionColor2Intensity() { EmissionC2Intensity = Mathf.Clamp01(EmissionC2Intensity); FindProperty("_EmissionColor2Intensity", CachedProps).floatValue = EmissionC2Intensity; }
    private void UpdateEmissionColor3Intensity() { EmissionC3Intensity = Mathf.Clamp01(EmissionC3Intensity); FindProperty("_EmissionColor3Intensity", CachedProps).floatValue = EmissionC3Intensity; }
    private void UpdateEmissionColor4Intensity() { EmissionC4Intensity = Mathf.Clamp01(EmissionC4Intensity); FindProperty("_EmissionColor4Intensity", CachedProps).floatValue = EmissionC4Intensity; }

    private void UpdateNormalColor1Blend()
    {
        NormalC1V3Blend = new Vector3(Mathf.Clamp01(NormalC1V3Blend.x), Mathf.Clamp01(NormalC1V3Blend.y), Mathf.Clamp01(NormalC1V3Blend.z));
        FindProperty("_NormalColor1TBlend", CachedProps).floatValue = NormalC1V3Blend.x;
        FindProperty("_NormalColor1BBlend", CachedProps).floatValue = NormalC1V3Blend.y;
        FindProperty("_NormalColor1NBlend", CachedProps).floatValue = NormalC1V3Blend.z;
    }
    private void UpdateNormalColor2Blend()
    {
        NormalC2V3Blend = new Vector3(Mathf.Clamp01(NormalC2V3Blend.x), Mathf.Clamp01(NormalC2V3Blend.y), Mathf.Clamp01(NormalC2V3Blend.z));
        FindProperty("_NormalColor2TBlend", CachedProps).floatValue = NormalC2V3Blend.x;
        FindProperty("_NormalColor2BBlend", CachedProps).floatValue = NormalC2V3Blend.y;
        FindProperty("_NormalColor2NBlend", CachedProps).floatValue = NormalC2V3Blend.z;
    }
    private void UpdateNormalColor3Blend()
    {
        NormalC3V3Blend = new Vector3(Mathf.Clamp01(NormalC3V3Blend.x), Mathf.Clamp01(NormalC3V3Blend.y), Mathf.Clamp01(NormalC3V3Blend.z));
        FindProperty("_NormalColor3TBlend", CachedProps).floatValue = NormalC3V3Blend.x;
        FindProperty("_NormalColor3BBlend", CachedProps).floatValue = NormalC3V3Blend.y;
        FindProperty("_NormalColor3NBlend", CachedProps).floatValue = NormalC3V3Blend.z;
    }
    private void UpdateNormalColor4Blend()
    {
        NormalC4V3Blend = new Vector3(Mathf.Clamp01(NormalC4V3Blend.x), Mathf.Clamp01(NormalC4V3Blend.y), Mathf.Clamp01(NormalC4V3Blend.z));
        FindProperty("_NormalColor4TBlend", CachedProps).floatValue = NormalC4V3Blend.x;
        FindProperty("_NormalColor4BBlend", CachedProps).floatValue = NormalC4V3Blend.y;
        FindProperty("_NormalColor4NBlend", CachedProps).floatValue = NormalC4V3Blend.z;
    }

    private void UpdateMetalnessColor1Blend() { MetalnessC1Blend = Mathf.Clamp01(MetalnessC1Blend); FindProperty("_MetalnessColor1Blend", CachedProps).floatValue = MetalnessC1Blend; }
    private void UpdateMetalnessColor2Blend() { MetalnessC2Blend = Mathf.Clamp01(MetalnessC2Blend); FindProperty("_MetalnessColor2Blend", CachedProps).floatValue = MetalnessC2Blend; }
    private void UpdateMetalnessColor3Blend() { MetalnessC3Blend = Mathf.Clamp01(MetalnessC3Blend); FindProperty("_MetalnessColor3Blend", CachedProps).floatValue = MetalnessC3Blend; }
    private void UpdateMetalnessColor4Blend() { MetalnessC4Blend = Mathf.Clamp01(MetalnessC4Blend); FindProperty("_MetalnessColor4Blend", CachedProps).floatValue = MetalnessC4Blend; }
    private void UpdateSmoothnessColor1Blend() { SmoothnessC1Blend = Mathf.Clamp01(SmoothnessC1Blend); FindProperty("_SmoothnessColor1Blend", CachedProps).floatValue = SmoothnessC1Blend; }
    private void UpdateSmoothnessColor2Blend() { SmoothnessC2Blend = Mathf.Clamp01(SmoothnessC2Blend); FindProperty("_SmoothnessColor2Blend", CachedProps).floatValue = SmoothnessC2Blend; }
    private void UpdateSmoothnessColor3Blend() { SmoothnessC3Blend = Mathf.Clamp01(SmoothnessC3Blend); FindProperty("_SmoothnessColor3Blend", CachedProps).floatValue = SmoothnessC3Blend; }
    private void UpdateSmoothnessColor4Blend() { SmoothnessC4Blend = Mathf.Clamp01(SmoothnessC4Blend); FindProperty("_SmoothnessColor4Blend", CachedProps).floatValue = SmoothnessC4Blend; }
    private void UpdateOcclusionColor1Blend() { OcclusionC1Blend = Mathf.Clamp01(OcclusionC1Blend); FindProperty("_OcclusionColor1Blend", CachedProps).floatValue = OcclusionC1Blend; }
    private void UpdateOcclusionColor2Blend() { OcclusionC2Blend = Mathf.Clamp01(OcclusionC2Blend); FindProperty("_OcclusionColor2Blend", CachedProps).floatValue = OcclusionC2Blend; }
    private void UpdateOcclusionColor3Blend() { OcclusionC3Blend = Mathf.Clamp01(OcclusionC3Blend); FindProperty("_OcclusionColor3Blend", CachedProps).floatValue = OcclusionC3Blend; }
    private void UpdateOcclusionColor4Blend() { OcclusionC4Blend = Mathf.Clamp01(OcclusionC4Blend); FindProperty("_OcclusionColor4Blend", CachedProps).floatValue = OcclusionC4Blend; }
    private void UpdateOcclusionStrengthBlend() { OcclusionStrengthBlend = Mathf.Clamp01(OcclusionStrengthBlend); FindProperty("_OcclusionStrengthBlend", CachedProps).floatValue = OcclusionStrengthBlend; }
    private void UpdateEmissionColor1Blend() { FindProperty("_EmissionColor1Blend", CachedProps).colorValue = EmissionC1Blend; }
    private void UpdateEmissionColor2Blend() { FindProperty("_EmissionColor2Blend", CachedProps).colorValue = EmissionC2Blend; }
    private void UpdateEmissionColor3Blend() { FindProperty("_EmissionColor3Blend", CachedProps).colorValue = EmissionC3Blend; }
    private void UpdateEmissionColor4Blend() { FindProperty("_EmissionColor4Blend", CachedProps).colorValue = EmissionC4Blend; }
    private void UpdateEmissionColor1IntensityBlend() { EmissionC1IntensityBlend = Mathf.Clamp01(EmissionC1IntensityBlend); FindProperty("_EmissionColor1IntensityBlend", CachedProps).floatValue = EmissionC1IntensityBlend; }
    private void UpdateEmissionColor2IntensityBlend() { EmissionC2IntensityBlend = Mathf.Clamp01(EmissionC2IntensityBlend); FindProperty("_EmissionColor2IntensityBlend", CachedProps).floatValue = EmissionC2IntensityBlend; }
    private void UpdateEmissionColor3IntensityBlend() { EmissionC3IntensityBlend = Mathf.Clamp01(EmissionC3IntensityBlend); FindProperty("_EmissionColor3IntensityBlend", CachedProps).floatValue = EmissionC3IntensityBlend; }
    private void UpdateEmissionColor4IntensityBlend() { EmissionC4IntensityBlend = Mathf.Clamp01(EmissionC4IntensityBlend); FindProperty("_EmissionColor4IntensityBlend", CachedProps).floatValue = EmissionC4IntensityBlend; }


    private void UpdateBlendOffset() { BlendOffset = Mathf.Clamp(BlendOffset, 0, 0.5f); FindProperty("_BlendOffset", CachedProps).floatValue = BlendOffset; }
    private void UpdateBlendExponent() { BlendExponent = Mathf.Clamp(BlendExponent, 1, 16); FindProperty("_BlendExponent", CachedProps).floatValue = BlendExponent; }
    private void UpdateRotation() { 
        if(RotationInt == 0) { FindProperty("_HasRotation", CachedProps).floatValue = 0;}
        else { FindProperty("_HasRotation", CachedProps).floatValue = 1; }
        FindProperty("_Rotation", CachedProps).floatValue = RotationInt;
    }

    private void UpdateFlip() {
        if (FlipHorizontal) { FindProperty("_FlipHorizontal", CachedProps).floatValue = 1; }
        else { FindProperty("_FlipHorizontal", CachedProps).floatValue = 0; }
        if (FlipVertical) { FindProperty("_FlipVertical", CachedProps).floatValue = 1; }
        else { FindProperty("_FlipVertical", CachedProps).floatValue = 0; }
    }
}
