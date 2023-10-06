Shader "Custom/Mirror_Shader"
{
    Properties
    {
        _MainTex("tex", 2D) = "white" {}
        _CUBE("Cubemap", CUBE) = "" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM

        #pragma surface surf Standard fullforwardshadows
        #pragma target 3.0

        sampler2D _MainTex;
        samplerCUBE _CUBE;

        struct Input
        {
            float2 uv_MainTex;
            float3 worldRefl;
            INTERNAL_DATA
        };

        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);

            float4 reflection = texCUBE(_CUBE, WorldReflectionVector(IN, o.Normal));
            o.Emission = reflection;
            o.Alpha = c.a;
        }
        ENDCG
    }
}
