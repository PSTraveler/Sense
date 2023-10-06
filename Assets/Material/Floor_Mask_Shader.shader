Shader "Custom/Floor_Mask_Shader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _ColorStrength("Color Strength", Range(0,4)) = 1

        _EmissionColor("Emission Color", Color) = (1,1,1,1)
        _EmissionTex("Emission (RGB)", 2D) = "white" {}
        _EmissionStrength("Emission Strength", Range(0,10)) = 1

        _Position("World Position", Vector) = (0,0,0,0)
        _Radius("Sphere Radius", Range(0,100)) = 0
        _Softness("Sphere Softness", Range(0,100)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _EmissionTex;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_EmissionTex;
            float3 worldPos;
        };

        half _ColorStrength, _ColorStrength2, _ColorStrength3, _EmissionStrength, _EmissionStrength2, _EmissionStrength3;
        fixed4 _Color, _EmissionColor;

        uniform float4 FLOORmask_pos;
        uniform float4 FLOORmask_pos2;
        uniform float4 FLOORmask_pos3;
        uniform half FLOORmask_rad;
        uniform half FLOORmask_rad2;
        uniform half FLOORmask_soft;
        uniform half FLOORmask_strength;
        uniform half FLOORmask_strength2;
        uniform half FLOORmask_strength3;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            _ColorStrength = FLOORmask_strength;
            _ColorStrength2 = FLOORmask_strength2;
            _ColorStrength3 = FLOORmask_strength3;
            _EmissionStrength = FLOORmask_strength;
            _EmissionStrength2 = FLOORmask_strength2;
            _EmissionStrength3 = FLOORmask_strength3;

            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;

            float blackscale = (c.r + c.g + c.b) * 0.0f;
            fixed3 c_g = fixed3(blackscale, blackscale, blackscale);

            fixed4 e = tex2D (_EmissionTex, IN.uv_EmissionTex) * _EmissionColor * _EmissionStrength;
            fixed4 e2 = tex2D (_EmissionTex, IN.uv_EmissionTex) * _EmissionColor * _EmissionStrength2;
            fixed4 e3 = tex2D (_EmissionTex, IN.uv_EmissionTex) * _EmissionColor * _EmissionStrength3;
            
            half d = distance(FLOORmask_pos, IN.worldPos);
            half d2 = distance(FLOORmask_pos2, IN.worldPos);
            half d3 = distance(FLOORmask_pos3, IN.worldPos);
            half sum = saturate((d - FLOORmask_rad) / -FLOORmask_soft);
            half sum2 = saturate((d2 - FLOORmask_rad2) / -FLOORmask_soft);
            half sum3 = saturate((d3 - 3.0f) / -FLOORmask_soft);
            fixed4 lerpColor = lerp(fixed4(c_g,1), c * _ColorStrength, sum) + lerp(fixed4(c_g,1), c * _ColorStrength2, sum2) + lerp(fixed4(c_g,1), c * _ColorStrength3, sum3);
            fixed4 lerpEmission = lerp(fixed4(0,0,0,0), e, sum) + lerp(fixed4(0,0,0,0), e2, sum2) + lerp(fixed4(0,0,0,0), e3, sum3);

            o.Albedo = lerpColor.rgb;
            // Metallic and smoothness come from slider variables
            o.Emission = lerpEmission.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
