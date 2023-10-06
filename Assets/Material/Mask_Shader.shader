Shader "Custom/Mask_Shader"
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

        #pragma surface surf Standard fullforwardshadows

        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _EmissionTex;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_EmissionTex;
            float3 worldPos;
        };

        half _ColorStrength, _EmissionStrength;
        fixed4 _Color, _EmissionColor;

        uniform float4 GLOBmask_pos;
        uniform half GLOBmask_rad;
        uniform half GLOBmask_soft;
        uniform half GLOBmask_strength;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            _ColorStrength = GLOBmask_strength;
            _EmissionStrength = GLOBmask_strength;

            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;

            float blackscale = (c.r + c.g + c.b) * 0.0;
            fixed3 c_g = fixed3(blackscale, blackscale, blackscale);

            fixed4 e = tex2D (_EmissionTex, IN.uv_EmissionTex) * _EmissionColor * _EmissionStrength;
            
            half d = distance(GLOBmask_pos, IN.worldPos);
            half sum = saturate((d - GLOBmask_rad) / -GLOBmask_soft);
            fixed4 lerpColor = lerp(fixed4(c_g,1), c * _ColorStrength, sum);
            fixed4 lerpEmission = lerp(fixed4(0,0,0,0), e, sum);

            o.Albedo = lerpColor.rgb;
            o.Emission = lerpEmission.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
