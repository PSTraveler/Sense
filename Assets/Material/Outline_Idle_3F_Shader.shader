Shader "Custom/Outline_Idle_3F_Shader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}

        _EmissionColor("Emission Color", Color) = (1,1,1,1)
        _EmissionTex("Emission (RGB)", 2D) = "white" {}

        _Position("World Position", Vector) = (0,0,0,0)
        _Radius("Sphere Radius", Range(0,100)) = 0
        _Softness("Sphere Softness", Range(0,100)) = 0

        _Outline ("Outline", Range(1.0, 10.0)) = 1.1
        _OutlineColor ("Outline Color", Color) = (1,1,1,1)
        _OutlineTex("Outline Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "Queue"="transparent" "RenderType"="Opaque" }
        LOD 200

        Pass
        {
            Name "OUTLINE"
            
            ZWrite Off

            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            float _Outline;
            float4 _OutlineColor;
            sampler2D _OutlineTex;

            struct vertexInput
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct vertexOutput
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            vertexOutput vert(vertexInput v)
            {
                v.vertex.xyz *= _Outline;
                vertexOutput OUT;

                OUT.pos = UnityObjectToClipPos(v.vertex);
                OUT.uv = v.uv;

                return OUT;
            }

            fixed4 frag(vertexOutput i) : SV_TARGET
            {

                float4 texColor = tex2D(_OutlineTex, i.uv);

                return texColor * _OutlineColor;
            }

            ENDCG
        }

        CGPROGRAM
        
        #pragma surface surf Standard fullforwardshadows

        sampler2D _MainTex;
        sampler2D _EmissionTex;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_EmissionTex;
        };

        fixed4 _Color, _EmissionColor;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {

            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;

            fixed4 e = tex2D (_EmissionTex, IN.uv_EmissionTex) * _EmissionColor;

            o.Albedo = c.rgb;
            o.Emission = e.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
}
